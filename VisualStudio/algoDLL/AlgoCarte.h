#ifdef WANTDLLEXP // exportation dll
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

class DLL AlgoCarte {
public:
	AlgoCarte() {}
	~AlgoCarte() {}
	int computeFoo();
	int** genererCarte(int taille);
	int * placerJoueur(int * tabCarte, int taille);
	int * creerTab(int taille);
};

// A ne pas implémenter dans le .h !
EXTERNC DLL AlgoCarte* Algo_new();
EXTERNC DLL void Algo_delete(AlgoCarte* algo);
EXTERNC DLL int Algo_computeAlgo(AlgoCarte* algo);
EXTERNC DLL int Algo_genererCarte(AlgoCarte * algo);
EXTERNC DLL int Algo_placerJoueur(AlgoCarte * algo);
EXTERNC DLL int Algo_creerTab(AlgoCarte * algo);