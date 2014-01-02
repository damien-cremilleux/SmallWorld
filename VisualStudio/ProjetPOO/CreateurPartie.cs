/**
 * @file CreateurPartie.cs
 * @brief Interface et classe du créateur de partie
 * 
 * Directeur du patron de conception Monteur, contient le processus de création
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 20/12/2013
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
   /**
    * @interface InterCreateurPartie
    * @brief Interface du créateur de partie
    */
    public interface InterCreateurPartie
    {
        /**
         * @fn construire()
         * @brief Construire la partie
         */
        Partie construire();

        /**
         * @fn ajoutJoueur(string nom, string peuple)
         * @brief Ajouter un joueur à la partie
         * 
         * @param string <b>nom</b> le nom du joueur
         * @param string <b>peuple</b> le type de peuple
         * @return void
         */
        void ajoutJoueur(string nom, string peuple);

    }

    /**
     * @class CreateurPartie
     * @brief Classe du créateur de partie
     */
    public class CreateurPartie : InterCreateurPartie
    {
        /**
         * @brief Attribut <b>monteurPartie</b> permettant de monter une partie
         */
        private MonteurPartie monteurPartie;

        /**
         * @brief Attribut <b>typePartie</b> le type de partie (démo, petit ou normale)
         */
        private string typePartie;

        /**
         * @brief Attribut <b>listeJoueur</b> la liste caractérisant les joueurs
         */
        private List<string> listeJoueur;

        /**
         * @fn MonteurPartie
         * @brief Properties pour l'attribut MonteurPartie
         */
        public MonteurPartie MonteurPartie
        {
            get
            {
                return monteurPartie;
            }
            set
            {
                monteurPartie = value;
            }
        }

        /**
         * @fn TypePartie
         * @brief Properties pour l'attribut typePartie
         */
        public string TypePartie
        {
            get
            {
                return typePartie;
            }
            set //le monteur partie est automatiquement mis à jour
            {
                if (value == "Démo")
                {
                    typePartie = value;
                    MonteurPartie = new MonteurPartieDemo();
                }

                if (value == "Petite")
                {
                    typePartie = value;
                    MonteurPartie = new MonteurPartiePetite();
                }

                if (value == "Normale")
                {
                    typePartie = value;
                    MonteurPartie = new MonteurPartieNormale();
                }
            }
        }

        //TODO properties pour les listes
        
        /**
         * @fn CreateurPartie()
         * @brief Constructeur du créateur de partie
         * 
         * @return CreateurPartie 
         */
        public CreateurPartie()
        {
            listeJoueur = new List<string>();
        }

        /**
         * @fn ajoutJoueur(string nom, string peuple)
         * @brief Ajouter un joueur à la partie
         * 
         * @param string <b>nom</b> le nom du joueur
         * @param string <b>peuple</b> le type de peuple
         * @return void
         */
        public void ajoutJoueur(string nom, string peuple)
        {
            listeJoueur.Add(nom);
            listeJoueur.Add(peuple);
        }
    
        /**
         * @fn construire()
         * @brief Construction d'une nouvelle partie
         * 
         * @return void
         */
        public Partie construire()
        {
            return MonteurPartie.creerPartie(listeJoueur[0], listeJoueur[1], listeJoueur[2], listeJoueur[3]);
        }

    }
}
