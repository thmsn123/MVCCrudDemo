using Microsoft.AspNetCore.Mvc;
using MVCCrudDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCCrudDemo.Controllers
{
    public class ProductController : Controller
    {
        ProductViewModel product = new ProductViewModel();
        public IActionResult Index()
        {
            List<ProductInfo> productsList = new List<ProductInfo>();
            productsList = product.GetAllProducts().ToList();
            return View(productsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductViewModel();

            return View("CreateOrEdit", model);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                product.AddProduct(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ProductInfo prod = product.GetProductByID(id);
            var model = new ProductViewModel();
            
            if (id == null || prod == null) {
                return NotFound();            
            }

            model.ProductInfo = new ProductInfo
            {
                ID = (int)id,
                Name = prod.Name,
                Specifications = prod.Specifications,
                Price = prod.Price
            };

            return View("CreateOrEdit", model);
        }

        [HttpPost]
        public IActionResult Edit(int? id, [Bind] ProductInfo objProd)
        {
            var model = new ProductViewModel();

            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid) {
                product.UpdateProduct(objProd);
                return RedirectToAction("Index");   
            }

            return View("CreateOrEdit", model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductInfo prod = product.GetProductByID(id);

            if (prod == null)
            {
                return NotFound();
            }

            return View(prod);
        }

        [HttpPost]
        public IActionResult Delete(int? id, [Bind] ProductInfo objProd)
        {
            if (id == null)
            {
                return NotFound();
            }

            product.DeleteProduct(objProd);
            return RedirectToAction("Index"); 
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductInfo prod = product.GetProductByID(id);

            return View(prod);
        }
    }
}
