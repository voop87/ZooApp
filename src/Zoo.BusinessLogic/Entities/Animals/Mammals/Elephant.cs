using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Elephant : Mammal
    {
        public override int RequiredFeet { get; } = 1000;

        public override string[] FavoriteFood { get; } = { "Vegetables" };

        public override bool IsFriendlyWith(Animal animal)
        {
            if (typeof(Bison) == animal.GetType() ||
                typeof(Parrot) == animal.GetType() ||
                typeof(Turtle) == animal.GetType())
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
