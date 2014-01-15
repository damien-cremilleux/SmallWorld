/**
 * @file FabriqueCase.cs
 * @brief Fabrique pour les cases
 * 
 * Singleton pour fabriquer des cases, et utilisé dans le poids mouche
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
     * @interface InterFabriqueCase
     * @brief interface pour la fabrique de case
     */
    public interface InterFabriqueCase
    {
        /**
        * @fn obtenirDesert()
        * @brief Obtenir une case de type Desert
        * 
        * @return Case une case Desert
        */
        Case obtenirDesert();

        /**
         * @fn obtenirEau()
         * @brief Obtenir une case de type Eau
         * 
         * @return Case une case Eau
         */
        Case obtenirEau();

        /**
         * @fn obtenirForet()
         * @brief Obtenir une case de type Foret
         * 
         * @return Case une case Foret
          */
        Case obtenirForet();

        /**
         * @fn obtenirMontagne()
         * @brief Obtenir une case de type Montagne
         * 
         * @return Case une case Montagne
         */
        Case obtenirMontagne();

        /**
         * @fn obtenirPlaine()
         * @brief Obtenir une case de type Plaine
         * 
         * @return Case une case Plaine
         */
        Case obtenirPlaine();
    }

    /**
     * @class FabriqueCase
     * @brief classe FabriqueCase pour la génération de cases
     */
    [Serializable]
    public class FabriqueCase : InterFabriqueCase
    {
        /**
         * @brief Attribut <b>instance_FabCase</b> unique instance de la FabriqueCase
         */
        private static FabriqueCase instance_FabCase;

        /**
         * @brief Attribut <b>desert</b> unique case Desert
         */
        private Desert desert;

        /**
         * @brief Attribut <b>eau</b> unique case Eau
         */
        private Eau eau;

        /**
         * @brief Attribut <b>foret</b> unique case Foret
         */
        private Foret foret;

        /**
         * @brief Attribut <b>montagne</b> unique case Montagne
         */
        private Montagne montagne;

        /**
         * @brief Attribut <b>plaine</b> unique case Plaine
         */
        private Plaine plaine;

        /**
         * @fn Instance_FabCase
         * @brief Properties pour l'attribut instance_FabCase
         */
        public static FabriqueCase Instance_FabCase
        {
            get
            {
                if (instance_FabCase == null)  //Cette classe est un singleton
                {
                    instance_FabCase = new FabriqueCase();
                }
                return instance_FabCase;
            }
        }

        /***
         * @FabriqueCase()
         * @brief Constructeur d'une FabriqueCase
         * 
         * @return une nouvelle FabriqueCase
         */
        private FabriqueCase()
        {
            desert = new Desert();
            eau = new Eau();
            foret = new Foret();
            montagne = new Montagne();
            plaine = new Plaine();
        }

        /**
         * @fn obtenirDesert()
         * @brief Obtenir une case de type Desert
         * 
         * @return Case une case Desert
         */
        public Case obtenirDesert()
        {
            return desert;
        }

        /**
         * @fn obtenirEau()
         * @brief Obtenir une case de type Eau
         * 
         * @return Case une case Eau
         */
        public Case obtenirEau()
        {
            return eau;
        }

        /**
         * @fn obtenirForet()
         * @brief Obtenir une case de type Foret
         * 
         * @return Case une case Foret
         */
        public Case obtenirForet()
        {
            return foret;
        }

        /**
         * @fn obtenirMontagne()
         * @brief Obtenir une case de type Montagne
         * 
         * @return Case une case Montagne
         */
        public Case obtenirMontagne()
        {
            return montagne;
        }

        /**
         * @fn obtenirPlaine()
         * @brief Obtenir une case de type Plaine
         * 
         * @return Case une case Plaine
         */
        public Case obtenirPlaine()
        {
            return plaine;
        }
    }
}
