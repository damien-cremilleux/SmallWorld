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

namespace Wpf_SmallWorld
{
    /// <summary>
    /// Logique d'interaction pour Jeu.xaml
    /// </summary>
    public partial class Jeu: Window
    {
        WrapperAlgo w;
        unsafe public Jeu()
        {
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

        unsafe private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialisation de la carte
          
            //TODO : récuperer taille carte
            int taille = 10;
            int** TCarte = w.genererCarte(taille);

            for (int c = 0; c < taille ; c++)
            {
                Carte.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20, GridUnitType.Pixel) });
            }
            for (int l = 0; l < Carte.Height; l++)
            {
                Carte.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20, GridUnitType.Pixel) });
                   for (int c = 0; c < taille; c++)
                   {
                    
                   }
               }
              /* updateUnitUI();
                  
            }
        }


        private Rectangle createRectangle(int c, int l, ITile tile)
        {
            var rectangle = new Rectangle();
            if (tile is ILand)
                rectangle.Fill = Brushes.Brown;
            if (tile is IForest)
                rectangle.Fill = Brushes.DarkGreen;
            if (tile is ISea)
                rectangle.Fill = Brushes.SlateBlue;
            // mise à jour des attributs (column et Row) référencant la position dans la grille à rectangle
            Grid.SetColumn(rectangle, c);
            Grid.SetRow(rectangle, l);
            rectangle.Tag = tile; // Tag : ref par defaut sur la tuile logique

            rectangle.Stroke = Brushes.Red;
            rectangle.StrokeThickness = 1;
            // enregistrement d'un écouteur d'evt sur le rectangle : 
            // source = rectangle / evt = MouseLeftButtonDown / délégué = rectangle_MouseLeftButtonDown
            rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
            return rectangle;
        }
*/
    }
}
