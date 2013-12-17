/**
 * @file Partie.cs
 * @brief Interface et classe d'une partie
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 16/12/2013
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    /**
     * @interface InterPartie
     * @brief interface pour les partie
     */
    public interface InterPartie
    {
    }

    /**
     * @class Partie
     * @brief classe pour les parties
     */
    public class Partie : InterPartie
    {

        /**
         * @brief Attribut <b>indiceJoueurEnCours</b> indice du joueur dont c'est le tour
         */
        private int indiceJoueurEnCours;

        /**
         * @brief Attribut <b>joueurEnCours</b> joueur dont c'est le tour
         */
        private Joueur joueurEnCours;

        /**
         * @brief Attribut <b>listeJoueurs</b> liste des joueurs de la partie
         */
        private List<Joueur> listeJoueurs;

        /**
         * @brief Attribut <b>nbTourRestant</b> nombre de tour restant
         */
        private int nbTourRestant;

        /**
         * @brief Attribut <b>cartePartie</b> carte de la partie
         */
        private Carte cartePartie;

        /**
         * @fn IndiceJoueurEnCours
         * @brief Properties pour l'attribut indiceJoueurEnCours
         */
        public int IndiceJoueurEnCours
        {
            get
            {
                return indiceJoueurEnCours;
            }
            set
            {
                indiceJoueurEnCours = value;
            }
        }

        /**
         * @fn JoueurEnCours
         * @brief Properties pour l'attribut joueurEnCours
         */
        public Joueur JoueurEnCours
        {
            get
            {
                return joueurEnCours;
            }
            set
            {
                joueurEnCours = value;
            }
        }


        /**
         * @fn ListeJoueurs
         * @brief Properties pour l'attribut listeJoueurs
         */
        public List<Joueur> ListeJoueurs
        {
            get
            {
                return listeJoueurs;
            }
            set
            {
                listeJoueurs = value;
            }
        }


        /**
         * @fn nbTourRestant
         * @brief Properties pour l'attribut nbTourRestant
         */
        public int NbTourRestant
        {
            get
            {
                return nbTourRestant;
            }
            set
            {
                nbTourRestant = value;
            }
        }

        /**
         * @fn CartePartie
         * @brief Properties pour l'attribut cartePartie
         */
        public Carte CartePartie
        {
            get
            {
                return cartePartie;
            }
            set
            {
                cartePartie = value;
            }
        }

        /**
         * @fn Partie()
         * @brief Constructeur d'une partie vide
         * 
         * Construit une partie sans joueur et avec une carte vide
         * 
         * @return une nouvelle partie
         */
        public Partie()
        {
            ListeJoueurs = new List<Joueur>();
            CartePartie = new Carte();
        }

        /**
         * @fn Partie(List<Joueur> listeJ, Carte carte)
         * @brief Constructeur d'une partie
         * 
         * @param List<Joueur> <b>listeJ</b> la liste des joueurs
         * @param Carte <b>Carte</b> la carte de la partie
         * @return une nouvelle partie
         */
        public Partie(List<Joueur> listeJ, Carte carte)
        {
            ListeJoueurs = listeJ;
            CartePartie = carte;
        }


        public void nouveauTour()
        {
            throw new System.NotImplementedException();
        }

        public void selectionnerUnite()
        {
            throw new System.NotImplementedException();
        }

        public void demanderDeplacement()
        {
            throw new System.NotImplementedException();
        }

        public void validerTour()
        {
            throw new System.NotImplementedException();
        }
    }
}
