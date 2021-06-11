using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Bison : Mammal
    {
        public override int RequiredFeet { get; } = 1000;

        public override string[] FavoriteFood { get; } = { "Grass" };

        public override bool IsFriendlyWith(Animal animal)
        {
            if (typeof(Elephant) == animal.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
