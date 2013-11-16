using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code_SmallWorld
{
    public interface FabriqueCase
    {
        void obtenirEau();

        void obtenirMontagne();

        void obtenirDesert();

        void obtenirPlaine();

        void obtenirForet();

        void obtenirCase();
    }
}
