using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterPlaine : InterCase
    {
    }

    public class Plaine : Case, InterPlaine
    {
        public Plaine()
        {
            throw new System.NotImplementedException();
        }
    }
}
