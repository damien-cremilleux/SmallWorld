/**
 * @file Partie.cs
 * @brief Interface et classe d'une partie
 * 
 * @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
 * @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
 * 
 * @date 06/01/2014
 * @version 0.1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public int * TabCarte
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

            //Le premier joueur est sélectionné au hasard
            Random r = new Random();
            indiceJoueurInitial = r.Next(ListeJoueurs.Count);
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
            //On met les points du joueur précédent à jour
            this.ListeJoueurs[IndiceJoueurEnCours].calculerPointVictoire();

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
            Coordonnees coord = new Coordonnees(x,y);

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
         * @fn demanderDeplacement(int indiceUnite, int x, int y)
         * @brief Déplacer, si possible, l'unité sur la case (x,y)
         * 
         * @param int <b>indiceUnite</b> l'indice de l'unité à déplacer, dans le tableau des unités du joueurs en cours
         * @param int <b>x</b> l'abscisse de la case destination
         * @param int <b>y</b> l'ordonnée de la case destination
         * @return void
         */
        public void demanderDeplacement(int indiceUnite, int x, int y)
        {
            //TODO faire une implémentation correcte
            ListeJoueurs[IndiceJoueurEnCours].ListeUnite[indiceUnite].Position = new Coordonnees(x, y);
        }
    }
}
