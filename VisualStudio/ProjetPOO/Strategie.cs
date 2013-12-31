/**
 * @file Strategie.cs
 * @brief Interface et classe pour le patron de coneption stratégie
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 31/12/2013
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public abstract class StrategieCarte : InterStrategieCarte
    {

    /**
     * @fn construire()
     * @brief Construit une nouvelle Carte
     */
        public abstract List<List<Case>> construire();
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
    public class StrategieDemo : StrategieCarte, SmallWorld.InterStrategieDemo
    {
        /**
         * @fn StrategieDemo()
         * @brief Constructeur d'une stratégie de type démo
         * 
         * @return une nouvelle stratégie
         */
        public StrategieDemo()
        {      
        }

        /**
         * @fn construire
         * @brief contruit une carte de taille démo
         * 
         * @return la carte demandée
         */
        public override List<List<Case>> construire()
        {
            throw new NotImplementedException();
        }
    }

    /**
     * @class StrategiePetite
     * @brief classe pour une stratégie petite
     */
    public class StrategiePetite : StrategieCarte, SmallWorld.InterStrategiePetite
    {
        /**
         * @fn StrategiePetite()
         * @brief Constructeur d'une stratégie de type petite
         * 
         * @return une nouvelle stratégie
         */
        public StrategiePetite()
        {
        }

        /**
         * @fn construire
         * @brief contruit une carte de taille petite
         * 
         * @return la carte demandée
         */
        public override List<List<Case>> construire()
        {
            throw new NotImplementedException();
        }
    }

    /**
     * @class StrategieNormale
     * @brief classe pour une stratégie normale
     */
    public class StrategieNormale : StrategieCarte, SmallWorld.InterStrategieNormale
    {
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
        public override List<List<Case>> construire()
        {
            throw new NotImplementedException();
        }
    }

}
