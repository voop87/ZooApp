using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Exceptions;

namespace Zoo.BusinessLogic.Entities.Animals.Mammals
{
    public class Bison : Mammal
    {
        public Bison(int id = 2, bool isSick = false, bool isHungry = true)
        {
            ID = id;
            IsSick = isSick;
            FeedShedule = new List<int>();
            IsHungry = isHungry;
            FavoriteFood = "Grass";
            RequiredFeet = 1000;
        }

        public override bool IsFriendlyWith(Animal animal)
        {
            if (typeof(Bison) == animal.GetType())
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
