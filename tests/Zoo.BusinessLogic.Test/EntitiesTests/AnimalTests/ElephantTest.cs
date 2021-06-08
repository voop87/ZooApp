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
    public class ElephantTest
    {
        [Fact]
        public void ShouldGetAnimalState()
        {
            int id = 6;
            Elephant elephant = new Elephant(id);
            List<int> feedShedule = elephant.FeedShedule;
            List<FeedTimeClass> feedTimes = elephant.FeedTimes;

            Assert.Equal(id, elephant.ID);
            Assert.False(elephant.IsSick);
            Assert.Empty(feedShedule);
            Assert.Empty(feedTimes);
            Assert.True(elephant.IsHungry);
        }

        [Fact]
        public void ShouldBeFriendlyWith()
        {
            Elephant elephant = new Elephant();
            Bison bison = new Bison();
            Parrot parrot = new Parrot();
            Turtle turtle = new Turtle();

            Assert.True(elephant.IsFriendlyWith(bison));
            Assert.True(elephant.IsFriendlyWith(parrot));
            Assert.True(elephant.IsFriendlyWith(turtle));
        }

        [Fact]
        public void ShouldNotBeFriendlyWith()
        {
            Lion lion = new Lion();
            Elephant elephant = new Elephant();
            Snake snake = new Snake();
            Penguin penguin = new Penguin();

            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                elephant.IsFriendlyWith(elephant);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                elephant.IsFriendlyWith(lion);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                elephant.IsFriendlyWith(snake);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                elephant.IsFriendlyWith(penguin);
            });
        }

        [Fact]
        public void ShouldBeFeedWhenHungry()
        {
            Elephant elephant = new Elephant();
            elephant.Feed(new Vegetables());
            Assert.False(elephant.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWithWrongFoodType()
        {
            Elephant elephant = new Elephant();
            elephant.Feed(new Meat());
            Assert.True(elephant.IsHungry); //проверить вывод консоли

            elephant.Feed(new Grass());
            Assert.True(elephant.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWhenNotHungry()
        {
            Elephant elephant = new Elephant();
            elephant.IsHungry = false;
            elephant.Feed(new Vegetables());
            Assert.False(elephant.IsHungry); //проверить вывод консоли
        }

        [Fact]
        public void ShouldAddFeedShedule()
        {
            Elephant elephant = new Elephant();
            List<int> hours = new List<int>();
            hours.Add(8);
            hours.Add(18);
            elephant.AddFeedShedule(hours);
            Assert.Equal(8, elephant.FeedShedule[0]);
            Assert.Equal(18, elephant.FeedShedule[1]);
        }
    }
}
