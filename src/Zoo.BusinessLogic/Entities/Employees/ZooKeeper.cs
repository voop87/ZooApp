using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class ZooKeeper : IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<string> AnimalExperience = new List<string>();
        public List<Food> AvailableFood { get; set; } = new List<Food>();

        public ZooKeeper(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddAnimalExperience(Animal animal)
        {
            if (!AnimalExperience.Contains(animal.GetType().ToString()))
            {
                AnimalExperience.Add(animal.GetType().ToString());
            }
        }

        public bool HasAnimalExperience(Animal animal)
        {
            foreach (string exp in AnimalExperience)
            {
                if (animal.GetType().ToString() == exp)
                {
                    return true;
                }
            }
            throw new NoNeededExperienceException();
        }

        public bool FeedAnimal(Animal animal, IConsole zooConsole = null)
        {
            if (HasAnimalExperience(animal) && (animal.IsHungry ||
                                                animal.FeedShedule.Count > 0 && animal.FeedShedule[0] > Convert.ToInt32(DateTime.Now.Hour) ||
                                                animal.FeedShedule[1] > Convert.ToInt32(DateTime.Now.Hour)))
            {
                foreach (var favoriteFood in animal.FavoriteFood)
                {
                    foreach (var availableFood in AvailableFood)
                    {
                        if (favoriteFood == availableFood.GetType().Name)
                        {
                            animal.Feed(availableFood);
                            FeedTime feedTime = new();
                            feedTime.TimeToFeed = DateTime.Now;
                            zooConsole?.WriteLine($"{animal.GetType().Name} was fed by {this.FirstName} {this.LastName} at {feedTime.TimeToFeed}");
                            feedTime.FedByZookeeper = this;
                            animal.FeedTimes.Add(feedTime);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
