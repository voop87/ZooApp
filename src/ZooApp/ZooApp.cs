using System;
using System.Collections.Generic;

namespace ZooApp
{
    public class ZooApp
    {
        private static List<Zoo> _zoos = new List<Zoo>();
        public static void AddZoo(Zoo zoo)
        {
            _zoos.Add(zoo);
        }
    }
}
