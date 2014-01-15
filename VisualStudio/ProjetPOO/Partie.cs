/**
 * @file Partie.cs
 * @brief Interface et classe d'une partie
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 15/01/2014
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Wrapper;

namespace SmallWorld
{
    /**
     * @interface InterPartie
     * @brief interface pour les partie
     */
    public interface InterPartie
    {
    }

    /**
     * @class Partie
     * @brief classe pour les parties
     */
    [Serializable]
    public unsafe class Partie : InterPartie
    {
        /**
         * @brief Attribut <b>indiceJoueurInitiale</b> indice du joueur ayant commencé
         */
        private int indiceJoueurInitial;

        /**
         * @brief Attribut <b>indiceJoueurEnCours</b> indice du joueur dont c'est le tour
         */
        private int indiceJoueurEnCours;

        /**
         * @brief Attribut <b>joueurEnCours</b> joueur dont c'est le tour
         */
        // private Joueur joueurEnCours; //TODO Supprimer si besoin

        /**
         * @brief Attribut <b>listeJoueurs</b> liste des joueurs de la partie
         */
        private List<Joueur> listeJoueurs;

        /**
         * @brief Attribut <b>nbTourRestant</b> nombre de tour restant
         */
        private int nbTourRestant;

        /**
         * @brief Attribut <b>partieFinie</b> indique si la partie est fini
         */
        private bool partieFinie;

        /**
         * @brief Attribut <b>cartePartie</b> carte de la partie
         */
        private Carte cartePartie;

        /**
         * @brief Attibut <b>tabCarte</b> la carte sous forme d'un tableau d'int
         */
        private int* tabCarte;

        /**
        * @brief Attibut <b>nomSauvegarde</b> le nom de la sauvegarde
        */
        private string nomSauvegarde;

        /**
         * @fn IndiceJoueurInitial
         * @brief Properties pour l'attribut indiceJoueurInitial
         */
        public int IndiceJoueurInitial
        {
            get
            {
                return indiceJoueurInitial;
            }
            set
            {
                indiceJoueurInitial = value;
            }
        }

        /**
         * @fn IndiceJoueurEnCours
         * @brief Properties pour l'attribut indiceJoueurEnCours
         */
        public int IndiceJoueurEnCours
        {
            get
            {
                return indiceJoueurEnCours;
            }
            set
            {
                indiceJoueurEnCours = value;
            }
        }

        /**
         * @fn JoueurEnCours
         * @brief Properties pour l'attribut joueurEnCours
         */
        /* public Joueur JoueurEnCours
         {
             get
             {
                 return joueurEnCours;
             }
             set
             {
                 joueurEnCours = value;
             }
         }*/
        //TODO Supprimer si besoin

        /**
         * @fn ListeJoueurs
         * @brief Properties pour l'attribut listeJoueurs
         */
        public List<Joueur> ListeJoueurs
        {
            get
            {
                return listeJoueurs;
            }
            set
            {
                listeJoueurs = value;
            }
        }


        /**
         * @fn nbTourRestant
         * @brief Properties pour l'attribut nbTourRestant
         */
        public int NbTourRestant
        {
            get
            {
                return nbTourRestant;
            }
            set
            {
                nbTourRestant = value;
            }
        }

        /**
         * @fn partieFinie
         * @brief Properties pour l'attribut partieFinie
         */
        public bool PartieFinie
        {
            get
            {
                return partieFinie;
            }
            set
            {
                partieFinie = value;
            }
        }

        /**
         * @fn CartePartie
         * @brief Properties pour l'attribut cartePartie
         */
        public Carte CartePartie
        {
            get
            {
                return cartePartie;
            }
            set
            {
                cartePartie = value;
            }
        }

        /**
         * @fn TabCarte
         * @brief Properties pour l'attribut tabCarte
         */
        public int* TabCarte
        {
            get
            {
                return tabCarte;
            }
            set
            {
                tabCarte = value;
            }
        }

        /**
         * @fn Partie()
         * @brief Constructeur d'une partie vide
         * 
         * Construit une partie sans joueur et avec une carte vide
         * 
         * @return une nouvelle partie
         */
        public Partie()
        {
            ListeJoueurs = new List<Joueur>();
            CartePartie = new Carte();
        }

        /**
         * @fn Partie(List<Joueur> listeJ, Carte carte)
         * @brief Constructeur d'une partie
         * 
         * @param List<Joueur> <b>listeJ</b> la liste des joueurs
         * @param Carte <b>Carte</b> la carte de la partie
         * @return une nouvelle partie
         */
        public Partie(List<Joueur> listeJ, Carte carte)
        {
            ListeJoueurs = listeJ;
            CartePartie = carte;
            nomSauvegarde = "";

            //Le premier joueur est sélectionné au hasard
            Random r = new Random();
            int premier = r.Next(ListeJoueurs.Count);
            indiceJoueurInitial = premier;
            IndiceJoueurEnCours = indiceJoueurInitial;
        }

        /**
         * @fn vainqueurs()
         * @brief Rend la liste des joueurs disposant du plus de points
         * 
         * @return Liste<Joueur> la liste des gagnants
         */
        public List<Joueur> vainqueurs()
        {
            int max, val;
            List<Joueur> listeRes = new List<Joueur>();
            max = ListeJoueurs[0].PointVictoire;

            foreach (Joueur j in ListeJoueurs)
            {
                val = j.PointVictoire;
                if (val > max)
                    max = val;
            }

            foreach (Joueur j in ListeJoueurs)
            {
                if (j.PointVictoire == max)
                    listeRes.Add(j);
            }
            return listeRes;
        }

        /**
         * @fn changerJoueur
         * @brief Change le joueur en cours, quand le joueur précédent a fini son tour
         * 
         * @return void
         */
        public void changerJoueur()
        {
            //On met les points du joueur précédent à jour et ses unités passent leur tour
            this.ListeJoueurs[IndiceJoueurEnCours].calculerPointVictoire();
            foreach (Unite unite in ListeJoueurs[IndiceJoueurEnCours].ListeUnite)
            {
                unite.passerSonTour();
                unite.PointDeDeplacement = 0;
            }

            //On passe au joueur suivant
            IndiceJoueurEnCours = (IndiceJoueurEnCours + 1) % ListeJoueurs.Count;
            foreach (Unite unite in ListeJoueurs[IndiceJoueurEnCours].ListeUnite)
            {
                unite.nouveauTour();
            }

            if (IndiceJoueurEnCours == indiceJoueurInitial)
            {
                NbTourRestant--;
            }

            if (NbTourRestant == 0)
            {
                PartieFinie = true;
            }
        }

        /**
         * @fn selectionnerUnite(int x, int y)
         * @brief Obtenir l'ensemble des unités du joueur en cours se situant sur la case demandée
         * 
         * @param int <b>x</b> l'abcsisse de la case demandée
         * @param int <b>y</b> l'ordonnée de la case demandée
         * @return List<Unite> la liste des unités présentes sur la cases, pour le joueur courant
         */
        public List<Unite> selectionnerUnite(int x, int y)
        {
            int indice;
            List<Unite> listeUnite = new List<Unite>();
            Coordonnees coord = new Coordonnees(x, y);

            for (indice = 0; indice < ListeJoueurs[IndiceJoueurEnCours].ListeUnite.Count; indice++)
            {
                if (ListeJoueurs[IndiceJoueurEnCours].ListeUnite[indice].Position.Equals(coord))
                {
                    listeUnite.Add(ListeJoueurs[IndiceJoueurEnCours].ListeUnite[indice]);
                }
            }
            return listeUnite;
        }

        /**
        * @fn selectionnerUniteAdverse(int x, int y)
        * @brief Obtenir l'ensemble des unités des joueurs adverses du joueur en cours se situant sur la case demandée
        * 
        * @param int <b>x</b> l'abcsisse de la case demandée
        * @param int <b>y</b> l'ordonnée de la case demandée
        * @return List<Unite> la liste des unités présentes sur la cases, pour les adversaires du joueur courant
        */
        public List<Unite> selectionnerUniteAdverse(int x, int y)
        {
            int indiceJ;
            int indiceU;
            List<Unite> listeUnite = new List<Unite>();
            Coordonnees coord = new Coordonnees(x, y);

            for (indiceJ = 0; indiceJ < ListeJoueurs.Count; indiceJ++)
            {
                if (indiceJ != IndiceJoueurEnCours)
                {
                    for (indiceU = 0; indiceU < ListeJoueurs[indiceJ].ListeUnite.Count; indiceU++)
                    {
                        if (ListeJoueurs[indiceJ].ListeUnite[indiceU].Position.Equals(coord))
                        {
                            listeUnite.Add(ListeJoueurs[indiceJ].ListeUnite[indiceU]);
                        }
                    }
                }
            }
            return listeUnite;
        }

        /**
        * @fn peutSeDeplacer(int indiceUnite, int x, int y)
        * @brief Indique si l'unité peut se déposer sur la case(x,y)
        * 
        * @param int <b>Unite</b> l'unité à déplacer
        * @param int <b>x</b> l'abscisse de la case destination
        * @param int <b>y</b> l'ordonnée de la case destination
        * @return bool, vrai si le déplacement est possible, faux sinon
        */
        public bool peutSeDeplacer(Unite unite, int x, int y)
        {
            //On gère le cas des nains se déplacant de montagne en montagne
            if ((unite.GetType() == new UniteNaine().GetType()) && (selectionnerUniteAdverse(x, y).Count != 0) && ((Math.Abs(x - unite.Position.Abscisse) + Math.Abs(y - unite.Position.Ordonnee)) > 1))
            {
                return false;
            }
            else
            {
                return unite.peutSeDeplacer(x, y);
            }
        }

        /**
         * @fn demanderDeplacement(int indiceUnite, int x, int y)
         * @brief Déplacer, si possible, l'unité sur la case (x,y). En cas d'unités adverses, il y a combat.
         * 
         * @param int <b>indiceUnite</b> l'indice de l'unité à déplacer, dans le tableau des unités du joueurs en cours
         * @param int <b>x</b> l'abscisse de la case destination
         * @param int <b>y</b> l'ordonnée de la case destination
         * @return int, 0 si l'unité ne peut pas se déplacer, 1, si elle se déplace sans combat, 2 s'il y a combat et qu'elle meurt,  3 si combat et déplacement possible, 4 si combat et déplacement non possible
         */
        public int demanderDeplacement(Unite unite, int x, int y)
        {
            if (peutSeDeplacer(unite, x, y))
            {
                //On regarde si un combat est nécessaire
                List<Unite> listUnite = selectionnerUniteAdverse(x, y);
                if (listUnite.Count == 0)
                {
                    unite.seDeplacer(x, y);
                    return 1;
                }
                else
                {
                    //On sélectionne la meilleur unité adverse
                    Unite meilleureU = meilleureUnite(listUnite);

                    //Si elle n'a pas de défense elle meurt et on redemande le déplacement
                    if (meilleureU.PointDefense == 0)
                    {
                        foreach (Joueur j in ListeJoueurs)
                        {
                            j.ListeUnite.Remove(meilleureU);
                            j.calculerPointVictoire();
                        }
                    }
                    else
                    //Combat
                    {
                        //on génère un nombre de combat aléatoire
                        int nbRoundCombat;
                        Random r = new Random();
                        nbRoundCombat = 3 + r.Next(Math.Max(unite.PointDeVie, meilleureU.PointDeVie));
                        Console.WriteLine("Il y a " + nbRoundCombat + " rouds");
                        unite.attaquer(meilleureU, nbRoundCombat);

                        //L'unité attaquante est morte
                        if (unite.PointDeVie == 0) //l'attaquant a perdu, son unité meurt
                        {
                            Console.WriteLine("L'unité A a perdu, elle meurt");
                            foreach (Joueur j in ListeJoueurs)
                            {
                                j.ListeUnite.Remove(unite);
                                j.calculerPointVictoire();
                            }
                            verifierFinPartie();
                            return 2;
                        }

                        //L'unité en défense est morte
                        if (meilleureU.PointDeVie == 0)
                        {
                            Console.WriteLine("L'unité B meurt");
                            foreach (Joueur j in ListeJoueurs)
                            {
                                j.ListeUnite.Remove(meilleureU);
                                j.calculerPointVictoire();
                            }

                            if (selectionnerUniteAdverse(x, y).Count == 0)
                            {
                                unite.seDeplacer(x, y);
                                verifierFinPartie();
                                return 3;
                            }
                        }

                        verifierFinPartie();
                        return 4;
                    }
                }
                verifierFinPartie();
                return 4;
            }
            else
            {
                return 0;
            }
        }

        /**
        * @fn meilleureUnite(List<Unite> listeUnite)
        * @brief Récupère la meilleure unité défensive de la list
        * 
        * @param List<Unite> <b>listeUnite</b> la liste d'unité
        * @return Unite la meilleure unité défensive
        */
        public Unite meilleureUnite(List<Unite> listeUnite)
        {
            if (listeUnite.Count == 0)
            {
                return null;
            }
            else
            {
                Unite meilleureU = listeUnite[0];
                foreach (Unite u in listeUnite)
                {
                    if ((u.PointDefense + u.PointDeVie) > (meilleureU.PointDefense + meilleureU.PointDeVie))
                    {
                        meilleureU = u;
                    }
                }
                return meilleureU;
            }

        }


        /**
         * @fn verifierFinPartie()
         * @brief Vérifier si la partie est finie (les joueurs adverses n'ont plus d'unité)
         * 
         * Met la variable PartieFinie à vraie si besoin 
         * 
         * @return void
         */
        public void verifierFinPartie()
        {
            bool plusUnite = false;

            foreach (Joueur j in ListeJoueurs)
            {
                plusUnite = plusUnite || (j.ListeUnite.Count == 0);
            }

            PartieFinie = plusUnite;
        }

        /**
         * @fn Enregistrer()
         * @brief Enregistre une partie
         * 
         * @return bool, vrai si le nom de fichier est connu, faux sinon
         */
        public bool enregistrer()
        {
            if (nomSauvegarde != "")
            {
                this.enregistrerSous(nomSauvegarde);
                return true;
            }
            else
            {
                return false;
            }
        }


        /**
         * @fn EnregistrerSous(string nomFichier)
         * @brief Enregistre la partie sous le nom passer en paramètre
         * 
         * @param string<b>nomFichier</b> le nom du fichier
         * @return void
         */
        public void enregistrerSous(string nomFichier)
        {
            FileStream stream = File.Create(nomFichier);
            BinaryFormatter formatter = new BinaryFormatter();
            Console.WriteLine("Serializing");
            formatter.Serialize(stream, this);
            stream.Close();
        }

        /**
         * @fn Charger(string nomFichier)
         * @brief Charge la partie
         * 
         * @param string<b>nomFichier</b> le nom du fichier à charger
         * @return Partie la partie à restaurer
         */
        public Partie charger(string nomFichier)
        {
            FileStream stream = File.OpenRead(nomFichier);
            BinaryFormatter formatter = new BinaryFormatter();
            Console.WriteLine("Deserializing");
            Partie p = (Partie)formatter.Deserialize(stream);
            stream.Close();
            p.restaurer();

            return p;
        }

        /**
         * @fn restaurer()
         * @brief Restaure les unités suite à une désérialisation
         */
        public void restaurer()
        {
            WrapperAlgo wrapperAlgo = new WrapperAlgo();

            //On transforme le tableau de case en int
            int tailleCarte = this.CartePartie.TailleCarte;
            int* tabCase = wrapperAlgo.creerTab(tailleCarte);
            int i, j;
            for (i = 0; i < tailleCarte; i++)
            {
                for (j = 0; j < tailleCarte; j++)
                {
                    if (CartePartie.ListeCases[i][j].GetType() == new Desert().GetType())
                        tabCase[i * tailleCarte + j] = Constantes.CASE_DESERT;

                    if (CartePartie.ListeCases[i][j].GetType() == new Eau().GetType())
                        tabCase[i * tailleCarte + j] = Constantes.CASE_EAU;

                    if (CartePartie.ListeCases[i][j].GetType() == new Foret().GetType())
                        tabCase[i * tailleCarte + j] = Constantes.CASE_FORET;

                    if (CartePartie.ListeCases[i][j].GetType() == new Montagne().GetType())
                        tabCase[i * tailleCarte + j] = Constantes.CASE_MONTAGNE;

                    if (CartePartie.ListeCases[i][j].GetType() == new Plaine().GetType())
                        tabCase[i * tailleCarte + j] = Constantes.CASE_PLAINE;
                }
            }

            //on restaure chaque unité
            foreach (Joueur joueur in ListeJoueurs)
            {
                foreach (Unite unite in joueur.ListeUnite)
                {
                    unite.restaurer(tabCase);
                }
            }
        }
    }
}
