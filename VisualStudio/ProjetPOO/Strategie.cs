/**
 * @file Strategie.cs
 * @brief Interface et classe pour le patron de coneption stratégie
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
using System.Threading.Tasks;

using Wrapper;

namespace SmallWorld
{
    /**
     * @interface InterStrategieCarte
     * @brief interface globale pour la stratégie
     */
    public interface InterStrategieCarte
    {
        /**
         * @fn construire()
         * @brief Construit une nouvelle Carte
         */
        List<List<Case>> construire();
    }

    /**
     * @class StrategieCarte
     * @brief classe abstraite pour la stratégie
     */
    public unsafe abstract class StrategieCarte : InterStrategieCarte
    {

        /**
         * @brief Attribut <b>TAILLE</b> indiquant la taille de la carte
         */
        private int taille;

        /**
         * @fn Taille
         * @brief Properties pour l'attribut taille
         */
        public abstract int Taille
        {
            get;
        }

        /**
         * @fn construire()
         * @brief Construit une nouvelle Carte
         */
        public unsafe List<List<Case>> construire()
        {
            int i, j, k;

            WrapperAlgo wrapperAlgo = new WrapperAlgo();
            int** carte;
            carte = wrapperAlgo.genererCarte(Taille);

            List<List<Case>> carteRes = new List<List<Case>>();

            for (i = 0; i < Taille; i++)
            {
                carteRes.Add(new List<Case>());

                for (j = 0; j < Taille; j++)
                {
                    k = carte[i][j];

                    switch (k)
                    {
                        case 0:
                            carteRes[i].Add(FabriqueCase.Instance_FabCase.obtenirDesert());
                            break;
                        case 1:
                            carteRes[i].Add(FabriqueCase.Instance_FabCase.obtenirEau());
                            break;
                        case 2:
                            carteRes[i].Add(FabriqueCase.Instance_FabCase.obtenirForet());
                            break;
                        case 3:
                            carteRes[i].Add(FabriqueCase.Instance_FabCase.obtenirMontagne());
                            break;
                        case 4:
                            carteRes[i].Add(FabriqueCase.Instance_FabCase.obtenirPlaine());
                            break;
                        default:
                            break;
                    }
                }
            }

            return carteRes;
        }
    }

    /**
     * @interface InterStrategieDemo
     * @brief interface pour une stratégie démo
     */
    public interface InterStrategieDemo : InterStrategieCarte
    {
        /**
         * @fn construire
         * @brief contruit une carte de taille démo
         * 
         * @return la carte demandée
         */
        new List<List<Case>> construire();
    }

    /**
     * @interface InterStrategiePetite
     * @brief interface pour une stratégie petite
     */
    public interface InterStrategiePetite : InterStrategieCarte
    {
        /**
         * @fn construire
         * @brief contruit une carte de taille petite
         * 
         * @return la carte demandée
         */
        new List<List<Case>> construire();
    }

    /**
     * @interface InterStrategieNormale
     * @brief interface pour une stratégie normale
     */
    public interface InterStrategieNormale : InterStrategieCarte
    {
        /**
         * @fn construire
         * @brief contruit une carte de taille normale
         * 
         * @return la carte demandée
         */
        new List<List<Case>> construire();
    }

    /**
     * @class StrategieDemo
     * @brief classe pour une stratégie démo
     */
    public class StrategieDemo : StrategieCarte, InterStrategieDemo
    {

        /**
         * @brief Attribut <b>TAILLE</b> indiquant la taille de la carte
         */
        private int taille = 5;

        /**
         * @fn Taille
         * @brief Properties pour l'attribut taille
         */
        public override int Taille
        {
            get
            {
                return taille;
            }
        }

        /**
         * @fn StrategieDemo()
         * @brief Constructeur d'une stratégie de type démo
         * 
         * @return une nouvelle stratégie
         */
        public StrategieDemo()
        {
        }
    }

    /**
     * @class StrategiePetite
     * @brief classe pour une stratégie petite
     */
    public class StrategiePetite : StrategieCarte, InterStrategiePetite
    {

        /**
         * @brief Attribut <b>taille</b> indiquant la taille de la carte
         */
        private int taille = 10;

        /**
       * @fn Taille
       * @brief Properties pour l'attribut taille
       */
        public override int Taille
        {
            get
            {
                return taille;
            }
        }

        /**
         * @fn StrategiePetite()
         * @brief Constructeur d'une stratégie de type petite
         * 
         * @return une nouvelle stratégie
         */
        public StrategiePetite()
        {
        }
    }

    /**
     * @class StrategieNormale
     * @brief classe pour une stratégie normale
     */
    public class StrategieNormale : StrategieCarte, InterStrategieNormale
    {

        /**
         * @brief Attribut <b>taille</b> indiquant la taille de la carte
         */
        private int taille = 15;

        /**
       * @fn Taille
       * @brief Properties pour l'attribut taille
       */
        public override int Taille
        {
            get
            {
                return taille;
            }
        }
        /**
         * @fn StrategieNormale()
         * @brief Constructeur d'une stratégie de type normale
         * 
         * @return une nouvelle stratégie
         */
        public StrategieNormale()
        {
        }

        /**
         * @fn construire
         * @brief contruit une carte de taille normale
         * 
         * @return la carte demandée
         */
        /*   public override List<List<Case>> construire()
           {
               throw new NotImplementedException();
           }*/
    }

}
