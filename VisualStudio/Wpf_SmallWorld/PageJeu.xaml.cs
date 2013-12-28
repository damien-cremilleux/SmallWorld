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
        WrapperAlgo w;

        unsafe public PageJeu()
        {
            InitializeComponent();
            InitializeComponent();
            w = new WrapperAlgo();


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
        }
        /// <summary>
        /// Définit les actions à réaliser lors du chargement de la fenêtre : initialisation de la carte et des unités
        /// </summary>
        unsafe private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialisation de la carte

            // Récuperer taille carte
            int taille = 10;

            // Récuperer une liste plutôt pour éviter l'allocation dynamique
            int** TCarte = w.genererCarte(taille);

            for (int c = 0; c < taille; c++)
            {
                Carte.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20, GridUnitType.Pixel) });
            }

            for (int l = 0; l < taille; l++)
            {

                Carte.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20, GridUnitType.Pixel) });
                for (int c = 0; c < taille; c++)
                {
                    // dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                    // On récupère le numéro correspondant au type de la case

                    var NumCase = TCarte[c][l];
                    Case Case = FabriqueCase.Instance_FabCase.obtenirCase(NumCase);
                    var element = createRectangle(c, l, Case);

                    // Aout de la case dans la carte
                    Carte.Children.Add(element);

                }

            }
            // Initilisaton des unités
            // TODO  : POUR CHAQUE UNITES
            updateUnit();
        }


        /// <summary>
        /// Création du rectangle matérialisant une tuile
        /// </summary>
        /// <param name="c"> Column </param>
        /// <param name="l"> Row </param>
        /// <param name="tile"> Tuile logique</param>
        /// <returns> Rectangle créé</returns>
        private Rectangle createRectangle(int c, int l, Case Case)
        {
            var rectangle = new Rectangle();

            // Test la classe de l'objet 
            if (Case is InterEau)
                rectangle.Fill = Brushes.Brown;
            if (Case is InterForet)
                rectangle.Fill = Brushes.DarkGreen;
            if (Case is InterMontagne)
                rectangle.Fill = Brushes.SlateBlue;
            if (Case is InterPlaine)
                rectangle.Fill = Brushes.Green;
            if (Case is InterDesert)
            {
                // A mettre avant avec chaque variable
                BitmapSource img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.Sable.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rectangle.Fill = new ImageBrush(img);
            }

            //  Panel.SetZIndex(rectangle, 50);

            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            //   rectangle.Tag = TCarte[c][l]; // Tag : ref par defaut sur la tuile logique

            rectangle.Stroke = Brushes.Red;
            rectangle.StrokeThickness = 1;
            /*           // enregistrement d'un écouteur d'evt sur le rectangle : 
                       // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
                       rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
               */
            return rectangle;

        }

        /// <summary>
        /// Récupération de la position de l'unité , mise à jour de l'ellipse (physique) matérialisant l'unité
        /// </summary>
        unsafe private void updateUnit()
        {
            // passer une unité en paramètre ? pour ne mettre à jour qu'elle ?

            // ajout des attributs (column et Row) référencant la position dans la grille à unitEllipse

            Grid.SetColumn(unitEllipse, 1);
            Grid.SetRow(unitEllipse, 1);
        }
    }
}
