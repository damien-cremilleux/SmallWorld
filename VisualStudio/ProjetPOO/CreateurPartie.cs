/**
 * @file CreateurPartie.cs
 * @brief Interface et classe du créateur de partie
 * 
 * Directeur du patron de conception Monteur, contient le processus de création
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</@>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</@>
 * 
 * @date 18/11/2013
 * @version 0.1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
   /**
    * @brief Interface du créateur de partie
    */ 
    public interface InterCreateurPartie
    {
        void construire();
    }


    /**
     * @brief Class du créateur de partie
     */
    public class CreateurPartie : InterCreateurPartie
    {
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
