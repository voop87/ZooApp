using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic
{
    public class Enclosure
    {
        public static string ParentZoo { get; private set; } = "Zoo";
        public string Name { get; private set; }
        public int SqureFeet { get; private set; }
        public static List<Animal> Animals { get; private set; } = new List<Animal>();

        public Enclosure(string name, int squreFeet)
        {
            Name = name;
            SqureFeet = squreFeet;
        }

        public static void AddAnimals(Animal animal)
        {
            Animals.Add(animal);
        }
    }
}
