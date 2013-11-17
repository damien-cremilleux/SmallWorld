using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterMontagne : InterCase
    {
    }

    public class Montagne : Case, InterMontagne
    {
    }
}
