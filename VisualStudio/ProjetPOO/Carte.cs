﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
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
