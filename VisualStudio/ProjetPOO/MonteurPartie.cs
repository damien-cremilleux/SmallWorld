/**
 * @file MonteurPartie.cs
 * @brief Interfaces et classes du monteur de partie
 * 
 * Monteur du patron de conception monteur, contient les interfaces et les
 * différentes implémentations pour le processus de création d'une partie
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</@>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</@>
 * 
 * @date 18/11/2013
 * @version 0.1
 */

using System;
namespace SmallWorld
{
    /**
     * @brief Interface globale du monteur
     */
    interface InterMonteurPartie
    {
        /**
         * @brief Ajout de la carte pour la construction d'une partie.
         * 
         * @param string <b>tailleCarte</b> La taille de la carte à créer.
         */
        void ajouterCarte(string tailleCarte);

        /**
         * @brief Ajout d'un joueur à la partie.
         * 
         * @param string <b>nomJoueur</b> Le nom du joueur à ajouter.
         * @param string <b>peuple</b> Le peuple joué par le joueur.
         */
        void ajouterJoueur(string nomJoueur, string peuple);

        /**
         * @brief Création la partie.
         */
        Partie creerPartie();

        /**
         * @brief Placement des unités avant le début de la partie.
         */
        void placerUnites();
    }

    /**
     * @brief Interface du monteur de partie démo
     */
    public interface InterMonteurPartieDemo : InterMonteurPartie
    {
    }

    /**
    * @brief Interface du monteur de partie petite
    */
    public interface InterMonteurPartiePetite : InterMonteurPartie
    {
    }


    /**
    * @brief Interface du monteur de partie normale
    */
    public interface InterMonteurPartieNormale : InterMonteurPartie
    {
    }


    /**
    * @brief Classe abstraite implémentant InterMonteur Partie
    */
    public abstract class MonteurPartie : InterMonteurPartie
    {
        /**
         * @brief Ajout de la carte pour la construction d'une partie.
         * 
         * @param string <b>tailleCarte</b> La taille de la carte à créer.
         */
        public void ajouterCarte()
        {
            throw new NotImplementedException();
        }

        public void ajouterJoueur()
        {
            throw new NotImplementedException();
        }

        public SmallWorld.Partie creerPartie()
        {
            throw new NotImplementedException();
        }

        public void placerUnites()
        {
            throw new NotImplementedException();
        }
    }


    public class MonteurPartieDemo : SmallWorld.MonteurPartie, SmallWorld.InterMonteurPartieDemo
    {
        public void ajouterPeuple()
        {
            throw new NotImplementedException();
        }

        public SmallWorld.Partie creerPartie()
        {
            throw new NotImplementedException();
        }

        public void ajouterCarte()
        {
            throw new NotImplementedException();
        }

        public void ajouterJoueur()
        {
            throw new NotImplementedException();
        }

        public void placerUnites()
        {
            throw new NotImplementedException();
        }
    }

    public class MonteurPartieNormale : SmallWorld.MonteurPartie, SmallWorld.InterMonteurPartieNormale
    {
        public void ajouterPeuple()
        {
            throw new NotImplementedException();
        }

        public SmallWorld.Partie creerPartie()
        {
            throw new NotImplementedException();
        }

        public void ajouterCarte()
        {
            throw new NotImplementedException();
        }

        public void ajouterJoueur()
        {
            throw new NotImplementedException();
        }

        public void placerUnites()
        {
            throw new NotImplementedException();
        }
    }


    public class MonteurPartiePetite : SmallWorld.MonteurPartie, SmallWorld.InterMonteurPartiePetite
    {
        public void ajouterPeuple()
        {
            throw new NotImplementedException();
        }

        public SmallWorld.Partie creerPartie()
        {
            throw new NotImplementedException();
        }

        public void ajouterCarte()
        {
            throw new NotImplementedException();
        }

        public void ajouterJoueur()
        {
            throw new NotImplementedException();
        }

        public void placerUnites()
        {
            throw new NotImplementedException();
        }
    }
}
