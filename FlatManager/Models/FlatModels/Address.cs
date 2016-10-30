using System;
using System.Text;

namespace FlatManager.Models.FlatModels
{
    public class Address : ICloneable
    {
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (Region != null)
                result.Append(Region)
                      .Append(" область ");
            result.Append("г. ")  .Append(City)
                  .Append(" ул. ").Append(Street)
                  .Append(" дом ").Append(HouseNumber)
                  .Append(" кв. ").Append(FlatNumber);
            return result.ToString();
        }

        public object Clone()
        {
            return new Address
            {
                Region = Region,
                City = City,
                Street = Street,
                HouseNumber = HouseNumber,
                FlatNumber = FlatNumber
            };
        }
    }
}
