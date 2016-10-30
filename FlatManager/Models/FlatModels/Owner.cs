using System;

namespace FlatManager.Models.FlatModels
{
    public class Owner : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Secondname { get; set; }
        public string PhoneNumber { get; set; }
        public object Clone()
        {
            return new Owner
            {
                Id = Id,
                Name = Name,
                Secondname = Secondname,
                PhoneNumber = PhoneNumber
            };
        }
    }
}
