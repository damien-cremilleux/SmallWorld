using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{


    public interface InterCarte
    {
        void creerCarte();

        void definirStrategie();
    }

    public class Carte : InterCarte
    {

        private List<List<Case>> listeCases;
    
        
        public Carte( List<List<Case>> listeC)
        {
            listeCases = listeC;
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

        public List<List<Case>> ListeCases
        {
            get
            {
                return listeCases;
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
