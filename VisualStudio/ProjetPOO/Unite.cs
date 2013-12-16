/**
 * @file Unite.cs
 * @brief Interface et classe pour les unités
 * 
 * Les unités sont déplacés par les joueurs. Selon le peuple, les unités ont des caractéristiques différentes.
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 26/12/2013
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    /**
     * @interface InterUnite
     * @brief Interface pour les unités
     */
    public interface InterUnite
    {
        /**
         * @fn attaquer
         * @brief attaquer une case contenant des unités ennemies
         */
        void attaquer();

        /**
         * @fn seDeplacer
         * @brief se déplacer sur une case
         */
        void seDeplacer();

        /**
         * @fn passerSonTour
         * @brief l'unité passe son tour
         */
        void passerSonTour();
    }

    /**
     * @class Unite
     * @brief Classe abstraite pour les unités
     */
    public abstract class Unite : InterUnite
    {

        /**
         * @brief Attribut <b>position</b>, contient la position courante de l'unité
         */
        private Coordonnees position;

        /**
         * @brief Attribut <b>pointDeVie</b>, contient le nombre de point de vie restant de l'unité
         */
        private int pointDeVie;

        /**
         * @brief Attribut <b>pointDeDeplacement</b>, contient le nombre de point de déplacement restant de l'unité
         * 
         * Le nombre de point de déplacement est réinitialisé à chaque début de tour.
         */
        private int pointDeDeplacement;

        /**
         * @brief Attribut <b>pointDeVictoire</b>, contient le nombre de victoire apporté par de l'unité
         */
        private int pointDeVictoire;

        /**
         * @brief Attribut <b>pointAttaque</b>, contient le nombre de point d'attaque de l'unité
         */
        private int pointAttaque;

        /**
          * @brief Attribut <b>pointDefense</b>, contient le nombre de point de défense de l'unité
          */
        private int pointDefense;

        /**
          * @brief Attribut <b>passeSonTour</b>, indique si l'unité passe son tour
          */
        private bool passeSonTour;


        /**
         * @fn Position
         * @brief Properties pour l'attribut position
         */
        public Coordonnees Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /**
         * @fn PointDeVie
         * @brief Properties pour l'attribut pointDeVie
         */
        public int PointDeVie
        {
            get
            {
                return pointDeVie;
            }
            set
            {
                pointDeVie = value;
            }
        }

        /**
         * @fn PointDeDeplacement
         * @brief Properties pour l'attribut pointDeDeplacement
         */
        public int PointDeDeplacement
        {
            get
            {
                return pointDeDeplacement;
            }
            set
            {
                pointDeDeplacement = value;
            }
        }

        /**
         * @fn PointDeVictoire
         * @brief Properties pour l'attribut pointDeVictoire
         */
        public int PointDeVictoire
        {
            get
            {
                return pointDeVictoire;
            }
            set
            {
                pointDeVictoire = value;
            }
        }

        /**
         * @fn PointAttaque
         * @brief Properties pour l'attribut pointAttaque
         */
        public int PointAttaque
        {
            get
            {
                return pointAttaque;
            }
            set
            {
                pointAttaque = value;
            }
        }

        /**
         * @fn PointDefense
         * @brief Properties pour l'attribut pointDefense
         */
        public int PointDefense
        {
            get
            {
                return pointDefense;
            }
            set
            {
                pointDefense = value;
            }
        }

        /**
         * @fn PasseSonTour
         * @brief Properties pour l'attribut passeSonTour
         */
        public bool PasseSonTour
        {
            get
            {
                return passeSonTour;
            }
            set
            {
                passeSonTour = value;
            }
        }

        /**
         * @fn attaquer
         * @brief attaquer une case contenant des unités ennemies
         */
        public void attaquer()
        {
            throw new NotImplementedException();
        }

        /**
         * @fn seDeplacer
         * @brief se déplacer sur une case
         */
        public void seDeplacer()
        {
            throw new NotImplementedException();
        }

        /**
         * @fn passerSonTour
         * @brief l'unité passe son tour
         */
        public void passerSonTour()
        {
            throw new NotImplementedException();
        }

        /**
         * @fn perdreVie
         * @brief l'unité perd une vie
         */
        public void perdreVie()
        {
            throw new System.NotImplementedException();
        }

        /**
         * @fn mourir
         * @brief l'unité meurt
         */
        public void mourir()
        {
            throw new System.NotImplementedException();
        }
    }


}
