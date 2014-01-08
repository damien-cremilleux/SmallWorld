/**
 * @file Joueur.cs
 * @brief Interface et classe pour les joueurs
 * 
 * Participants au jeu SmallWorld
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 04/01/2014
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    /**
     * @interface InterJoueur
     * @brief interface pour un joueur
     */
    public interface InterJoueur
    {
    }

    /**
     * @class Joueur
     * @brief classe pour un joueur
     */
    [Serializable]
    public class Joueur : InterJoueur
    {

        /**
         * @brief Attribut <b>peupleJ</b>, le peuple choisit par le joueur
         */
        private Peuple peupleJ;

        /**
         * @brief Attribut <b>pointVictoire</b>, le nombre de point de victoire du joueur
         */
        private int pointVictoire;

        /**
         * @brief Attribut <b>nomJ</b>, le nom du joueur
         */
        private string nomJ;

        /**
         * @brief Attribut <b>listeUnite</b>, la liste des unités du joueur
         */
        private List<Unite> listeUnite;

        /**
         * @fn PeupleJ
         * @brief Properties pour l'attribut peupleJ
         */
        public Peuple PeupleJ
        {
            get
            {
                return peupleJ;
            }
            set
            {
                peupleJ = value;
            }
        }

        /**
         * @fn PointVictoire
         * @brief Properties pour l'attribut pointVictoire
         */
        public int PointVictoire
        {
            get
            {
                return pointVictoire;
            }
            set
            {
                pointVictoire = value;
            }
        }

        /**
        * @fn NomJ
        * @brief Properties pour l'attribut nomJ
        */
        public string NomJ
        {
            get
            {
                return nomJ;
            }
            set
            {
                nomJ = value;
            }
        }

        /**
         * @fn ListeUnites
         * @brief Properties pour l'attribut listeUnites
         */
        public List<Unite> ListeUnite
        {
            get
            {
                return listeUnite;
            }
            set
            {
                listeUnite = value;
            }
        }

        /**
         * @fn Joueur(string nom, Peuple nomPeuple)
         * @brief Constructeur d'un joueur
         * 
         * Crée le joueur à partir de son nom et de son peuple
         * 
         * @param string <b>nom</b> le nom du joueur
         * @param Peuple <b>nomPeuple</b> le peuple sélectionné par le joueur
         */
        public Joueur(string nom, Peuple nomPeuple)
        {
            NomJ = nom;
            PeupleJ = nomPeuple;
            ListeUnite = new List<Unite>();
        }

        /**
        * @fn Joueur()
        * @brief Constructeur d'un joueur par défaut
        * @return Joueur un nouveau joueur
        */
        public Joueur()
        {
        }

        /**
         * @fn calculerPointVictoire()
         * @brief Met à jour les points de victoire du joueur
         * @return void
         */
        public void calculerPointVictoire()
        {
            int cptPt = 0;
            foreach (Unite unite in listeUnite)
            {
                cptPt += unite.PointDeVictoire;
            }
            PointVictoire = cptPt;
        }
    }
}
