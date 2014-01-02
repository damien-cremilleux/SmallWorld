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
    /// Logique d'interaction pour Carte.xaml
    /// </summary>
    public partial class Carte : UserControl
    {
        private string TailleCarte = "";
        private Partie partie;

        public Carte()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Récupération de la taille de la carte
        /// </summary>
        void carte(object sender, RoutedEventArgs e)
        {
            RadioButton taille = (sender as RadioButton);
            TailleCarte = taille.Content.ToString();
        }

        /// <summary>
        /// Retour en arrière (page joueur)
        /// </summary>
        void Retour(object sender, RoutedEventArgs e)
        {
            MainWindow parent = (Application.Current.MainWindow as MainWindow);
            parent.joueurs.Visibility = Visibility.Visible;
            parent.carte.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Lancement de la partie, creation de la carte et de la partie
        /// </summary>
        private void LancerPartie(object sender, RoutedEventArgs e)
        {

            if (TailleCarte == "")
            {
                MessageBox.Show("Vous n'avez pas donné tous les paramètres");
            }
            else
            {
                MainWindow parent = (Application.Current.MainWindow as MainWindow);
                // Création de la partie
                parent.ajoutCarte(TailleCarte);
                partie = parent.construirePartie();

                // Lancement du jeu 
                PageJeu jeu = new PageJeu(partie);
                parent.Content = jeu;
            }
        }

    }
}
