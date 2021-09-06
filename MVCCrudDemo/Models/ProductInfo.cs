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
        [Required]
        public string Name { get; set; }
        public string Specifications { get; set; }
        [Required]
        public string Price { get; set; }
    }
}
