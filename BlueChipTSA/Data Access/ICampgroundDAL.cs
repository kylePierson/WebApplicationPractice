using BlueChipTSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueChipTSA.Data_Access
{
    public interface ICampgroundDAL
    {
        Campground GetCampground(int campgroundId);
        List<Campground> GetCampgroundsForPark(int parkId);
    }
}
