﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface InterUniteGauloise : SmallWorld.InterUnite
    {
    }

    public class UniteGauloise : Unite, InterUniteGauloise
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
