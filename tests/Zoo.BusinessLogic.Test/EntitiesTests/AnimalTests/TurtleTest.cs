using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zoo.BusinessLogic.Entities.Animals.Mammals;
using Zoo.BusinessLogic.Entities.Animals.Reptiles;
using Zoo.BusinessLogic.Entities.Animals.Birds;
using Zoo.BusinessLogic.Entities;
using Zoo.BusinessLogic.Exceptions;

namespace Zoo.BusinessLogic.Test
{
    public class TurtleTest
    {
        [Fact]
        public void ShouldGetAnimalState()
        {
            int id = 2;
            Turtle turtle = new Turtle(id);
            List<int> feedShedule = turtle.FeedShedule;
            List<FeedTimeClass> feedTimes = turtle.FeedTimes;

            Assert.Equal(id, turtle.ID);
            Assert.False(turtle.IsSick);
            Assert.Empty(feedShedule);
            Assert.Empty(feedTimes);
            Assert.True(turtle.IsHungry);
        }

        [Fact]
        public void ShouldBeFriendlyWith()
        {
            Turtle turtle = new Turtle();
            Bison bison = new Bison();
            Elephant elephant = new Elephant();
            Parrot parrot = new Parrot();

            Assert.True(turtle.IsFriendlyWith(turtle));
            Assert.True(turtle.IsFriendlyWith(bison));
            Assert.True(turtle.IsFriendlyWith(elephant));
            Assert.True(turtle.IsFriendlyWith(parrot));
        }

        [Fact]
        public void ShouldNotBeFriendlyWith()
        {
            Turtle turtle = new Turtle();
            Lion lion = new Lion();
            Snake snake = new Snake();
            Penguin penguin = new Penguin();

            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                turtle.IsFriendlyWith(lion);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                turtle.IsFriendlyWith(snake);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                turtle.IsFriendlyWith(penguin);
            });
        }

        [Fact]
        public void ShouldBeFeedWhenHungry()
        {
            Turtle turtle = new Turtle();
            turtle.Feed(new Grass());
            Assert.False(turtle.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWithWrongFoodType()
        {
            Turtle turtle = new Turtle();
            turtle.Feed(new Vegetables());
            Assert.True(turtle.IsHungry); //проверить вывод консоли

            turtle.Feed(new Meat());
            Assert.True(turtle.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWhenNotHungry()
        {
            Turtle turtle = new Turtle();
            turtle.IsHungry = false;
            turtle.Feed(new Vegetables());
            Assert.False(turtle.IsHungry); //проверить вывод консоли
        }

        [Fact]
        public void ShouldAddFeedShedule()
        {
            Turtle turtle = new Turtle();
            List<int> hours = new List<int>();
            hours.Add(8);
            hours.Add(18);
            turtle.AddFeedShedule(hours);
            Assert.Equal(8, turtle.FeedShedule[0]);
            Assert.Equal(18, turtle.FeedShedule[1]);
        }
    }
}
