/**
 * @file Unite.cs
 * @brief Interface et classe pour les unités
 * 
 * Les unités sont déplacés par les joueurs. Selon le peuple, les unités ont des caractéristiques différentes.
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 07/01/2014
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace SmallWorld
{

    /**
     * @interface InterUnite
     * @brief interface pour les unités
     */
    public unsafe interface InterUnite
    {
        /**
         * @fn attaquer
         * @brief attaquer une case contenant des unités ennemies
         */
        void attaquer();

        /**
         * @fn seDeplacer
         * @brief se déplacer sur une case
         * 
         * @param int <b>x</b> l'abscisse demandée
         * @param int <b>y</b> l'ordinnée demandée
         * @return void
         */
        void seDeplacer(int x, int y);

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
    public unsafe abstract class Unite : InterUnite
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
        * @brief Attribut <b>tabCarte</b>, contient la carte sous forme d'un tableau d'int
        */
        private int* tabCarte;

        /**
        * @brief Attribut <b>tabDeplacement</b>, contient le tableau des déplacements possibles
        */
        private int* tabDeplacement;

        /**
         * @brief Attribut <b>tabCout</b>, contient le tableau des couts de déplacements
         */
        private double* tabCout;

        /**
         * @brief Attribut <b>taillCarteJeu</b>, contient la taille de la carte du jeu
         */
        private int tailleCarteJeu;

        /**
         * @brief Attribut <b>pointDeVie</b>, contient le nombre de point de vie restant de l'unité
         */
        private int pointDeVie;

        /**
         * @brief Attribut <b>pointDeDeplacement</b>, contient le nombre de point de déplacement restant de l'unité
         * 
         * Le nombre de point de déplacement est réinitialisé à chaque début de tour.
         */
        private double pointDeDeplacement;

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
         * @fn TabCarte
         * @brief Properties pour l'attribut tabCarte
         */
        public int* TabCarte
        {
            get
            {
                return tabCarte;
            }
            set
            {
                tabCarte = value;
            }
        }

        /**
         * @fn CartePartie
         * @brief Properties pour l'attribut tabDeplacement
         */
        public int* TabDeplacement
        {
            get
            {
                return tabDeplacement;
            }
            set
            {
                tabDeplacement = value;
            }
        }

        /**
         * @fn TabCout
         * @brief Properties pour l'attribut tabCout
         */
        public double* TabCout
        {
            get
            {
                return tabCout;
            }
            set
            {
                tabCout = value;
            }
        }

        /**
         * @fn TailleCarteJeu
         * @brief Properties pour l'attribut tailleCarteJeu
         */
        public int TailleCarteJeu
        {
            get
            {
                return tailleCarteJeu;
            }
            set
            {
                tailleCarteJeu = value;
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
        public double PointDeDeplacement
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
         * @fn seDeplacer
         * @brief se déplacer sur une case
         * 
         * @param int <b>x</b> l'abscisse demandée
         * @param int <b>y>/b> l'ordonnée demandée
         * @param int* <b>carte</b> la carte
         * @param int <b>tailleCarte</b> la taille de la carte
         * @return void
         */
        public void seDeplacer(int x, int y)
        {
            if (TabDeplacement[x * TailleCarteJeu + y] > 1)
            {
                //On met à jour l'unité
                PointDeDeplacement = TabCout[x * TailleCarteJeu + y];
                Position.Abscisse = x;
                Position.Ordonnee = y;

                //on met à jour les déplcements
                this.calculerDeplacement();
            }
        }

        /**
        * @fn calculerDeplacement
        * @brief calculer les déplacements possibles
        * 
        * @return void
        */
        public abstract void calculerDeplacement();

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

        /**
        * @fn nouveauTour()
        * @brief Les attributs de l'unité sont mis à jour pour le nouveau tour
        */
        public void nouveauTour()
        {
            PasseSonTour = false;
            PointDeDeplacement = 1;
            //On met à jour les matrices de déplacements
            calculerDeplacement();
        }
    }


    /**
     * @class UniteGauloise
     * @brief Classe pour les unités gauloises
     */
    public unsafe class UniteGauloise : Unite, InterUniteGauloise
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

        /**
         * @fn calculerDeplacement
         * @brief met à jour les déplacements possibles
         * 
         * @return void
         */
        public override void calculerDeplacement()
        {
            WrapperAlgo w = new WrapperAlgo();
            w.deplacementGauloisInitial(TabCarte, TailleCarteJeu, Position.Abscisse, Position.Ordonnee, TabCout, TabDeplacement, PointDeDeplacement);
        }

    }

    /**
     * @class UniteNaine
     * @brief Classe pour les unités naines
     */
    public unsafe class UniteNaine : Unite, InterUniteNaine
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

        /**
         * @fn calculerDeplacement
         * @brief met à jour les déplacements possibles
         * 
         * @return void
         */
        public override void calculerDeplacement()
        {
            WrapperAlgo w = new WrapperAlgo();
            w.deplacementNainInitial(TabCarte, TailleCarteJeu, Position.Abscisse, Position.Ordonnee, TabCout, TabDeplacement, PointDeDeplacement);
        }
    }

    /**
     * @class UniteViking
     * @brief Classe pour les unités viking
     */
    public unsafe class UniteViking : Unite, InterUniteViking
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

        /**
         * @fn calculerDeplacement
         * @brief met à jour les déplacements possibles
         * 
         * @return void
         */
        public override void calculerDeplacement()
        {
            WrapperAlgo w = new WrapperAlgo();
            w.deplacementVikingInitial(TabCarte, TailleCarteJeu, Position.Abscisse, Position.Ordonnee, TabCout, TabDeplacement, PointDeDeplacement);
        }
    }
}
