using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Snake : Reptile
    {
        public override int RequiredFeet { get; } = 2;
        public override string[] FavoriteFood { get; } = { "Meat" };

        public override bool IsFriendlyWith(Animal animal)
        {
            if (typeof(Snake) == animal.GetType())
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
