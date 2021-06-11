using System.Collections.Generic;
using System;

namespace Zoo.BusinessLogic
{
    public abstract class Animal
    {
        public int ID { get; set; }
        public abstract string[] FavoriteFood { get; }
        public abstract int RequiredFeet { get; }
        public string NeededMedicine { get; } = new string[3] { "Antibiotics", "AntiDepression", "AntiInflammatory" }[new Random().Next(0, 3)];

        public bool IsSick { get; set; } = (new Random().Next(0, 10) > 5);

        public bool IsHungry { get; set; } = (new Random().Next(0, 10) > 5);
        public List<FeedTime> FeedTimes { get; } = new List<FeedTime>();
        public List<int> FeedShedule { get; private set; } = new List<int>();

        public abstract bool IsFriendlyWith(Animal animal);
        public void Feed(Food food, IConsole zooConsole = null)
        {
            foreach (var anyFood in FavoriteFood)
            {
                if (food.GetType().Name == anyFood)
                {
                    IsHungry = false;
                }
            }
        }

        public void AddFeedShedule(List<int> hours)
        {
            FeedShedule = hours;
        }

        public void Heal(Medicine medicine)
        {
            if (medicine.GetType().Name == NeededMedicine)
            {
                IsSick = false;
            }
        }
    }
}


