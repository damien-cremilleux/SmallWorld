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
        private int joueurEnCours;
    
        public Partie()
        {
            throw new System.NotImplementedException();
        }
    
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

        public int nbTourRestant
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void nouveauTour()
        {
            throw new System.NotImplementedException();
        }

        public void selectionnerUnite()
        {
            throw new System.NotImplementedException();
        }

        public void demanderDeplacement()
        {
            throw new System.NotImplementedException();
        }

        public void validerTour()
        {
            throw new System.NotImplementedException();
        }
    }
}
