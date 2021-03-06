using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Lion : Mammal
    {
        public override int RequiredFeet { get; } = 1000;
        public override string[] FavoriteFood { get; } = { "Meat" };

        public override bool IsFriendlyWith(Animal animal)
        {
            if (typeof(Lion) == animal.GetType())
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
