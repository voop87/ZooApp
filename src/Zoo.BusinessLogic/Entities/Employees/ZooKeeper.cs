using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Entities.Animals.Birds;

namespace Zoo.BusinessLogic.Entities.Employees
{
    public class ZooKeeper : IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<string> AnimalExperience = new List<string>();

        public ZooKeeper(string firstName, string lastName){
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddAnimalExperience(Animal animal)
        {
            AnimalExperience.Add(animal.GetType().ToString());
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
    }
}
