using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Exceptions;

namespace Zoo.BusinessLogic.Entities.Animals.Reptiles
{
    public class Snake : Reptile
    {
        public Snake(int id = 2, bool isSick = false, bool isHungry = true)
        {
            ID = id;
            IsSick = isSick;
            FeedShedule = new List<int>();
            IsHungry = isHungry;
            FavoriteFood = "Meat";
            RequiredFeet = 2;
        }

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
