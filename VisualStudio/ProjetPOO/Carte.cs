﻿/**
 * @file Carte.cs
 * @brief Interface et classe de la Carte
 * 
 * Une Carte représente le plateau de jeu et se compose d'un ensemble de Case, de type différent
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
     * @interface InterCarte
     * @brief Interface pour Carte
     */
    public interface InterCarte
    {
        void creerCarte();

        void definirStrategie(StrategieCarte strat);
    }

    /**
     * @brief Classe Carte
     * Représente la carte du monde
     */
    public class Carte : InterCarte
    {
        /**
         * @brief Attribut <b>listeCases</b> stockant l'ensemble des cases
         */
        private List<List<Case>> listeCases;

        /**
         * @brief Attribut <b>strategieCarte</b> strategie à adopter pour la création de la Carte
         */
        private StrategieCarte strategieCarte;

        /**
        * @brief Attribut <b>fabriqueCase</b> la fabrique pour générer les nouvelles cases
        */
        private FabriqueCase fabriqueCase;

        /**
         * @fn StrategieCarte
         * @brief Properties pour l'attribut strategieCarte
         */
        public StrategieCarte StrategieCarte
        {
            get
            {
                return strategieCarte;
            }
            set
            {
                strategieCarte = value;
            }
        }

        /**
         * @fn ListeCases
         * @brief Properties pour l'attribut listeCases
         */
        public List<List<Case>> ListeCases
        {
            get
            {
                return listeCases;
            }
            set
            {
            }
        }

        /**
         * @fn FabriqueCase
         * @brief Properties pour l'attribut fabriqueCase
         */
        public FabriqueCase FabriqueCase
        {
            get
            {
                return fabriqueCase;
            }
            set
            {
                fabriqueCase = value;
            }
        }


        /**
         * @fn Carte(List<List<Case>> listeC)
         * @brief Constructeur d'une nouvelle Carte
         * 
         * Construit une nouvelle Carte à l'aide d'une liste de Cases
         * 
         * @param List<List<Case>> <b>listeC</b> La liste des cases formant la carte
         * @return La nouvelle Carte
         */
        public Carte(List<List<Case>> listeC)
        {
            fabriqueCase = FabriqueCase.Instance_FabCase;
            listeCases = listeC;
        }
        
        /**
         * @fn creerCarte
         * @brief Génération d'une nouvelle Carte
         * 
         * génère une nouvelle Carte, suivant la stratégie demandée
         * 
         * @return void
         */
        public void creerCarte()
        {
            strategieCarte.construire();
        }

        /**
         * @fn definirStrategie(StrategieCarte strat)
         * @brief Définit la stratégie à adopter pour la génération d'une nouvelle carte
         * 
         * @param StrategieCarte <b>strat</b> La nouvelle stratégie à adopter
         * @return void
         */
        public void definirStrategie(StrategieCarte strat)
        {
            strategieCarte = strat;
        }
    }


}
