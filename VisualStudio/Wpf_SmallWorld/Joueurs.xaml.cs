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
    /// Logique d'interaction pour Joueur1.xaml
    /// </summary>
    public partial class Joueurs : UserControl
    {
        private string joueur1;
        private string peuplej1;
        private string joueur2;
        private string peuplej2;

        public Joueurs()
        {
            InitializeComponent();
            joueur1 = "";
            peuplej1 = "";
            joueur2 = "";
            peuplej2 = "";
        }

        /// <summary>
        /// Assignation du peuple du joueur 1
        /// </summary>
        private void peuple1(object sender, RoutedEventArgs e)
        {
            RadioButton peuple = (sender as RadioButton);
            peuplej1 = peuple.Content.ToString();
            Error1.Visibility = Visibility.Hidden;

            // TODO : voir si autrement ex : enable
            if (peuplej1 == peuplej2)
            {
                peuple.IsChecked = false;
                peuplej1 = "";
                Error1.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Assignation du peuple du joueur 2
        /// </summary>
        private void peuple2(object sender, RoutedEventArgs e)
        {
            RadioButton peuple = (sender as RadioButton);
            peuplej2 = peuple.Content.ToString();
            Error2.Visibility = Visibility.Hidden;
            if (peuplej1 == peuplej2)
            {
                peuple.IsChecked = false;
                peuplej2 = "";
                Error2.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Vérification et création des joueurs et passage au choix de la carte
        /// </summary>
        private void joueurSuivant(object sender, RoutedEventArgs e)
        {
            joueur1 = NomJ1.Text;
            joueur2 = NomJ2.Text;

            if (joueur1 == joueur2)
            {
                ErrorNom.Visibility = Visibility.Visible;
            }
            if (joueur1 == "" || peuplej1 == "" || joueur2 == "" || peuplej2 == "")
            {
                MessageBox.Show("Vous n'avez pas donné tous les paramètres");
            }
            else
            {
                // TODO : voir si pas mieux, ex : parent.
                MainWindow parent = (Application.Current.MainWindow as MainWindow);
                parent.ajoutJoueur(joueur1, peuplej1);
                parent.ajoutJoueur(joueur2, peuplej2);
                parent.joueurs.Visibility = Visibility.Hidden;
                parent.carte.Visibility = Visibility.Visible;
            }
        }
    }
}
