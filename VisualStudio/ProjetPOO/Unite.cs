using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterUnite
    {
        void attaquer();

        void deplacer();
    }

    public abstract class Unite : InterUnite
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
