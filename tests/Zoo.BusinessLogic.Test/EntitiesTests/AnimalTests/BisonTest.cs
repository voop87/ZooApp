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
    public class BisonTest
    {
        [Fact]
        public void ShouldGetAnimalState()
        {
            int id = 5;
            Bison bison = new Bison(id);
            List<int> feedShedule = bison.FeedShedule;
            List<FeedTimeClass> feedTimes = bison.FeedTimes;

            Assert.Equal(id, bison.ID);
            Assert.False(bison.IsSick);
            Assert.Empty(feedShedule);
            Assert.Empty(feedTimes);
            Assert.True(bison.IsHungry);
        }

        [Fact]
        public void ShouldBeFriendlyWith()
        {
            Bison bison = new Bison();
            Assert.True(bison.IsFriendlyWith(bison));
        }

        [Fact]
        public void ShouldNotBeFriendlyWith()
        {
            Lion lion = new Lion();
            Bison bison = new Bison();
            Elephant elephant = new Elephant();
            Turtle turtle = new Turtle();
            Snake snake = new Snake();
            Parrot parrot = new Parrot();
            Penguin penguin = new Penguin();

            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                bison.IsFriendlyWith(lion);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                bison.IsFriendlyWith(elephant);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                bison.IsFriendlyWith(turtle);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                bison.IsFriendlyWith(snake);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                bison.IsFriendlyWith(parrot);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                bison.IsFriendlyWith(penguin);
            });
        }

        [Fact]
        public void ShouldBeFeedWhenHungry()
        {
            Bison bison = new Bison();
            bison.Feed(new Grass());
            Assert.False(bison.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWithWrongFoodType()
        {
            Bison bison = new Bison();
            bison.Feed(new Meat());
            Assert.True(bison.IsHungry); //проверить вывод консоли

            bison.Feed(new Vegetables());
            Assert.True(bison.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWhenNotHungry()
        {
            Bison bison = new Bison();
            bison.IsHungry = false;
            bison.Feed(new Grass());
            Assert.False(bison.IsHungry); //проверить вывод консоли
        }

        [Fact]
        public void ShouldAddFeedShedule()
        {
            Bison bison = new Bison();
            List<int> hours = new List<int>();
            hours.Add(8);
            hours.Add(18);
            bison.AddFeedShedule(hours);
            Assert.Equal(8, bison.FeedShedule[0]);
            Assert.Equal(18, bison.FeedShedule[1]);
        }
    }
}
