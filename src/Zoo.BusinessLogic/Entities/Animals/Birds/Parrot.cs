using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Exceptions;
using Zoo.BusinessLogic.Entities.Animals.Mammals;
using Zoo.BusinessLogic.Entities.Animals.Reptiles;

namespace Zoo.BusinessLogic.Entities.Animals.Birds
{
    public class Parrot : Bird
    {
        public Parrot(int id = 2, bool isSick = false, bool isHungry = true)
        {
            ID = id;
            IsSick = isSick;
            FeedShedule = new List<int>();
            IsHungry = isHungry;
            FavoriteFood = "Vegetables";
            RequiredFeet = 5;
        }

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
                throw new NotFriendlyAnimalException();
            }
        }
    }
}
