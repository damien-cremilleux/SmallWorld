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
 * @date 03/01/2014
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
         * @brief constante <b>nb_tour</b> le nombre initial de tour
         */
        private int nb_tour;

        /**
         * @brief constante <b>nb_unite</b> le nombre initial d'unité par joueur
         */
        private int nb_unite;

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
        public abstract int Nb_tour
        {
            get;
        }

        /**
         * @fn Nb_unite
         * @brief Properties pour l'attribut nb_unite
         */
        public abstract int Nb_unite
        {
            get;
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
        public abstract void placerUnites();
    }

    /**
     * @class MonteurPartieDemo
     * @brief classe pour un monteur d'une partie démo
     */
    public class MonteurPartieDemo : MonteurPartie, InterMonteurPartieDemo
    {
        /**
         * @brief constante <b>nb_tour</b> le nombre initial de tour
         */
        private const int nb_tour = 5;

        /**
         * @brief constante <b>nb_unite</b> le nombre initial d'unité par joueur
         */
        private const int nb_unite = 4;

        /**
         * @fn Nb_tour
         * @brief Properties pour l'attribut nb_tour
         */
        public override int Nb_tour
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
        public override int Nb_unite
        {
            get
            {
                return nb_unite;
            }
        }

        /**
         * @fn MonteurPartieDemo
         * @brief Constructeur d'un MonteurPartieDemo
         */
        public MonteurPartieDemo()
        {
            FabriquePeuple = new FabriquePeuple(); //TODO singleton
            Carte = new Carte();
            Partie = new Partie();
            Strategie = new StrategieDemo();
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
         * @brief constante <b>nb_tour</b> le nombre initial de tour
         */
        private const int nb_tour = 20;

        /**
         * @brief constante <b>nb_unite</b> le nombre initial d'unité par joueur
         */
        private const int nb_unite = 6;

        /**
         * @fn Nb_tour
         * @brief Properties pour l'attribut nb_tour
         */
        public override int Nb_tour
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
        public override int Nb_unite
        {
            get
            {
                return nb_unite;
            }
        }

        /**
         * @fn MonteurPartiePetite
         * @brief Constructeur d'un MonteurPartiePetite
         */
        public MonteurPartiePetite()
        {
            FabriquePeuple = new FabriquePeuple(); //TODO singleton
            Carte = new Carte();
            Partie = new Partie();
            Strategie = new StrategiePetite();
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
         * @brief constante <b>nb_tour</b> le nombre initial de tour
         */
        private const int nb_tour = 30;

        /**
         * @brief constante <b>nb_unite</b> le nombre initial d'unité par joueur
         */
        private const int nb_unite = 8;

        /**
         * @fn Nb_tour
         * @brief Properties pour l'attribut nb_tour
         */
        public override int Nb_tour
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
        public override int Nb_unite
        {
            get
            {
                return nb_unite;
            }
        }

        /**
         * @fn MonteurPartieNormale
         * @brief Constructeur d'un MonteurPartieNormale
         */
        public MonteurPartieNormale()
        {
            FabriquePeuple = new FabriquePeuple();
            Carte = new Carte();
            Partie = new Partie();
            Strategie = new StrategieNormale();
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