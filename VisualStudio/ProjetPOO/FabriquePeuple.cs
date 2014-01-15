/**
 * @file FabriquePeuple.cs
 * @brief Interfaces et classes pour la fabrique des peuples
 * 
 * Fabrique des différents peuples : gaulois, nain, viking.
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 15/01/2014
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
        /**
         * @fn fabriquerPeuple(string peuple)
         * @brief Récupération d'un peuple
         * 
         * @param string <b>peuple</b> le peuple demandé
         * @return Peuple Le peuple
         */
        Peuple fabriquerPeuple(string peuple);
    }

    /**
     * @class FabriquePeuple
     * @brief classe pour la fabrique d'un peuple
     * 
     * FabriquePeuple est un singleton
     */
    [Serializable]
    public class FabriquePeuple : InterFabriquePeuple
    {
        /**
         * @brief Attribut <b>instance_FabPeuple</b> Singleton de la classe
         */
        private static FabriquePeuple instance_FabPeuple;

        /**
         * @fn Instance_FabPeuple
         * @brief Properties pour l'attribut instance_FabPeuple
         */
        public static FabriquePeuple Instance_FabPeuple
        {
            get
            {
                if (instance_FabPeuple == null) //C'est un singleton
                {
                    instance_FabPeuple = new FabriquePeuple();
                }
                return instance_FabPeuple;
            }
        }

        /**
         * @fn FabriquePeuple
         * @brief Constructeur d'une fabrique de peuple
         */
        public FabriquePeuple()
        {
        }

       /**
        * @fn fabriquerPeuple(string peuple)
        * @brief Récupération d'un peuple
        * 
        * @param string <b>peuple</b> le peuple demandé
        * @return Peuple Le peuple
        */
        public Peuple fabriquerPeuple(string peuple)
        {
            switch (peuple)
            {
                case Constantes.PEUPLE_GAULOIS:
                    return new PeupleGaulois();

                case Constantes.PEUPLE_NAIN:
                    return new PeupleNain();

                case Constantes.PEUPLE_VIKING:
                    return new PeupleViking();

                default:
                    return null;
            }
        }
    }
}
