using System;
using System.Collections.Generic;

namespace Zoo.BusinessLogic

{
    public class Zoo : ZooApp
    {
        public List<Enclosure> Enclosures { get; private set; } = new List<Enclosure>();

        public string Location {  get; private set; } = "Zoo";

    }
}