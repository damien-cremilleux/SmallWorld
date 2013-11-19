using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterStrategieCarte
    {
        /// <remarks></remarks>
        void construire();
    }

    public interface InterCarte
    {
        void creerCarte();

        void definirStrategie();
    }

    public class Carte : InterCarte
    {
        public Carte()
        {
            throw new System.NotImplementedException();
        }
    
        public SmallWorld.StrategieCarte StrategieCarte
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Case Case
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public FabriqueCase FabriqueCase
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void creerCarte()
        {
            throw new NotImplementedException();
        }

        public void definirStrategie()
        {
            throw new NotImplementedException();
        }
    }

 
}
