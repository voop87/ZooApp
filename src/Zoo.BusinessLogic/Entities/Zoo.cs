using System;
using System.Collections.Generic;

namespace Zoo.BusinessLogic

{
    public class Zoo : ZooApp
    {
        public List<Enclosure> Enclosures { get; private set; } = new List<Enclosure>();

        public string Location {  get; private set; } = "Zoo";

        public Enclosure AddEnclosure(string name, int squreFeet)
        {
            Enclosure enclosure = new Enclosure(name, squreFeet);

            Enclosures.Add(enclosure);
            return enclosure;
        }
    }
}