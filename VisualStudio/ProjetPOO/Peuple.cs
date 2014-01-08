/**
 * @file Peuple.cs
 * @brief Interface et classe pour les peuples
 * 
 * Chaque joueur est d'un peuple particulier.
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 03/01/2014
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    /**
     * @interface InterPeuple
     * @brief interface globale pour les peuples
     */
    public interface InterPeuple
    {

        /**
         * @fn creerUnite()
         * @brief créer une unité
         * 
         * @return l'unité
         */
        Unite creerUnite();
    }

    /**
     * @class Peuple
     * @brief classe abstraite pour les peuples
     */
    [Serializable]
    public abstract class Peuple : InterPeuple
    {
        /**
         * @fn creerUnite()
         * @brief créer une unité
         * 
         * @return l'unité
         */
        public abstract Unite creerUnite();
    }

    /**
     * @interface InterPeupleGaulois
     * @brief interface pour le peuple gaulois
     */
    public interface InterPeupleGaulois : InterPeuple
    {
    }

    /**
     * @interface InterPeupleNain
     * @brief interface pour le peuple nain
     */
    public interface InterPeupleNain : InterPeuple
    {
    }

    /**
     * @interface InterPeupleViking
     * @brief interface pour le peuple viking
     */
    public interface InterPeupleViking : InterPeuple
    {
    }

    /**
     * @class PeupleGaulois
     * @brief classe pour le peuple Gaulois
     */
    [Serializable]
    public class PeupleGaulois : Peuple, InterPeupleGaulois
    {
        /**
         * @fn PeupleGaulois()
         * @brief Constructeur d'un peuple gaulois
         * 
         * @return PeupleGaulois un peuple gaulois
         */
        public PeupleGaulois()
        {
        }

        /**
         * @fn creerUnite()
         * @brief création d'une unité gauloise
         * 
         * @return Unite une nouvelle unité
         */
        public override Unite creerUnite()
        {
            return new UniteGauloise();
        }
    }

    /**
     * @class PeupleNain
     * @brief classe pour le peuple nain
     */
    [Serializable]
    public class PeupleNain : Peuple, InterPeupleNain
    {
        /**
         * @fn PeupleNain()
         * @brief Constructeur d'un peuple nain
         * 
         * @return PeupleNain un peuple nain
         */
        public PeupleNain()
        {
        }

        /**
         * @fn creerUnite()
         * @brief création d'une unité naine
         * 
         * @return Unite une nouvelle unité
         */
        public override Unite creerUnite()
        {
            return new UniteNaine();
        }
    }

    /**
     * @class PeupleViking
     * @brief classe pour le peuple viking
     */
    [Serializable]
    public class PeupleViking : Peuple, InterPeupleViking
    {
        /**
         * @fn PeupleViking()
         * @brief Constructeur d'un peuple viking
         * 
         * @return PeupleViking un peuple viking
         */
        public PeupleViking()
        {
        }

        /**
        * @fn creerUnite()
        * @brief création d'une unité viking
        * 
        * @return Unite une nouvelle unité
        */
        public override Unite creerUnite()
        {
            return new UniteViking();
        }
    }

}
