﻿using System;
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
        public Joueur2()
        {
            InitializeComponent();
        }

        private void LancerPartie(object sender, RoutedEventArgs e)
        {
            Jeu a = new Jeu();
            a.Show();
            this.Close();
        }
    }
}
