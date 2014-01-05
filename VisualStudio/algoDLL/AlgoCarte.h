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
	double * creerTabDouble(int taille);
	void deplacementGauloisInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes);
	void deplacementGaulois(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl);
	void deplacementGauloisCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl);
    void deplacementNainInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes);
	void deplacementNain(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl);
	void deplacementNainCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl);
    void deplacementVikingInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes);
	void deplacementViking(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl);
	void deplacementVikingCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl);
};

// A ne pas implémenter dans le .h !
EXTERNC DLL AlgoCarte* Algo_new();
EXTERNC DLL void Algo_delete(AlgoCarte* algo);
EXTERNC DLL int Algo_computeAlgo(AlgoCarte* algo);
EXTERNC DLL int Algo_genererCarte(AlgoCarte * algo);
EXTERNC DLL int Algo_placerJoueur(AlgoCarte * algo);
EXTERNC DLL int Algo_creerTab(AlgoCarte * algo);
EXTERNC DLL double Algo_creerTabDouble(AlgoCarte * algo);
EXTERNC DLL void Algo_deplacementGauloisInitial(AlgoCarte * algo);
EXTERNC DLL void Algo_deplacementNainInitial(AlgoCarte * algo);
EXTERNC DLL void Algo_deplacementVikingInitial(AlgoCarte * algo);

