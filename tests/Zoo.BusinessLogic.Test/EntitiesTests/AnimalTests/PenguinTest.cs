using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test
{
    public class PenguinTest
    {

        [Fact]
        public void ShoulBeAbleToCreatePenguin()
        {
            Penguin penguin = new();
        }

        [Fact]
        public void ShouldRequireTenSqFeet()
        {
            Penguin penguin = new();
            int requiredArea = penguin.RequiredFeet;
            Assert.Equal(10, requiredArea);
        }

        [Fact]
        public void ShouldBeAbleToGetFavoriteFood()
        {
            Penguin penguin = new();
            List<string> food = penguin.FavoriteFood.ToList<string>();
        }

        [Fact]
        public void ShouldBeFriendlyWithPinguins()
        {
            Penguin firstPenguin = new();
            Penguin secondPenguin = new();

            bool isFriendlyWithPenguins = firstPenguin.IsFriendlyWith(secondPenguin);
            Assert.True(isFriendlyWithPenguins);
        }

        [Fact]
        public void ShouldNotBeFriendlyWithOtherAnimals()
        {
            Penguin penguin = new();
            Parrot parrot = new();
            Bison bison = new();
            Elephant elephant = new();
            Lion lion = new();
            Snake snake = new();
            Turtle turtle = new();

            Assert.False(penguin.IsFriendlyWith(lion));
            Assert.False(penguin.IsFriendlyWith(bison));
            Assert.False(penguin.IsFriendlyWith(parrot));
            Assert.False(penguin.IsFriendlyWith(elephant));
            Assert.False(penguin.IsFriendlyWith(snake));
            Assert.False(penguin.IsFriendlyWith(turtle));
        }
    }
}
