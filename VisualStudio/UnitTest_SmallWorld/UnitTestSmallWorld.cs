/**
 * @file UnitTestSmallWorld.cs
 * @brief Tests unitaires pour SmallWorld
 *
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 05/01/2014
 * @version 0.1
 */
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld;
using System.Collections.Generic;
using Wrapper;

namespace UnitTest_SmallWorld
{
    [TestClass]
    public class UnitTestSmallWorld
    {
        /**
         * @fn TestNomJoueur()
         * @brief Tests unitaire vérifiant la bonne récupération du nom des joueurs
         */
        [TestMethod]
        public void TestNomJoueur()
        {
            CreateurPartie c = new CreateurPartie();
            c.TypePartie = Constantes.CARTE_DEMO;
            c.ajoutJoueur("Damien", Constantes.PEUPLE_GAULOIS);
            c.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);

            Partie p;

            p = c.construire();

            Assert.AreEqual("Damien", p.ListeJoueurs[0].NomJ);
            Assert.AreEqual("Lauriane", p.ListeJoueurs[1].NomJ);
        }

        /**
         * @fn TestPeupleJoueur()
         * @brief Tests unitaire vérifiant la bonne récupération des peuples
         */
        [TestMethod]
        public void TestPeupleJoueur()
        {
            CreateurPartie c = new CreateurPartie();
            c.TypePartie = Constantes.CARTE_PETITE;
            c.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p;
            p = c.construire();

            Assert.AreEqual(new PeupleViking().GetType(), p.ListeJoueurs[0].PeupleJ.GetType());
            Assert.AreEqual(new PeupleGaulois().GetType(), p.ListeJoueurs[1].PeupleJ.GetType());
        }

        /**
         * @fn TestTailleCarte()
         * @brief Vérification de la taille des cartes crées
         */
        [TestMethod]
        public void TestTailleCarte()
        {
            //Carte démo
            CreateurPartie c1 = new CreateurPartie();
            c1.TypePartie = Constantes.CARTE_DEMO;
            c1.ajoutJoueur("Damien", Constantes.PEUPLE_NAIN);
            c1.ajoutJoueur("Lauriane", Constantes.PEUPLE_NAIN);
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(Constantes.NB_CASE_DEMO, p1.CartePartie.TailleCarte);

            //Carte petite
            CreateurPartie c2 = new CreateurPartie();
            c2.TypePartie = Constantes.CARTE_PETITE;
            c2.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c2.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p2;
            p2 = c2.construire();

            Assert.AreEqual(Constantes.NB_CASE_PETITE, p2.CartePartie.TailleCarte);

            //Carte normale
            CreateurPartie c3 = new CreateurPartie();
            c3.TypePartie = Constantes.CARTE_NORMALE;
            c3.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c3.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p3;
            p3 = c3.construire();

            Assert.AreEqual(Constantes.NB_CASE_NORMALE, p3.CartePartie.TailleCarte);
        }

        /**
        * @fn TestNombreTour()
        * @brief Vérification du nombre de tour
        */
        [TestMethod]
        public void TestNombreTour()
        {
            //Carte démo
            CreateurPartie c1 = new CreateurPartie();
            c1.TypePartie = Constantes.CARTE_DEMO;
            c1.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c1.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(Constantes.NB_TOUR_DEMO, p1.NbTourRestant);

            //Carte petite
            CreateurPartie c2 = new CreateurPartie();
            c2.TypePartie = Constantes.CARTE_PETITE;
            c2.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c2.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p2;
            p2 = c2.construire();
            Assert.AreEqual(Constantes.NB_TOUR_PETITE, p2.NbTourRestant);

            //Carte normale
            CreateurPartie c3 = new CreateurPartie();
            c3.TypePartie = Constantes.CARTE_NORMALE;
            c3.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c3.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p3;
            p3 = c3.construire();

            Assert.AreEqual(Constantes.NB_TOUR_NORMALE, p3.NbTourRestant);
        }

        /**
         * @fn TestNombreUnite()
         * @brief Vérification du nombre d'unités
         */
        [TestMethod]
        public void TestNombreUnite()
        {
            //Carte démo
            CreateurPartie c1 = new CreateurPartie();
            c1.TypePartie = Constantes.CARTE_DEMO;
            c1.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c1.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(Constantes.NB_UNITE_DEMO, p1.ListeJoueurs[0].ListeUnite.Count);
            Assert.AreEqual(Constantes.NB_UNITE_DEMO, p1.ListeJoueurs[1].ListeUnite.Count);

            //Carte petite
            CreateurPartie c2 = new CreateurPartie();
            c2.TypePartie = Constantes.CARTE_PETITE;
            c2.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c2.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p2;
            p2 = c2.construire();

            Assert.AreEqual(Constantes.NB_UNITE_PETITE, p2.ListeJoueurs[0].ListeUnite.Count);
            Assert.AreEqual(Constantes.NB_UNITE_PETITE, p2.ListeJoueurs[1].ListeUnite.Count);

            //Carte normale
            CreateurPartie c3 = new CreateurPartie();
            c3.TypePartie = Constantes.CARTE_NORMALE;
            c3.ajoutJoueur("Damien", Constantes.PEUPLE_VIKING);
            c3.ajoutJoueur("Lauriane", Constantes.PEUPLE_GAULOIS);
            Partie p3;
            p3 = c3.construire();

            Assert.AreEqual(Constantes.NB_UNITE_NORMALE, p3.ListeJoueurs[0].ListeUnite.Count);
            Assert.AreEqual(Constantes.NB_UNITE_NORMALE, p3.ListeJoueurs[1].ListeUnite.Count);
        }

