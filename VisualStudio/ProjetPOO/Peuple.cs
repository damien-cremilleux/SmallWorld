using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterPeuple
    {
    
        InterUnite creerUnite();
    }

    public abstract class Peuple : InterPeuple
    {
        public InterUnite creerUnite()
        {
            throw new NotImplementedException();
        }
    }
}
