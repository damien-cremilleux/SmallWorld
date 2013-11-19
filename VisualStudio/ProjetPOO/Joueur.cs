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
        public Joueur()
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

        public void creerJoueur()
        {
            throw new System.NotImplementedException();
        }
    }
}
