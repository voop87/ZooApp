using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Turtle : Reptile
    {
        public override int RequiredFeet { get; } = 5;
        public override string[] FavoriteFood { get; } = { "Grass" };

        public override bool IsFriendlyWith(Animal animal)
        {
            if (typeof(Bison) == animal.GetType() ||
                typeof(Parrot) == animal.GetType() ||
                typeof(Turtle) == animal.GetType() ||
                typeof(Elephant) == animal.GetType())
            {
                return true;
            }
            else
            {
                throw new NotFriendlyAnimalException();
            }
        }
    }
}
