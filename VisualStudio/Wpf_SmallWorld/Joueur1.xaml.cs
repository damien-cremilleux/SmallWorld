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
        private string joueur1;
        private string peuple1;

        public Joueur1()
        {
            InitializeComponent();
        }

        private void joueurSuivant(object sender, RoutedEventArgs e)
        {
            //CreateurPartie createur = new CreateurPartie();

            joueur1 = NomJ1.Text;


            if (joueur1 == "" || peuple1 == "")
            {
                MessageBox.Show("Vous n'avez pas donné tous les paramètres");
            }
            else
            {
                //createur.ajouterJoueur(joueur1,peuple1);
                Joueur2 a = new Joueur2();
                a.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Assignation du peuple du joueur 1
        /// </summary>
        void peuple(object sender, RoutedEventArgs e)
        {
            RadioButton peuple = (sender as RadioButton);
            peuple1 = peuple.Content.ToString();
        }

    }
}
