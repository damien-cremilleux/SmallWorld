/**
 * @file Unite.cs
 * @brief Interface et classe pour les unités
 * 
 * Les unités sont déplacés par les joueurs. Selon le peuple, les unités ont des caractéristiques différentes.
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 03/01/2014
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
     * @brief interface pour les unités
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
     * @interface InterUniteGauloise
     * @brief Interface pour les unités gauloises
     */
    public interface InterUniteGauloise : InterUnite
    {
    }


    /**
     * @interface InterUniteNaine
     * @brief Interface pour les unités naines
     */
    public interface InterUniteNaine : InterUnite
    {
    }
    /**
     * @interface InterUniteViking
     * @brief Interface pour les unités viking
     */
    public interface InterUniteViking : InterUnite
    {
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
         * @brief Attribut <b>case</b>, contient le type de case sur laquelle est l'unité
         */
        private Case caseUnite;

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
         * @fn TypeCase
         * @brief Properties pour l'attribut typeCase
         */
        public Case CaseUnite
        {
            get
            {
                return caseUnite;
            }
            set
            {
                caseUnite = value;
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
                this.calculPointVictoire();
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
         * @fn Unite() 
         * @brief Constructeur d'une nouvelle unité
         * 
         * Créé une nouvelle unité et initialise les différentes caractéristiques de celle-ci
         * 
         * @return la nouvelle unité
         */
        public Unite()
        {
            PointDeVie = 2;
            PointAttaque = 2;
            PointDefense = 1;
            PointDeDeplacement = 1;
            PasseSonTour = false;
        }

        /**
         * @fn calculPointVictoire()
         * @brief Met à jour les points de victoire du joueur
         */
        public abstract void calculPointVictoire();

        /**
         * @fn attaquer()
         * @brief attaquer une case contenant des unités ennemies
         */
        public void attaquer()
        {
            throw new NotImplementedException();
        }

        /**
         * @fn seDeplacer()
         * @brief se déplacer sur une case
         */
        public void seDeplacer()
        {
            throw new NotImplementedException();
        }

        /**
         * @fn passerSonTour()
         * @brief l'unité passe son tour
         */
        public void passerSonTour()
        {
            this.PasseSonTour = true;
        }

        /**
         * @fn perdreVie()
         * @brief l'unité perd une vie
         */
        public void perdreVie()
        {
            this.PointDeVie--;
        }

        /**
         * @fn mourir()
         * @brief l'unité meurt
         */
        public void mourir()
        {
            throw new System.NotImplementedException();
        }
    }


    /**
     * @class UniteGauloise
     * @brief Classe pour les unités gauloises
     */
    public class UniteGauloise : Unite, InterUniteGauloise
    {
        /**
         * @fn UniteGauloise
         * @brief Constructeur d'une unité gauloise
         *
         * @return la nouvelle unité gauloise
         */
        public UniteGauloise()
        {
        }

        /**
         * @fn calculPointVictoire()
         * @brief Met à jour les points de victoire apportés par l'unité
         */
        public override void calculPointVictoire()
        {
            if (CaseUnite.GetType() == new Desert().GetType())
                PointDeVictoire = 1;

            if (CaseUnite.GetType() == new Eau().GetType())
                PointDeVictoire = 0;

            if (CaseUnite.GetType() == new Foret().GetType())
                PointDeVictoire = 1;

            if (CaseUnite.GetType() == new Montagne().GetType())
                PointDeVictoire = 1;

            if (CaseUnite.GetType() == new Plaine().GetType())
                PointDeVictoire = 2;
        }
    }

    /**
     * @class UniteNaine
     * @brief Classe pour les unités naines
     */
    public class UniteNaine : Unite, InterUniteNaine
    {
        /**
         * @fn UniteNaine()
         * @brief Constructeur d'une unité naine
         * 
         * @return une unité naine
         */
        public UniteNaine()
        {
        }

        /**
         * @fn calculPointVictoire()
         * @brief Met à jour les points de victoire apportés par l'unité
         */
        public override void calculPointVictoire()
        {
            if (CaseUnite.GetType() == new Desert().GetType())
                PointDeVictoire = 1;

            if (CaseUnite.GetType() == new Eau().GetType())
                PointDeVictoire = 0;

            if (CaseUnite.GetType() == new Foret().GetType())
                PointDeVictoire = 2;

            if (CaseUnite.GetType() == new Montagne().GetType())
                PointDeVictoire = 1;

            if (CaseUnite.GetType() == new Plaine().GetType())
                PointDeVictoire = 0;
        }
    }

    /**
     * @class UniteViking
     * @brief Classe pour les unités viking
     */
    public class UniteViking : Unite, InterUniteViking
    {
        /**
         * @brief Attribut <b>bordEau</b> indique si l'unité occupe une case au bord de l'eau
         */
        private bool bordEau;

        /**
         * @fn BordEau
         * @brief Properties pour l'attribut BordEau
         */
        public bool BordEau
        {
            get
            {
                return bordEau;
            }
            set
            {
                bordEau = value;
            }
        }

        /**
         * @fn UniteViking()
         * @brief Constructeur d'une unité viking
         * 
         * @return une unité viking
         */
        public UniteViking()
        {
        }

        /**
         * @fn calculPointVictoire()
         * @brief Met à jour les points de victoire apportés par l'unité
         */
        public override void calculPointVictoire()
        {
            if (CaseUnite.GetType() == new Desert().GetType())
                PointDeVictoire = 0;

            if (CaseUnite.GetType() == new Eau().GetType())
                PointDeVictoire = 0;

            if (CaseUnite.GetType() == new Foret().GetType())
                PointDeVictoire = 1;

            if (CaseUnite.GetType() == new Montagne().GetType())
                PointDeVictoire = 1;

            if (CaseUnite.GetType() == new Plaine().GetType())
                PointDeVictoire = 1;
            
            if (BordEau)
            {
                PointDeVictoire++;
            }
        }

    }
}
