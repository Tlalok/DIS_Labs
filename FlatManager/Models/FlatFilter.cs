using FlatManager.Models.FlatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.Models
{

    public class Range
    {
        public int? Min { get; set; }
        public int? Max { get; set; }
    }

    public class FlatFilterArgs
    {
        public Range Square { get; set; }
        public Range Cost { get; set; }
        public Range RoomCount { get; set; }

        public string City { get; set; }

        public Func<Flat, bool> Predicate
        {
            get
            {
                return flat => !Square.Min.HasValue || flat.Square >= Square.Min
                            && !Square.Max.HasValue || flat.Square <= Square.Max

                            && !Cost.Min.HasValue || flat.RentCostPerMonth >= Cost.Min
                            && !Cost.Max.HasValue || flat.RentCostPerMonth <= Cost.Max

                            && !RoomCount.Min.HasValue || flat.RoomCount >= RoomCount.Min
                            && !RoomCount.Max.HasValue || flat.RoomCount <= RoomCount.Max

                            && string.IsNullOrEmpty(City) || flat.Address.City.StartsWith(City, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
