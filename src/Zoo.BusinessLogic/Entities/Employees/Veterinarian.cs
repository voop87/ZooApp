using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Veterinarian : IEmployee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<string> AnimalExperience = new List<string>();
        public List<Medicine> AvailableMedicine { get; set; } = new List<Medicine>();

        public Veterinarian(string firstName, string lastName)
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

        public bool HealAnimal(Animal animal)
        {
            if (HasAnimalExperience(animal) && animal.IsSick)
            {
                foreach (var medicine in AvailableMedicine)
                {
                    if (medicine.GetType().Name == animal.NeededMedicine)
                    {
                        animal.Heal(medicine);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
