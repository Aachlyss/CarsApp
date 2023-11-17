using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.Infrastructure.Data.Domain
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(8)]
        public string RegNumber { get; set; } = null!;
        [Required]
        [MaxLength(30)]
        public string Manufacturer { get; set; } = null!;
        [Required]
        [MaxLength(30)]
        public string Model { get; set; } = null!;
        public string? Picture { get; set; }
        public DateTime YearOfmanufacture { get; set; }
        [Required]
        [Range(1000,300000)]
        public double Price { get; set; }


    }
}
