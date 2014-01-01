/**
 * @file FabriquePeuple.cs
 * @brief Interfaces et classes pour la fabrique des peuoles
 * 
 * Fabrique des différents peuples : gaulois, nain, viking
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 01/01/2014
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    /**
     * @interface InterFabriquePeuple
     * @brief Interface pour la fabrique de peuple
     */
    public interface InterFabriquePeuple
    {
        void fabriquerPeuple();
    }

    /**
     * @interface FabriqueUniteGaulois
     */
    public interface Fabrique_Unite_Gaulois : InterFabriquePeuple
    {
    }

    public class FabriquePeuple : InterFabriquePeuple
    {
        public FabriquePeuple()
        {
           // throw new System.NotImplementedException();
        }

      /*  public Peuple Peuple
        {
            get
            {
              //  throw new System.NotImplementedException();
            }
            set
            {
            }
        */

        public void fabriquerPeuple()
        {
            //throw new NotImplementedException();
        }
    }
}
