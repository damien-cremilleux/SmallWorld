using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    public interface Fabrique_Unite_Gaulois : InterFabriquePeuple
    {
    }

    public class FabriquePeuple : InterFabriquePeuple
    {
        public FabriquePeuple()
        {
            throw new System.NotImplementedException();
        }
    
        public Peuple Peuple
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void fabriquerPeuple()
        {
            throw new NotImplementedException();
        }
    }
}
