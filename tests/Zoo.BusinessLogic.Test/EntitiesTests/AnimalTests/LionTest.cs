using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test
{
    public class LionTest
    {

        [Fact]
        public void ShouldBeAbleToCreateLion()
        {
            Lion lion = new();
        }

        [Fact]
        public void ShouldRequire1000SqFeet()
        {
            Lion lion = new();
            int requiredArea = lion.RequiredFeet;
            Assert.Equal(1000, requiredArea);
        }

        [Fact]
        public void ShouldBeAbletToGetFavoriteFood()
        {
            Lion lion = new();
            List<string> food = lion.FavoriteFood.ToList<string>();
        }

        [Fact]
        public void ShouldBeFriendlyWithLions()
        {
            Lion firstLion = new();
            Lion secondLion = new();
            bool isFriendlyWithLions = firstLion.IsFriendlyWith(secondLion);
        }

        [Fact]
        public void ShouldNotBeFriendlyWithOtherAnimals()
        {
            Lion lion = new();
            Elephant elephant = new();
            Bison bison = new();
            Penguin penguin = new();
            Parrot parrot = new();
            Turtle turtle = new();
            Snake snake = new();

            Assert.Throws<NotFriendlyAnimalException>(() => { lion.IsFriendlyWith(elephant); });
            Assert.Throws<NotFriendlyAnimalException>(() => { lion.IsFriendlyWith(bison); });
            Assert.Throws<NotFriendlyAnimalException>(() => { lion.IsFriendlyWith(penguin); });
            Assert.Throws<NotFriendlyAnimalException>(() => { lion.IsFriendlyWith(parrot); });
            Assert.Throws<NotFriendlyAnimalException>(() => { lion.IsFriendlyWith(turtle); });
            Assert.Throws<NotFriendlyAnimalException>(() => { lion.IsFriendlyWith(snake); });
        }
    }
}
