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
using System.IO;

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

        /// <summary>
        /// Accès à la partie
        /// </summary>
        public Partie Partie
        {
            get { return partie; }
            set { partie = value; }
        }

        public CreateurPartie Createur
        {
            get { return createur; }
        }


        public MainWindow()
        {
            InitializeComponent();
            createur = new CreateurPartie();
            partie = new Partie();
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

        public void construireNouvellePartie()
        {
            partie = createur.construire();
            PagePrincipale.Source = new Uri("PageJeu.xaml", UriKind.Relative);
        }
    }
}
