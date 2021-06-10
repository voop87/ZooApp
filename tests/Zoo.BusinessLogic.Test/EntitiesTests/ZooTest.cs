using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test
{
    public class ZooTest
    {
        /*
        [Fact]
        public void ShouldCreateZoo()
        {
            Zoo zoo = new Zoo();
        }

        [Fact]
        public void ShouldGetLocation()
        {
            Zoo zoo = new Zoo();
            string location = zoo.Location;
            Assert.Equal("Zoo", location);
        }

        [Fact]
        public void ShouldGetEnclosuresList()
        {
            Zoo zoo = new Zoo();
            List<Enclosure> enclosures = zoo.Enclosures;
            Assert.Empty(enclosures);
        }

        [Fact]
        public void ShouldAddEnclosure()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Enclosure-1", 100);
            List<Enclosure> enclosures = zoo.Enclosures;
            Assert.Equal("Enclosure-1", enclosures[0].Name);
            Assert.Equal(100, enclosures[0].SqureFeet);
        }*/
        [Fact]
        public void ShoulBeAbleToCreateZoo()
        {
            Zoo zoo = new Zoo();
        }

        [Fact]
        public void ShoulBeAbleToGetIdForAnimals()
        {
            Zoo zoo = new Zoo();
            Assert.Equal(1, zoo.StartingId);

        }

        [Fact]
        public void ShoulBeAbleToCreateZooWithLocation()
        {
            Zoo zoo = new Zoo("Zoo-1");
        }

        [Fact]
        public void ShoulBeAbleToGetEnclosures()
        {
            Zoo zoo = new Zoo();
            List<Enclosure> enclosures = zoo.Enclosures;
            Assert.Equal(enclosures, zoo.Enclosures);
        }

        [Fact]
        public void ShoulBeAbleToGetEmployees()
        {
            Zoo zoo = new Zoo();
            List<IEmployee> employees = zoo.Employees;
            Assert.Equal(employees, zoo.Employees);
        }

        [Fact]
        public void ShoulBeAbleToGetLocation()
        {
            Zoo zoo = new Zoo();
            string zooLoczation = zoo.Location;
        }

        [Fact]
        public void ShoulBeAbleToAddLocation()
        {
            Zoo zoo = new Zoo();
            string location = "Zoo-2";
            zoo.AddLocation(location);
            Assert.Equal(location, zoo.Location);
        }

        [Fact]
        public void ShoulBeAbleToAddEnclosure()
        {
            Zoo zoo = new Zoo();
            zoo.AddEnclosure("Lions Enclosure", 5000);

            Enclosure enclosure = zoo.Enclosures[0];
            string enclosureName = enclosure.Name;
            int enclosureArea = enclosure.SqureFeet;

            Assert.Equal("Lions Enclosure", enclosureName);
            Assert.Equal(5000, enclosureArea);
        }


        [Fact]
        public void ShoulBeAbleToFindAvailableEnclosure()
        {
            Zoo zoo = new Zoo();
            Lion lion = new Lion();
            zoo.AddEnclosure("enclosure for lion", 10000);
            Enclosure enclosureForLion = zoo.FindAvailableEnclosure(lion);

            Assert.Equal(enclosureForLion, zoo.Enclosures[0]);
            enclosureForLion.AddAnimals(lion);
            Assert.Single(enclosureForLion.Animals);

        }

        [Fact]
        public void ShouldThrowExeptionIfEnclosureNotFound()
        {
            Zoo zoo = new();
            Lion lion = new();

            Assert.Throws<NoAvailableEnclosureException>(() => {
                zoo.FindAvailableEnclosure(lion);
            });
        }

        [Fact]
        public void ShouldNotBeAbleToHireZooKeeperWithoutExpirience()
        {
            Zoo zoo = new();
            zoo.AddEnclosure("new enclosure", 10000);
            Elephant elephant = new Elephant();
            Enclosure newEnclousure = zoo.FindAvailableEnclosure(elephant);
            newEnclousure.AddAnimals(elephant);
            IEmployee zooKeeper = new ZooKeeper("First Name", "Last Name");

            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(zooKeeper));

        }

        [Fact]
        public void ShouldNotBeAbleToHireVeterinarianWithoutExpirience()
        {
            Zoo zoo = new();
            zoo.AddEnclosure("new enclosure", 10000);
            zoo.AddEnclosure("another enclosure", 10000);
            Elephant elephant = new Elephant();
            Bison bison = new();
            Enclosure newEnclousure = zoo.FindAvailableEnclosure(elephant);
            Enclosure anotherEnclousure = zoo.FindAvailableEnclosure(bison);
            newEnclousure.AddAnimals(elephant);
            anotherEnclousure.AddAnimals(bison);
            Veterinarian veterinarian = new Veterinarian("First Name", "Last Name");
            veterinarian.AddAnimalExperience(new Elephant());

            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(veterinarian));
        }
        /*
        [Fact]
        public void ShouldBeAbleToHireExpiriencedZooKeeper()
        {
            Zoo zoo = new();
            Bison bison = new Bison();
            zoo.AddEnclosure("new enclosure", 10000);
            Enclosure newEnclosure = zoo.FindAvailableEnclosure(bison);
            newEnclosure.AddAnimals(bison);
            ZooKeeper zooKeeper = new("First Name", "Last Name");
            zooKeeper.AddAnimalExperience(new Bison());
            zoo.HireEmployee(zooKeeper);

            Assert.Equal(zooKeeper, zoo.Employees[0]);
        }

        [Fact]
        public void ShouldBeAbleToHireExpiriencedVeterinarian()
        {
            Zoo zoo = new();
            Bison bison = new Bison();
            zoo.AddEnclosure("new enclosure", 10000);
            Enclosure newEnclosure = zoo.FindAvailableEnclosure(bison);
            newEnclosure.AddAnimals(bison);
            Veterinarian veterinarian = new("First Name", "Last Name");
            veterinarian.AddAnimalExperience(new Bison());
            zoo.HireEmployee(veterinarian);

            Assert.Equal(veterinarian, zoo.Employees[0]);
        }
        */
        [Fact]
        public void ShouldBeAbleToFeedAllAnimals()
        {
            Zoo zoo = new();
            zoo.AddEnclosure("Lions enclosure", 10000);
            Lion lion = new();
            ZooKeeper zooKeeper = new("John", "Doe");
            zooKeeper.AvailableFood.Add(new Grass());
            zooKeeper.AvailableFood.Add(new Vegetables());
            zooKeeper.AvailableFood.Add(new Meat());
            zooKeeper.AddAnimalExperience(lion);

            zoo.HireEmployee(zooKeeper);

            lion.IsHungry = true;

            zoo.FindAvailableEnclosure(lion).AddAnimals(lion);
            zoo.FeedAnimals();

            Assert.False(lion.IsHungry);
        }

        [Fact]
        public void ShouldBeAbleToHealAllAnimals()
        {
            Zoo zoo = new();
            zoo.AddEnclosure("Lions enclosure", 10000);

            Lion lion = new();

            Veterinarian veterinarian = new("John", "Doe");

            veterinarian.AvailableMedicine.Add(new Antibiotics());
            veterinarian.AvailableMedicine.Add(new AntiDepression());
            veterinarian.AvailableMedicine.Add(new AntiInflammatory());
            veterinarian.AddAnimalExperience(lion);

            zoo.HireEmployee(veterinarian);

            lion.IsSick = true;

            zoo.FindAvailableEnclosure(lion).AddAnimals(lion);
            zoo.HealAnimals();

            Assert.False(lion.IsSick);
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsAreZooKeepersHired()
        {
            Zoo zoo = new();
            zoo.Employees.Add(new Veterinarian("", ""));

            Assert.Throws<NoNeededEmployeeException>(() => zoo.FeedAnimals());
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsAreNoVeterinariansHired()
        {
            Zoo zoo = new();
            zoo.Employees.Add(new ZooKeeper("", ""));

            Assert.Throws<NoNeededEmployeeException>(() => zoo.HealAnimals());
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsAreNoEmployeesThenTryingToFeedAnimals()
        {
            Zoo zoo = new();
            Assert.Throws<NoEmployeesException>(() => zoo.FeedAnimals());
        }

        [Fact]
        public void ShouldThrowExceptionIfThereIsAreNoEmployeesThenTryingToHealAnimals()
        {
            Zoo zoo = new();
            Assert.Throws<NoEmployeesException>(() => zoo.HealAnimals());
        }
    }
}
