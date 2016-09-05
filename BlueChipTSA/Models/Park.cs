using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueChipTSA.Models
{
    public class Park
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime EstablishDate { get; set; }
        public int Area { get; set; }
        public int AnnualVisitors { get; set; }
        public string Description { get; set; }
        public List<Campground> Campgrounds { get; set; }
    }
}