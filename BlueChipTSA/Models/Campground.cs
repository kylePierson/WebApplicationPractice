using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueChipTSA.Models
{
    public class Campground
    {
        public int CampgroundId { get; set; }
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string UtilityHookup { get; set; }
        public string DumpStation { get; set; }
    }
}