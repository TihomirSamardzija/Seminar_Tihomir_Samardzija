using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seminar_Tihomir_Samardzija.Models.Base
{
    public class ProductBase
    {
        [Required]
        [Display(Name = "Naziv")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Količina")]
        public decimal Quantity { get; set; }

        [Required]
        [Display(Name = "Cijena")]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }

    }
}
