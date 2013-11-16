using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code_SmallWorld
{
    public interface StrategieCarte
    {
        /// <remarks></remarks>
        void construire();
    }

    public interface Carte
    {
        void creerCarte();

        void definirStrategie();
    }

 
}
