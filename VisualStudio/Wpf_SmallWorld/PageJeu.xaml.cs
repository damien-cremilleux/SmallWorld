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
        private Partie partie;
        private bool selected;
        Unite selectedUnit;

        unsafe public PageJeu(Partie partie)
        {
            InitializeComponent();
            this.partie = partie;

            // Ajout d'un évenement pour permettre au joueur de passer au tour suivant en appuyant sur la touche espace
            this.KeyDown += new KeyEventHandler(TourSuivantEspace);
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

            for (int c = 0; c < taille; c++)
            {
                Carte.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(40, GridUnitType.Pixel) });
            }

            for (int l = 0; l < taille; l++)
            {

                Carte.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(40, GridUnitType.Pixel) });
                for (int c = 0; c < taille; c++)
                {
                    // Dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    Case numCase = partie.CartePartie.ListeCases[c][l];
                    var element = createRectangle(c, l, numCase);

                    // Ajout de la case dans la carte
                    Carte.Children.Add(element);
                }
            }

            // Initilisaton des unités

            // TODO : trouver autre solution ?

            foreach (Joueur joueur in partie.ListeJoueurs)
            {
                // TODO : get position de départ plus élégante ?
                int column = joueur.ListeUnite[0].Position.Abscisse;
                int row = joueur.ListeUnite[0].Position.Ordonnee;

                Rectangle rect = new Rectangle();
                RecColorUnite(joueur.PeupleJ, rect);
                Panel.SetZIndex(rect, 50);

                // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
                Grid.SetColumn(rect, column);
                Grid.SetRow(rect, row);

                // récuperation du type de la case 
                rect.Tag = partie.CartePartie.ListeCases[column][row] as Case;
                
                // Même évenements que les autres cases 
                rect.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
                rect.MouseRightButtonDown += new MouseButtonEventHandler(rectangle_MouseRightButtonDown);

                Carte.Children.Add(rect);
            }
        }

        /// <summary>
        /// Permet de mettre la case à la texture de son type
        /// </summary>
        /// <param name="cas"> La Case </param>
        /// <param name="rec"> Le rectange </param>
        /// <returns></returns>
        private void RecColor(Case cas, Rectangle rec)
        {
            if (cas is InterEau)
                rec.Fill = Brushes.SlateBlue;
            if (cas is InterForet)
                rec.Fill = Brushes.DarkGreen;
            if (cas is InterMontagne)
                rec.Fill = Brushes.Brown;
            if (cas is InterPlaine)
                rec.Fill = Brushes.Green;
            if (cas is InterDesert)
            {
                BitmapSource img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.Sable.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
        }

        /// <summary>
        /// Permet de mettre la case à la l'image du peuple present dessus
        /// </summary>
        /// <param name="cas"> La Case </param>
        /// <param name="rec"> Le rectange </param>
        /// <returns></returns>
        private void RecColorUnite(Peuple peuple, Rectangle rec)
        {
            // TODO : Pour la position initiale on crée une image globale des unités pour chaque joueurs
            BitmapSource img;
            if (peuple is InterPeupleViking)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.UnitRest.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
            if (peuple is InterPeupleNain)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.UnitRest.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
            if (peuple is InterPeupleGaulois)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.UnitRest.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
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

            RecColor(Case, rectangle);

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

            // Maj des données de la case d'information
            RecColor(cas, CaseSelect);
            InfoCase.Visibility = Visibility.Visible;
            InfoUnites.Children.Clear();

            // Liste des unités présentes sur la case (on crée une listbox contenant les usercontrols (InfoUnite)
            // de chaque unités presentent sur la case
            ListBox listeUniteCase = new ListBox();
            listeUniteCase.SelectionChanged += SelectUnite;

            List<Unite> uniteCase = partie.selectionnerUnite(column, row);
            List<InfoUnite> listeInfoUnite = new List<InfoUnite>();

            foreach( Unite unite in uniteCase)
            {
                InfoUnite infoUnite = new InfoUnite(unite);
                listeInfoUnite.Add(infoUnite);
            }

            listeUniteCase.ItemsSource = listeInfoUnite;
            InfoUnites.Children.Add(listeUniteCase);

            e.Handled = true;
        }


        /// <summary>
        /// Délégué : réponse à l'evt selection d'une unité
        /// </summary>
        /// <param name="sender"> le User Control de l'unité </param>
        /// <param name="args"> l'evt </param>
        void SelectUnite(object sender, SelectionChangedEventArgs args)
        {
            var unite = ((sender as ListBox).SelectedItem as InfoUnite);
            selectedUnit = unite.Unite;
            selected = true;
        }


        /// <summary>
        /// Délégué : réponse à l'evt click droit sur le rectangle, déplacement d'une unité si elle est selectionnée
        /// </summary>
        /// <param name="sender"> le rectangle (la source) </param>
        /// <param name="e"> l'evt </param>
        private void rectangle_MouseRightButtonDown(object sender, RoutedEventArgs e)
        {
            // Voir si maj de la selection même si pas l'unité selectionnée
            if (selected)
            {
            // Récuperation des données du rectangle selectionné
            var rectangle = sender as Rectangle;
            var cas = rectangle.Tag as Case;
            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            // Maj de la selection sur le rectangle selectionné
            Grid.SetColumn(selectionRectangleDeplacement, column);
            Grid.SetRow(selectionRectangleDeplacement, row);
            selectionRectangleDeplacement.Tag = cas;
            selectionRectangleDeplacement.Visibility = System.Windows.Visibility.Visible;

                // TODO 
                // partie.demanderDeplacement(SelectedUnit, column, row, ); 
                // NB de point de déplacement fait dans le code ? ou dynamiquement aussi dans InfoUnite ? 

                // le joueur ne peut décider qu'une seule fois de la case de déplacement de l'unité ; l'affichage se fait à la fin du tour.
            selectionRectangleDeplacement.Visibility = System.Windows.Visibility.Hidden;
            selected = false;
  
            }

            e.Handled = true;
        }


        /// <summary>
        /// Délégué : réaction à l'evt : clic sur le bouton "Tour Suivant"
        /// </summary>
        /// <param name="sender"> le bouton "tour suivant" </param>
        /// <param name="e"></param>
        private void TourSuivant(object sender, RoutedEventArgs e)
        {
            partie.changerJoueur();

            if (!partie.PartieFinie)
            {
                //  updateUnit();
                //maj des données joueurs
                //foreach (Joueur joueur in partie.ListeJoueurs)
                //{
                //    InfoJoueur j = new InfoJoueur(joueur);
                //    InfoJoueurs.Children.Add(j);
                //}

                ////maj du nombre de tour
                //
                //NbTour.Text += " " + partie.NbTourRestant;
            }
            else
            {
                string vainqueurs = "";

                foreach (Joueur vainqueur in partie.vainqueurs())
                {
                    vainqueurs += vainqueur.NomJ;
                }

                string messageBoxText = "Partie terminée ! Vainqueur(s) : " +vainqueurs+ " ! Nouvelle partie ?";
                string caption = "Small World";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                // Relancer sur une nouvelle partie ou menu principal ?
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Recharger(sender, e);
                        break;
                    case MessageBoxResult.No:
                        MainWindow parent = (Application.Current.MainWindow as MainWindow);
                        parent.Close();
                        break;
                }
            }
        }

        /// <summary>
        /// Récupération de la position de l'unité , mise à jour de l'ellipse (physique) matérialisant l'unité
        /// </summary>
        unsafe private void updateUnit()
        {
            // passer une unité en paramètre ? pour ne mettre à jour qu'elle ?

            // ajout des attributs (column et Row) référencant la position dans la grille à unitEllipse

            //Grid.SetColumn(unitj1, 1);
            //Grid.SetRow(unitj1, 1);
            //Grid.SetColumn(unitEllipse, unit.Column);
            //Grid.SetRow(unitEllipse, unit.Row);
        }

        /// <summary>
        /// Délégué : réaction à l'evt : touche espace correspondant au bouton "Tour Suivant"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">e, la touche préssée</param>
        private void TourSuivantEspace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                TourSuivant(sender, e); // ok ?
            }

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

            // Configuration de la boite de dialogue
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
            // Vérification et enregistrement
            string messageBoxText = "Voulez-vous enregistrer la partie ?";
            string caption = "Small World";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            MainWindow parent = (Application.Current.MainWindow as MainWindow);

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
