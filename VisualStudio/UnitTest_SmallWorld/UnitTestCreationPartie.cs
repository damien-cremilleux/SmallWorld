using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld;
using System.Collections.Generic;

/**
 * @file UnitTestCreationPartie.cs
 * @brief Tests unitaires pour la création de partie
 *
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 03/01/2014
 * @version 0.1
 */
namespace UnitTest_SmallWorld
{
    [TestClass]
    public class UnitTestCreationPartie
    {
        /**
         * @fn TestNomJoueur()
         * @brief Tests unitaire vérifiant la bonne récupération du nom des joueurs
         */
        [TestMethod]
        public void TestNomJoueur()
        {
            CreateurPartie c = new CreateurPartie();
            c.TypePartie = "normale";
            c.ajoutJoueur("Damien", "viking");
            c.ajoutJoueur("Lauriane", "gaulois");

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
            /*     CreateurPartie c = new CreateurPartie();
                 c.TypePartie = "normale";
                 c.ajoutJoueur("Damien", "viking");
                 c.ajoutJoueur("Lauriane", "gaulois");

                 Partie p;

                 p = c.construire();

                 Assert.AreEqual("Damien", p.ListeJoueurs[0].NomJ);
                 Assert.AreEqual("Lauriane", p.ListeJoueurs[1].NomJ);*/
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
            c1.TypePartie = "demo";
            c1.ajoutJoueur("Damien", "viking");
            c1.ajoutJoueur("Lauriane", "gaulois");
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(5, p1.CartePartie.TailleCarte);

            //Carte petite
            CreateurPartie c2 = new CreateurPartie();
            c2.TypePartie = "petite";
            c2.ajoutJoueur("Damien", "viking");
            c2.ajoutJoueur("Lauriane", "gaulois");
            Partie p2;
            p2 = c2.construire();

            Assert.AreEqual(10, p2.CartePartie.TailleCarte);

            //Carte normale
            CreateurPartie c3 = new CreateurPartie();
            c3.TypePartie = "normale";
            c3.ajoutJoueur("Damien", "viking");
            c3.ajoutJoueur("Lauriane", "gaulois");
            Partie p3;
            p3 = c3.construire();

            Assert.AreEqual(15, p3.CartePartie.TailleCarte);
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
            c1.TypePartie = "demo";
            c1.ajoutJoueur("Damien", "viking");
            c1.ajoutJoueur("Lauriane", "gaulois");
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(5, p1.NbTourRestant);

            //Carte petite
            CreateurPartie c2 = new CreateurPartie();
            c2.TypePartie = "petite";
            c2.ajoutJoueur("Damien", "viking");
            c2.ajoutJoueur("Lauriane", "gaulois");
            Partie p2;
            p2 = c2.construire();
            Assert.AreEqual(20, p2.NbTourRestant);

            //Carte normale
            CreateurPartie c3 = new CreateurPartie();
            c3.TypePartie = "normale";
            c3.ajoutJoueur("Damien", "viking");
            c3.ajoutJoueur("Lauriane", "gaulois");
            Partie p3;
            p3 = c3.construire();

            Assert.AreEqual(30, p3.NbTourRestant);

        }

    }
}
