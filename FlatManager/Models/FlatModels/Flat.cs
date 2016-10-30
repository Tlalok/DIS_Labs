using System;

namespace FlatManager.Models.FlatModels
{
    public class Flat : ICloneable
    {
        public int Id { get; set; }
        public int RoomCount { get; set; }
        public Address Address { get; set; }
        public int Square { get; set; }
        public double RentCostPerMonth { get; set; }
        public int Views { get; set; }
        public Owner Owner { get; set; }

        public Flat()
        {
            Address = new Address();
        }

        public object Clone()
        {
            var clone = new Flat();
            clone.Id = Id;
            clone.RoomCount = RoomCount;
            clone.Square = Square;
            clone.RentCostPerMonth = RentCostPerMonth;
            clone.Views = Views;
            clone.Address = (Address)Address.Clone();
            clone.Owner = (Owner)Owner.Clone();
            return clone;
        }
    }
}
