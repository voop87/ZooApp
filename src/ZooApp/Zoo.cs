using System;
using System.Collections.Generic;

namespace ZooApp
{
    public class Zoo : ZooApp
    {
        public List<Enclosure> Enclosures { get; private set; } = new List<Enclosure>();

        public string Location {  get; private set; } = "Zoo";

        public string GetLocation()
        {
            return Location;
        }

        public List<Enclosure> GetEnclosures()
        {
            return Enclosures;
        }

        
    }
}