using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test
{
    public class SnakeTest
    {

        [Fact]
        public void ShoulBeAbleToCreateSnake()
        {
            Snake snake = new();
        }

        [Fact]
        public void ShouldRequire2sqFeet()
        {
            Snake snake = new();
            int requiredArea = snake.RequiredFeet;
            Assert.Equal(2, requiredArea);
        }

        [Fact]
        public void ShouldBeAbleToGetFavoriteFood()
        {
            Snake snake = new();
            List<string> food = snake.FavoriteFood.ToList<string>();
        }

        [Fact]
        public void ShouldBeFriendlyWithSnakes()
        {
            Snake firstSnake = new();
            Snake secondSnake = new();

            bool isFriendlyWithSnakes = firstSnake.IsFriendlyWith(secondSnake);

            Assert.True(isFriendlyWithSnakes);
        }

        [Fact]
        public void ShouldNotBeFriendlyWithOtherAnimals()
        {
            Snake snake = new();
            Lion lion = new();
            Elephant elephant = new();
            Bison bison = new();
            Penguin penguin = new();
            Parrot parrot = new();
            Turtle turtle = new();

            Assert.Throws<NotFriendlyAnimalException>(() => { snake.IsFriendlyWith(lion); });
            Assert.Throws<NotFriendlyAnimalException>(() => { snake.IsFriendlyWith(elephant); });
            Assert.Throws<NotFriendlyAnimalException>(() => { snake.IsFriendlyWith(bison); });
            Assert.Throws<NotFriendlyAnimalException>(() => { snake.IsFriendlyWith(penguin); });
            Assert.Throws<NotFriendlyAnimalException>(() => { snake.IsFriendlyWith(parrot); });
            Assert.Throws<NotFriendlyAnimalException>(() => { snake.IsFriendlyWith(turtle); });
        }
    }
}
