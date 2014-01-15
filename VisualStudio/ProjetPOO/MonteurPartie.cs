/**
 * @file MonteurPartie.cs
 * @brief Interfaces et classes du monteur de partie
 * 
 * Monteur du patron de conception monteur, contient les interfaces et les
 * différentes implémentations pour le processus de création d'une partie
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 06/01/2014
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using Wrapper;

namespace SmallWorld
{
    /**
     * @interface InterMonteurPartie
     * @brief Interface globale du monteur
     */
    public interface InterMonteurPartie
    {
        /**
         * @fn ajouterCarte();
         * @brief Ajout de la carte pour la construction d'une partie.
         * 
         * @return void
         */
        void ajouterCarte();

        /**
         * @fn ajouterJoueur(string nomJoueur, string peuple)
         * @brief Ajout d'un joueur à la partie.
         * 
         * @param string <b>nomJoueur</b> Le nom du joueur à ajouter.
         * @param string <b>peuple</b> Le peuple joué par le joueur.
         * @return void
         */
        void ajouterJoueur(string nomJoueur, string peuple);

        /**
         * @fn creerPartie(string nomJoueurA, string peupleA, string nomJoueurB, string peupleB)
         * @brief Création de la partie
         * 
         * @param string <b>nomJoueurA</b> le nom du premier joueur
         * @param string <b>peupleA</b> le peuple du premier joueur
         * @param string <b>nomJoueurB</b> le nom du deuxième joueur
         * @param string <b>peupleB</b> le peuple du deuxième joueur
         * @return Partie la nouvelle partie
         */
        Partie creerPartie(string nomJoueurA, string peupleA, string nomJoueurB, string peupleB);

        /**
         * @fn placerUnites()
         * @brief Placement des unités avant le début de la partie.
         * 
         * @return void
         */
        void placerUnites();

        /**
     * @fn initialiserNombreTour
     * @brief initialise le nombre de tour d'un partie
     * 
     * @return void
     */
        void initialiserNombreTour();
    }

    /**
     * @interface InterMonteurPartieDemo
     * @brief Interface du monteur de partie démo
     */
    public interface InterMonteurPartieDemo : InterMonteurPartie
    {
    }

    /**
     * @interface InterMonteurPartiePetite
     * @brief Interface du monteur de partie petite
     */
    public interface InterMonteurPartiePetite : InterMonteurPartie
    {
    }


    /**
     * @interface InterMonteurPartieNormale
     * @brief Interface du monteur de partie normale
     */
    public interface InterMonteurPartieNormale : InterMonteurPartie
    {
    }


    /**
     * @class MonteurPartie
     * @brief Classe abstraite implémentant InterMonteur InterPartie
     */
    public abstract class MonteurPartie : InterMonteurPartie
    {
        /**
         * @brief constante <b>nb_case</b> le nombre initial de tour
         */
        protected int nb_case;

        /**
         * @brief constante <b>nb_tour</b> le nombre initial de tour
         */
        protected int nb_tour;

        /**
         * @brief constante <b>nb_unite</b> le nombre initial d'unité par joueur
         */
        protected int nb_unite;

        /**
         * @brief Attribut <b>fabriquePeuple</b> la fabrique de peuple
         */
        private FabriquePeuple fabriquePeuple;

        /**
         * @brief Attribut <b>partie</b> la partie à créer
         */
        private Partie partie;

        /**
         * @brief Attribut <b>carte</b> la carte associée à la partie
         */
        private Carte carte;

        /**
         * @brief Attribut <b>strategie</b> la strategie à adopter
         */
        private StrategieCarte strategie;

        /**
         * @fn Nb_tour
         * @brief Properties pour l'attribut nb_tour
         */
        public int Nb_case
        {
            get
            {
                return nb_case;
            }
        }

        /**
         * @fn Nb_tour
         * @brief Properties pour l'attribut nb_tour
         */
        public int Nb_tour
        {
            get
            {
                return nb_tour;
            }
        }

        /**
         * @fn Nb_unite
         * @brief Properties pour l'attribut nb_unite
         */
        public int Nb_unite
        {
            get
            {
                return nb_unite;
            }
        }

        /**
         * @fn FabriquePeuple
         * @brief Properties pour l'attribut fabriquePeuple
         */
        public FabriquePeuple FabriquePeuple
        {
            get
            {
                return fabriquePeuple;
            }
            set
            {
                fabriquePeuple = value;
            }
        }

        /**
         * @fn Partie
         * @brief Properties pour l'attribut partie
         */
        public Partie Partie
        {
            get
            {
                return partie;
            }
            set
            {
                partie = value;
            }
        }

        /**
         * @fn Carte
         * @brief Properties pour l'attribut carte
         */
        public Carte Carte
        {
            get
            {
                return carte;
            }
            set
            {
                carte = value;
            }
        }

        /**
         * @fn Strategie
         * @brief Properties pour l'attribut strategie
         */
        public StrategieCarte Strategie
        {
            get
            {
                return strategie;
            }
            set
            {
                strategie = value;
            }
        }

        /**
         * @fn ajouterCarte()
         * @brief Ajout de la carte pour la construction d'une partie.
         * 
         * @return void
         */
        public void ajouterCarte()
        {
            List<List<Case>> listeCases;
            listeCases = Strategie.construire();

            Partie.CartePartie.ListeCases = listeCases;
        }

        /**
         * @fn ajouterJoueur(string nomJoueur, string peuple)
         * @brief Ajout d'un joueur
         * 
         * @param string <b>nomJoueur</b> le nom du joueur
         * @param string <b>peuple</b> le type de peuple
         * @return void
         */
        public void ajouterJoueur(string nomJoueur, string peuple)
        {
            Peuple p = FabriquePeuple.Instance_FabPeuple.fabriquerPeuple(peuple);
            Joueur j = new Joueur(nomJoueur, p);
            Partie.ListeJoueurs.Add(j);

            //Le premier joueur est sélectionné au hasard
            Random r = new Random();
            int premier = r.Next(Partie.ListeJoueurs.Count);
            Partie.IndiceJoueurInitial = premier;
            Partie.IndiceJoueurEnCours = Partie.IndiceJoueurInitial;
        }

        /**
         * @fn creerPartie(string nomJoueurA, string peupleA, string nomJoueurB, string peupleB)
         * @brief Création de la partie
         * 
         * @param string <b>nomJoueurA</b> le nom du premier joueur
         * @param string <b>peupleA</b> le peuple du premier joueur
         * @param string <b>nomJoueurB</b> le nom du deuxième joueur
         * @param string <b>peupleB</b> le peuple du deuxième joueur
         * @return Partie la nouvelle partie
         */
        public Partie creerPartie(string nomJoueurA, string peupleA, string nomJoueurB, string peupleB)
        {
            this.ajouterJoueur(nomJoueurA, peupleA);
            this.ajouterJoueur(nomJoueurB, peupleB);
            this.ajouterCarte();
            this.placerUnites();
            this.initialiserNombreTour();
            return Partie;
        }

        /**
         * @fn initialiserNombreTour
         * @brief initialise le nombre de tour d'un partie
         * 
         * @return void
         */
        public void initialiserNombreTour()
        {
            Partie.NbTourRestant = Nb_tour;
        }

        /**
         * @fn placerUnites()
         * @brief Place le nombre d'unité nécessaire au début de la partie
         * 
         * @return void
         */
        public unsafe void placerUnites()
        {
            int i, j;
            for (i = 0; i < Nb_unite; i++)
            {
                Partie.ListeJoueurs[0].ListeUnite.Add(Partie.ListeJoueurs[0].PeupleJ.creerUnite());
                Partie.ListeJoueurs[1].ListeUnite.Add(Partie.ListeJoueurs[1].PeupleJ.creerUnite());
            }

            WrapperAlgo wrapperAlgo = new WrapperAlgo();
            int* position;

            //On transforme le tableau de case en int
            int* tabCase = wrapperAlgo.creerTab(Nb_case);

            for (i = 0; i < Nb_case; i++)
            {
                for (j = 0; j < Nb_case; j++)
                {
                    if (Partie.CartePartie.ListeCases[i][j].GetType() == new Desert().GetType())
                        tabCase[i * Nb_case + j] = Constantes.CASE_DESERT;

                    if (Partie.CartePartie.ListeCases[i][j].GetType() == new Eau().GetType())
                        tabCase[i * Nb_case + j] = Constantes.CASE_EAU;

                    if (Partie.CartePartie.ListeCases[i][j].GetType() == new Foret().GetType())
                        tabCase[i * Nb_case + j] = Constantes.CASE_FORET;

                    if (Partie.CartePartie.ListeCases[i][j].GetType() == new Montagne().GetType())
                        tabCase[i * Nb_case + j] = Constantes.CASE_MONTAGNE;

                    if (Partie.CartePartie.ListeCases[i][j].GetType() == new Plaine().GetType())
                        tabCase[i * Nb_case + j] = Constantes.CASE_PLAINE;
                }
            }

            position = wrapperAlgo.placerJoueur(tabCase, Nb_case);

            Partie.TabCarte = tabCase;

            int x1, y1, x2, y2;

            x1 = position[0];
            y1 = position[1];
            x2 = position[2];
            y2 = position[3];

            Coordonnees coordJ1 = new Coordonnees(x1, y1);
            Coordonnees coordJ2 = new Coordonnees(x2, y2);
            Coordonnees[] tabCoord = { coordJ1, coordJ2 };

            //On initialise chaque unité
            for (i = 0; i < Partie.ListeJoueurs.Count; i++)
            {
                for (j = 0; j < Partie.ListeJoueurs[i].ListeUnite.Count; j++)
                {
                    Partie.ListeJoueurs[i].ListeUnite[j].Position = new Coordonnees(tabCoord[i].Abscisse, tabCoord[i].Ordonnee);
                    Partie.ListeJoueurs[i].ListeUnite[j].TabCarte = tabCase;
                    Partie.ListeJoueurs[i].ListeUnite[j].TailleCarteJeu = Nb_case;
                    Partie.ListeJoueurs[i].ListeUnite[j].TabDeplacement = wrapperAlgo.creerTab(Nb_case);
                    Partie.ListeJoueurs[i].ListeUnite[j].TabCout = wrapperAlgo.creerTabDouble(Nb_case);
                    Partie.ListeJoueurs[i].ListeUnite[j].calculerDeplacement();
                }

                //On met à jour les points de victoire du joueur
                Partie.ListeJoueurs[i].calculerPointVictoire();
            }
        }
    }

    /**
     * @class MonteurPartieDemo
     * @brief classe pour un monteur d'une partie démo
     */
    public class MonteurPartieDemo : MonteurPartie, InterMonteurPartieDemo
    {
        /**
         * @fn MonteurPartieDemo
         * @brief Constructeur d'un MonteurPartieDemo
         */
        public MonteurPartieDemo()
        {
            nb_case = Constantes.NB_CASE_DEMO;
            nb_tour = Constantes.NB_TOUR_DEMO;
            nb_unite = Constantes.NB_UNITE_DEMO;

            FabriquePeuple = new FabriquePeuple();
            Carte = new Carte();
            Partie = new Partie();
            Strategie = new StrategieDemo();
        }
    }

    /**
    * @class MonteurPartiePetite
    * @brief classe pour un monteur d'une partie petite
    */
    public class MonteurPartiePetite : MonteurPartie, InterMonteurPartiePetite
    {
        /**
         * @fn MonteurPartiePetite
         * @brief Constructeur d'un MonteurPartiePetite
         */
        public MonteurPartiePetite()
        {
            nb_case = Constantes.NB_CASE_PETITE;
            nb_tour = Constantes.NB_TOUR_PETITE;
            nb_unite = Constantes.NB_UNITE_PETITE;

            FabriquePeuple = new FabriquePeuple();
            Carte = new Carte();
            Partie = new Partie();
            Strategie = new StrategiePetite();
        }
    }

    /**
    * @class MonteurPartieNormale
    * @brief classe pour un monteur d'une partie normale
    */
    public class MonteurPartieNormale : MonteurPartie, InterMonteurPartieNormale
    {
        /**
         * @fn MonteurPartieNormale
         * @brief Constructeur d'un MonteurPartieNormale
         */
        public MonteurPartieNormale()
        {
            nb_case = Constantes.NB_CASE_NORMALE;
            nb_tour = Constantes.NB_TOUR_NORMALE;
            nb_unite = Constantes.NB_UNITE_NORMALE;

            FabriquePeuple = new FabriquePeuple();
            Carte = new Carte();
            Partie = new Partie();
            Strategie = new StrategieNormale();
        }
    }
}