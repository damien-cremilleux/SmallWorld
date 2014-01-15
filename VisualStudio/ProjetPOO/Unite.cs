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
         * @fn attaquer(Unite uniteAdverse, int nbRoundCombat)
         * @brief attaquer une unité adverse, sachant le nombre de rounds
         * 
         * @param Unite <b>uniteAdverse</b> l'unité à combattre
         * @param int <b>nbRoundCombat</b> le nombre de round
         */
        void attaquer(Unite uniteAdverse, int nbRoundCombat);

        /**
         * @fn seDeplacer
         * @brief se déplacer sur une case
         * 
         * @param int <b>x</b> l'abscisse demandée
         * @param int <b>y</b> l'ordinnée demandée
         * @return void
         */
        bool seDeplacer(int x, int y);

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
    [Serializable]
    public unsafe abstract class Unite : InterUnite
    {

        /**
         * @brief Attribut <b>position</b>, contient la position courante de l'unité
         */
        private Coordonnees position;

        /**
         * @brief Attribut <b>tabCarte</b>, contient la carte sous forme d'un tableau d'int
         */
        [NonSerialized]
        protected int* tabCarte;

        /**
        * @brief Attribut <b>tabDeplacement</b>, contient le tableau des déplacements possibles
        */
        [NonSerialized]
        private int* tabDeplacement;

        /**
         * @brief Attribut <b>tabCout</b>, contient le tableau des couts de déplacements
         */
        [NonSerialized]
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
        protected int pointDeVictoire;

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
         * @brief Attribut <b>wrapperAlgo</b>, le wrapper pour l'unité
         */
        [NonSerialized]
        protected WrapperAlgo wrapperAlgo;

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
            PointDeVie = Constantes.UNITE_POINT_VIE;
            PointAttaque = Constantes.UNITE_POINT_ATT;
            PointDefense = Constantes.UNITE_POINT_DEF;
            PointDeDeplacement = Constantes.UNITE_POINT_DEPL;
            PasseSonTour = false;
            wrapperAlgo = new WrapperAlgo();
        }

        /**
         * @fn calculPointVictoire()
         * @brief Met à jour les points de victoire du joueur
         */
        public abstract void calculPointVictoire();

        /**
         * @fn attaquer(Unite uniteAdverse, int nbRoundCombat)
         * @brief attaquer une unité adverse, sachant le nombre de rounds
         * 
         * @param Unite <b>uniteAdverse</b> l'unité à combattre
         * @param int <b>nbRoundCombat</b> le nombre de round
         */
        public void attaquer(Unite uniteAdverse, int nbRoundCombat)
        {
            while ((nbRoundCombat > 0) && (PointDeVie > 0) && (uniteAdverse.PointDeVie > 0))
            {
                double probaAttaquantPerd = 0.5; //Par défaut on est à 50%
                if (PointAttaque != uniteAdverse.PointDefense)
                {
                    double coefficient = ((double)Math.Abs(PointAttaque - uniteAdverse.PointDefense) / (double)Math.Max(PointAttaque, uniteAdverse.PointDefense));
                    Console.WriteLine("Coefficient du combat" + coefficient);
                    double ponderation = coefficient * 0.5;
                    Console.WriteLine("Pondération du combat" + ponderation);

                    if (PointAttaque > uniteAdverse.PointDefense)
                        probaAttaquantPerd = 0.5 - ponderation;

                    if (PointAttaque < uniteAdverse.PointDefense)
                        probaAttaquantPerd = 0.5 + ponderation;
                }

                Random r = new Random();
                double random = r.Next(100);
                if (random < (probaAttaquantPerd * 100))
                {
                    PointDeVie--;
                    Console.WriteLine("L'unité A perd une vie");
                }
                else
                {
                    uniteAdverse.PointDeVie--;
                    Console.WriteLine("L'unité B perd une vie");
                }
                nbRoundCombat--;
            }
        }

        /**
         * @fn seDeplacer
         * @brief se déplacer sur une case, uniquement si le déplacement est possible
         * 
         * @param int <b>x</b> l'abscisse demandée
         * @param int <b>y>/b> l'ordonnée demandée
         * @return bool vrai si l'unité peut se déplacer, faux sinon
         */
        public bool seDeplacer(int x, int y)
        {
            if (peutSeDeplacer(x, y))
            {
                //On met à jour l'unité
                PointDeDeplacement = TabCout[x * TailleCarteJeu + y];
                Position.Abscisse = x;
                Position.Ordonnee = y;

                //on met à jour les déplacements, si l'unité n'a plus de point de déplacement, elle passe son tour
                this.calculerDeplacement();
                if (PointDeDeplacement == 0)
                {
                    PasseSonTour = true;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * @fn peutSeDeplacer(int x, int y)
         * @brief Indique si l'unité peut se déplacer sur une case
         * 
         * @param int <b>x</b> l'abscisse demandée
         * @param int <b>y</b> l'ordonnée demandée
         * @return bool vrai si l'unité peut se déplacer, faux sinon
         */
        public bool peutSeDeplacer(int x, int y)
        {
            return TabDeplacement[x * TailleCarteJeu + y] > 1;
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

        /**
         * @fn restaurer()
         * @brief Restaure l'unité suite à une désérialisation
         * 
         * @return void
         */
        public void restaurer(int* carte)
        {
            wrapperAlgo = new WrapperAlgo();

            TabCarte = carte;
            TabDeplacement = wrapperAlgo.creerTab(TailleCarteJeu);
            TabCout = wrapperAlgo.creerTabDouble(TailleCarteJeu);

            //On met à jour les matrices de déplacements
            calculerDeplacement();
        }

        /**
         * @fn suggererCaseNonPossible()
         * @brief Suggère les cases de déplacement impossible pour une unité
         * 
         * @return List<Coordonnee> la liste des coordonnées impossibles
         */
        public List<Coordonnees> suggererCaseNonPossible()
        {
            List<Coordonnees> listeRes = new List<Coordonnees>();
            int i, j;
            for (i = 0; i < TailleCarteJeu; i++)
            {
                for (j = 0; j < TailleCarteJeu; j++)
                {
                    if (TabDeplacement[i * TailleCarteJeu + j] < 2)
                            listeRes.Add(new Coordonnees(i, j));
                }
            }

            return listeRes;
        }

        /**
         * @fn suggererCaseOptimele()
         * @brief Suggère les cases de déplacement pour une unité qui sont optimales
         * 
         * @return List<Coordonnee> la liste des coordonnées possibles
         */
        public List<Coordonnees> suggererCaseOptimale()
        {
            List<Coordonnees> listeRes = new List<Coordonnees>();
            int i, j;
            for (i = 0; i < TailleCarteJeu; i++)
            {
                for (j = 0; j < TailleCarteJeu; j++)
                {

                    if (TabDeplacement[i * TailleCarteJeu + j] > 2)
                        listeRes.Add(new Coordonnees(i, j));
                }
            }

            return listeRes;
        }
    }


    /**
     * @class UniteGauloise
     * @brief Classe pour les unités gauloises
     */
    [Serializable]
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
            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_DESERT)
                pointDeVictoire = Constantes.POINT_CASE;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_EAU)
                pointDeVictoire = 0;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_FORET)
                pointDeVictoire = Constantes.POINT_CASE;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_MONTAGNE)
                pointDeVictoire = Constantes.POINT_CASE;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_PLAINE)
                pointDeVictoire = Constantes.POINT_CASE + 1;
        }

        /**
         * @fn calculerDeplacement
         * @brief met à jour les déplacements possibles
         * 
         * @return void
         */
        public override void calculerDeplacement()
        {
            wrapperAlgo.deplacementGauloisInitial(TabCarte, TailleCarteJeu, Position.Abscisse, Position.Ordonnee, TabCout, TabDeplacement, PointDeDeplacement);
        }

    }

    /**
     * @class UniteNaine
     * @brief Classe pour les unités naines
     */
    [Serializable]
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
            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_DESERT)
                pointDeVictoire = Constantes.POINT_CASE;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_EAU)
                pointDeVictoire = 0;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_FORET)
                pointDeVictoire = Constantes.POINT_CASE + 1;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_MONTAGNE)
                pointDeVictoire = Constantes.POINT_CASE;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_PLAINE)
                pointDeVictoire = 0;
        }

        /**
         * @fn calculerDeplacement
         * @brief met à jour les déplacements possibles
         * 
         * @return void
         */
        public override void calculerDeplacement()
        {
            wrapperAlgo.deplacementNainInitial(TabCarte, TailleCarteJeu, Position.Abscisse, Position.Ordonnee, TabCout, TabDeplacement, PointDeDeplacement);
        }
    }

    /**
     * @class UniteViking
     * @brief Classe pour les unités viking
     */
    [Serializable]
    public unsafe class UniteViking : Unite, InterUniteViking
    {
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
            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_DESERT)
                pointDeVictoire = 0;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_EAU)
                pointDeVictoire = 0;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_FORET)
                pointDeVictoire = Constantes.POINT_CASE;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_MONTAGNE)
                pointDeVictoire = Constantes.POINT_CASE;

            if (TabCarte[Position.Abscisse * TailleCarteJeu + Position.Ordonnee] == Constantes.CASE_PLAINE)
                pointDeVictoire = Constantes.POINT_CASE;

            if (this.surCaseBordEau())
            {
                pointDeVictoire++;
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
            wrapperAlgo.deplacementVikingInitial(TabCarte, TailleCarteJeu, Position.Abscisse, Position.Ordonnee, TabCout, TabDeplacement, PointDeDeplacement);
        }

        /**
       * @fn surCaseBordEau()
       * @brief Test si l'unité est sur une case au bord de l'eau
       * 
       * @return bool, vrai si l'unité est sur une case au bord de l'eau, faux sinon
       */
        public bool surCaseBordEau()
        {
            if (wrapperAlgo.caseBordEau(TabCarte, TailleCarteJeu, Position.Abscisse, Position.Ordonnee) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
