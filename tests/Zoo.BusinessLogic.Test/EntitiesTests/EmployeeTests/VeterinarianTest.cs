using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test.EntitiesTests.EmployeeTests
{
    public class VeterinarianTests
    {
        [Fact]
        public void ShouldBeAbleToCreateVeterinarian()
        {
            Veterinarian veterinarian = new("First Name", "Last Name");

        }

        [Fact]
        public void ShouldBeAbleToGetVetarinarianNames()
        {
            Veterinarian veterinarian = new("First Name", "Last Name");

            string firstName = veterinarian.FirstName;
            string lastName = veterinarian.LastName;

            Assert.Equal("First Name", firstName);
            Assert.Equal("Last Name", lastName);
        }

        [Fact]
        public void ShouldBeAbleToGetAndSetAvailableMedicine()
        {
            Veterinarian veterinarian = new("First Name", "Last Name");
            List<Medicine> availableMedicine = veterinarian.AvailableMedicine;
            Assert.Equal(availableMedicine, veterinarian.AvailableMedicine);
        }

        [Fact]
        public void ShouldBeAbleToHaveAnimalExpirience()
        {
            Veterinarian veterinarian = new("First Name", "Last Name");

            List<string> familiarAnimals = veterinarian.AnimalExperience;

            Assert.Equal(familiarAnimals, veterinarian.AnimalExperience);
        }

        [Fact]
        public void ShouldBeAbleToAddNewAnimalToAnimalExperience()
        {
            Veterinarian veterinarian = new("First Name", "Last Name");
            Lion lion = new Lion();
            veterinarian.AddAnimalExperience(lion);

            Assert.Equal(lion.GetType().Name, veterinarian.AnimalExperience[0]);
        }

        [Fact]
        public void ShouldBeAbleToCheckIfHasAnimalExpirience()
        {
            Veterinarian veterinarian = new("First Name", "Last Name");
            veterinarian.AddAnimalExperience(new Elephant());

            Assert.True(veterinarian.HasAnimalExperience(new Elephant()));
            Assert.Throws<NoNeededExperienceException>(() => { veterinarian.HasAnimalExperience(new Lion()); });
        }

        [Fact]
        public void ShouldBeAbleToHealSickAnimalIfHasExpirienceWith()
        {
            Veterinarian veterinarian = new Veterinarian("First Name", "Last Name");
            veterinarian.AvailableMedicine.Add(new Antibiotics());
            veterinarian.AvailableMedicine.Add(new AntiDepression());
            veterinarian.AvailableMedicine.Add(new AntiInflammatory());
            Animal bison = new Bison();
            bison.IsSick = true;
            veterinarian.AddAnimalExperience(bison);
            veterinarian.HealAnimal(bison);
            Assert.False(bison.IsSick);
        }

        [Fact]
        public void ShouldNotBeAbleToHealSickAnimalIfHasNoExperience()
        {
            Veterinarian veterinarian = new Veterinarian("First Name", "Last Name");
            Animal lion = new Lion();
            lion.IsSick = true;
            veterinarian.AddAnimalExperience(new Bison());
            Assert.Throws<NoNeededExperienceException>(() => { veterinarian.HealAnimal(lion); });
            Assert.True(lion.IsSick);
        }

        [Fact]
        public void ShouldNotHealAnimalWithoutNeededMedicine()
        {
            Veterinarian veterinarian = new Veterinarian("First Name", "Last Name");
            Animal lion = new Lion();
            lion.IsSick = true;
            veterinarian.AddAnimalExperience(new Lion());
            bool canVeterinarianHealBison = veterinarian.HealAnimal(lion);
            Assert.False(canVeterinarianHealBison);
            Assert.True(lion.IsSick);
        }


        [Fact]
        public void ShouldNotHealHealthyAnimal()
        {
            Veterinarian veterinarian = new Veterinarian("First Name", "Last Name");
            Animal lion = new Lion();
            lion.IsSick = false;
            veterinarian.AddAnimalExperience(new Lion());
            bool canVeterinarianHealBison = veterinarian.HealAnimal(lion);
            Assert.False(canVeterinarianHealBison);
            Assert.False(lion.IsSick);
        }
    }
}
