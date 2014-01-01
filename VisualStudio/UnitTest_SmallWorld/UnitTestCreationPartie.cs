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
 * @date 01/01/2014
 * @version 0.1
 */
namespace UnitTest_SmallWorld
{
    [TestClass]
    public class UnitTestCreationPartie
    {
        /**
         * @fn TestCreationCarte()
         * @brief Tests unitaire vérifiant la bonne création de la map
         */
        [TestMethod]
        public void TestCreationCarte()
        {
            CreateurPartie c = new CreateurPartie();
            c.TypePartie = "normale";
            c.ajoutJoueur("Damien", "viking");
            c.ajoutJoueur("Lauriane", "gaulois");

            Partie p;

            p = c.construire();

            Assert.AreEqual("Damien", p.ListeJoueurs[0].NomJ);
            Assert.AreEqual("Lauriane", p.ListeJoueurs[1].NomJ);

            Assert.AreEqual(15, p.CartePartie.TailleCarte);
        }
    }
}
