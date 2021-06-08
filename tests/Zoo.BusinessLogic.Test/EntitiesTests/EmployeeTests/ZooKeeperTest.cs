using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zoo.BusinessLogic.Entities.Employees;
using Zoo.BusinessLogic.Entities.Animals.Birds;

namespace Zoo.BusinessLogic.Test.EntitiesTests.EmployeeTests
{
    public class ZooKeeperTest
    {
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
    }
}
