using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterFabriqueCase
    {
        void obtenirEau();

        void obtenirMontagne();

        void obtenirDesert();

        void obtenirPlaine();

        void obtenirForet();

        void obtenirCase();
    }

    public class FabriqueCase : InterFabriqueCase
    {
        public Foret Foret
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Plaine Plaine
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Desert Desert
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Montagne Montagne
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Eau Eau
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void obtenirEau()
        {
            throw new NotImplementedException();
        }

        public void obtenirMontagne()
        {
            throw new NotImplementedException();
        }

        public void obtenirDesert()
        {
            throw new NotImplementedException();
        }

        public void obtenirPlaine()
        {
            throw new NotImplementedException();
        }

        public void obtenirForet()
        {
            throw new NotImplementedException();
        }

        public void obtenirCase()
        {
            throw new NotImplementedException();
        }
    }

}
