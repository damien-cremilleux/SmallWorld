using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public abstract class StrategieCarte : SmallWorld.InterStrategieCarte
    {
        public int position
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void construire()
        {
            throw new NotImplementedException();
        }
    }
}
