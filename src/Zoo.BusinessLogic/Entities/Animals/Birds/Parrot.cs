using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Parrot : Bird
    {
        public override int RequiredFeet { get; } = 5;
        public override string[] FavoriteFood { get; } = { "Vegetable" };

        public override bool IsFriendlyWith(Animal animal)
        {
            if (typeof(Elephant) == animal.GetType() ||
                typeof(Bison) == animal.GetType() ||
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
