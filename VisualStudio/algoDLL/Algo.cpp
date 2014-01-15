/**
* @file Algo.cpp
* @brief Librairie CPP pour SmallWorld
* 
* Ce fichier contient les différents algorithmes nécessaire au jeu SmallWorld
* 
* @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
* @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
* 
* @date 15/01/2014
* @version 0.1
*/
#include "Algo.h"
#include <stdio.h>
#include <stdlib.h> 
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */
#include <algorithm>    /* std::max */

#define CASE_DESERT 0
#define CASE_EAU 1
#define CASE_FORET 2
#define CASE_MONTAGNE 3
#define CASE_PLAINE 4

#define CASE_NONCALCULEE 0
#define CASE_IMPOSSIBLE 1
#define CASE_POSSIBLE 2
#define CASE_OPTIMALE 3 //Une case optimale est une case qui rapporte plus de point au joueur


/**
* Constructeur
*/
Algo* Algo_new() { return new Algo(); }

/**
* Destructeur
*/
void Algo_delete(Algo* algo) { delete algo; }


/**
* @fn genererCarte(int taille)
* @brief génère une carte de la taille demandée
*
* @return int** la carte sous forme d'une matrice d'int
*/
int** Algo::genererCarte(int taille) 
{
	/* initialize random seed: */
	srand((unsigned int)time(NULL));

	// tableau des tuiles
	int** tabCase = (int**) malloc(taille * sizeof(int *));

	//Initialisation caseRestante
	// TODO : Variable globale nb ressources
	int nbCaseParRessoure = (taille*taille)/5;

	//tableau contenant le nombre de cases de chaques types restante à placer
	int caseRestante[] = {nbCaseParRessoure,nbCaseParRessoure,nbCaseParRessoure,nbCaseParRessoure,nbCaseParRessoure};

	//Initialisation Carte 
	int i,j;
	for (i = 0; i < taille; i++)
	{
		tabCase[i] = (int*) malloc(taille * sizeof(int));
	}

	// Remplissage
	int typeCase;
	for (i = 0; i < taille; i++) {
		for (j = 0; j < taille; j++){

			/* nombre random entre 0 et 4 */
			typeCase = rand() % 5;
			while(caseRestante[typeCase] == 0)
			{
				typeCase = rand() % 5; 
				//typeCase = (typeCase++ % 5);
			}
			tabCase[i][j] = typeCase;
			caseRestante[typeCase]--;
		}
	}

	return tabCase;
}

/**
* @fn placerJoueur(int * tabCarte, int taille)
* @brief Suggère le placement des joueurs en début de partie
*
* @param int * <b>tabCarte</b> la carte sous forme de matrice d'int
* @param int <b>taille</b> la taille de la carte
* @return int *, un tableau contenant les coordonnées des deux joueurs
*/
int * Algo::placerJoueur(int * tabCarte, int taille) {
	int  * tabCoordonnee = (int*) malloc(4 * sizeof(int));;
	int i=0, j=0 ,k, l;

	//On vérifie  que le joueur 1 ne commence pas sur de l'eau
	while(tabCarte[i*taille+j] == CASE_EAU){
		i = i + (rand() % 2);
		j = j + (rand() % 2);
	}

	printf("i : %d\n", i);
	tabCoordonnee[0] = i;
	tabCoordonnee[1] = j;

	k = taille-1;
	l = taille-1;

	//On vérifie  que le joueur 2 ne commence pas sur de l'eau
	while(tabCarte[k*taille + l] == 1){
		k = k - (rand() % 2);
		l = l - (rand() % 2);
	}

	tabCoordonnee[2] = k;
	tabCoordonnee[3] = l;

	return tabCoordonnee;
}

/**
* @fn creerTab(int taille)
* @brief Création d'un tableau int
*
* @param int <b>taille</b> le taille du tableau
* @return int *, le tableau
*/
int * Algo::creerTab(int taille) {
	int  * tab = (int*) malloc(taille * taille * sizeof(int));;
	return tab;
}

/**
* @fn creerTabDouble(int taille)
* @brief Création d'un tableau de double
*
* @param int <b>taille</b> le taille du tableau
* @return double *, le tableau
*/
double * Algo::creerTabDouble(int taille) {
	double * tab = (double*) malloc(taille * taille * sizeof(double));;
	return tab;
}

/**
* @fn libererTab()
* @brief Libération du pointeur d'int
*
* @return void
*/
void Algo::libererTab(int * tab) {
	free(tab);
}

