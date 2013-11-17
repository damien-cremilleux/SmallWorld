using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterForet : InterCase
    {
    }

    public class Foret : Case, InterForet
    {
    }
}
