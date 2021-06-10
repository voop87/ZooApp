using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Enclosure
    {
        public Zoo ParentZoo { get; private set; }
        public string Name { get; private set; }
        public int SqureFeet { get; private set; }
        public List<Animal> Animals { get; private set; } = new List<Animal>();

        public Enclosure(Zoo parentZoo, string name, int squreFeet)
        {
            ParentZoo = parentZoo;
            Name = name;
            SqureFeet = squreFeet;
        }

        public void AddAnimals(Animal animal)
        {
            if (SqureFeet >= animal.RequiredFeet)
            {
                foreach (var creature in Animals)
                {
                    if (!creature.IsFriendlyWith(animal))
                    {
                        throw new NotFriendlyAnimalException();
                    }
                }
                Animals.Add(animal);
                animal.ID = ParentZoo.StartingId;
                ParentZoo.StartingId++;
                SqureFeet -= animal.RequiredFeet;
            }
            else
            {
                throw new NoAvailableSpaceException();
            }
        }

        public bool IsFriendlyTo(Animal animal)
        {
            foreach (var creature in Animals)
            {
                if (!creature.IsFriendlyWith(animal))
                {
                    throw new NotFriendlyAnimalException();
                }
            }
            return true;
        }
    }
}
