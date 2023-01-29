using System;
using System.Collections.Generic;

namespace InlamningDatabaser
{
    class LocationClass
    {
        public int id { get; set; }
        public string location { get; set; }
        public DateOnly relocatedDate { get; set; }
        public string prevLocation { get; set; }

        public static List<LocationClass> locations = new List<LocationClass>();
        public LocationClass(int id, string location)
        {
            this.id = id;
            this.location = location;
        }

        public override string? ToString() => this.location;

    }
}