        /**
       * @fn TestPlacementUnite()
       * @brief Vérification du placement des unités
       */
        [TestMethod]
        public void TestPlacementUnite()
        {
            //Carte démo
            CreateurPartie c1 = new CreateurPartie();
            c1.TypePartie = Constantes.CARTE_DEMO;
            c1.ajoutJoueur("Damien", "viking");
            c1.ajoutJoueur("Lauriane", "gaulois");
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(0, p1.ListeJoueurs[0].ListeUnite[0].CaseUnite);

            Assert.AreEqual(0, p1.ListeJoueurs[0].ListeUnite[0].Position.Abscisse);
            Assert.AreEqual(0, p1.ListeJoueurs[0].ListeUnite[0].Position.Ordonnee);
            Assert.AreEqual(0, p1.ListeJoueurs[1].ListeUnite[0].Position.Abscisse);
            Assert.AreEqual(0, p1.ListeJoueurs[1].ListeUnite[0].Position.Ordonnee);
            Assert.AreEqual(0, p1.ListeJoueurs[1].ListeUnite.Count);

            //Carte petite
            CreateurPartie c2 = new CreateurPartie();
            c2.TypePartie = Constantes.CARTE_PETITE;
            c2.ajoutJoueur("Damien", "viking");
            c2.ajoutJoueur("Lauriane", "gaulois");
            Partie p2;
            p2 = c2.construire();

            Assert.AreEqual(Constantes.NB_UNITE_PETITE, p2.ListeJoueurs[0].ListeUnite.Count);
            Assert.AreEqual(Constantes.NB_UNITE_PETITE, p2.ListeJoueurs[1].ListeUnite.Count);

            //Carte normale
            CreateurPartie c3 = new CreateurPartie();
            c3.TypePartie = Constantes.CARTE_NORMALE;
            c3.ajoutJoueur("Damien", "viking");
            c3.ajoutJoueur("Lauriane", "gaulois");
            Partie p3;
            p3 = c3.construire();

            Assert.AreEqual(Constantes.NB_UNITE_NORMALE, p3.ListeJoueurs[0].ListeUnite.Count);
            Assert.AreEqual(Constantes.NB_UNITE_NORMALE, p3.ListeJoueurs[1].ListeUnite.Count);
        }
    }

    [TestClass]
    public class UnitTestCoordonnees
    {
        /**
         * @fn TestCoordonnees()
         * @brief Vérification du comportement des coordonnées
         */
        [TestMethod]
        public void TestCoordonnees()
        {
            Coordonnees c1 = new Coordonnees(1, 2);
            Coordonnees c2 = new Coordonnees(2, 1);
            Coordonnees c3 = new Coordonnees(1, 2);

            Assert.IsTrue(c1.Equals(c3));
            Assert.IsFalse(c3.Equals(c2));

            Assert.AreEqual(1, c1.Abscisse);
            Assert.AreEqual(2, c1.Ordonnee);
        }

    }
     
    [TestClass]
    public unsafe class UnitTestDeplacement
    {
        /**
         * @fn TestDeplacementBasique()
         * @brief Vérification du déplacement sur un cas simple
         */
        [TestMethod]
        public void TestDeplacementBasique()
        {
        /*    WrapperAlgo w = new WrapperAlgo();
            int nbCase = 5;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            //On fait une carte de plaine
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabCarte[i * nbCase + j] = Constantes.CASE_PLAINE;
                }
            }

            //On initialise une unité
            UniteViking uniteV = new UniteViking();
            Partie.ListeJoueurs[i].ListeUnite[j].Position = tabCoord[i];
            Partie.ListeJoueurs[i].ListeUnite[j].CaseUnite = Partie.CartePartie.ListeCases[x1][y1];
            Partie.ListeJoueurs[i].ListeUnite[j].TabCarte = tabCase;
            Partie.ListeJoueurs[i].ListeUnite[j].TailleCarteJeu = Nb_case;
            Partie.ListeJoueurs[i].ListeUnite[j].TabDeplacement = wrapperAlgo.creerTab(Nb_case);
            Partie.ListeJoueurs[i].ListeUnite[j].TabCout = wrapperAlgo.creerTabDouble(Nb_case);
            Partie.ListeJoueurs[i].ListeUnite[j].calculerDeplacement();
            */

        }
    }
}