/**
* @fn libererTab()
* @brief Libération du pointeur d'int
*
* @return void
*/
void Algo::libererTabDouble(double * tab) {
	free(tab);
}


/*****************************************************************************/
/* Algorithmes gaulois */
/*****************************************************************************/

/**
* @fn deplacementGauloisInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
* @brief Suggère les déplacements pour une unité gauloise
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unité
* @param int <b>y</b> l'ordonnée de l'unité
* @param int <b>tabCout</b> le tableau des couts de déplacement
* @param int * <b>tabRes</b> la carte des déplacements possibles
* @param double <b>pointDepl</b> les points de déplacement actuel
* @return void
*/
void Algo::deplacementGauloisInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
{
	//Par défaut toute les cases sont inacessibles
	int i, j;
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			tabRes[i*taille + j] = CASE_NONCALCULEE;
		}
	}

	//Les points de déplacements restants sont initialisés à 0
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			tabCout[i*taille + j] = 0;
		}
	}

	//On autorise la case initiale
	if (carte[x*taille + y] == CASE_PLAINE)
	{
		tabRes[x*taille + y ] = CASE_OPTIMALE;
	}
	else
	{
		tabRes[x*taille+y] = CASE_POSSIBLE;
	}
	tabCout[x*taille+y] = pointDepl;

	deplacementGaulois(carte, taille, x, y, tabRes, tabCout);
}

