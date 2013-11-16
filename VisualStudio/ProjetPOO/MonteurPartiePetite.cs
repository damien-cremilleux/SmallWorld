using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code_SmallWorld
{
    public interface InterMonteurPartiePetite : Code_SmallWorld.InterMonteurPartie
    {
        void ajouterPeuple();
    }

    public class MonteurPartiePetite : MonteurPartie, InterMonteurPartiePetite
    {
        public void ajouterPeuple()
        {
            throw new NotImplementedException();
        }

        public Code_SmallWorld.Partie creerPartie()
        {
            throw new NotImplementedException();
        }

        public void ajouterCarte()
        {
            throw new NotImplementedException();
        }

        public void ajouterJoueur()
        {
            throw new NotImplementedException();
        }

        public void placerUnites()
        {
            throw new NotImplementedException();
        }
    }
}
