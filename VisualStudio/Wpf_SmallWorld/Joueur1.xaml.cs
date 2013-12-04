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
using System.Windows.Shapes;

namespace Wpf_SmallWorld
{
    /// <summary>
    /// Logique d'interaction pour Joueur1.xaml
    /// </summary>
    public partial class Joueur1 : Window
    {
        public Joueur1()
        {
            InitializeComponent();
        }

        private void joueurSuivant(object sender, RoutedEventArgs e)
        {
            Joueur2 a = new Joueur2();
            a.Show();
            this.Close();

        }
       
    }
}
