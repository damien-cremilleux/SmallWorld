using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterPeupleViking : InterPeuple
    {
    }

    public class PeupleViking : Peuple, InterPeupleViking
    {
        public PeupleViking()
        {
           // throw new System.NotImplementedException();
        }
    
        /*new public InterUnite creerUnite()
        {
            //throw new NotImplementedException();
        }*/
    }
}
