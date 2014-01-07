/**
* @file AlgoCarte.cpp
* @brief Librairie CPP pour SmallWorld
* 
* Ce fichier contient les diff�rents algorithmes n�cessaire au jeu SmallWorld
* 
* @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Cr�milleux</a>
* @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
* 
* @date 05/01/2014
* @version 0.1
*/
#include "AlgoCarte.h"
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

//TODO Supprimer si besoin
int AlgoCarte::computeFoo() {
	return 56;
}

//TODO supprimer si besoin
AlgoCarte* Algo_new() { return new AlgoCarte(); }
void Algo_delete(AlgoCarte* algo) { delete algo; }
int Algo_computeAlgo(AlgoCarte* algo) { return algo->computeFoo(); } 

/**
* @fn genererCarte(int taille)
* @brief g�n�re une carte de la taille demand�e
*
* @return int** la carte sous forme d'une matrice d'int
*/
int** AlgoCarte::genererCarte(int taille) 
{
	/* initialize random seed: */
	srand((unsigned int)time(NULL));

	// tableau des tuiles
	int** tabCase = (int**) malloc(taille * sizeof(int *));

	//Initialisation caseRestante
	// TODO : Variable globale nb ressources
	int nbCaseParRessoure = (taille*taille)/5;

	//tableau contenant le nombre de cases de chaques types restante � placer
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
* @brief Sugg�re le placement des joueurs en d�but de partie
*
* @param int * <b>tabCarte</b> la carte sous forme de matrice d'int
* @param int <b>taille</b> la taille de la carte
* @return int *, un tableau contenant les coordonn�es des deux joueurs
*/
int * AlgoCarte::placerJoueur(int * tabCarte, int taille) {
	int  * tabCoordonnee = (int*) malloc(4 * sizeof(int));;
	int i=0, j=0 ,k, l;

	//On v�rifie  que le joueur 1 ne commence pas sur de l'eau
	while(tabCarte[i*taille+j] == CASE_EAU){
		i = i + (rand() % 2);
		j = j + (rand() % 2);
	}

	printf("i : %d\n", i);
	tabCoordonnee[0] = i;
	tabCoordonnee[1] = j;

	k = taille-1;
	l = taille-1;

	//On v�rifie  que le joueur 2 ne commence pas sur de l'eau
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
* @brief Cr�ation d'un tableau int
*
* @param int <b>taille</b> le taille du tableau
* @return int *, le tableau
*/
int * AlgoCarte::creerTab(int taille) {
	int  * tab = (int*) malloc(taille * taille * sizeof(int));;
	return tab;
}

/**
* @fn creerTabDouble(int taille)
* @brief Cr�ation d'un tableau de double
*
* @param int <b>taille</b> le taille du tableau
* @return double *, le tableau
*/
double * AlgoCarte::creerTabDouble(int taille) {
	double * tab = (double*) malloc(taille * taille * sizeof(double));;
	return tab;
}

/*****************************************************************************/
/* Algorithmes gaulois */
/*****************************************************************************/

/**
* @fn deplacementGauloisInitial(int * carte, int taille, int x, int y)
* @brief Sugg�re les d�placements pour une unit� gauloise
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unit�
* @param int <b>y</b> l'ordonn�e de l'unit�
* @param int <b>tabCout</b> le tableau des couts de d�placement
* @param int * <b>tabRes</b> la carte des d�placements possibles
* @param double <b>pointDepl</b> les points de d�placement actuel
* @return void
*/
void AlgoCarte::deplacementGauloisInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
{
	//Par d�faut toute les cases sont inacessibles
	int i, j;
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			tabRes[i*taille + j] = CASE_NONCALCULEE;
		}
	}

	//Les points de d�placements restants sont initialis�s � 0
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
* @fn deplacementGaulois(int * carte, int taille, int x, int y)
* @brief Regarde les cases alentours pour les d�placements, puis s'appelle r�cursivement pour parcourir toute la carte
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unit�
* @param int <b>y</b> l'ordonn�e de l'unit�
* @param int * <b>tabRes</b> la carte des d�placements possibles
* @param double * <b>tabDepl</b> la table des points de d�placement
*/
void AlgoCarte::deplacementGaulois(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
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


	//case � droite
	if (y != (taille-1)) 
	{
		if (tabRes[x*taille+y+1] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x, y+1, tabRes, tabDepl, tabDepl[x*taille+y]);
			deplacementGaulois2(carte, taille, x, y+1, tabRes, tabDepl);
		}
	}


	//case � gauche
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
* @brief Regarde les cases alentours pour les d�placements, puis s'appelle r�cursivement pour parcourir toute la carte
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unit�
* @param int <b>y</b> l'ordonn�e de l'unit�
* @param int * <b>tabRes</b> la carte des d�placements possibles
* @param double * <b>tabDepl</b> la table des points de d�placement
*/
void AlgoCarte::deplacementGaulois2(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
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
	
	//case � droite
	if (y != (taille-1)) 
	{
		if (tabRes[x*taille+y+1] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x, y+1, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}
	
	//case � gauche
	if (y != 0) 
	{
		if (tabRes[x*taille+y-1] == CASE_NONCALCULEE)
		{
			deplacementGauloisCase(carte,taille, x, y-1, tabRes, tabDepl, tabDepl[x*taille+y]);
		}
	}
}

/**
* @fn deplacementGauloisCase(int * carte, int taille, int x, int y, int * tabRes, double * pointDepl)
* @brief Regarde si le d�placement sur la case est possible
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de la case
* @param int <b>y</b> l'ordonn�e de la case
* @param int * <b>tabRes</b> le tableau r�sultat
* @param double * <b>pointDepl</b> le nombre de point de d�placement
* @return void
*/
void AlgoCarte::deplacementGauloisCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
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
			tabRes[x*taille + y] = CASE_NONCALCULEE; //On met non calcul� pour permettre � un meilleur chemin d'aboutir
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
* @fn deplacementNainInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes)
* @brief Sugg�re les d�placements pour une unit� gauloise
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unit�
* @param int <b>y</b> l'ordonn�e de l'unit�
* @param int <b>tabCout</b> le tableau des couts de d�placement
* @param int * <b>tabRes</b> la carte des d�placements possibles
* @param double c*<b>pointDepl</b> le nombre de d�placement actuel
* @return void
*/
void AlgoCarte::deplacementNainInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
{
	//Par d�faut toute les cases sont inacessibles, sauf les cases montagnes
	int i, j;
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			//Un nain peut se d�placer sur n'importe quelle case montagne s'il est d�j� sur une case montagne et qu'il a un point d�placement
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

	//Les points de d�placements restants sont initialis�s � 0
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
* @brief Regarde les cases alentours pour les d�placements, puis s'appelle r�cursivement pour parcourir toute la carte
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unit�
* @param int <b>y</b> l'ordonn�e de l'unit�
* @param int * <b>tabRes</b> la carte des d�placements possibles
* @param double * <b>tabDepl</b> la table des points de d�placement
*/
void AlgoCarte::deplacementNain(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
{
	//case au dessus
	if (x != 0) 
	{
		if (tabRes[(x-1)*taille + y] == CASE_NONCALCULEE)
		{
			deplacementNainCase(carte,taille, x-1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
		//	deplacementNain(carte, taille, x-1, y, tabRes, tabDepl);
		}
	}

	//case � droite
	if (y != (taille-1)) 
	{
		if (tabRes[x*taille+y+1] == CASE_NONCALCULEE)
		{
			deplacementNainCase(carte,taille, x, y+1, tabRes, tabDepl, tabDepl[x*taille+y]);
		//	deplacementNain(carte, taille, x, y+1, tabRes, tabDepl);
		}
	}

	//case au dessous
	if (x != (taille-1)) 
	{
		if (tabRes[(x+1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementNainCase(carte,taille, x+1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
			//deplacementNain(carte, taille, x+1, y, tabRes, tabDepl);
		}
	}

	//case � gauche
	if (y != 0) 
	{
		if (tabRes[x*taille+y-1] == CASE_NONCALCULEE)
		{
			deplacementNainCase(carte,taille, x, y-1, tabRes, tabDepl, tabDepl[x*taille+y]);
		//	deplacementNain(carte, taille, x, y-1, tabRes, tabDepl);
		}
	}
}

/**
* @fn deplacementNainCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
* @brief Regarde si le d�placement sur la case est possible
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de la case
* @param int <b>y</b> l'ordonn�e de la case
* @param int * <b>tabRes</b> le tableau r�sultat
* @param double * <b>tabDepl</b> le tableau de point de d�placement
* @param double <b>pointDepl </b> le nombre de point de d�placement actuel
* @return void
*/
void AlgoCarte::deplacementNainCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
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
* @fn deplacementVikingInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes)
* @brief Sugg�re les d�placements pour une unit� gauloise
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unit�
* @param int <b>y</b> l'ordonn�e de l'unit�
* @param double * <b>tabCout</b> le tableau des couts de d�placement
* @param int * <b>tabRes</b> la carte des d�placements possibles
* @param double <b>pointDepl</b> les points de d�placement initial
* @return void
*/
void AlgoCarte::deplacementVikingInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl)
{
	//Par d�faut toute les cases sont inacessibles
	int i, j;
	for (i = 0; i < taille; i++)
	{
		for (j = 0; j < taille; j++)
		{
			tabRes[i*taille + j] = CASE_NONCALCULEE;
		}
	}

	//Les points de d�placements restants sont initialis�s � 0
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
* @brief Regarde les cases alentours pour les d�placements, puis s'appelle r�cursivement pour parcourir toute la carte
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de l'unit�
* @param int <b>y</b> l'ordonn�e de l'unit�
* @param int * <b>tabRes</b> la carte des d�placements possibles
* @param double * <b>tabDepl</b> la table des points de d�placement
* @return void
*/
void AlgoCarte::deplacementViking(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl)
{
	//case au dessus
	if (x != 0) 
	{
		if (tabRes[(x-1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementVikingCase(carte,taille, x-1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
			//deplacementViking(carte, taille, x-1, y, tabRes, tabDepl);
		}
	}

	//case � droite
	if (y != (taille-1)) 
	{
		if (tabRes[x*taille+y+1] == CASE_NONCALCULEE)
		{
			deplacementVikingCase(carte,taille, x, y+1, tabRes, tabDepl, tabDepl[x*taille+y]);
			//deplacementViking(carte, taille, x, y+1, tabRes, tabDepl);
		}
	}

	//case au dessous
	if (x != (taille-1)) 
	{
		if (tabRes[(x+1)*taille+y] == CASE_NONCALCULEE)
		{
			deplacementVikingCase(carte,taille, x+1, y, tabRes, tabDepl, tabDepl[x*taille+y]);
			//deplacementViking(carte, taille, x+1, y, tabRes, tabDepl);
		}
	}

	//case � gauche
	if (y != 0) 
	{
		if (tabRes[x*taille+y-1] == CASE_NONCALCULEE)
		{
			deplacementVikingCase(carte,taille, x, y-1, tabRes, tabDepl, tabDepl[x*taille+y]);
			//deplacementViking(carte, taille, x, y-1, tabRes, tabDepl);
		}
	}
}

/**
* @fn deplacementVikingCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
* @brief Regarde si le d�placement sur la case est possible
*
* @param int * <b>carte</b> la carte du jeu
* @param int <b>taille</b> la taille de la carte
* @param int <b>x</b> l'abscisse de la case
* @param int <b>y</b> l'ordonn�e de la case
* @param int * <b>tabRes</b> le tableau r�sultat
* @param double * <b>tabDepl</b> le tableau des points de d�placement
* @param double <b>pointDepl</b> les points de d�placement actuels
* @return void
*/
void AlgoCarte::deplacementVikingCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl)
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
 * @param int <b>y</b> l'ordonn�e de la case
 * @return int 1 si la case est au bord de l'eau, 0 sinon
 */
int AlgoCarte::caseBordEau(int * carte, int taille, int x, int y)
{
//case au dessus
	if (x != 0) 
	{
		if (carte[(x -1) * taille + y] == CASE_EAU)
		{
			return 1;
		}
	}

	//case � droite
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

	//case � gauche
	if (y != 0) 
	{
		if (carte[x*taille+y-1] == CASE_EAU)
		{
			return 1;
		}
	}

	return 0;

}