using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCrudDemo.Models
{
    public class ProductDAL
    {
        static List<ProductInfo> productsList = new List<ProductInfo>() {
                new ProductInfo(){ ID = 0, Name="Xiaomi Essentials", Price="350$"},
                new ProductInfo(){ ID = 1, Name="Xiaomi m365", Price="400$"},
                new ProductInfo(){ ID = 2, Name="Xiaomi MI 1 s", Price="450$"},
                new ProductInfo(){ ID = 3, Name="Xiaomi 3 BLK", Price="550$"},
                new ProductInfo(){ ID = 4, Name="Xiaomi 2 PRO", Price="600$"}
            };
        public IEnumerable<ProductInfo> GetAllProducts()
        {
            return productsList;
        }

        public IEnumerable<ProductInfo> AddProduct(ProductInfo product)
        {
            productsList.Add(product);

            return productsList;
        }

        public IEnumerable<ProductInfo> DeleteProduct(ProductInfo item)
        {
            productsList.Remove(item);

            return productsList;
        }

        public ProductInfo GetProductByID(int? ID)
        {
            int index = 0;

            if (ID.HasValue) {
                index = ID.Value;
            }

            return productsList[index];
        }

        public ProductInfo UpdateProduct(ProductInfo objProd) { 
            return productsList[0];
        }
    }
}
