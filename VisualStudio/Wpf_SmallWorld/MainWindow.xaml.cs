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

        /// <summary>
        /// Accès au créateur
        /// </summary>
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


        /// <summary>
        /// Ajout d'un joueur
        /// </summary>
        /// <param name="nom"> le nom du joueur </param>
        /// <param name="peuple">le peuple du joueur</param>
        public void ajoutJoueur(string nom, string peuple)
        {
            createur.ajoutJoueur(nom, peuple);
        }

        /// <summary>
        /// Ajout de la taille de la carte
        /// </summary>
        /// <param name="taille"> La taille de la carte</param>
        public void ajoutCarte(string taille)
        {
            createur.TypePartie = taille;
        }

        /// <summary>
        /// Construction de la partie
        /// </summary>
        public Partie construirePartie()
        {
            partie = createur.construire();
            return partie;
        }

        ///// <summary>
        ///// Ajout d'un joueur
        ///// </summary>
        ///// <param name="nom"> le nom du joueur </param>
        ///// <param name="peuple">le peuple du joueur</param>
        //public void construireNouvellePartie()
        //{
        //    partie = createur.construire();
        //    PagePrincipale.Source = new Uri("PageJeu.xaml", UriKind.Relative);
        //}
    }
}
