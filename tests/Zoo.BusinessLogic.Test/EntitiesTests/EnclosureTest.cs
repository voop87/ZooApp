using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zoo.BusinessLogic;
using Zoo.BusinessLogic.Entities.Animals.Mammals;


namespace Zoo.BusinessLogic.Test
{
    public class EnclosureTest
    {

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
        }
    }
}
