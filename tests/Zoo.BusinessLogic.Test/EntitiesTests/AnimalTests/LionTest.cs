﻿using System;
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
    public class LionTest
    {
        [Fact]
        public void ShouldGetAnimalState()
        {
            int id = 2;
            Lion lion = new Lion(id);
            List<int> feedShedule = lion.FeedShedule;
            List<FeedTimeClass> feedTimes = lion.FeedTimes;

            Assert.Equal(id, lion.ID);
            Assert.False(lion.IsSick);
            Assert.Empty(feedShedule);
            Assert.Empty(feedTimes);
            Assert.True(lion.IsHungry);
        }

        [Fact]
        public void ShouldBeFriendlyWith()
        {
            Lion lion = new Lion();
            Assert.True(lion.IsFriendlyWith(lion));
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
                lion.IsFriendlyWith(bison);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                lion.IsFriendlyWith(elephant);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                lion.IsFriendlyWith(turtle);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                lion.IsFriendlyWith(snake);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                lion.IsFriendlyWith(parrot);
            });
            Assert.Throws<NotFriendlyAnimalException>(() =>
            {
                lion.IsFriendlyWith(penguin);
            });
        }

        [Fact]
        public void ShouldBeFeedWhenHungry()
        {
            Lion lion = new Lion();
            lion.Feed(new Meat());
            Assert.False(lion.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWithWrongFoodType()
        {
            Lion lion = new Lion();
            lion.Feed(new Vegetables());
            Assert.True(lion.IsHungry); //проверить вывод консоли

            lion.Feed(new Grass());
            Assert.True(lion.IsHungry);
        }

        [Fact]
        public void ShouldNotBeFeedWhenNotHungry()
        {
            Lion lion = new Lion();
            lion.IsHungry = false;
            lion.Feed(new Vegetables());
            Assert.False(lion.IsHungry); //проверить вывод консоли
        }

        [Fact]
        public void ShouldAddFeedShedule()
        {
            Lion lion = new Lion();
            List<int> hours = new List<int>();
            hours.Add(8);
            hours.Add(18);
            lion.AddFeedShedule(hours);
            Assert.Equal(8, lion.FeedShedule[0]);
            Assert.Equal(18, lion.FeedShedule[1]);
        }
    }
}
