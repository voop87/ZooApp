using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test
{
    public class ElephantTest
    {
        [Fact]
        public void ShouldBeAbleToCreateElephant()
        {
            Elephant elephant = new();
        }

        [Fact]
        public void ShouldRequire1000dSqFeet()
        {
            Elephant elephant = new();
            Assert.Equal(1000, elephant.RequiredFeet);
        }

        [Fact]
        public void ShouldBeAbleToGetFavoriteFood()
        {
            Elephant elephant = new();
            List<string> food = elephant.FavoriteFood.ToList<string>();
        }

        [Fact]
        public void ShouldBeFriendlyWithBisons()
        {
            Elephant elephant = new();
            Bison bison = new();
            bool isFrindlyWithBisons = elephant.IsFriendlyWith(bison);
            Assert.True(isFrindlyWithBisons);
        }

        [Fact]
        public void ShouldBeFriendlyWithParrots()
        {
            Elephant elephant = new();
            Parrot parrot = new();
            bool isFriendlyWithParrots = elephant.IsFriendlyWith(parrot);
            Assert.True(isFriendlyWithParrots);
        }

        [Fact]
        public void ShouldBeFriendlyWithTurtles()
        {
            Elephant elephant = new();
            Turtle turtle = new();
            bool isFriendlyWithTurtles = elephant.IsFriendlyWith(turtle);
            Assert.True(isFriendlyWithTurtles);
        }

        [Fact]
        public void ShouldNotBeFriendlyWithOtherAnimals()
        {
            Elephant elephant = new();
            Lion lion = new();
            Penguin penguin = new();
            Snake snake = new();

            Assert.False(elephant.IsFriendlyWith(elephant));
            Assert.False(elephant.IsFriendlyWith(lion));
            Assert.False(elephant.IsFriendlyWith(penguin));
            Assert.False(elephant.IsFriendlyWith(snake));
        }
    }
}
