using System.ComponentModel.DataAnnotations;

namespace CarsApp.Models.Car
{
    public class CarAllViewModel
    {

        public int Id { get; set; }
        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; } = null!;
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = null!;
        [Display(Name = "Model")]
        public string Model { get; set; } = null!;
        [Display(Name = "Picture")]
        public string? Picture { get; set; }
        [Display(Name = "Year Of Manufacture")]
        public DateTime YearOfmanufacture { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
