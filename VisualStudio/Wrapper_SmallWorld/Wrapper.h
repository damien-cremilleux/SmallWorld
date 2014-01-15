/**
* @file Wrapper.h
* @brief Wrapper pour les algo
* 
* @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
* @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
* 
* @date 15/01/2014
* @version 0.1
*/
#ifndef __WRAPPER__
#define __WRAPPER__

#include "../algoDLL/Algo.h"
#pragma comment(lib, "../Debug/algoDLL.lib")
#pragma comment(lib, "../Release/algoDLL.lib")

using namespace System;

namespace Wrapper {
	public ref class WrapperAlgo {
	private:
		Algo* algo;
	public:
		WrapperAlgo(){ algo = Algo_new(); }
		~WrapperAlgo(){ Algo_delete(algo); }
		int ** genererCarte(int taille) { return algo->genererCarte(taille);}
		int * placerJoueur(int * tabCarte, int taille) { return algo->placerJoueur(tabCarte,taille);}
		int * creerTab(int taille) {return algo->creerTab(taille);}
		double * creerTabDouble(int taille) {return algo->creerTabDouble(taille);}
		int caseBordEau(int * carte, int taille, int x, int y) {return algo->caseBordEau(carte, taille, x, y);}
		void deplacementGauloisInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl) {return algo->deplacementGauloisInitial(carte, taille, x,y, tabCout, tabRes, pointDepl);}
		void deplacementNainInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl) {return algo->deplacementNainInitial(carte, taille, x,y, tabCout, tabRes, pointDepl);}
		void deplacementVikingInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl) {return algo->deplacementVikingInitial(carte, taille, x,y, tabCout, tabRes, pointDepl);}
	};
}
#endif