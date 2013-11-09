using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface FabriqueJeu
    {
        void creerPartie();

        void creerJoueur(string nomJoueur, string Peuple);

        void chargerPartie();
    }
}
