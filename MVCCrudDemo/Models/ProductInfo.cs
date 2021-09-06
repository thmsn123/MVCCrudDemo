using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCrudDemo.Models
{
    public class ProductInfo
    {
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter product name in correct format!")]
        [Display(Name = "Scooter Name")]
        public string Name { get; set; }
        [MinLength(50),MaxLength(500)]
        [Display(Name = "Scooter Specifications")]
        public string Specifications { get; set; }
        [Required (ErrorMessage ="Enter Price in correct format!")]
        [Display(Name = "Scooter Price")]
        public int Price { get; set; }
    }
}
