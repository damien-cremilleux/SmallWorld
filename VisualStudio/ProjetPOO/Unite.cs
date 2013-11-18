using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterUnite
    {
        void attaquer();

        void seDeplacer();

        void passerSonTour();
    }

    public abstract class Unite : InterUnite
    {

        public int position
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int pointDeVie
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int pointDeDeplacement
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int pointDeVictoire
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int pointAttaque
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int pointDefense
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int passeSonTour
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void attaquer()
        {
            throw new NotImplementedException();
        }

        public void seDeplacer()
        {
            throw new NotImplementedException();
        }


        public void passerSonTour()
        {
            throw new NotImplementedException();
        }

        public void perdreVie()
        {
            throw new System.NotImplementedException();
        }

        public void mourir()
        {
            throw new System.NotImplementedException();
        }
    }

   
}
