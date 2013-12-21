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

namespace Wpf_SmallWorld
{
    /// <summary>
    /// Logique d'interaction pour Joueur2.xaml
    /// </summary>
    public partial class Joueur2 : Window
    {
        private string joueur2;
        private string peuple2;

        private string TailleCarte;

        public Joueur2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lancement de la partie, creation du joueur 2, de la carte et de la partie
        /// </summary>
        private void LancerPartie(object sender, RoutedEventArgs e)
        {
            //CreateurPartie createur = new CreateurPartie();
           
            //Creer joueur2
            joueur2 = NomJ2.Text;

            if (joueur2 == "" || peuple2 == "" || TailleCarte == "")
            {
                MessageBox.Show("Vous n'avez pas donné tous les paramètres");
            }
            else
            {
                //createur.ajouterJoueur(joueur2,peuple2);

                //Creer carte
                // createur.ajouterCarte();

                //Creer partie
                Jeu a = new Jeu();
                a.Show();
                this.Close();
            }
            
        }

        /// <summary>
        /// Récuperation du peuple du joueur 2
        /// </summary>
        void peuple(object sender, RoutedEventArgs e)
        {
            RadioButton peuple = (sender as RadioButton);
           peuple2 = peuple.Content.ToString();
        }

        /// <summary>
        /// Récupération de la taille de la carte
        /// </summary>
        void carte(object sender, RoutedEventArgs e)
        {
            RadioButton taille = (sender as RadioButton);
            TailleCarte = taille.Content.ToString();
        }
    }
}
