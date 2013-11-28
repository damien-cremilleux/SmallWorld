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
		int * placerJoueur(int ** tabCarte, int taille) { return algo->placerJoueur(tabCarte,taille);}
	};
}
#endif