using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface Sauvegarde
    {
        void charge();

        void enregistrer();
    }
}
