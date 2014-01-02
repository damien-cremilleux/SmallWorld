using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Wrapper;
using SmallWorld;

namespace Wpf_SmallWorld
{
    /// <summary>
    /// Logique d'interaction pour PageJeu.xaml
    /// </summary>
    public partial class PageJeu : Page
    {
        private WrapperAlgo w;
        private Partie partie;

        unsafe public PageJeu(Partie partie)
        {
            InitializeComponent();
            w = new WrapperAlgo();
            this.partie = partie;
            /*
            int taille = 10;
            int** test = w.genererCarte(taille);
            int* placeJoueur = w.placerJoueur(test, taille);
            int i, j, k;
            string res;
            res = "Map : \n";
            for (i = 0; i < taille; i++)
            {
                for (j = 0; j < taille; j++)
                {
                    res += test[i][j] + "  ";
                }
                res += "\n";
            }
            MessageBox.Show(res);

            string res2;
            res2 = "Joueurs : ";
            for (k = 0; k < 4; k++)
            {
                res2 += placeJoueur[k] + "\t";
            }
            MessageBox.Show(res2);
            */

        }

        /// <summary>
        /// Définit les actions à réaliser lors du chargement de la fenêtre : initialisation des données et de la carte
        /// </summary>
        unsafe private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Initialisation des données joueurs
            foreach (Joueur joueur in partie.ListeJoueurs)
            {
                InfoJoueur j = new InfoJoueur(joueur);
                InfoJoueurs.Children.Add(j);
            }

            //Initialisation du nombre de tour
            NbTour.Text += " " + partie.NbTourRestant;

            // Initialisation de la carte
            int taille = partie.CartePartie.TailleCarte;

            int** TCarte = w.genererCarte(taille);

