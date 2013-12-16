/**
 * @file Coordonnees.cs
 * @brief classe Coordonnees
 * 
 * Représentation de coordonnées pour le jeu SmallWorld
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 15/12/2013
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    /**
     * @class Coordonnees
     * @brief Rprésentation des coordonnées
      */
    public class Coordonnees
    {
        /**
         * @brief Attribut <b>abscisse</b>
         */
        private int abscisse;

        /**
         * @brief Attribut <b>abscisse</b>
         */
        private int ordonnee;

        /**
         * @fn Abscisse
         * @brief Properties pour l'attribut abscisse
         */
        public int Abscisse
        {
            get
            {
                return abscisse;
            }
            set
            {
                if (value > 0) //Les coordonnées démarrent à (0,0) et ne peuvent pas être négatives
                {
                    abscisse = value;
                }
            }
        }

        /**
         * @fn Ordonnee
         * @brief Properties pour l'attribut ordonnee
         */
        public int Ordonnee
        {
            get
            {
                return ordonnee;
            }
            set
            {
                if (value > 0) //Les coordonnées démarrent à (0,0) et ne peuvent pas être négatives
                {
                    ordonnee = value;
                }
            }
        }

        /**
         * @fn Coordonnees(int abs, int ord)
         * @brief Constructeur de coordonnees
         * 
         * @param int <b>abs</b> L'abscisse
         * @param int <b>ord</b> L'ordonnée
         * @return les nouvelles coordonnées
         */
        public Coordonnees(int abs, int ord)
        {
            this.abscisse = abs;
            this.ordonnee = ord;
        }
    }
}
