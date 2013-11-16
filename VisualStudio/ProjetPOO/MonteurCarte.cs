using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code_SmallWorld
{
    public interface InterMonteurPartie
    {

        Partie creerPartie();

        void ajouterCarte();

        void ajouterJoueur();

        void placerUnites();
    }
}
