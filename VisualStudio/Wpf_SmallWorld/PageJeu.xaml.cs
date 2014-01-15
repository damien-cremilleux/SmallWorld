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
        Coordonnees positionInitiale;
        int deplacementautorise;
        bool testsauvegarder;

        unsafe public PageJeu(Partie parti)
        {
            InitializeComponent();
            this.partie = parti;
            selected = false;
            positionInitiale = new Coordonnees(0, 0);

            deplacementautorise = 0;
            Partie.Tag = partie.NbTourRestant;
            JoueurEnCours.Tag = partie.ListeJoueurs[partie.IndiceJoueurEnCours].NomJ;
            testsauvegarder = false;

            // Ajout d'un évenement pour permettre au joueur de passer au tour suivant en appuyant sur la touche espace
            //  this.KeyDown += new KeyEventHandler(passerSonTour);
        }

        /// <summary>
        /// Définit les actions à réaliser lors du chargement de la fenêtre : initialisation des données et de la carte
        /// </summary>
        unsafe private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Initialisation des données joueurs
            listejoueur();

            // Initialisation de la carte et des unités
            int taille = partie.CartePartie.TailleCarte;

            for (int c = 0; c < taille; c++)
            {
                Carte.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
                CarteSuggestion.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
                Unite.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
            }

            for (int l = 0; l < taille; l++)
            {

                Carte.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
                CarteSuggestion.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
                Unite.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });

                for (int c = 0; c < taille; c++)
                {
                    // Dans chaque case de la grille Carte on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    Case numCase = partie.CartePartie.ListeCases[c][l];
                    var element = createRectangle(c, l, numCase);

                    // Ajout de la case dans la carte
                    Carte.Children.Add(element);
                }
            }

            // Initilisaton des unités

            foreach (Joueur joueur in partie.ListeJoueurs)
            {
                //Position initiale
                int column = joueur.ListeUnite[0].Position.Abscisse;
                int row = joueur.ListeUnite[0].Position.Ordonnee;

                //Rectangle rect = new Rectangle();
                //RecColorUnite(joueur.PeupleJ, rect);
                //Panel.SetZIndex(rect, 10);

                ////mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
                //Grid.SetColumn(rect, column);
                //Grid.SetRow(rect, row);

                //// récuperation du type de la case 
                //rect.Tag = partie.CartePartie.ListeCases[column][row] as Case;

                //// Même évenements que les autres cases 
                //rect.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
                //rect.MouseRightButtonDown += new MouseButtonEventHandler(rectangle_MouseRightButtonDown);

                //TextBlock test = new TextBlock();
                //test.Text = "" + partie.selectionnerUnite(column, row).Count(); ;

                //Panel.SetZIndex(test, 5);
                //Grid.SetColumn(test, column);
                //Grid.SetRow(test, row);

                //Unite.Children.Add(test);
                //Unite.Children.Add(rect);

                refreshUnite();

            }
        }

        //////////////////////////////////////////////////////// STYLE DES RECTANGLES ////////////////////////////////////////////////////////

        /// <summary>
        /// Permet de mettre la case à la texture de son type
        /// </summary>
        /// <param name="cas"> La Case </param>
        /// <param name="rec"> Le rectange </param>
        /// <returns></returns>
        private void RecColor(Case cas, Rectangle rec)
        {
            BitmapSource img;
            if (cas is InterEau)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.water.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
            if (cas is InterForet)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.forest.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
            if (cas is InterMontagne)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.mountain.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
            if (cas is InterPlaine)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.plain.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
            if (cas is InterDesert)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.Sable.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.viking.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
            if (peuple is InterPeupleNain)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.dwarf.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rec.Fill = new ImageBrush(img);
            }
            if (peuple is InterPeupleGaulois)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.Gaulois.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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
            rectangle.Stroke = Brushes.White;
            rectangle.StrokeThickness = 1;

            Panel.SetZIndex(rectangle, 50);

            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = Case as Case; // Récupère le type de la case mais : SmallWorld.montagne ....

            // enregistrement d'écouteurs d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);

            // source = rectangle / evt = MouseRightButtonDown / délégué = rectangle_MouseRightButtonDown
            rectangle.MouseRightButtonDown += new MouseButtonEventHandler(rectangle_MouseRightButtonDown);

            return rectangle;
        }

        //////////////////////////////////////////////////////// EVENEMENTS ////////////////////////////////////////////////////////
        /// <summary>
        /// Délégué : réponse à l'evt click gauche sur le rectangle, affichage des informations de la case (type case et unités présentes)
        /// </summary>
        /// <param name="sender"> le rectangle (la source) </param>
        /// <param name="e"> l'evt </param>
        private void rectangle_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            // Ne plus affiché de cases de suggestion
            CarteSuggestion.Children.Clear();
            InfoAction.Visibility = Visibility.Hidden;

            // Récuperation des données du rectangle selectionné
            var rectangle = sender as Rectangle;
            var cas = rectangle.Tag as Case;
            int column = Grid.GetColumn(rectangle);
            int row = Grid.GetRow(rectangle);

            ////enregistrement des coordonnées de la case selectionnée
            //positionInitiale.Abscisse = column;
            //positionInitiale.Ordonnee = row;

            // Maj de la selection sur le rectangle selectionné
            Grid.SetColumn(selectionRectangle, column);
            Grid.SetRow(selectionRectangle, row);
            selectionRectangle.Tag = cas as Case;
            selectionRectangle.Visibility = System.Windows.Visibility.Visible;

            // Maj des données de la case d'information
            RecColor(cas, CaseSelect);
            InfoUnites.Children.Clear();
            listeUnite(column, row);
            e.Handled = true;
        }


        /// <summary>
        /// Délégué : réponse à l'evt selection d'une unité
        /// </summary>
        /// <param name="sender"> le User Control de l'unité </param>
        /// <param name="args"> l'evt de selection</param>
        private void SelectUnite(object sender, SelectionChangedEventArgs args)
        {
            var unite = ((sender as ListBox).SelectedItem as InfoUnite);
            selectedUnit = unite.Unite;

            positionInitiale.Abscisse = selectedUnit.Position.Abscisse;
            positionInitiale.Ordonnee = selectedUnit.Position.Ordonnee;

            Grid.SetColumn(UniteSelectionnee, selectedUnit.Position.Abscisse);
            Grid.SetRow(UniteSelectionnee, selectedUnit.Position.Ordonnee);
            UniteSelectionnee.Visibility = System.Windows.Visibility.Visible;
            CarteSuggestion.Children.Clear();
            refreshSuggestion();
            selected = true;
        }


        /// <summary>
        /// Délégué : réponse à l'evt click droit sur le rectangle, déplacement d'une unité si elle est selectionnée
        /// </summary>
        /// <param name="sender"> le rectangle (la source) </param>
        /// <param name="e"> l'evt </param>
        private void rectangle_MouseRightButtonDown(object sender, RoutedEventArgs e)
        {
            if (selected)
            {
                // Récuperation des données du rectangle selectionné
                var rectangle = sender as Rectangle;
                var cas = rectangle.Tag as Case;
                int column = Grid.GetColumn(rectangle);
                int row = Grid.GetRow(rectangle);

                UniteSelectionnee.Visibility = System.Windows.Visibility.Hidden;

                deplacementautorise = partie.demanderDeplacement(selectedUnit, column, row);

                //TODO : trouver d'autres messages
                switch (deplacementautorise)
                {
                    //l'unité combat et meurt 
                    case 2:
                        InfoAction.Content = "Vous avez perdu la bataille !";
                        InfoAction.Visibility = Visibility.Visible;
                        break;

                    //l'unité combat et se déplace
                    case 3:
                        InfoAction.Content = "Vous avez gagné la bataille !";
                        InfoAction.Visibility = Visibility.Visible;
                        break;

                    //l'unité combat mais ne se déplace pas (aucune des deux unités ne meurt)
                    case 4:
                        InfoAction.Content = "Personne n'est sorti vainqueur";
                        InfoAction.Visibility = Visibility.Visible;
                        break;
                    default :
                        break;
                }

                //regénération des éléments unités et joueurs pour mettre à jour
                InfoUnites.Children.Clear();

             //   MessageBox.Show("" + positionInitiale.Abscisse + "" + positionInitiale.Ordonnee);

                listeUnite(positionInitiale.Abscisse, positionInitiale.Ordonnee);
                InfoJoueurs.Children.Clear();
                listejoueur();

                Unite.Children.Clear();
                refreshUnite();


                // le joueur ne peut décider qu'une seule fois de la case de déplacement de l'unité
                // selectionRectangleDeplacement.Visibility = System.Windows.Visibility.Hidden;
                selected = false;

            }

            e.Handled = true;
        }

        //////////////////////////////////////////////////////// RAFRAICHISSEMENT ////////////////////////////////////////////////////////

        /// <summary>
        /// Affichage de la liste des joueurs et de ses informations
        /// </summary>
        private void listejoueur()
        {
            foreach (Joueur joueur in partie.ListeJoueurs)
            {
                joueur.calculerPointVictoire();
                InfoJoueur j = new InfoJoueur(joueur, partie.ListeJoueurs[partie.IndiceJoueurEnCours]);
                InfoJoueurs.Children.Add(j);
            }
        }

        /// <summary>
        /// Affichages des unités présentent sur la case selectionnée
        /// </summary>
        private void listeUnite(int column, int row)
        {
            // Ne plus affiché a qui appartiennent les unités
            AppartientUnite.Content = "";

            if (partie.selectionnerUniteAdverse(column, row).Count() == 0 && partie.selectionnerUnite(column, row).Count() != 0)
            {
                // Liste des unités du joueur en cours présentes sur la case (on crée une listbox contenant les usercontrols (InfoUnite)
                // de chaque unités presentent sur la case pour le joueur courant (les cases sont cliquables)
                AppartientUnite.Content = "Vos unités";
                ListBox listeUniteCase = new ListBox();
                listeUniteCase.Width = 275;
                listeUniteCase.HorizontalAlignment = HorizontalAlignment.Center;
                listeUniteCase.SelectionChanged += SelectUnite;

                List<Unite> uniteCase = partie.selectionnerUnite(column, row);

                List<InfoUnite> listeInfoUnite = new List<InfoUnite>();
                foreach (Unite unite in uniteCase)
                {
                    InfoUnite infoUnite = new InfoUnite(unite);
                    listeInfoUnite.Add(infoUnite);
                }

                listeUniteCase.ItemsSource = listeInfoUnite;
                InfoUnites.Children.Add(listeUniteCase);
            }
            else if (partie.selectionnerUniteAdverse(column, row).Count() != 0 && partie.selectionnerUnite(column, row).Count() == 0)
            {
                // Affiche les unités du joueur adverse 
                AppartientUnite.Content = "Unités adverses";
                List<Unite> uniteCaseAdverse = partie.selectionnerUniteAdverse(column, row);
                List<InfoUnite> listeInfoUniteAdverse = new List<InfoUnite>();
                
                ItemsControl listeUniteCaseAdverse = new ItemsControl();
                listeUniteCaseAdverse.Width = 275;

                listeUniteCaseAdverse.HorizontalAlignment = HorizontalAlignment.Center;
                foreach (Unite unite in uniteCaseAdverse)
                {
                    InfoUnite infoUniteAdverse = new InfoUnite(unite);
                    listeInfoUniteAdverse.Add(infoUniteAdverse);
                }

                listeUniteCaseAdverse.ItemsSource = listeInfoUniteAdverse;
                InfoUnites.Children.Add(listeUniteCaseAdverse);
            }

        }

        /// <summary>
        /// Récupération de la position de l'unité , mise à jour de l'ellipse (physique) matérialisant l'unité
        /// </summary>
        unsafe private void refreshUnite()
        {
            if (!partie.PartieFinie)
            {
                foreach (Joueur joueur in partie.ListeJoueurs)
                {
                    foreach (Unite unite in joueur.ListeUnite)
                    {
                        int column = unite.Position.Abscisse;
                        int row = unite.Position.Ordonnee;

                        Rectangle rect = new Rectangle();
                        RecColorUnite(joueur.PeupleJ, rect);
                        Panel.SetZIndex(rect, 50);

                        // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
                        Grid.SetColumn(rect, column);
                        Grid.SetRow(rect, row);

                        TextBlock test = new TextBlock();
                        if (partie.selectionnerUnite(column, row).Count() == 0)
                            test.Text = "" + partie.selectionnerUniteAdverse(column, row).Count();
                        else
                            test.Text = "" + partie.selectionnerUnite(column, row).Count();

                        Panel.SetZIndex(test, 40);
                        Grid.SetColumn(test, column);
                        Grid.SetRow(test, row);

                        // récuperation du type de la case 
                        rect.Tag = partie.CartePartie.ListeCases[column][row] as Case;

                        // Même évenements que les autres cases 
                        rect.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
                        rect.MouseRightButtonDown += new MouseButtonEventHandler(rectangle_MouseRightButtonDown);

                        Unite.Children.Add(rect);
                        Unite.Children.Add(test);
                    }
                }
            }
            else
                partieFini();

        }

        /// <summary>
        /// Affichage des suggestions des meilleurs cases et non disponibilité des cases 
        /// </summary>
        private void refreshSuggestion()
        {
            foreach (Coordonnees coordNonDispo in selectedUnit.suggererCaseNonPossible())
            {
                int columnNonDispo = coordNonDispo.Abscisse;
                int rowNonDispo = coordNonDispo.Ordonnee;

                Rectangle suggestionNonDispo = new Rectangle();
                suggestionNonDispo.Fill = Brushes.White;
                suggestionNonDispo.Opacity = 0.6;

                // le blanchissement doit être au dessus de la carte et des unités
                Panel.SetZIndex(suggestionNonDispo, 60);

                // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
                Grid.SetColumn(suggestionNonDispo, columnNonDispo);
                Grid.SetRow(suggestionNonDispo, rowNonDispo);

                CarteSuggestion.Children.Add(suggestionNonDispo);
            }

            foreach (Coordonnees coordOptimale in selectedUnit.suggererCaseOptimale())
            {
                int column = coordOptimale.Abscisse;
                int row = coordOptimale.Ordonnee;

                Rectangle suggestionOptimale = new Rectangle();
                suggestionOptimale.StrokeThickness = 3;
                suggestionOptimale.Stroke = Brushes.Red;

                // le blanchissement doit être au dessus de la carte et des unités
                Panel.SetZIndex(suggestionOptimale, 60);

                // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
                Grid.SetColumn(suggestionOptimale, column);
                Grid.SetRow(suggestionOptimale, row);

                // récuperation du type de la case 
                suggestionOptimale.Tag = partie.CartePartie.ListeCases[column][row] as Case;

                // Même évenements que les autres cases 
                suggestionOptimale.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
                suggestionOptimale.MouseRightButtonDown += new MouseButtonEventHandler(rectangle_MouseRightButtonDown);

                CarteSuggestion.Children.Add(suggestionOptimale);
            }
        }

      
        //////////////////////////////////////////////////////// Changement de joueur ////////////////////////////////////////////////////////
        /// <summary>
        /// Délégué : réponse à l'evt d'une touche enfoncée
        /// </summary>
        /// <param name="sender"> la grid</param>
        /// <param name="args"> l'evt, la touche</param>
        private void passerSonTour(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (selected)
                {
                    MessageBox.Show("je suis dedans !!!");
                    selectedUnit.PasseSonTour = true;
                    InfoUnites.Children.Clear();
                    listeUnite(selectedUnit.Position.Abscisse, selectedUnit.Position.Ordonnee);
                }
            }
        }


        /// <summary>
        /// Délégué : réaction à l'evt : clic sur le bouton "Tour Suivant"
        /// </summary>
        /// <param name="sender"> le bouton "tour suivant" </param>
        /// <param name="e"></param>
        private void TourSuivant(object sender, RoutedEventArgs e)
        {
            InfoUnites.Children.Clear();
            listeUnite(positionInitiale.Abscisse, positionInitiale.Ordonnee);

            CarteSuggestion.Children.Clear();
            partie.changerJoueur();

            if (!partie.PartieFinie)
            {
                Partie.Tag = partie.NbTourRestant;
                JoueurEnCours.Tag = partie.ListeJoueurs[partie.IndiceJoueurEnCours].NomJ;
                //maj des données joueurs
                InfoUnites.Children.Clear();
                InfoJoueurs.Children.Clear();
                listejoueur();
            }
            else 
                partieFini();
          
        }


        /// <summary>
        /// Fin de la partie : affichage du gagnant et divers choix
        /// </summary>
        /// <param name="sender"> le bouton "tour suivant" </param>
        /// <param name="e"></param>
        /// 
        private void partieFini()
        {
                string vainqueurs = "";
                string messageBoxText = "";
                string caption = "Small World";

                foreach (Joueur vainqueur in partie.vainqueurs())
                {
                    vainqueurs += vainqueur.NomJ;
                }

                // S'il y a égalité
                if (partie.vainqueurs().Count() == 1)
                {
                    messageBoxText = "Partie terminée ! Bravo " + partie.vainqueurs()[0].NomJ + " ! Revanche ?";
                }
                else
                {
                    messageBoxText = "Partie terminée ! Match nul entre " + partie.vainqueurs()[0].NomJ + " et " + partie.vainqueurs()[1].NomJ + " ! Revanche ?";
                }
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                // Relancer sur une nouvelle partie ou menu principal ?
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        MainWindow parent = (Application.Current.MainWindow as MainWindow);
                        parent.Close();
                        break;
                }
        }


        //Interaction du menu

        /// <summary>
        /// Rejouer une partie
        /// </summary>
        private void Recharger(object sender, RoutedEventArgs e)
        {
            // TODO
            MainWindow parent = (Application.Current.MainWindow as MainWindow);
        }

        /// <summary>
        /// Rejouer une partie
        /// </summary>
        private void Sauvegarder(object sender, RoutedEventArgs e)
        {
            //testsauvegarder = partie.enregistrer();
            //if (!testsauvegarder)
            //{
            // Configuration de la boite de dialogue
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Sauvegarde"; // Default file name
            dlg.DefaultExt = ".sw"; // Default file extension
            dlg.Filter = "Sauvegarde Small World (.sw)|*.smallWorld"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                partie.enregistrerSous(filename);
            }
            //}

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
