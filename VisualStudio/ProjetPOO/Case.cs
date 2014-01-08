/**
 * @file Case.cs
 * @brief Interfaces et classes pour les cases
 * 
 * Les Cases sont les composants de la carte.
 * Il en existe cinq types : désert, eau, forêt, montagne, plaine.
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 15/12/2013
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    /**
    * @interface InterCase
    * @brief Interface pour Case
    */
    public interface InterCase
    {
    }

    /**
     * @interface InterDesert
     * @brief Interface pour Case de type désert
     */
    public interface InterDesert : InterCase
    {
    }

    /**
     * @interface InterEau
     * @brief Interface pour Case de type eau
     */
    public interface InterEau : InterCase
    {
    }

    /**
     * @interface InterForet
     * @brief Interface pour Case de type forêt
     */
    public interface InterForet : InterCase
    {
    }

    /**
     * @interface InterMontagne
     * @brief Interface pour Case de type montagne
     */
    public interface InterMontagne : InterCase
    {
    }

    /**
     * @interface InterPlaine
     * @brief Interface pour Case de type plaine
     */
    public interface InterPlaine : InterCase
    {
    }

    /**
     * @class Case
     * @brief classe abstraite Case
     */
    [Serializable]
    public abstract class Case : InterCase
    {
        //TODO à supprimer après test
        public static int obtenirInt()
        {
            throw new NotImplementedException();
        }
    }

    /**
     * @class Desert
     * @brief class pour Case de type desert
     */
    [Serializable]
    public class Desert : Case, InterDesert
    {
        public Desert()
        {

        }
    }

    /**
     * @class Eau
     * @brief class pour Case de type eau
     */
    [Serializable]
    public class Eau : Case, InterEau
    {
        public Eau()
        {

        }
    }

    /**
     * @class Foret
     * @brief class pour Case de type foret
     */
    [Serializable]
    public class Foret : Case, InterForet
    {
        public Foret()
        {

        }
    }

    /**
     * @class Montagne
     * @brief class pour Case de type montagne
     */
    [Serializable]
    public class Montagne : Case, InterMontagne
    {
        public Montagne()
        {

        }
    }

    /**
     * @class Plaine
     * @brief class pour Case de type plaine
     */
    [Serializable]
    public class Plaine : Case, InterPlaine
    {
        public Plaine()
        {

        }
    }
}
