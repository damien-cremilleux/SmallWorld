#include "AlgoCarte.h"
#include <stdio.h>
#include <stdlib.h> 
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */

int AlgoCarte::computeFoo() {
	return 56;
}

AlgoCarte* Algo_new() { return new AlgoCarte(); }
void Algo_delete(AlgoCarte* algo) { delete algo; }
int Algo_computeAlgo(AlgoCarte* algo) { return algo->computeFoo(); } 


int** AlgoCarte::genererCarte(int taille) 
{
	/* initialize random seed: */
	srand(time(NULL));


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

int * AlgoCarte::placerJoueur(int * tabCarte, int taille) {
	int  * tabCoordonnee = (int*) malloc(4 * sizeof(int));;
	int i=0, j=0 ,k, l;


	while(tabCarte[i*taille+j] == 1){
		i = i + (rand() % 2);
		j = j + (rand() % 2);
	}
	
	printf("i : %d\n", i);
	tabCoordonnee[0] = i;
	tabCoordonnee[1] = j;

	k = taille-1;
	l = taille-1;

	while(tabCarte[k*taille + l] == 1){
		k = k - (rand() % 2);
		l = l - (rand() % 2);
	}

	tabCoordonnee[2] = k;
	tabCoordonnee[3] = l;

	return tabCoordonnee;
}

int * AlgoCarte::creerTab(int taille) {
	int  * tab = (int*) malloc(taille * taille * sizeof(int));;
	return tab;
}