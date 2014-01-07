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
        /*    [TestMethod]
            public void TestPlacementUnite()
            {
                //Carte démo
                CreateurPartie c1 = new CreateurPartie();
                c1.TypePartie = Constantes.CARTE_DEMO;
                c1.ajoutJoueur("Damien", Constantes.PEUPLE_GAULOIS);
                c1.ajoutJoueur("Lauriane", Constantes.PEUPLE_VIKING);
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
         * @fn TestDeplacementNainPlaine()
         * @brief Vérification du déplacement d'une unité naine sur de la plaine
         */
        [TestMethod]
        public void TestDeplacementNainPlaine()
        {
            WrapperAlgo w = new WrapperAlgo();
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
            UniteNaine uniteN = new UniteNaine();
            uniteN.Position = new Coordonnees(0, 0);
            uniteN.TabCarte = tabCarte;
            uniteN.TailleCarteJeu = nbCase;
            uniteN.TabDeplacement = w.creerTab(nbCase);
            uniteN.TabCout = w.creerTabDouble(nbCase);
            uniteN.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 0;
                }
            }
            tabRef[0 * nbCase + 0] = 2;
            tabRef[0 * nbCase + 1] = 2;
            tabRef[0 * nbCase + 2] = 0;
            tabRef[1 * nbCase + 0] = 2;
            tabRef[1 * nbCase + 1] = 0;
            tabRef[2 * nbCase + 0] = 0;

            //tabRef[0 * nbCase + 3] = 1;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteN.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteN.TabDeplacement[i * nbCase + j], res);
                }
            }


            Assert.AreEqual(1, uniteN.TabCout[0]);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        Assert.AreEqual(1, uniteN.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteN.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteN.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
         * @fn TestDeplacementNainForet()
         * @brief Vérification du déplacement d'une unité naine sur de la foret
         */
        [TestMethod]
        public void TestDeplacementNainForet()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 5;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            //On fait une carte de plaine
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabCarte[i * nbCase + j] = Constantes.CASE_FORET;
                }
            }

            //On initialise une unité
            UniteNaine uniteN = new UniteNaine();
            uniteN.Position = new Coordonnees(1, 1);
            uniteN.TabCarte = tabCarte;
            uniteN.TailleCarteJeu = nbCase;
            uniteN.TabDeplacement = w.creerTab(nbCase);
            uniteN.TabCout = w.creerTabDouble(nbCase);
            uniteN.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 0;
                }
            }
            tabRef[0 * nbCase + 0] = 0;
            tabRef[0 * nbCase + 1] = 3;
            tabRef[0 * nbCase + 2] = 0;
            tabRef[1 * nbCase + 0] = 3;
            tabRef[1 * nbCase + 1] = 3;
            tabRef[1 * nbCase + 2] = 3;
            tabRef[2 * nbCase + 1] = 3;

            //tabRef[0 * nbCase + 3] = 1;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteN.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteN.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        Assert.AreEqual(1, uniteN.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteN.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteN.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
        * @fn TestDeplacementNainMontagne()
        * @brief Vérification du déplacement d'une unité naine sur de la montagne
        */
        [TestMethod]
        public void TestDeplacementNainMontagne()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 5;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            //On fait une carte de plaine
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabCarte[i * nbCase + j] = Constantes.CASE_MONTAGNE;
                }
            }

            //On initialise une unité
            UniteNaine uniteN = new UniteNaine();
            uniteN.Position = new Coordonnees(3, 2);
            uniteN.TabCarte = tabCarte;
            uniteN.TailleCarteJeu = nbCase;
            uniteN.TabDeplacement = w.creerTab(nbCase);
            uniteN.TabCout = w.creerTabDouble(nbCase);
            uniteN.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 2;
                }
            }

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteN.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteN.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 3) && (j == 2))
                    {
                        Assert.AreEqual(1, uniteN.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteN.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteN.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
       * @fn TestDeplacementNainMixte()
       * @brief Vérification du déplacement d'une unité naine sur différents terrains
       */
        [TestMethod]
        public void TestDeplacementNainMixte()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 3;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            tabCarte[0] = Constantes.CASE_DESERT;
            tabCarte[1] = Constantes.CASE_FORET;
            tabCarte[2] = Constantes.CASE_PLAINE;
            tabCarte[3] = Constantes.CASE_PLAINE;
            tabCarte[4] = Constantes.CASE_PLAINE;
            tabCarte[5] = Constantes.CASE_FORET;
            tabCarte[6] = Constantes.CASE_EAU;
            tabCarte[7] = Constantes.CASE_DESERT;
            tabCarte[8] = Constantes.CASE_DESERT;

            //On initialise une unité
            UniteNaine uniteN = new UniteNaine();
            uniteN.Position = new Coordonnees(1, 1);        
            uniteN.TabCarte = tabCarte;
            uniteN.TailleCarteJeu = nbCase;
            uniteN.TabDeplacement = w.creerTab(nbCase);
            uniteN.TabCout = w.creerTabDouble(nbCase);
            uniteN.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            tabRef[0] = 0;
            tabRef[1] = 3;
            tabRef[2] = 0;
            tabRef[3] = 2;
            tabRef[4] = 2;
            tabRef[5] = 3;
            tabRef[6] = 0;
            tabRef[7] = 2;
            tabRef[8] = 0;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteN.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteN.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        Assert.AreEqual(1, uniteN.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteN.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteN.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
       * @fn TestDeplacementVikingPlaine()
       * @brief Vérification du déplacement d'une unité viking sur de la plaine
       */
        [TestMethod]
        public void TestDeplacementVikingPlaine()
        {
            WrapperAlgo w = new WrapperAlgo();
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
            uniteV.Position = new Coordonnees(0, 0);
            uniteV.TabCarte = tabCarte;
            uniteV.TailleCarteJeu = nbCase;
            uniteV.TabDeplacement = w.creerTab(nbCase);
            uniteV.TabCout = w.creerTabDouble(nbCase);
            uniteV.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 0;
                }
            }
            tabRef[0 * nbCase + 0] = 2;
            tabRef[0 * nbCase + 1] = 2;
            tabRef[0 * nbCase + 2] = 0;
            tabRef[1 * nbCase + 0] = 2;
            tabRef[1 * nbCase + 1] = 0;
            tabRef[2 * nbCase + 0] = 0;

            //tabRef[0 * nbCase + 3] = 1;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteV.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteV.TabDeplacement[i * nbCase + j], res);
                }
            }

            Assert.AreEqual(1, uniteV.TabCout[0]);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        Assert.AreEqual(1, uniteV.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteV.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteV.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
         * @fn TestDeplacementVikingForet()
         * @brief Vérification du déplacement d'une unité viking sur de la foret
         */
        [TestMethod]
        public void TestDeplacementVikingForet()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 5;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            //On fait une carte de plaine
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabCarte[i * nbCase + j] = Constantes.CASE_FORET;
                }
            }

            //On initialise une unité
            UniteViking uniteV = new UniteViking();
            uniteV.Position = new Coordonnees(1, 1);        
            uniteV.TabCarte = tabCarte;
            uniteV.TailleCarteJeu = nbCase;
            uniteV.TabDeplacement = w.creerTab(nbCase);
            uniteV.TabCout = w.creerTabDouble(nbCase);
            uniteV.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 0;
                }
            }
            tabRef[0 * nbCase + 0] = 0;
            tabRef[0 * nbCase + 1] = 2;
            tabRef[0 * nbCase + 2] = 0;
            tabRef[1 * nbCase + 0] = 2;
            tabRef[1 * nbCase + 1] = 2;
            tabRef[1 * nbCase + 2] = 2;
            tabRef[2 * nbCase + 1] = 2;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteV.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteV.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        Assert.AreEqual(1, uniteV.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteV.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteV.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
        * @fn TestDeplacementVikingEau()
        * @brief Vérification du déplacement d'une unité naine sur de l'eau
        */
        [TestMethod]
        public void TestDeplacementVikingEau()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 5;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            //On fait une carte de plaine
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabCarte[i * nbCase + j] = Constantes.CASE_EAU;
                }
            }

            //On initialise une unité
            UniteViking uniteV = new UniteViking();
            uniteV.Position = new Coordonnees(3, 2);
            uniteV.TabCarte = tabCarte;
            uniteV.TailleCarteJeu = nbCase;
            uniteV.TabDeplacement = w.creerTab(nbCase);
            uniteV.TabCout = w.creerTabDouble(nbCase);
            uniteV.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 0;
                }
            }
            tabRef[2 * nbCase + 2] = 2;
            tabRef[3 * nbCase + 1] = 2;
            tabRef[3 * nbCase + 2] = 2;
            tabRef[3 * nbCase + 3] = 2;
            tabRef[4 * nbCase + 2] = 2;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteV.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteV.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 3) && (j == 2))
                    {
                        Assert.AreEqual(1, uniteV.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteV.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteV.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
       * @fn TestDeplacementVikingMixte()
       * @brief Vérification du déplacement d'une unité viking sur différents terrains
       */
        [TestMethod]
        public void TestDeplacementVikingMixte()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 3;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            tabCarte[0] = Constantes.CASE_DESERT;
            tabCarte[1] = Constantes.CASE_EAU;
            tabCarte[2] = Constantes.CASE_PLAINE;
            tabCarte[3] = Constantes.CASE_PLAINE;
            tabCarte[4] = Constantes.CASE_PLAINE;
            tabCarte[5] = Constantes.CASE_FORET;
            tabCarte[6] = Constantes.CASE_EAU;
            tabCarte[7] = Constantes.CASE_DESERT;
            tabCarte[8] = Constantes.CASE_DESERT;

            //On initialise une unité
            UniteViking uniteV = new UniteViking();
            uniteV.Position = new Coordonnees(1, 1);
            uniteV.TabCarte = tabCarte;
            uniteV.TailleCarteJeu = nbCase;
            uniteV.TabDeplacement = w.creerTab(nbCase);
            uniteV.TabCout = w.creerTabDouble(nbCase);
            uniteV.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            tabRef[0] = 0;
            tabRef[1] = 2;
            tabRef[2] = 0;
            tabRef[3] = 2;
            tabRef[4] = 2;
            tabRef[5] = 2;
            tabRef[6] = 0;
            tabRef[7] = 2;
            tabRef[8] = 0;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteV.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteV.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        Assert.AreEqual(1, uniteV.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteV.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteV.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
         * @fn TestDeplacementGauloisPlaine()
         * @brief Vérification du déplacement d'une unité gauloise sur de la plaine
         */
        [TestMethod]
        public void TestDeplacementGauloiPlaine()
        {
            WrapperAlgo w = new WrapperAlgo();
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
            UniteGauloise uniteG = new UniteGauloise();
            uniteG.Position = new Coordonnees(0, 0);
            uniteG.TabCarte = tabCarte;
            uniteG.TailleCarteJeu = nbCase;
            uniteG.TabDeplacement = w.creerTab(nbCase);
            uniteG.TabCout = w.creerTabDouble(nbCase);
            uniteG.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 0;
                }
            }
            tabRef[0 * nbCase + 0] = 3;
            tabRef[0 * nbCase + 1] = 3;
            tabRef[0 * nbCase + 2] = 3;
            tabRef[1 * nbCase + 0] = 3;
            tabRef[1 * nbCase + 1] = 3;
            tabRef[2 * nbCase + 0] = 3;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteG.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteG.TabDeplacement[i * nbCase + j], res);
                }
            }

            Assert.AreEqual(1, uniteG.TabCout[0]);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        Assert.AreEqual(1, uniteG.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        if ((i == 0 && j == 1) || (i == 1 && j == 0))
                        {
                            Assert.AreEqual(0.5, uniteG.TabCout[i * nbCase + j]);
                        }
                        else
                        {
                            string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteG.TabCout[i * nbCase + j];
                            Assert.AreEqual(0, uniteG.TabCout[i * nbCase + j], res);
                        }
                    }
                }
            }
        }

        /**
         * @fn TestDeplacementGauloisForet()
         * @brief Vérification du déplacement d'une unité gauloise sur de la foret
         */
        [TestMethod]
        public void TestDeplacementGauloisForet()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 5;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            //On fait une carte de plaine
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabCarte[i * nbCase + j] = Constantes.CASE_FORET;
                }
            }

            //On initialise une unité
            UniteGauloise uniteG = new UniteGauloise();
            uniteG.Position = new Coordonnees(1, 1);
            uniteG.TabCarte = tabCarte;
            uniteG.TailleCarteJeu = nbCase;
            uniteG.TabDeplacement = w.creerTab(nbCase);
            uniteG.TabCout = w.creerTabDouble(nbCase);
            uniteG.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 0;
                }
            }
            tabRef[0 * nbCase + 0] = 0;
            tabRef[0 * nbCase + 1] = 2;
            tabRef[0 * nbCase + 2] = 0;
            tabRef[1 * nbCase + 0] = 2;
            tabRef[1 * nbCase + 1] = 2;
            tabRef[1 * nbCase + 2] = 2;
            tabRef[2 * nbCase + 1] = 2;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteG.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteG.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        Assert.AreEqual(1, uniteG.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteG.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteG.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
        * @fn TestDeplacementGauloisMontagne()
        * @brief Vérification du déplacement d'une unité gauuloise sur de la montagne
        */
        [TestMethod]
        public void TestDeplacementGauloisMontagne()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 5;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            //On fait une carte de plaine
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabCarte[i * nbCase + j] = Constantes.CASE_MONTAGNE;
                }
            }

            //On initialise une unité
            UniteGauloise uniteG = new UniteGauloise();
            uniteG.Position = new Coordonnees(3, 2);
            uniteG.TabCarte = tabCarte;
            uniteG.TailleCarteJeu = nbCase;
            uniteG.TabDeplacement = w.creerTab(nbCase);
            uniteG.TabCout = w.creerTabDouble(nbCase);
            uniteG.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    tabRef[i * nbCase + j] = 0;
                }
            }
            tabRef[2 * nbCase + 2] = 2;
            tabRef[3 * nbCase + 1] = 2;
            tabRef[3 * nbCase + 2] = 2;
            tabRef[3 * nbCase + 3] = 2;
            tabRef[4 * nbCase + 2] = 2;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteG.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteG.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 3) && (j == 2))
                    {
                        Assert.AreEqual(1, uniteG.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteG.TabCout[i * nbCase + j];
                        Assert.AreEqual(0, uniteG.TabCout[i * nbCase + j], res);
                    }
                }
            }
        }

        /**
       * @fn TestDeplacementGauloisMixte()
       * @brief Vérification du déplacement d'une unité gauloise sur différents terrains
       */
        [TestMethod]
        public void TestDeplacementGauloisMixte()
        {
            WrapperAlgo w = new WrapperAlgo();
            int nbCase = 3;
            int* tabCarte = w.creerTab(nbCase);

            int i, j;

            tabCarte[0] = Constantes.CASE_DESERT;
            tabCarte[1] = Constantes.CASE_EAU;
            tabCarte[2] = Constantes.CASE_PLAINE;
            tabCarte[3] = Constantes.CASE_PLAINE;
            tabCarte[4] = Constantes.CASE_PLAINE;
            tabCarte[5] = Constantes.CASE_FORET;
            tabCarte[6] = Constantes.CASE_PLAINE;
            tabCarte[7] = Constantes.CASE_MONTAGNE;
            tabCarte[8] = Constantes.CASE_FORET;

            //On initialise une unité
            UniteGauloise uniteG = new UniteGauloise();
            uniteG.Position = new Coordonnees(1, 1);
            uniteG.TabCarte = tabCarte;
            uniteG.TailleCarteJeu = nbCase;
            uniteG.TabDeplacement = w.creerTab(nbCase);
            uniteG.TabCout = w.creerTabDouble(nbCase);
            uniteG.calculerDeplacement();

            //Tableau référence
            int* tabRef = w.creerTab(nbCase);
            tabRef[0] = 0;
            tabRef[1] = 1;
            tabRef[2] = 0;
            tabRef[3] = 3;
            tabRef[4] = 3;
            tabRef[5] = 2;
            tabRef[6] = 3;
            tabRef[7] = 2;
            tabRef[8] = 0;

            //Test
            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteG.TabDeplacement[i * nbCase + j];
                    Assert.AreEqual(tabRef[i * nbCase + j], uniteG.TabDeplacement[i * nbCase + j], res);
                }
            }

            for (i = 0; i < nbCase; i++)
            {
                for (j = 0; j < nbCase; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        Assert.AreEqual(1, uniteG.TabCout[i * nbCase + j]);
                    }
                    else
                    {
                        if ((i == 1) && (j == 0))
                        {
                            Assert.AreEqual(0.5, uniteG.TabCout[i * nbCase + j]);
                        }
                        else
                        {
                            string res = "i : " + i + " / j : " + j + " - " + tabRef[i * nbCase + j] + " " + uniteG.TabCout[i * nbCase + j];
                            Assert.AreEqual(0, uniteG.TabCout[i * nbCase + j], res);
                        }
                    }
                }
            }
        }
    }
}