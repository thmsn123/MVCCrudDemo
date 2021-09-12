using System.ComponentModel.DataAnnotations;

namespace MVCCrudDemo.Models
{
    public class ProductInfo : IEntityWithId
    {
        [Required]
        [Range(0, 2000000)]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter product name in correct format!")]
        [Display(Name = "Scooter Name")]
        public string Name { get; set; }
        [MinLength(50), MaxLength(500)]
        [Display(Name = "Scooter Specifications")]
        public string Specifications { get; set; }
        [Required(ErrorMessage = "Enter Price in correct format!")]
        [Display(Name = "Scooter Price")]
        public double Price { get; set; }
    }

    public interface IEntityWithId
    {
        int ID { get; set; }
    }
}
