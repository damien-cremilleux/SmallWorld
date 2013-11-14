using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public interface MonteurPartie
    {

        Partie creerPartie();

        void ajouterCarte();

        void ajouterJoueur();

        void placerUnites();
    }
}
