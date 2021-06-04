using System;
using System.Collections.Generic;
using Xunit;

namespace ZooApp.Test
{
    public class ZooAppTest
    {
        [Fact]
        public void ShouldCreateZooApp()
        {
            ZooApp zooApp = new ZooApp();
        }

        [Fact]
        public void ShouldAddNewZooInList()
        {
            Zoo newZoo = new Zoo();
            ZooApp.AddZoo(newZoo);
        }
    }
}
