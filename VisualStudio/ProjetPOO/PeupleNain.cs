using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterPeupleNain : InterPeuple
    {
    }

    public class PeupleNain : Peuple, InterPeupleNain
    {
        public InterUnite creerUnite()
        {
            throw new NotImplementedException();
        }
    }
}
