using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterJoueur
    {
    }

    public class Joueur : InterJoueur
    {
        public Joueur(string nomJoueur, Peuple peuple)
        {
            throw new System.NotImplementedException();
        }

        public Unite unite
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Peuple peuple
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int pointVictoire
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void calculerPointVictoire()
        {
            throw new System.NotImplementedException();
        }
    }
}
