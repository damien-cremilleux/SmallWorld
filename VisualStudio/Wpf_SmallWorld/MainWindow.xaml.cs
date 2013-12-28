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

namespace Wpf_SmallWorld
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
