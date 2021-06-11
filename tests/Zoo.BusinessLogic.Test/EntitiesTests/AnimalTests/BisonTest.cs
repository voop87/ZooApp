using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test
{
    public class BisonTest
    {
        [Fact]
        public void ShoulBeAbleToCreateBison()
        {
            Bison bison = new();
        }

        [Fact]
        public void ShoulRequire1000SqFeet()
        {
            Bison bison = new();
            int requiredArea = bison.RequiredFeet;
            Assert.Equal(1000, requiredArea);
        }

        [Fact]
        public void ShouldBeAbleToGetFavoriteFood()
        {
            Bison bison = new();
            List<string> food = bison.FavoriteFood.ToList<string>();
        }

        [Fact]
        public void ShouldBeAbleToAddFeedShedule()
        {
            Bison bison = new();
            List<int> feedHours = new List<int>();
            feedHours.Add(9);
            feedHours.Add(18);
            bison.AddFeedShedule(feedHours);

            Assert.Equal(bison.FeedShedule, feedHours);
        }

        [Fact]
        public void ShouldBeFriendlyWithElephants()
        {
            Bison bison = new();
            Elephant elephant = new();

            bool isFrindlyWithElephants = bison.IsFriendlyWith(elephant);
            Assert.True(isFrindlyWithElephants);
        }

        [Fact]
        public void ShouldNotBeFriendlyWithOtherAnimals()
        {
            Bison bison = new();
            Lion lion = new();
            Penguin penguin = new();
            Parrot parrot = new();
            Turtle turtle = new();
            Snake snake = new();

            Assert.False(bison.IsFriendlyWith(bison));
            Assert.False(bison.IsFriendlyWith(lion));
            Assert.False(bison.IsFriendlyWith(penguin));
            Assert.False(bison.IsFriendlyWith(parrot));
            Assert.False(bison.IsFriendlyWith(turtle));
            Assert.False(bison.IsFriendlyWith(snake));
        }
    }
}
