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
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallWorld;
using System.Collections.Generic;
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
            c.TypePartie = Constantes.CARTE_DEMO;
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
            CreateurPartie c = new CreateurPartie();
            c.TypePartie = Constantes.CARTE_PETITE;
            c.ajoutJoueur("Damien", "viking");
            c.ajoutJoueur("Lauriane", "gaulois");
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
            c1.ajoutJoueur("Damien", "viking");
            c1.ajoutJoueur("Lauriane", "gaulois");
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(Constantes.NB_CASE_DEMO, p1.CartePartie.TailleCarte);

            //Carte petite
            CreateurPartie c2 = new CreateurPartie();
            c2.TypePartie = Constantes.CARTE_PETITE;
            c2.ajoutJoueur("Damien", "viking");
            c2.ajoutJoueur("Lauriane", "gaulois");
            Partie p2;
            p2 = c2.construire();

            Assert.AreEqual(Constantes.NB_CASE_PETITE, p2.CartePartie.TailleCarte);

            //Carte normale
            CreateurPartie c3 = new CreateurPartie();
            c3.TypePartie = Constantes.CARTE_NORMALE;
            c3.ajoutJoueur("Damien", "viking");
            c3.ajoutJoueur("Lauriane", "gaulois");
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
            c1.ajoutJoueur("Damien", "viking");
            c1.ajoutJoueur("Lauriane", "gaulois");
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(Constantes.NB_TOUR_DEMO, p1.NbTourRestant);

            //Carte petite
            CreateurPartie c2 = new CreateurPartie();
            c2.TypePartie = Constantes.CARTE_PETITE;
            c2.ajoutJoueur("Damien", "viking");
            c2.ajoutJoueur("Lauriane", "gaulois");
            Partie p2;
            p2 = c2.construire();
            Assert.AreEqual(Constantes.NB_TOUR_PETITE, p2.NbTourRestant);

            //Carte normale
            CreateurPartie c3 = new CreateurPartie();
            c3.TypePartie = Constantes.CARTE_NORMALE;
            c3.ajoutJoueur("Damien", "viking");
            c3.ajoutJoueur("Lauriane", "gaulois");
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
            c1.ajoutJoueur("Damien", "viking");
            c1.ajoutJoueur("Lauriane", "gaulois");
            Partie p1;
            p1 = c1.construire();

            Assert.AreEqual(Constantes.NB_UNITE_DEMO, p1.ListeJoueurs[0].ListeUnite.Count);
            Assert.AreEqual(Constantes.NB_UNITE_DEMO, p1.ListeJoueurs[1].ListeUnite.Count);

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

        /**
       * @fn TestPlacementUnite()
       * @brief Vérification du placement des unités
       */
     /*   [TestMethod]
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
        }*/
    }
}
