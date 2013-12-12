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
            
            for (int l = 0; l < taille; l++)
            {
                
                Carte.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20, GridUnitType.Pixel) });
                    for (int c = 0; c < taille; c++)  {
                     // dans chaque case de la grille on ajoute une tuile (logique) matérialisée par un rectangle (physique)
                     // On récupère le numéro correspondant au type de la case
                     // Var ???
                        var NumCase = TCarte[c][l];
                        // TODO obtenir le type !?
                        //Case Case = FabriqueCase.Instance_FabCase.obtenirCase(NumCase);
                        int i = FabriqueCase.Instance_FabCase.obtenirInt(4);
                        MessageBox.Show("k"+i);
                       // var element = createRectangle(c, l, Case);
              
                        // Aout de la case dans la carte ?
                     //   Carte.Children.Add(element);


                        



                    }
             }
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

        // Test la classe de l'objet ? 
            if (Case is InterEau)
                rectangle.Fill = Brushes.Brown;
            if (Case is InterForet)
                rectangle.Fill = Brushes.DarkGreen;
            if (Case is InterMontagne)
                rectangle.Fill = Brushes.SlateBlue;
            if (Case is InterPlaine)
                rectangle.Fill = Brushes.Green;
            if (Case is InterDesert)
                rectangle.Fill = Brushes.Beige;

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
    }
}
