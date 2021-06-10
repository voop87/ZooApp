using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zoo.BusinessLogic;


namespace Zoo.BusinessLogic.Test
{
    public class EnclosureTest
    {
        /*
        [Fact]
        public void ShouldAddAnimal()
        {
            Lion lion = new Lion(1);
            List<Animal> animals = Enclosure.Animals;
            Enclosure.AddAnimals(lion);

            Assert.Equal(lion, animals[0]);
        }

        [Fact]
        public void ShouldGetParentZoo()
        {
            Assert.Equal("Zoo", Enclosure.ParentZoo);
        }*/

        [Fact]
        public void ShouldBeAbleToCreateEnclosureWithNameAreaAndParentZoo()
        {
            Enclosure enclosure = new Enclosure(new Zoo(), "anyName", 5);
        }

        [Fact]
        public void ShouldBeAbleToGetName()
        {
            Enclosure enclosure = new Enclosure(new Zoo(), "Some name", 1000);
            string anyName = enclosure.Name;
        }

        [Fact]
        public void ShouldBeAbleToGetAnimals()
        {
            Enclosure enclosure = new Enclosure(new Zoo(), "Some name", 1000);
            List<Animal> animals = enclosure.Animals;
        }

        [Fact]
        public void ShouldBeAbleToGetParentZoo()
        {
            Enclosure enclosure = new Enclosure(new Zoo(), "Some name", 1000);
            Zoo anyZoo = enclosure.ParentZoo;
        }

        [Fact]
        public void ShouldBeAbleToGetSquareFeet()
        {
            Enclosure enclosure = new Enclosure(new Zoo(), "Some name", 1000);
            int anyArea = enclosure.SqureFeet;
        }

        [Fact]
        public void ShouldBeAbleToAddAnimalsIfThereIsSpaceAndNoUnfriendlyAnimals()
        {
            Enclosure enclosure = new(new Zoo(), "huge enclosure", 100000);
            Elephant elephant = new Elephant();
            enclosure.AddAnimals(elephant);

            Assert.Equal(elephant, enclosure.Animals[0]);
        }

        [Fact]
        public void ShouldBeAbleToTagAddedAnimal()
        {
            Zoo parentZoo = new();
            Enclosure enclosure = new(parentZoo, "huge enclosure", 100000);
            Elephant elephant = new Elephant();
            enclosure.AddAnimals(elephant);

            Assert.Equal(1, elephant.ID);
        }

        [Fact]
        public void ShouldBeNotAbleToAddAnimalsIfThereIsNoSpace()
        {
            Enclosure enclosure = new(new Zoo(), "tiny enclosure", 5);
            Elephant elephant = new Elephant();

            Assert.Throws<NoAvailableSpaceException>(() => enclosure.AddAnimals(elephant));
        }

        [Fact]
        public void ShouldBeNotAbleToAddAnimalsIfThereIsUnfriendlyAnimal()
        {
            Enclosure enclosure = new(new Zoo(), "huge enclosure", 10000);
            enclosure.AddAnimals(new Lion());
            Elephant elephant = new Elephant();

            Assert.Throws<NotFriendlyAnimalException>(() => enclosure.AddAnimals(elephant));
        }

        [Fact]
        public void ShouldBeAbleToDecideIsEnclosureSafeForAnimal()
        {
            Enclosure firstEnclosure = new(new Zoo(), "huge enclosure", 10000);
            firstEnclosure.AddAnimals(new Lion());

            Assert.Throws<NotFriendlyAnimalException>(() => { firstEnclosure.IsFriendlyTo(new Bison()); });

            Enclosure secondEnclosure = new(new Zoo(), "big enclosure", 9000);
            secondEnclosure.AddAnimals(new Bison());
            bool isFriendlyToAnotherBison = secondEnclosure.IsFriendlyTo(new Elephant());

            Assert.True(isFriendlyToAnotherBison);
        }
    }
}
