#ifndef __WRAPPER__
#define __WRAPPER__

#include "../algoDLL/AlgoCarte.h"
#pragma comment(lib, "../Debug/algoDLL.lib")

using namespace System;

namespace Wrapper {
	public ref class WrapperAlgo {
	private:
		AlgoCarte* algo;
	public:
		WrapperAlgo(){ algo = Algo_new(); }
		~WrapperAlgo(){ Algo_delete(algo); }
		int computeFoo() { return algo->computeFoo(); }
		int ** genererCarte(int taille) { return algo->genererCarte(taille);}
		int * placerJoueur(int * tabCarte, int taille) { return algo->placerJoueur(tabCarte,taille);}
		int * creerTab(int taille) {return algo->creerTab(taille);}
		double * creerTabDouble(int taille) {return algo->creerTabDouble(taille);}
		void deplacementGauloisInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes) {return algo->deplacementGauloisInitial(carte, taille, x,y, tabCout, tabRes);}
		void deplacementNainInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes) {return algo->deplacementNainInitial(carte, taille, x,y, tabCout, tabRes);}
		void deplacementVikingInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes) {return algo->deplacementVikingInitial(carte, taille, x,y, tabCout, tabRes);}
	};
}
#endif