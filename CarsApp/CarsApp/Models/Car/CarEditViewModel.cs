using System.ComponentModel.DataAnnotations;

namespace CarsApp.Models.Car
{
    public class CarEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; } = null!;
        [Required]
        [MaxLength(30)]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = null!;
        [Required]
        [MaxLength(30)]
        [Display(Name = "Model")]
        public string Model { get; set; } = null!;
        [Display(Name = "Picture")]
        public string? Picture { get; set; }
        [Display(Name = "Year Of Manufacture")]
        public DateTime YearOfmanufacture { get; set; }
        [Required]
        [Range(1000, 300000, ErrorMessage = "Price must be between 1000 and 300000")]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}
