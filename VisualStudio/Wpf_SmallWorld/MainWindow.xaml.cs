using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CreateurPartie createur;
        private Partie partie;

        public MainWindow()
        {
            InitializeComponent();
            createur = new CreateurPartie();
            partie = new Partie();
            this.joueurs.Visibility = Visibility.Collapsed;
            this.carte.Visibility = Visibility.Collapsed;
        }

        private void CreerPartie(object sender, RoutedEventArgs e)
        {
            this.joueurs.Visibility = Visibility.Visible;
            this.carte.Visibility = Visibility.Collapsed;
        }

        private void ChargerPartie(object sender, RoutedEventArgs e)
        {
            
            this.joueurs.Visibility = Visibility.Collapsed;
            this.carte.Visibility = Visibility.Collapsed;
            
            //TODO
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Sauvegarde"; // Default file name
            dlg.DefaultExt = ".sw"; // Default file extension
            dlg.Filter = "Sauvegarder SmallWorld (.sw)|*.smallWorld"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                Partie sauv = partie.charger(filename);
                // Lancement du jeu 
                PageJeu jeu = new PageJeu(sauv);
                this.Content = jeu;
            }
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ajoutJoueur(string nom, string peuple)
        {
            createur.ajoutJoueur(nom, peuple);
        }

        public void ajoutCarte(string taille)
        {
            createur.TypePartie = taille;
        }

        public Partie construirePartie()
        {
            partie = createur.construire();
            return partie;
        }
    }
}
