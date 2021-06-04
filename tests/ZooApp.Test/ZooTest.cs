using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ZooApp.Test
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
            string location = zoo.GetLocation();
            Assert.Equal("Zoo", location);
        }

        [Fact]
        public void ShouldGetEnclosuresList()
        {
            Zoo zoo = new Zoo();
            List<Enclosure> enclosures = zoo.GetEnclosures();
            Assert.Empty(enclosures);
        }
    }
}
