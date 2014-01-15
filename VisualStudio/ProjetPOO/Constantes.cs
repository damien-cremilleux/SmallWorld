/**
 * @file Constantes.cs
 * @brief Constantes pour le jeu SmallWorld
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

namespace SmallWorld
{
    /**
     * @class Constantes
     * @brief Les différentes constantes du jeu SmallWorld
     */
    public class Constantes
    {
        //Cases
        public const int CASE_DESERT = 0;
        public const int CASE_EAU = 1;
        public const int CASE_FORET = 2;
        public const int CASE_MONTAGNE = 3;
        public const int CASE_PLAINE = 4;

        //Peuple
        public const string PEUPLE_GAULOIS = "Gaulois";
        public const string PEUPLE_NAIN = "Nains";
        public const string PEUPLE_VIKING = "Vikings";

        //Carte
        public const string CARTE_DEMO = "Démo";
        public const string CARTE_PETITE = "Petite";
        public const string CARTE_NORMALE = "Normale";

        //Nombre d'unité
        public const int NB_UNITE_DEMO = 4;
        public const int NB_UNITE_PETITE = 6;
        public const int NB_UNITE_NORMALE= 8;

        //Nombre de tour
        public const int NB_TOUR_DEMO = 5;
        public const int NB_TOUR_PETITE = 20;
        public const int NB_TOUR_NORMALE = 30;

        //Nombre de case
        public const int NB_CASE_DEMO = 5;
        public const int NB_CASE_PETITE = 10;
        public const int NB_CASE_NORMALE = 15;

        //Point d'une case
        public const int POINT_CASE = 1;

        //Caractéristiques unités
        public const int UNITE_POINT_DEPL = 2;
        public const int UNITE_POINT_ATT = 2;
        public const int UNITE_POINT_DEF = 1;
        public const int UNITE_POINT_VIE = 5;

    }
}
