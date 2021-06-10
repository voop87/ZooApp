using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Penguin : Bird
    {
        public override int RequiredFeet { get; } = 10;

        public override string[] FavoriteFood { get; } = { "Meat" };

        public override bool IsFriendlyWith(Animal animal)
        {
            if (typeof(Penguin) == animal.GetType())
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
