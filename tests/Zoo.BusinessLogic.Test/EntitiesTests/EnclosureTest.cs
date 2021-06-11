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
            Turtle turtle = new Turtle();
            enclosure.AddAnimals(elephant);
            enclosure.AddAnimals(turtle);

            Assert.Equal(elephant, enclosure.Animals[0]);
            Assert.Equal(turtle, enclosure.Animals[1]);
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

            Assert.False(firstEnclosure.IsFriendlyTo(new Bison()));

            Enclosure secondEnclosure = new(new Zoo(), "big enclosure", 9000);
            secondEnclosure.AddAnimals(new Bison());
            bool isFriendlyToAnotherBison = secondEnclosure.IsFriendlyTo(new Elephant());

            Assert.True(isFriendlyToAnotherBison);
        }

        [Fact]
        public void ShouldBeFindAvailableEnclosure()
        {
            Zoo zoo1 = new Zoo();
            zoo1.AddEnclosure("lions", 10000);
            zoo1.AddEnclosure("others", 10000);

            Lion lion = new();
            Elephant elephant = new();
            Turtle turtle = new();
            Lion lion2 = new();

            zoo1.FindAvailableEnclosure(lion).AddAnimals(lion);
            zoo1.FindAvailableEnclosure(elephant).AddAnimals(elephant);
            zoo1.FindAvailableEnclosure(turtle).AddAnimals(turtle);
            zoo1.FindAvailableEnclosure(lion2).AddAnimals(lion2);

            Assert.Equal(lion, zoo1.Enclosures[0].Animals[0]);
            Assert.Equal(elephant, zoo1.Enclosures[1].Animals[0]);
            Assert.Equal(turtle, zoo1.Enclosures[1].Animals[1]);
            Assert.Equal(lion2, zoo1.Enclosures[0].Animals[1]);
        }
    }
}
