using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Entities.Animals.Reptiles;
using Zoo.BusinessLogic.Entities.Animals.Mammals;
using Zoo.BusinessLogic.Entities.Animals.Birds;
using Zoo.BusinessLogic.Exceptions;

namespace Zoo.BusinessLogic.Entities.Animals.Reptiles
{
    public class Turtle : Reptile
    {
        public Turtle(int id = 2, bool isSick = false, bool isHungry = true)
        {
            ID = id;
            IsSick = isSick;
            FeedShedule = new List<int>();
            IsHungry = isHungry;
            FavoriteFood = "Grass";
            RequiredFeet = 5;
        }

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
