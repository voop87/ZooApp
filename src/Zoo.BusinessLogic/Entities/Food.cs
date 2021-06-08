using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic.Entities
{
    public abstract class Food
    {
        public string FoodType { get; set; }
    }

    public class Meat : Food
    {
        public Meat()
        {
            FoodType = "Meat";
        }
    }

    public class Vegetables : Food
    {
        public Vegetables()
        {
            FoodType = "Vegetables";
        }
    }

    public class Grass : Food
    {
        public Grass()
        {
            FoodType = "Grass";
        }
    }
}
