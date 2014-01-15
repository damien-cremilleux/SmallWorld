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
            InitializeComponent();
            unite = unit;

            // Récuperation des données de l'unité
            PointVie.Text = "" +unite.PointDeVie;
            PointDeplacement.Text = "" + unite.PointDeDeplacement;
            PointVictoire.Text = "" + unite.PointDeVictoire;
            PointAttaque.Text = "" + unite.PointAttaque;
            PointDefense.Text = "" + unite.PointDefense;

            BitmapSource img;
            if (unite is InterUniteNaine)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.dwarf.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ImgPeuple.Fill = new ImageBrush(img);
                ImgPeuple.Tag = "Unité Naine";
            }
            if (unite is InterUniteViking)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.viking.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ImgPeuple.Fill = new ImageBrush(img);
                ImgPeuple.Tag = "Unité Viking";

            }
            if (unite is InterUniteGauloise)
            {
                img = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Wpf_SmallWorld.Properties.Resources.Gaulois.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ImgPeuple.Fill = new ImageBrush(img);
                ImgPeuple.Tag = "Unité Gauloise";
            }

            if (unite.PasseSonTour)
                Container.Opacity = 0.3;
            else
              PasserSonTour.Visibility = Visibility.Visible;
        }


        private void passerSonTour(object sender, RoutedEventArgs e)
        {
                unite.PasseSonTour = true;
                Container.Opacity = 0.3;
                PointDeplacement.Text = "" + unite.PointDeDeplacement;
                PasserSonTour.Visibility = Visibility.Hidden;
        }

    }
}
