using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterUniteViking : SmallWorld.InterUnite
    {
    }

    public class UniteViking : Unite, InterUniteViking
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
