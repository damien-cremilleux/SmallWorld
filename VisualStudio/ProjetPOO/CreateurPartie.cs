/**
 * @file CreateurPartie.cs
 * @brief Interface et classe du créateur de partie
 * 
 * Directeur du patron de conception Monteur, contient le processus de création
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 25/12/2013
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
         * @fn construire
         * @brief Construire la partie
         */
        void construire();
    }


    /**
     * @class CreateurPartie
     * @brief Classe du créateur de partie
     */
    public class CreateurPartie : InterCreateurPartie
    {

        /**
         * @fn CreateurPartie
         * @brief Constructeur du créateur de partie
         * 
         * @return CreateurPartie 
         */
        public CreateurPartie()
        {
            throw new System.NotImplementedException();
        }

        /**
         * @brief Attribut permettant de monter une partie
         */
         public MonteurPartie MonteurPartie
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        /**
         * @brief Construction d'une nouvelle partie
         */
        public void construire()
        {
            throw new NotImplementedException();
        }

        public void ajouterJoueur(string nom, string peuple)
        {
            throw new System.NotImplementedException();
        }

        public void ajouterCarte()
        {
            throw new System.NotImplementedException();
        }
    }
}
