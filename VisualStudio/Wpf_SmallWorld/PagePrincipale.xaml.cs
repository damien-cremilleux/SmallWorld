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
    /// Logique d'interaction pour PagePrincipale.xaml
    /// </summary>
    public partial class PagePrincipale : Page
    {
        private CreateurPartie createur;
        private Partie partie;
        private MainWindow parent;

        public PagePrincipale()
        {
            InitializeComponent();
            createur = new CreateurPartie();
            partie = new Partie();
            parent = (Application.Current.MainWindow as MainWindow);
        }


        private void CreerPartie(object sender, RoutedEventArgs e)
        {
           
            parent.PageSelection.Source = new Uri("Joueurs.xaml", UriKind.Relative);
            parent.PageSelection.Visibility = Visibility.Visible;
        }

        private void ChargerPartie(object sender, RoutedEventArgs e)
        {
            parent.PageSelection.Visibility = Visibility.Collapsed;

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
                // Lancement du jeu 
                parent.Partie = partie.charger(filename);
                parent.PagePrincipale.Source = new Uri("PageJeu.xaml", UriKind.Relative);
            }
        }

        private void Aide(object sender, RoutedEventArgs e)
        {
            parent.PageSelection.Source = new Uri("ReglesJeu2.xaml", UriKind.Relative);
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            parent.Close();
        }


    }

}
