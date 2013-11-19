using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterDesert : InterCase
    {
    }

    public class Desert : Case, InterDesert
    {
        public Desert()
        {
            throw new System.NotImplementedException();
        }
    }
}
