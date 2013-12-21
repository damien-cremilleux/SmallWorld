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
 * @date 20/12/2013
 * @version 0.1
 */
using System;
using System.Collections.Generic;
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
         * @fn ajouterCarte()
         * @brief Ajout de la carte pour la construction d'une partie.
         * 
         * @return void
         */
        public abstract void ajouterCarte();

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
            Joueur j = new Joueur(nomJoueur, peuple);
            Partie.ListeJoueurs.Add(j);
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
            this.initialiserNombreTour();
            return Partie;
        }

        /**
         * @fn initialiserNombreTour
         * @brief initialise le nombre de tour d'un partie
         * 
         * @return void
         */
        public abstract void initialiserNombreTour();

        /**
         * @fn placerUnites()
         * @brief Place le nombre d'unité nécessaire au début de la partie
         * 
         * @return void
         */
        public abstract void placerUnites();
    }

    /**
     * @class MonteurPartieDemo
     * @brief classe pour un monteur d'une partie démo
     */
    public class MonteurPartieDemo : MonteurPartie, InterMonteurPartieDemo
    {
        /**
         * @brief constante <b>NB_CASE</b> le nombre de case en largeur et longueur de la carte
         */
        private const int NB_CASE = 5;

        /**
         * @brief constante <b>NB_TOUR</b> le nombre initial de tour
         */
        private const int NB_TOUR = 5;

        /**
         * @brief constante <b>NB_UNITE</b> le nombre initial d'unité par joueur
         */
        private const int NB_UNITE = 4;

        /**
         * @fn MonteurPartieDemo
         * @brief Constructeur d'un MonteurPartieDemo
         */
        public MonteurPartieDemo()
        {
            FabriquePeuple = new FabriquePeuple(); //TODO singleton
            Carte = new Carte();
            Partie = new Partie();
        }

        /**
         * @fn ajouterCarte()
         * @brief Ajout d'une carte de taille Démo
         * 
         * @return void
         */
        public override void ajouterCarte()
        {
            int i;
            int j;
            List<List<Case>> listeCases = new List<List<Case>>();
            // TODO passer par carte -> strategie.construire
            for (i = 0; i < NB_CASE; i++)
            {
                for (j = 0; j < NB_CASE; j++)
                {
                    listeCases[i][j] = new Desert();
                }
            }

            Partie.CartePartie.ListeCases = listeCases;

        }

        /**
         * @fn initialiserNombreTour
         * @brief initialise le nombre de tour d'un partie
         * 
         * @return void
         */
        public override void initialiserNombreTour()
        {
            Partie.NbTourRestant = NB_TOUR;
        }

        /**
         * @fn placerUnites()
         * @brief Place le nombre d'unité nécessaire au début de la partie
         * 
         * @return void
         */
        public override void placerUnites()
        {
            //TODO
        }
    }

    /**
    * @class MonteurPartiePetite
    * @brief classe pour un monteur d'une partie petite
    */
    public class MonteurPartiePetite : MonteurPartie, InterMonteurPartiePetite
    {
        /**
          * @brief constante <b>NB_CASE</b> le nombre de case en largeur et longueur de la carte
          */
        private const int NB_CASE = 10;

        /**
         * @brief constante <b>NB_TOUR</b> le nombre initial de tour
         */
        private const int NB_TOUR = 20;

        /**
         * @brief constante <b>NB_UNITE</b> le nombre initial d'unité par joueur
         */
        private const int NB_UNITE = 6;

        /**
         * @fn MonteurPartiePetite
         * @brief Constructeur d'un MonteurPartiePetite
         */
        public MonteurPartiePetite()
        {
            FabriquePeuple = new FabriquePeuple(); //TODO singleton
            Carte = new Carte();
            Partie = new Partie();
        }

        /**
         * @fn ajouterCarte()
         * @brief Ajout d'une carte de taille Démo
         * 
         * @return void
         */
        public override void ajouterCarte()
        {
            int i;
            int j;
            List<List<Case>> listeCases = new List<List<Case>>();
            // TODO passer par carte -> strategie.construire
            for (i = 0; i < NB_CASE; i++)
            {
                for (j = 0; j < NB_CASE; j++)
                {
                    listeCases[i][j] = new Desert();
                }
            }

            Partie.CartePartie.ListeCases = listeCases;

        }

        /**
         * @fn initialiserNombreTour
         * @brief initialise le nombre de tour d'un partie
         * 
         * @return void
         */
        public override void initialiserNombreTour()
        {
            Partie.NbTourRestant = NB_TOUR;
        }

        /**
         * @fn placerUnites()
         * @brief Place le nombre d'unité nécessaire au début de la partie
         * 
         * @return void
         */
        public override void placerUnites()
        {
            //TODO
        }
    }

    /**
    * @class MonteurPartieNormale
    * @brief classe pour un monteur d'une partie normale
    */
    public class MonteurPartieNormale : MonteurPartie, InterMonteurPartieNormale
    {
        /**
        * @brief constante <b>NB_CASE</b> le nombre de case en largeur et longueur de la carte
        */
        private const int NB_CASE = 15;

        /**
         * @brief constante <b>NB_TOUR</b> le nombre initial de tour
         */
        private const int NB_TOUR = 30;

        /**
         * @brief constante <b>NB_UNITE</b> le nombre initial d'unité par joueur
         */
        private const int NB_UNITE = 8;

        /**
         * @fn MonteurPartieNormale
         * @brief Constructeur d'un MonteurPartieNormale
         */
        public MonteurPartieNormale()
        {
            FabriquePeuple = new FabriquePeuple(); //TODO singleton
            Carte = new Carte();
            Partie = new Partie();
        }

        /**
          * @fn ajouterCarte()
          * @brief Ajout d'une carte de taille Démo
          * 
          * @return void
          */
        public override void ajouterCarte()
        {
            int i;
            int j;
            List<List<Case>> listeCases = new List<List<Case>>();
            // TODO passer par carte -> strategie.construire
            for (i = 0; i < NB_CASE; i++)
            {
                for (j = 0; j < NB_CASE; j++)
                {
                    listeCases[i][j] = new Desert();
                }
            }

            Partie.CartePartie.ListeCases = listeCases;

        }

        /**
         * @fn initialiserNombreTour
         * @brief initialise le nombre de tour d'un partie
         * 
         * @return void
         */
        public override void initialiserNombreTour()
        {
            Partie.NbTourRestant = NB_TOUR;
        }

        /**
         * @fn placerUnites()
         * @brief Place le nombre d'unité nécessaire au début de la partie
         * 
         * @return void
         */
        public override void placerUnites()
        {
            //TODO
        }

    }
}