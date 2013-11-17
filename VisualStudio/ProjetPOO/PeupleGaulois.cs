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
        public InterUnite creerUnite()
        {
            throw new NotImplementedException();
        }
    }
}
