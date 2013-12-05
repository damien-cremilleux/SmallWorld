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
        public UniteNaine()
        {
            throw new System.NotImplementedException();
        }
    
     }
}
