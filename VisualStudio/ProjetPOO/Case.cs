using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterCase
    {
    }

    public abstract class Case : InterCase
    {
    }

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

    public interface InterForet : InterCase
    {
    }

    public class Foret : Case, InterForet
    {
        public Foret()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface InterMontagne : InterCase
    {
    }

    public class Montagne : Case, InterMontagne
    {
        public Montagne()
        {
            throw new System.NotImplementedException();
        }
    }

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
