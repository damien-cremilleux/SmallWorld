using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterEau : InterCase
    {
    }

    public class Eau : Case, InterEau
    {
        public Eau()
        {
            throw new System.NotImplementedException();
        }
    }
}
