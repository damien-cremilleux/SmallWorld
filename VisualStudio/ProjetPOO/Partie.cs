using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterPartie
    {
    }

    public class Partie : InterPartie
    {
        public Joueur Joueur
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Carte Carte
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
