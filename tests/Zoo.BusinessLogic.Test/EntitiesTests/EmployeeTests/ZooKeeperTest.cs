using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test.EntitiesTests.EmployeeTests
{
    public class ZooKeeperTest
    {
        /*
        [Fact]
        public void ShouldGetZooKeeperState()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Vasya", "Petrov");
            Assert.Equal("Vasya", zooKeeper.FirstName);
            Assert.Equal("Petrov", zooKeeper.LastName);
        }

        [Fact]
        public void ShouldBeAbleToAddExperience()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Vasya", "Petrov");
            Parrot parrot = new Parrot();
            zooKeeper.AddAnimalExperience(parrot);
            Assert.Equal(typeof(Parrot).ToString(), zooKeeper.AnimalExperience[0]);
        }

        [Fact]
        public void ShouldHasExperience()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Vasya", "Petrov");
            Parrot parrot = new Parrot();
            zooKeeper.AddAnimalExperience(parrot);
            Assert.True(zooKeeper.HasAnimalExperience(parrot));
        }
        [Fact]
        public void ShouldHasNoExperience()
        {
            ZooKeeper zooKeeper = new ZooKeeper("Vasya", "Petrov");
            Parrot parrot = new Parrot();
            Penguin penguin = new Penguin();
            Assert.Throws<NoNeededExperienceException>(() => {
                zooKeeper.HasAnimalExperience(parrot);
            });

            zooKeeper.AddAnimalExperience(penguin);
            Assert.Throws<NoNeededExperienceException>(() => {
                zooKeeper.HasAnimalExperience(parrot);
            });
        }
        */

        [Fact]
        public void ShouldBeAbleToCreateZooKeeper()
        {
            ZooKeeper zooKeeper = new ZooKeeper("First Name", "Last Name");

        }

        [Fact]
        public void ShouldBeAbleToGetZooKeeperNames()
        {
            ZooKeeper zooKeeper = new ZooKeeper("First Name", "Last Name");

            string firstName = zooKeeper.FirstName;
            string lastName = zooKeeper.LastName;

            Assert.Equal("First Name", firstName);
            Assert.Equal("Last Name", lastName);
        }

        [Fact]
        public void ShouldBeAbleToHaveAnimalExpirience()
        {
            ZooKeeper zookeeper = new("First Name", "Last Name");

            List<string> familiarAnimals = zookeeper.AnimalExperience;

            Assert.Equal(familiarAnimals, zookeeper.AnimalExperience);
        }

        [Fact]
        public void ShouldBeAbleToHaveGetAndSetAvailableFood()
        {
            ZooKeeper zookeeper = new("First Name", "Last Name");
            zookeeper.AvailableFood.Add(new Grass());

            List<Food> availableFood = zookeeper.AvailableFood;

            Assert.Equal(availableFood, zookeeper.AvailableFood);
        }

        /*
        [Fact]
        public void ShouldBeAbleToAddNewAnimalToAnimalExperience()
        {
            ZooKeeper zooKeeper = new("First Name", "Last Name");
            zooKeeper.AddAnimalExperience(new Lion());
            string faimiliarAnimal = zooKeeper.AnimalExperience[0];

            Assert.Equal("Lion", faimiliarAnimal);
        }

        [Fact]
        public void ShouldBeAbleToCheckIfHasAnimalExpirience()
        {
            ZooKeeper zooKeeper = new("First Name", "Last Name");
            zooKeeper.AddAnimalExperience(new Elephant());

            Assert.True(zooKeeper.HasAnimalExperience(new Elephant()));
            Assert.False(zooKeeper.HasAnimalExperience(new Lion()));
        }
        */
        [Fact]
        public void ShouldBeAbleToFeedlHungryAnimalIfHasExperienceWith()
        {
            ZooKeeper zooKeeper = new("First Name", "Last Name");
            zooKeeper.AvailableFood.Add(new Grass());
            Animal bison = new Bison();
            bison.IsHungry = true;
            zooKeeper.AddAnimalExperience(bison);
            bool canZooKeeperFeedBison = zooKeeper.FeedAnimal(bison);
            Assert.True(canZooKeeperFeedBison);
            Assert.False(bison.IsHungry);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedHungryAnimalIfHasNoExperience()
        {
            ZooKeeper zooKeeper = new("First Name", "Last Name");
            Animal lion = new Lion();
            lion.IsHungry = true;
            zooKeeper.AddAnimalExperience(new Bison());
            Assert.Throws<NoNeededExperienceException>(() => { zooKeeper.FeedAnimal(lion); });
            Assert.True(lion.IsHungry);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedHungryAnimalIfHasNoFavoriteFood()
        {
            ZooKeeper zooKeeper = new("First Name", "Last Name");
            zooKeeper.AvailableFood.Add(new Vegetables());
            Animal lion = new Lion();
            lion.IsHungry = true;
            zooKeeper.AddAnimalExperience(new Lion());
            bool canZooKeeperFeedLion = zooKeeper.FeedAnimal(lion);
            Assert.True(lion.IsHungry);
            Assert.False(canZooKeeperFeedLion);

        }

        [Fact]
        public void ShouldBeAbleToFeedlAnimalIfItIsTimeToFeed()
        {
            ZooKeeper zooKeeper = new("First Name", "Last Name");
            zooKeeper.AvailableFood.Add(new Grass());
            Animal bison = new Bison();
            bison.IsHungry = false;
            bison.FeedShedule.Add(100);
            bison.FeedShedule.Add(100);
            zooKeeper.AddAnimalExperience(bison);
            bool canZooKeeperFeedBison = zooKeeper.FeedAnimal(bison);
            Assert.True(canZooKeeperFeedBison);
        }

        [Fact]
        public void ShouldNotBeAbleToFeedlAnimalIfItIsNotTimeToFeed()
        {
            ZooKeeper zooKeeper = new("First Name", "Last Name");
            zooKeeper.AvailableFood.Add(new Grass());
            Animal bison = new Bison();
            bison.IsHungry = false;
            bison.FeedShedule.Add(0);
            bison.FeedShedule.Add(0);
            zooKeeper.AddAnimalExperience(bison);
            bool canZooKeeperFeedBison = zooKeeper.FeedAnimal(bison);
            Assert.False(canZooKeeperFeedBison);
        }
    }
}
