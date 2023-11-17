using System.ComponentModel.DataAnnotations;

namespace CarsApp.Models.Car
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Picture { get; set; }
        public DateTime YearOfmanufacture { get; set; }
        public double Price { get; set; }

    }
}
