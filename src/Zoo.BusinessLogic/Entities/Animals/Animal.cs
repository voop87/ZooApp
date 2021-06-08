using System.Collections.Generic;
using Zoo.BusinessLogic.Entities;
using System;

namespace Zoo.BusinessLogic
{
    public abstract class Animal
    {
        public int ID { get; set; }
        public bool IsSick { get; set; }
        public bool IsHungry { get; set; }
        public string FavoriteFood { get; set; }
        public int RequiredFeet { get; set; }

        public List<int> FeedShedule { get; set; }
        public List<FeedTimeClass> FeedTimes { get; } = new List<FeedTimeClass>();

        public abstract bool IsFriendlyWith(Animal animal);
        public void Feed(Food food)
        {
            if (IsHungry)
            {
                if (FavoriteFood == food.FoodType)
                {
                    IsHungry = false;
                    Console.WriteLine("Animal has been fed");
                } else
                {
                    Console.WriteLine("Animal don't like this food!");
                }
                
            } else
            {
                Console.WriteLine("Animal is not hungry!");
            }
            
        }

        public void AddFeedShedule(List<int> hours)
        {
            foreach (int hour in hours)
            {
                FeedShedule.Add(hour);
            }
        }

        public void Heal(Medicine medicine)
        {
            if (IsSick)
            {
                IsSick = false;
                Console.WriteLine("Animal has been healed");
            }
            else
            {
                Console.WriteLine("Animal doesn't need to heal!");
            }
        }
    }
}


