using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld
{
    public interface InterStrategieCarte
    {
        /// <remarks></remarks>
        void construire();
    }

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

        public abstract void construire();
    }

    public interface InterStrategieDemo : InterStrategieCarte
    {
        new void construire();
    }

    public interface InterStrategiePetite : InterStrategieCarte
    {
        new void construire();
    }

    public interface InterStrategieNormale : InterStrategieCarte
    {
        new void construire();
    }

    public class StrategieDemo : StrategieCarte, SmallWorld.InterStrategieDemo
    {
        public StrategieDemo()
        {
            throw new System.NotImplementedException();
        }

        public override void construire()
        {
            throw new NotImplementedException();
        }
    }

    public class StrategiePetite : StrategieCarte, SmallWorld.InterStrategiePetite
    {
        public StrategiePetite()
        {
            throw new System.NotImplementedException();
        }

        public override void construire()
        {
            throw new NotImplementedException();
        }
    }

    public class StrategieNormale : StrategieCarte, SmallWorld.InterStrategieNormale
    {
        public StrategieNormale()
        {
            throw new System.NotImplementedException();
        }

        public override void construire()
        {
            throw new NotImplementedException();
        }
    }

}
