﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Zoo.BusinessLogic.Test
{
    public class ParrotTest
    {
        /*
        [Fact]
        public void ShouldGetAnimalState()
        {
            int id = 4;
            Parrot parrot = new Parrot(id);
            List<int> feedShedule = parrot.FeedShedule;
            List<FeedTimeClass> feedTimes = parrot.FeedTimes;

            Assert.Equal(id, parrot.ID);
            Assert.False(parrot.IsSick);
            Assert.Empty(feedShedule);
            Assert.Empty(feedTimes);
            Assert.True(parrot.IsHungry);
        }

        [Fact]
        public void ShouldBeFriendlyWith()
        {
            Parrot parrot = new Parrot();
            Bison bison = new Bison();
            Elephant elephant = new Elephant();
            Turtle turtle = new Turtle();

            Assert.True(parrot.IsFriendlyWith(bison));
            Assert.True(parrot.IsFriendlyWith(parrot));
            Assert.True(parrot.IsFriendlyWith(elephant));
            Assert.True(parrot.IsFriendlyWith(turtle));
        }

        [Fact]
        public void ShouldNotBeFriendlyWith()
        {
            Lion lion = new Lion();
            Parrot parrot = new Parrot();
            Snake snake = new Snake();
            Penguin penguin = new Penguin();

            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                parrot.IsFriendlyWith(lion);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                parrot.IsFriendlyWith(snake);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                parrot.IsFriendlyWith(penguin);
            });
        }

        [Fact]
        public void ShouldBeFeedWhenHungry()
        {
            Parrot parrot = new Parrot();
            parrot.Feed(new Vegetables());
            Assert.False(parrot.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWithWrongFoodType()
        {
            Parrot parrot = new Parrot();
            parrot.Feed(new Meat());
            Assert.True(parrot.IsHungry); //проверить вывод консоли

            parrot.Feed(new Grass());
            Assert.True(parrot.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWhenNotHungry()
        {
            Parrot parrot = new Parrot();
            parrot.IsHungry = false;
            parrot.Feed(new Vegetables());
            Assert.False(parrot.IsHungry); //проверить вывод консоли
        }

        [Fact]
        public void ShouldAddFeedShedule()
        {
            Parrot parrot = new Parrot();
            List<int> hours = new List<int>();
            hours.Add(8);
            hours.Add(18);
            parrot.AddFeedShedule(hours);
            Assert.Equal(8, parrot.FeedShedule[0]);
            Assert.Equal(18, parrot.FeedShedule[1]);
        }
        */

        [Fact]
        public void ShoulBeAbleToCreateParrot()
        {
            Parrot parrot = new();
        }

        [Fact]
        public void ShouldRequireFiveSqFeet()
        {
            Parrot parrot = new();
            int requiredArea = parrot.RequiredFeet;
            Assert.Equal(5, requiredArea);
        }

        [Fact]
        public void ShouldFetBeAbleToGetFavoriteFood()
        {
            Parrot parrot = new();
            string[] food = parrot.FavoriteFood;
        }

        [Fact]
        public void ShoulBeFriendlyWithParrots()
        {
            Parrot firstParrot = new();
            Parrot secondParrot = new();
            bool isFriendlyWithParrots = firstParrot.IsFriendlyWith(secondParrot);

            Assert.True(isFriendlyWithParrots);
        }

        [Fact]
        public void ShoulBeFriendlyWithBisons()
        {
            Parrot parrot = new();
            Bison bison = new();
            bool isFriendlyWithBisons = parrot.IsFriendlyWith(bison);

            Assert.True(isFriendlyWithBisons);
        }

        [Fact]
        public void ShoulBeFriendlyWithElephants()
        {
            Parrot parrot = new();
            Elephant elephant = new();
            bool isFriendlyWithElephants = parrot.IsFriendlyWith(elephant);

            Assert.True(isFriendlyWithElephants);
        }

        [Fact]
        public void ShoulBeFriendlyWithTurtles()
        {
            Parrot parrot = new();
            Turtle turtle = new();
            bool isFriendlyWithTurtles = parrot.IsFriendlyWith(turtle);

            Assert.True(isFriendlyWithTurtles);
        }

        [Fact]
        public void ShoulNotBeFriendlyWithLions()
        {
            Parrot parrot = new();
            Lion lion = new();

            Assert.Throws<NotFriendlyAnimalException>(() => { parrot.IsFriendlyWith(lion); });
        }

        [Fact]
        public void ShoulNotBeFriendlyWithSnakes()
        {
            Parrot parrot = new();
            Snake snake = new();

            Assert.Throws<NotFriendlyAnimalException>(() => { parrot.IsFriendlyWith(snake); });
        }
    }
}
