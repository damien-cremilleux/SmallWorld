using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterFabriqueCase
    {
        Case obtenirEau();

        Case obtenirMontagne();

        Case obtenirDesert();

        Case obtenirPlaine();

        Case obtenirForet();

        Case obtenirCase(int typeCase);
    }

    public class FabriqueCase : InterFabriqueCase
    {
        private static FabriqueCase instance_FabCase;

        private Desert desert;
        private Eau eau;
        private Foret foret;
        private Montagne montagne;
        private Plaine plaine;


        public static FabriqueCase Instance_FabCase
        {
            get
            {
                if (instance_FabCase == null)
                {
                    instance_FabCase = new FabriqueCase();
                }
                return instance_FabCase;
            }
        }

        private FabriqueCase()
        {
            desert = new Desert();
            eau = new Eau();
            foret = new Foret();
            montagne = new Montagne();
            plaine = new Plaine();
        }


        public Desert Desert
        {
            get
            {
                return desert;
            }
            set
            {
            }
        }


        public Eau Eau
        {
            get
            {
                return eau;
            }
            set
            {
            }
        }
        public Foret Foret
        {
            get
            {
                return foret;
            }
            set
            {
            }
        }



        public Montagne Montagne
        {
            get
            {
                return montagne;
            }
            set
            {
            }
        }

        public Plaine Plaine
        {
            get
            {
                return plaine;
            }
            set
            {
            }
        }

        public Case obtenirDesert()
        {
            return Desert;
        }

        public Case obtenirEau()
        {
            return Eau;
        }

        public Case obtenirForet()
        {
            return Foret;
        }


        public Case obtenirMontagne()
        {
            return Montagne;
        }


        public Case obtenirPlaine()
        {
            return Plaine;
        }

        public int obtenirInt(int test)
        {
            return test;
        }

        public Case obtenirCase(int typeCase)
        {
            switch (typeCase)
            {
                case 1:
                    return Desert;
       
                case 2:
                    return Eau;
          
                case 3:
                    return Foret;
     
                case 4:
                    return Montagne;
         
                case 5:
                    return Plaine;
              
                default:
                    return null; /* TODO */
            }
        }

    }
}
