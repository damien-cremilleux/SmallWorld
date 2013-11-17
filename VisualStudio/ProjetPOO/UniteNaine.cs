using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterUniteNaine : SmallWorld.InterUnite
    {
    }

    public class UniteNaine : Unite, InterUniteNaine
    {
        public void attaquer()
        {
            throw new NotImplementedException();
        }

        public void deplacer()
        {
            throw new NotImplementedException();
        }
    }
}
