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
        /*
        [Fact]
        public void ShouldGetAnimalState()
        {
            int id = 3;
            Snake snake = new Snake(id);
            List<int> feedShedule = snake.FeedShedule;
            List<FeedTimeClass> feedTimes = snake.FeedTimes;

            Assert.Equal(id, snake.ID);
            Assert.False(snake.IsSick);
            Assert.Empty(feedShedule);
            Assert.Empty(feedTimes);
            Assert.True(snake.IsHungry);
        }

        [Fact]
        public void ShouldBeFriendlyWith()
        {
            int id = 2;
            Snake snake = new Snake(id);

            Assert.True(snake.IsFriendlyWith(snake));
        }

        [Fact]
        public void ShouldNotBeFriendlyWith()
        {
            int id = 2;
            Lion lion = new Lion(id);
            Parrot parrot = new Parrot(id);
            Snake snake = new Snake(id);
            Penguin penguin = new Penguin(id);
            Elephant elephant = new Elephant(id);
            Bison bison = new Bison(id);
            Turtle turtle = new Turtle(id);

            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                snake.IsFriendlyWith(lion);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                snake.IsFriendlyWith(parrot);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                snake.IsFriendlyWith(penguin);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                snake.IsFriendlyWith(elephant);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                snake.IsFriendlyWith(bison);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                snake.IsFriendlyWith(turtle);
            });
        }

        [Fact]
        public void ShouldBeFeedWhenHungry()
        {
            Snake snake = new Snake();
            snake.Feed(new Meat());
            Assert.False(snake.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWithWrongFoodType()
        {
            Snake snake = new Snake();
            snake.Feed(new Vegetables());
            Assert.True(snake.IsHungry); //проверить вывод консоли

            snake.Feed(new Grass());
            Assert.True(snake.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWhenNotHungry()
        {
            Snake snake = new Snake();
            snake.IsHungry = false;
            snake.Feed(new Meat());
            Assert.False(snake.IsHungry); //проверить вывод консоли
        }

        [Fact]
        public void ShouldAddFeedShedule()
        {
            Snake snake = new Snake();
            List<int> hours = new List<int>();
            hours.Add(8);
            hours.Add(18);
            snake.AddFeedShedule(hours);
            Assert.Equal(8, snake.FeedShedule[0]);
            Assert.Equal(18, snake.FeedShedule[1]);
        }

        [Fact]
        public void ShouldBeHealWhenSick()
        {
            Snake snake = new Snake();
            snake.IsSick = true;
            snake.Heal(new Antibiotics());
            Assert.False(snake.IsSick); //проверить вывод консоли
        }

        [Fact]
        public void ShouldNotBeHealWhenHealthy()
        {
            Snake snake = new Snake();
            snake.IsSick = false;
            snake.Heal(new Antibiotics());
            Assert.False(snake.IsSick); //проверить вывод консоли
        }
        */

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
