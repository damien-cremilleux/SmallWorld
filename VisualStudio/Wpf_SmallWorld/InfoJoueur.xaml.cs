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
    /// Logique d'interaction pour InfoJoueur.xaml
    /// </summary>
    public partial class InfoJoueur : UserControl
    {

        /// <summary>
        /// Logique d'interaction pour InfoJoueur.xaml
        /// </summary>
        /// <param name="joueur">Le joueur</param>
        public InfoJoueur(Joueur joueur)
        {
            InitializeComponent();
            // Récuperation des données joueur
         // Nom.Text += joueur.nomJ;  // TODO
            Points.Text += joueur.PointVictoire;
         // Unite.Text += joueur.NbUnite; // TODO
        }


    }
}