            for (int c = 0; c < taille; c++)
            {
                Carte.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(40, GridUnitType.Pixel) });
            }

            for (int l = 0; l < taille; l++)
            {

                Carte.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40, GridUnitType.Pixel) });
                for (int c = 0; c < taille; c++)
                {
                    // dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    // On récupère le numéro correspondant au type de la case
                    var NumCase = TCarte[c][l];
                    Case Case = FabriqueCase.Instance_FabCase.obtenirCase(NumCase);
                    var element = createRectangle(c, l, Case);

                    // Ajout de la case dans la carte
                    Carte.Children.Add(element);
                }
            }

            // Initilisaton des unités
            // Mettre une image spéciale quand plusieurs unités sur la même case ?
            int* Coord = w.placerJoueur(TCarte, taille);

            Grid.SetColumn(unitj1, Coord[0]);
            Grid.SetRow(unitj1, Coord[1]);
            Grid.SetColumn(unitj2, Coord[2]);
            Grid.SetRow(unitj2, Coord[3]);

            // de façon dynamique  ... 
            //foreach (Joueur j in partie.ListeJoueurs)
            //{
            //    Carte.Children.Add(unit);
            //}

        }


        /// <summary>
        /// Création du rectangle matérialisant une tuile
        /// </summary>
        /// <param name="c"> Column </param>
        /// <param name="l"> Row </param>
        /// <param name="tile"> Tuile logique</param>
        /// <returns> Rectangle créé</returns>
        private unsafe Rectangle createRectangle(int c, int l, Case Case)
        {
            var rectangle = new Rectangle();

            if (Case is InterEau)
                rectangle.Fill = Brushes.SlateBlue;
            if (Case is InterForet)
                rectangle.Fill = Brushes.DarkGreen;
            if (Case is InterMontagne)
                rectangle.Fill = Brushes.Brown;
            if (Case is InterPlaine)
                rectangle.Fill = Brushes.Green;
            if (Case is InterDesert)
            {
                BitmapSource img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.Sable.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rectangle.Fill = new ImageBrush(img);
            }

            Panel.SetZIndex(rectangle, 50);

            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = Case; // Récupère le type de la case mais : SmallWorld.montagne ....

            // enregistrement d'écouteurs d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);

            // source = rectangle / evt = MouseRightButtonDown / délégué = rectangle_MouseRightButtonDown
            rectangle.MouseRightButtonDown += new MouseButtonEventHandler(rectangle_MouseRightButtonDown);

            return rectangle;

        }

        /// <summary>
        /// Récupération de la position de l'unité , mise à jour de l'ellipse (physique) matérialisant l'unité
        /// </summary>
        unsafe private void updateUnit()
        {
            // passer une unité en paramètre ? pour ne mettre à jour qu'elle ?

            // ajout des attributs (column et Row) référencant la position dans la grille à unitEllipse

            Grid.SetColumn(unitj1, 1);
            Grid.SetRow(unitj1, 1);
            //Grid.SetColumn(unitEllipse, unit.Column);
            //Grid.SetRow(unitEllipse, unit.Row);
        }

        /// <summary>
        /// Délégué : réponse à l'evt click gauche sur le rectangle, affichage des informations de la case (type case et unités présentes)
        /// </summary>
        /// <param name="sender"> le rectangle (la source) </param>
        /// <param name="e"> l'evt </param>
        private void rectangle_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

            // Récuperation des données du rectangle selectionné
            var rectangle = sender as Rectangle;
            var cas = rectangle.Tag as Case;
            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            // Maj de la selection sur le rectangle selectionné
            Grid.SetColumn(selectionRectangle, column);
            Grid.SetRow(selectionRectangle, row);
            selectionRectangle.Tag = cas;
            selectionRectangle.Visibility = System.Windows.Visibility.Visible;

            InfoUnites.Children.Clear();
            InfoCase.Visibility = Visibility.Visible;
            ListBox a = new ListBox();
            a.SelectionChanged += SelectUnite;

            // TODO : tester avec la creation d'une unité mais impossible pour le moment

            List<InfoJoueur> r = new List<InfoJoueur>();

            foreach (Joueur joueur in partie.ListeJoueurs)
            {
                InfoJoueur j = new InfoJoueur(joueur);
                r.Add(j);
            }

            a.ItemsSource = r;
            InfoUnites.Children.Add(a);

            e.Handled = true;
        }

        /// <summary>
        /// Délégué : réponse à l'evt selection d'une unité
        /// </summary>
        /// <param name="sender"> le User Control de l'unité </param>
        /// <param name="args"> l'evt </param>
        void SelectUnite(object sender, SelectionChangedEventArgs args)
        {
            var lbi = ((sender as ListBox).SelectedItem as InfoJoueur);
            tb.Text = "   You selected " + lbi.Test + ".";
        }


        /// <summary>
        /// Délégué : réponse à l'evt click droit sur le rectangle, déplacement d'une unité si elle est selectionnée
        /// </summary>
        /// <param name="sender"> le rectangle (la source) </param>
        /// <param name="e"> l'evt </param>
        private void rectangle_MouseRightButtonDown(object sender, RoutedEventArgs e)
        {

            // Récuperation des données du rectangle selectionné
            var rectangle = sender as Rectangle;
            var cas = rectangle.Tag as Case;
            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            // Maj de la selection sur le rectangle selectionné
            Grid.SetColumn(selectionRectangle, column);
            Grid.SetRow(selectionRectangle, row);
            selectionRectangle.Tag = cas;

            // TODO

            e.Handled = true;
        }


        /// <summary>
        /// Délégué : réaction à l'evt : clic sur le bouton "Tour Suivant"
        /// </summary>
        /// <param name="sender"> le bouton "tour suivant" </param>
        /// <param name="e"></param>
        private void TourSuivant(object sender, RoutedEventArgs e)
        {
            updateUnit();
            // changement de joueur en cours
        }




        //Interaction du menu

        /// <summary>
        /// Rejouer une partie
        /// </summary>
        private void Recharger(object sender, RoutedEventArgs e)
        {
            MainWindow parent = (Application.Current.MainWindow as MainWindow);
            PageJeu jeu = new PageJeu(partie);
            parent.Content = jeu;
        }

        /// <summary>
        /// Rejouer une partie
        /// </summary>
        private void Sauvegarder(object sender, RoutedEventArgs e)
        {
            //TODO 

            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Sauvegarde"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }

        }


        /// <summary>
        /// Quitter l'application
        /// </summary>
        private void Quitter(object sender, RoutedEventArgs e)
        {
            // vérification, enregistrement
            string messageBoxText = "Voulez-vous enregistrer la partie ?";
            string caption = "Small World";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            MainWindow parent = (Application.Current.MainWindow as MainWindow);
            // Process message box results
            switch (result)
            {   
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                    Sauvegarder(sender, e);
                    parent.Close();
                    break;
                case MessageBoxResult.No:
                    parent.Close();
                    break;
                
            }


        }
    }
}
