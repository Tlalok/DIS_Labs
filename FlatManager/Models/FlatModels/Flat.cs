namespace FlatManager.Models.FlatModels
{
    public class Flat
    {
        public int Id { get; set; }
        public int RoomCount { get; set; }
        public Address Address { get; set; }
        public int Square { get; set; }
        public double RentCostPerMonth { get; set; }
        public int Views { get; set; }
        public Owner Owner { get; set; }
    }
}
