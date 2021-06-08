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
        }
    }
}
