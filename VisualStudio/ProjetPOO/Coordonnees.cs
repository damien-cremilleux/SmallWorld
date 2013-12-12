using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public class Coordonnees
    {
        private int abscisse;
        private int ordonnee;

        public int Abscisse
        {
            get
            {
                return abscisse;
            }
            set
            {
                if (value > 0)
                {
                    abscisse = value;
                }
            }
        }

        public int Ordonnee
        {
            get
            {
                return ordonnee;
            }
            set
            {
                if (value > 0)
                {
                    ordonnee = value;
                }
            }
        }

        public Coordonnees(int abs, int ord)
        {
            this.abscisse = abs;
            this.ordonnee = ord;
        }
    }
}
