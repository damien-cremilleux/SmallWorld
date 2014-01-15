/**
* @file Algo.h
* @brief Fichier d'entête pour les algo
*
* @author <a href="mailto:damien.cremilleux@insa-rennes.fr">Damien Crémilleux</a>
* @author <a href="mailto:lauriane.holy@insa-rennes.fr">Lauriane Holy</a>
* 
* @date 15/01/2014
* @version 0.1
*/
#ifdef WANTDLLEXP // exportation dll
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

class DLL Algo {
public:
	Algo() {}
	~Algo() {}

	/**
	* @fn genererCarte(int taille)
	* @brief génère une carte de la taille demandée
	*
	* @return int** la carte sous forme d'une matrice d'int
	*/
	int** genererCarte(int taille);

	/**
	* @fn placerJoueur(int * tabCarte, int taille)
	* @brief Suggère le placement des joueurs en début de partie
	*
	* @param int * <b>tabCarte</b> la carte sous forme de matrice d'int
	* @param int <b>taille</b> la taille de la carte
	* @return int *, un tableau contenant les coordonnées des deux joueurs
	*/
	int * placerJoueur(int * tabCarte, int taille);

	/**
	* @fn creerTab(int taille)
	* @brief Création d'un tableau int
	*
	* @param int <b>taille</b> le taille du tableau
	* @return int *, le tableau
	*/
	int * creerTab(int taille);

	/**
	* @fn creerTabDouble(int taille)
	* @brief Création d'un tableau de double
	*
	* @param int <b>taille</b> le taille du tableau
	* @return double *, le tableau
	*/
	double * creerTabDouble(int taille);

	/**
	* @fn libererTab()
	* @brief Libération du pointeur d'int
	*
	* @return void
	*/
	void Algo::libererTab(int * tab);

	/**
	* @fn libererTab()
	* @brief Libération du pointeur d'int
	*
	* @return void
	*/
	void Algo::libererTabDouble(double * tab);

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
	int caseBordEau(int * carte, int taille, int x, int y);

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
	void deplacementGauloisInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl);

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
	void deplacementGaulois(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl);

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
	void deplacementGaulois2(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl);

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
	void deplacementGauloisCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl);

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
	void deplacementNainInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl);

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
	void deplacementNain(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl);

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
	void deplacementNainCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl);

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
	void deplacementVikingInitial(int * carte, int taille, int x, int y, double * tabCout, int * tabRes, double pointDepl);

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
	void deplacementViking(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl);

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
	void deplacementVikingCase(int * carte, int taille, int x, int y, int * tabRes, double * tabDepl, double pointDepl);
};


EXTERNC DLL Algo* Algo_new();
EXTERNC DLL void Algo_delete(Algo* algo);
EXTERNC DLL int Algo_computeAlgo(Algo* algo);
EXTERNC DLL int Algo_genererCarte(Algo * algo);
EXTERNC DLL int Algo_placerJoueur(Algo * algo);
EXTERNC DLL int Algo_creerTab(Algo * algo);
EXTERNC DLL double Algo_creerTabDouble(Algo * algo);
EXTERNC DLL int Algo_caseBordEau(Algo * algo);
EXTERNC DLL void Algo_deplacementGauloisInitial(Algo * algo);
EXTERNC DLL void Algo_deplacementNainInitial(Algo * algo);
EXTERNC DLL void Algo_deplacementVikingInitial(Algo * algo);

