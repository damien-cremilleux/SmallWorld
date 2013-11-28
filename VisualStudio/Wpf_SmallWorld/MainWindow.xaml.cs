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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WrapperAlgo w;
        unsafe public MainWindow()
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
    }
}
