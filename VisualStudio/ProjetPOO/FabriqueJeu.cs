using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code_SmallWorld
{
    public interface FabriqueJeu
    {
        void creerPartie();

        void creerJoueur(string nomJoueur, string Peuple);

        void chargerPartie();
    }
}
