using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterPeupleGaulois : InterPeuple
    {
    }

    public class PeupleGaulois : Peuple, InterPeupleGaulois
    {
        public PeupleGaulois()
        {
            throw new System.NotImplementedException();
        }
    
        public InterUnite creerUnite()
        {
            throw new NotImplementedException();
        }
    }
}
