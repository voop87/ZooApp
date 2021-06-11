using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.BusinessLogic;

namespace Zoo.ConsoleApp
{
    public class RunZooApp
    {
        public static void RunZoo()
        {

            BusinessLogic.Zoo zoo1 = new BusinessLogic.Zoo("zoo-1", new MockConsole());
            BusinessLogic.Zoo zoo2 = new BusinessLogic.Zoo("zoo-2", new MockConsole());
            ZooApp.AddZoo(zoo1);
            ZooApp.AddZoo(zoo2);

            zoo1.AddEnclosure("lions", 10000);
            zoo1.AddEnclosure("snakes", 100);
            zoo1.AddEnclosure("birds", 100);
            zoo1.AddEnclosure("others", 10000);
            zoo1.AddEnclosure("others2", 10000);

            zoo2.AddEnclosure("lions", 10000);
            zoo2.AddEnclosure("snakes", 100);
            zoo2.AddEnclosure("birds", 100);
            zoo2.AddEnclosure("others", 10000);
            zoo2.AddEnclosure("others2", 10000);

            Lion lion1 = new();
            Snake snake1 = new();
            Elephant elephant1 = new();
            Bison bison1 = new();
            Parrot parrot1 = new();
            Penguin penguin1 = new();
            Turtle turtle1 = new();

            Lion lion2 = new();
            Snake snake2 = new();
            Elephant elephant2 = new();
            Bison bison2 = new();
            Parrot parrot2 = new();
            Penguin penguin2 = new();
            Turtle turtle2 = new();

            List<int> hours = new List<int>();
            hours.Add(8);
            hours.Add(16);

            lion1.AddFeedShedule(hours);
            snake1.AddFeedShedule(hours);
            elephant1.AddFeedShedule(hours);
            bison1.AddFeedShedule(hours);
            parrot1.AddFeedShedule(hours);
            penguin1.AddFeedShedule(hours);
            turtle1.AddFeedShedule(hours);

            lion2.AddFeedShedule(hours);
            snake2.AddFeedShedule(hours);
            elephant2.AddFeedShedule(hours);
            bison2.AddFeedShedule(hours);
            parrot2.AddFeedShedule(hours);
            penguin2.AddFeedShedule(hours);
            turtle2.AddFeedShedule(hours);


            zoo1.FindAvailableEnclosure(lion1).AddAnimals(lion1);
            zoo1.FindAvailableEnclosure(snake1).AddAnimals(snake1);
            zoo1.FindAvailableEnclosure(elephant1).AddAnimals(elephant1);
            zoo1.FindAvailableEnclosure(bison1).AddAnimals(bison1);
            zoo1.FindAvailableEnclosure(parrot1).AddAnimals(parrot1);
            zoo1.FindAvailableEnclosure(penguin1).AddAnimals(penguin1);
            zoo1.FindAvailableEnclosure(turtle1).AddAnimals(turtle1);

            zoo2.FindAvailableEnclosure(lion2).AddAnimals(lion2);
            zoo2.FindAvailableEnclosure(snake2).AddAnimals(snake2);
            zoo2.FindAvailableEnclosure(elephant2).AddAnimals(elephant2);
            zoo2.FindAvailableEnclosure(bison2).AddAnimals(bison2);
            zoo2.FindAvailableEnclosure(parrot2).AddAnimals(parrot2);
            zoo2.FindAvailableEnclosure(penguin2).AddAnimals(penguin2);
            zoo2.FindAvailableEnclosure(turtle2).AddAnimals(turtle2);

            ZooKeeper zooKeeper1 = new ZooKeeper("keeper", "1");
            ZooKeeper zooKeeper2 = new ZooKeeper("keeper", "2");
            ZooKeeper zooKeeper3 = new ZooKeeper("keeper", "3");
            ZooKeeper zooKeeper4 = new ZooKeeper("keeper", "4");

            zooKeeper1.AddAnimalExperience(lion1);
            zooKeeper1.AddAnimalExperience(snake1);
            zooKeeper1.AddAnimalExperience(elephant1);
            zooKeeper1.AddAnimalExperience(bison1);
            zooKeeper1.AddAnimalExperience(parrot2);
            zooKeeper1.AddAnimalExperience(penguin2);
            zooKeeper1.AddAnimalExperience(turtle2);

            zooKeeper2.AddAnimalExperience(parrot2);
            zooKeeper2.AddAnimalExperience(penguin2);
            zooKeeper2.AddAnimalExperience(turtle2);
            zooKeeper2.AddAnimalExperience(bison1);
            zooKeeper2.AddAnimalExperience(lion1);
            zooKeeper2.AddAnimalExperience(snake1);
            zooKeeper2.AddAnimalExperience(elephant1);

            zooKeeper3.AddAnimalExperience(lion2);
            zooKeeper3.AddAnimalExperience(snake2);
            zooKeeper3.AddAnimalExperience(elephant1);
            zooKeeper3.AddAnimalExperience(bison1);
            zooKeeper3.AddAnimalExperience(parrot2);
            zooKeeper3.AddAnimalExperience(penguin2);
            zooKeeper3.AddAnimalExperience(turtle2);

            zooKeeper4.AddAnimalExperience(lion2);
            zooKeeper4.AddAnimalExperience(snake2);
            zooKeeper4.AddAnimalExperience(elephant1);
            zooKeeper4.AddAnimalExperience(bison1);
            zooKeeper4.AddAnimalExperience(parrot2);
            zooKeeper4.AddAnimalExperience(penguin2);
            zooKeeper4.AddAnimalExperience(turtle2);

            Veterinarian veterinarian1 = new Veterinarian("vet", "1");
            Veterinarian veterinarian2 = new Veterinarian("vet", "2");
            Veterinarian veterinarian3 = new Veterinarian("vet", "3");
            Veterinarian veterinarian4 = new Veterinarian("vet", "4");
            veterinarian1.AvailableMedicine.Add(new Antibiotics());
            veterinarian1.AvailableMedicine.Add(new AntiDepression());
            veterinarian1.AvailableMedicine.Add(new AntiInflammatory());

            veterinarian2.AvailableMedicine.Add(new Antibiotics());
            veterinarian2.AvailableMedicine.Add(new AntiDepression());
            veterinarian2.AvailableMedicine.Add(new AntiInflammatory());

            veterinarian3.AvailableMedicine.Add(new Antibiotics());
            veterinarian3.AvailableMedicine.Add(new AntiDepression());
            veterinarian3.AvailableMedicine.Add(new AntiInflammatory());

            veterinarian4.AvailableMedicine.Add(new Antibiotics());
            veterinarian4.AvailableMedicine.Add(new AntiDepression());
            veterinarian4.AvailableMedicine.Add(new AntiInflammatory());

            veterinarian1.AnimalExperience.Add(lion1.GetType().Name);
            veterinarian1.AnimalExperience.Add(snake1.GetType().Name);
            veterinarian1.AddAnimalExperience(elephant1);
            veterinarian1.AddAnimalExperience(bison1);
            veterinarian1.AddAnimalExperience(parrot2);
            veterinarian1.AddAnimalExperience(penguin2);
            veterinarian1.AddAnimalExperience(turtle2);

            veterinarian2.AnimalExperience.Add(lion1.GetType().Name);
            veterinarian2.AnimalExperience.Add(snake1.GetType().Name);
            veterinarian2.AddAnimalExperience(elephant1);
            veterinarian2.AddAnimalExperience(bison1);
            veterinarian2.AddAnimalExperience(parrot2);
            veterinarian2.AddAnimalExperience(penguin2);
            veterinarian2.AddAnimalExperience(turtle2);

            veterinarian3.AnimalExperience.Add(lion2.GetType().Name);
            veterinarian3.AnimalExperience.Add(snake2.GetType().Name);
            veterinarian3.AddAnimalExperience(elephant1);
            veterinarian3.AddAnimalExperience(bison1);
            veterinarian3.AddAnimalExperience(parrot2);
            veterinarian3.AddAnimalExperience(penguin2);
            veterinarian3.AddAnimalExperience(turtle2);

            veterinarian4.AnimalExperience.Add(lion2.GetType().Name);
            veterinarian4.AnimalExperience.Add(snake2.GetType().Name);
            veterinarian4.AddAnimalExperience(elephant1);
            veterinarian4.AddAnimalExperience(bison1);
            veterinarian4.AddAnimalExperience(parrot2);
            veterinarian4.AddAnimalExperience(penguin2);
            veterinarian4.AddAnimalExperience(turtle2);

            zoo1.HireEmployee(zooKeeper1);
            zoo1.HireEmployee(zooKeeper2);
            zoo1.HireEmployee(veterinarian1);
            zoo1.HireEmployee(veterinarian2);

            zoo2.HireEmployee(zooKeeper3);
            zoo2.HireEmployee(zooKeeper4);
            zoo2.HireEmployee(veterinarian3);
            zoo2.HireEmployee(veterinarian4);

            zoo1.FeedAnimals();
            zoo1.HealAnimals();

            zoo2.FeedAnimals();
            zoo2.HealAnimals();

        }
    }
}
