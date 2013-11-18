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
        public UniteViking()
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
