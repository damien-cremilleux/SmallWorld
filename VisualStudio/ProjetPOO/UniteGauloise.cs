using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterUniteGauloise : SmallWorld.InterUnite
    {
    }

    public class UniteGauloise : Unite, InterUniteGauloise
    {
        public UniteGauloise()
        {
            throw new System.NotImplementedException();
        }
    
        public void attaquer()
        {
            throw new NotImplementedException();
        }

        public void seDeplacer()
        {
            throw new NotImplementedException();
        }

        public void passerSonTour()
        {
            throw new System.NotImplementedException();
        }
    }
}