/**
* @fn deplacementGaulois(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
* @brief Regarde les cases alentours pour les déplacements
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unité
* @param int <b>y</b> l'ordonnée de l'unité
* @param int * <b>tabRes</b> la carte des déplacements possibles
* @param double * <b>tabDepl</b> la table des points de déplacement
*/
void Algo::deplacementGaulois(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
{
	//case au dessus
	if (x != 0) 
	{
		if (tabRes[(x-1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x-1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
			deplacementGaulois2(carte, taille, x-1, y, tabRes, tabDepl);
		}
	}

	//case au dessous
	if (x != (taille-1)) 
	{
		if (tabRes[(x+1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x+1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
			deplacementGaulois2(carte, taille, x+1, y, tabRes, tabDepl);
		}
	}


	//case à droite
	if (y != (taille-1)) 
	{
		if (tabRes[x*taille+y+1] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x, y+1, tabRes, tabDepl, tabDepl[x*taille+y]);
			deplacementGaulois2(carte, taille, x, y+1, tabRes, tabDepl);
		}
	}


	//case à gauche
	if (y != 0) 
	{
		if (tabRes[x*taille+y-1] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x, y-1, tabRes, tabDepl, tabDepl[x*taille+y]);
			deplacementGaulois2(carte, taille, x, y-1, tabRes, tabDepl);
		}
	}
}

/**
* @fn deplacementGaulois2(int * carte, int taille, int x, int y)
* @brief Regarde les cases alentours pour les déplacements
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unité
* @param int <b>y</b> l'ordonnée de l'unité
* @param int * <b>tabRes</b> la carte des déplacements possibles
* @param double * <b>tabDepl</b> la table des points de déplacement
*/
void Algo::deplacementGaulois2(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
{
	//case au dessus
	if (x != 0) 
	{
		if (tabRes[(x-1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x-1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case au dessous
	if (x != (taille-1)) 
	{
		if (tabRes[(x+1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x+1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case à droite
	if (y != (taille-1)) 
	{
		if (tabRes[x*taille+y+1] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x, y+1, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case à gauche
	if (y != 0) 
	{
		if (tabRes[x*taille+y-1] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x, y-1, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}
}

/**
* @fn deplacementGauloisCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
* @brief Regarde si le déplacement sur la case est possible
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de la case
* @param int <b>y</b> l'ordonnée de la case
* @param int * <b>tabRes</b> le tableau résultat
* @param double * <b>tabDepl</b> le tableau de point de déplacement
* @param double <b>pointDepl</b> le nombre de point de déplacement
* @return void
*/
void Algo::deplacementGauloisCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
{
	double pointDeplacement;
	pointDeplacement = pointDepl;

	switch (carte[x*taille + y])
	{
	case CASE_DESERT:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = std::max(pointDeplacement, tabDepl[x*taille+y]); //on garde le meilleur chemin
		}
		else
		{
			tabRes[x*taille + y] = CASE_NONCALCULEE; //On met non calculé pour permettre à un meilleur chemin d'aboutir
		}
		break;
	case CASE_EAU:
		tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		break;
	case CASE_FORET:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = std::max(pointDeplacement, tabDepl[x*taille+y]);
		}
		else
		{
			tabRes[x*taille + y] = CASE_NONCALCULEE;
		}
		break;
	case CASE_MONTAGNE:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = std::max(pointDeplacement, tabDepl[x*taille+y]);
		}
		else
		{
			tabRes[x*taille + y ] = CASE_NONCALCULEE;
		}
		break;
	case CASE_PLAINE:
		if (pointDeplacement >= 0.5)
		{
			pointDeplacement -= 0.5;
			tabRes[x*taille + y] = CASE_OPTIMALE;
			tabDepl[x*taille + y] = std::max(pointDeplacement, tabDepl[x*taille+y]);
		}
		else
		{
			tabRes[x*taille + y] = CASE_NONCALCULEE;
		}
		break;
	default:
		break;
	}
}


/*****************************************************************************/
/* Algorithmes nain */
/*****************************************************************************/

/**
* @fn deplacementNainInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
* @brief Suggère les déplacements pour une unité naine
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unité
* @param int <b>y</b> l'ordonnée de l'unité
* @param int <b>tabCout</b> le tableau des couts de déplacement
* @param int * <b>tabRes</b> la carte des déplacements possibles
* @param double <b>pointDepl</b> le nombre de point de déplacement actuel
* @return void
*/
void Algo::deplacementNainInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
{
	//Par défaut toute les cases sont inacessibles, sauf les cases montagnes
	int i, j;
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			//Un nain peut se déplacer sur n'importe quelle case montagne s'il est déjà sur une case montagne et qu'il a un point déplacement
			if ((carte[i*taille + j] == CASE_MONTAGNE) && (carte[x*taille + y] == CASE_MONTAGNE) && (pointDepl >= 1))
			{
				tabRes[i*taille + j] = CASE_POSSIBLE;
			}
			else
			{
				tabRes[i*taille + j] = CASE_NONCALCULEE;
			}
		}
	}

	//Les points de déplacements restants sont initialisés à 0
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			tabCout[i*taille + j] = 0;
		}
	}

	//On autorise la case initiale
	if (carte[x*taille + y] == CASE_FORET)
	{
		tabRes[x*taille + y ] = CASE_OPTIMALE;
	}
	else
	{
		tabRes[x*taille+y] = CASE_POSSIBLE;
	}
	tabCout[x*taille+y] = pointDepl;

	deplacementNain(carte, taille, x, y, tabRes, tabCout);
}

/**
* @fn deplacementNain(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
* @brief Regarde les cases alentours pour les déplacements
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unité
* @param int <b>y</b> l'ordonnée de l'unité
* @param int * <b>tabRes</b> la carte des déplacements possibles
* @param double * <b>tabDepl</b> la table des points de déplacement
*/
void Algo::deplacementNain(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
{
	//case au dessus
	if (x != 0) 
	{
		if (tabRes[(x-1)*taille + y] == CASE_NONCALCULEE)
		{
			deplacementNainCase(carte,taille, x-1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case à droite
	if (y != (taille-1)) 
	{
		if (tabRes[x*taille+y+1] == CASE_NONCALCULEE)
		{
			deplacementNainCase(carte,taille, x, y+1, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case au dessous
	if (x != (taille-1)) 
	{
		if (tabRes[(x+1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementNainCase(carte,taille, x+1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case à gauche
	if (y != 0) 
	{
		if (tabRes[x*taille+y-1] == CASE_NONCALCULEE)
		{
			deplacementNainCase(carte,taille, x, y-1, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}
}

/**
* @fn deplacementNainCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
* @brief Regarde si le déplacement sur la case est possible
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de la case
* @param int <b>y</b> l'ordonnée de la case
* @param int * <b>tabRes</b> le tableau résultat
* @param double * <b>tabDepl</b> le tableau de point de déplacement
* @param double <b>pointDepl </b> le nombre de point de déplacement actuel
* @return void
*/
void Algo::deplacementNainCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
{
	double pointDeplacement;
	pointDeplacement = pointDepl;

	switch (carte[x*taille + y])
	{
	case CASE_DESERT:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		}
		break;
	case CASE_EAU:
		tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		break;
	case CASE_FORET:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_OPTIMALE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		}
		break;
	case CASE_MONTAGNE:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y ] = CASE_IMPOSSIBLE;
		}
		break;
	case CASE_PLAINE:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		}
		break;
	default:
		break;
	}
}


/*****************************************************************************/
/* Algorithmes viking */
/*****************************************************************************/

/**
* @fn deplacementVikingInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
* @brief Suggère les déplacements pour une unité viking
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unité
* @param int <b>y</b> l'ordonnée de l'unité
* @param double * <b>tabCout</b> le tableau des couts de déplacement
* @param int * <b>tabRes</b> la carte des déplacements possibles
* @param double <b>pointDepl</b> les points de déplacement initial
* @return void
*/
void Algo::deplacementVikingInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
{
	//Par défaut toute les cases sont inacessibles
	int i, j;
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			tabRes[i*taille + j] = CASE_NONCALCULEE;
		}
	}

	//Les points de déplacements restants sont initialisés à 0
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			tabCout[i*taille + j] = 0;
		}
	}

	//On autorise la case initiale
	tabRes[x*taille+y] = CASE_POSSIBLE;
	tabCout[x*taille+y] = pointDepl;

	deplacementViking(carte, taille, x, y, tabRes, tabCout);
}

/**
* @fn deplacementViking(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
* @brief Regarde les cases alentours pour les déplacements
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unité
* @param int <b>y</b> l'ordonnée de l'unité
* @param int * <b>tabRes</b> la carte des déplacements possibles
* @param double * <b>tabDepl</b> la table des points de déplacement
* @return void
*/
void Algo::deplacementViking(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
{
	//case au dessus
	if (x != 0) 
	{
		if (tabRes[(x-1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementVikingCase(carte,taille, x-1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case à droite
	if (y != (taille-1)) 
	{
		if (tabRes[x*taille+y+1] == CASE_NONCALCULEE)
		{
			deplacementVikingCase(carte,taille, x, y+1, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case au dessous
	if (x != (taille-1)) 
	{
		if (tabRes[(x+1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementVikingCase(carte,taille, x+1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}

	//case à gauche
	if (y != 0) 
	{
		if (tabRes[x*taille+y-1] == CASE_NONCALCULEE)
		{
			deplacementVikingCase(carte,taille, x, y-1, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}
}

/**
* @fn deplacementVikingCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
* @brief Regarde si le déplacement sur la case est possible
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de la case
* @param int <b>y</b> l'ordonnée de la case
* @param int * <b>tabRes</b> le tableau résultat
* @param double * <b>tabDepl</b> le tableau des points de déplacement
* @param double <b>pointDepl</b> les points de déplacement actuels
* @return void
*/
void Algo::deplacementVikingCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
{
	double pointDeplacement;
	pointDeplacement = pointDepl;

	switch (carte[x*taille + y])
	{
	case CASE_DESERT:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		}
		break;
	case CASE_EAU:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		}
		break;
	case CASE_FORET:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		}
		break;
	case CASE_MONTAGNE:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y ] = 1;
		}
		break;
	case CASE_PLAINE:
		if (pointDeplacement >= 1)
		{
			pointDeplacement--;
			tabRes[x*taille + y] = CASE_POSSIBLE;
			tabDepl[x*taille + y] = pointDeplacement;
		}
		else
		{
			tabRes[x*taille + y] = CASE_IMPOSSIBLE;
		}
		break;
	default:
		break;
	}
}

/**
* @fn caseBordEau(int * crate, int taille, int x, int y)
* @brief Indique si une case est au bord de l'eau
* 
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille du jeu
* @param int <b>x</b> l'abscisse de la case
* @param int <b>y</b> l'ordonnée de la case
* @return int 1 si la case est au bord de l'eau, 0 sinon
*/
int Algo::caseBordEau(int * carte, int taille, int x, int y)
{
	//case au dessus
	if (x != 0) 
	{
		if (carte[(x -1) * taille + y] == CASE_EAU)
		{
			return 1;
		}
	}

	//case à droite
	if (y != (taille-1)) 
	{
		if (carte[x*taille+y+1] == CASE_EAU)
		{
			return 1;
		}
	}

	//case au dessous
	if (x != (taille-1)) 
	{
		if (carte[(x+1)*taille+y] == CASE_EAU)
		{
			return 1;
		}
	}

	//case à gauche
	if (y != 0) 
	{
		if (carte[x*taille+y-1] == CASE_EAU)
		{
			return 1;
		}
	}

	return 0;
}