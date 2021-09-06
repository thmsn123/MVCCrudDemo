using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCrudDemo.Models
{
    public class ProductDAL
    {
        static List<ProductInfo> productsList = new List<ProductInfo>() {
                new ProductInfo(){ ID = 1, Name="Mi Electric Scooter Essential", Specifications="Mi Electric Scooter Essential is designed for people who want to keep it light and easy. It uses a low-density, high-strength aerospace grade aluminum alloy, so that the net weight of the vehicle is only 12kg, making it easy to carry.",Price="350$"},
                new ProductInfo(){ ID = 2, Name="Mi Electric M365", Specifications="The Xiaomi Mi M365 has reigned supreme as the best electric scooter in the world since it hit the market in 2016. Winning a Red Dot award a year later, the M365 has historical importance, as it is the workhorse scooter selected by sharing companies to sprinkle throughout metropolitan cities around the world. For that reason, more people have experienced their first ride on a M365 than most other scooters and find it familiar and comfortable.", Price="400$"},
                new ProductInfo(){ ID = 3, Name="Mi Electric Scooter 1S",  Specifications="The kinetic energy recovery system (KERS) has been fully upgraded, and the energy conversion efficiency has been furtherimproved. It can recover the kinetic energy of each braking and non-powered coasting, and convert it into usable electricalenergy to further improve the cruising range. The efficiency of energy recovery can be adjusted through the Mi Home App tomeet your individual riding needs", Price="450$"},
                new ProductInfo(){ ID = 4, Name="Mi Electric Scooter 3",  Specifications="The scooter can reach a maximum speed of 25km/h and has a 16% slope climbing capacity. Propel yourself forward with just a light press of the accelerator.", Price="550$"},
                new ProductInfo(){ ID = 5, Name="Mi Electric Scooter PRO 2",  Specifications="The battery is safe and durable with a capacity of 446Wh. Acceleration is fastreaching a maximum speed of 25km/h. A full charge can take you 45 kilometers.", Price="600$"}
            };
        public IEnumerable<ProductInfo> GetAllProducts()
        {
            return productsList;
        }

        public IEnumerable<ProductInfo> AddProduct(ProductInfo product)
        {
            product.ID = productsList.Count() + 1;
            productsList.Add(product);

            return productsList;
        }

        public IEnumerable<ProductInfo> DeleteProduct(ProductInfo item)
        {
            productsList.Remove(GetProductByID(item.ID));

            return productsList;
        }

        public ProductInfo GetProductByID(int? ID)
        {
            int index = 0;

            if (ID.HasValue) {
                index = productsList.IndexOf(productsList.Where(prop => prop.ID == ID).FirstOrDefault());
            }

            return productsList[index];
        }

        public ProductInfo UpdateProduct(ProductInfo objProd) 
        {
            int index = productsList.IndexOf(productsList.Where(prop => prop.ID == objProd.ID).FirstOrDefault());
            productsList[index] = objProd;

            return productsList[index];
        }
    }
}
