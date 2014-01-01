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
    /// Logique d'interaction pour InfoUnite.xaml
    /// </summary>
    public partial class InfoUnite : UserControl
    {
        private Unite unite;
   
        /// <summary>
        /// Accès à l'unité dont on indique les renseignements
        /// </summary>
        public Unite Unite
        {
            get { return unite; }
        }

        public InfoUnite(Unite unit)
        {
          
            this.unite = unit;
            InitializeComponent();

            // Récuperation des données de l'unité
            PointVie.Text += unite.PointDeVie;
            PointDeplacement.Text += unite.PointDeDeplacement;
            PointVictoire.Text += unite.PointDeVictoire;  
            PointAttaque.Text += unite.PointAttaque;  
            PointDefense.Text += unite.PointDefense;  

        }
    }
}
