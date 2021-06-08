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
    public class PenguinTest
    {
        [Fact]
        public void ShouldGetAnimalState()
        {
            int id = 2;
            Penguin penguin = new Penguin(id);
            List<int> feedShedule = penguin.FeedShedule;
            List<FeedTimeClass> feedTimes = penguin.FeedTimes;

            Assert.Equal(id, penguin.ID);
            Assert.False(penguin.IsSick);
            Assert.Empty(feedShedule);
            Assert.Empty(feedTimes);
            Assert.True(penguin.IsHungry);
        }

        [Fact]
        public void ShouldBeFriendlyWith()
        {
            Penguin penguin = new Penguin();

            Assert.True(penguin.IsFriendlyWith(penguin));
        }

        [Fact]
        public void ShouldNotBeFriendlyWith()
        {
            Lion lion = new Lion();
            Parrot parrot = new Parrot();
            Snake snake = new Snake();
            Penguin penguin = new Penguin();
            Elephant elephant = new Elephant();
            Bison bison = new Bison();
            Turtle turtle = new Turtle();

            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                penguin.IsFriendlyWith(lion);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                penguin.IsFriendlyWith(parrot);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                penguin.IsFriendlyWith(snake);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                penguin.IsFriendlyWith(elephant);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                penguin.IsFriendlyWith(bison);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                penguin.IsFriendlyWith(turtle);
            });
        }

        [Fact]
        public void ShouldBeFeedWhenHungry()
        {
            Penguin penguin = new Penguin();
            penguin.Feed(new Meat());
            Assert.False(penguin.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWithWrongFoodType()
        {
            Penguin penguin = new Penguin();
            penguin.Feed(new Vegetables());
            Assert.True(penguin.IsHungry); //проверить вывод консоли

            penguin.Feed(new Grass());
            Assert.True(penguin.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWhenNotHungry()
        {
            Penguin penguin = new Penguin();
            penguin.IsHungry = false;
            penguin.Feed(new Vegetables());
            Assert.False(penguin.IsHungry); //проверить вывод консоли
        }

        [Fact]
        public void ShouldAddFeedShedule()
        {
            Penguin penguin = new Penguin();
            List<int> hours = new List<int>();
            hours.Add(8);
            hours.Add(18);
            penguin.AddFeedShedule(hours);
            Assert.Equal(8, penguin.FeedShedule[0]);
            Assert.Equal(18, penguin.FeedShedule[1]);
        }
    }
}
