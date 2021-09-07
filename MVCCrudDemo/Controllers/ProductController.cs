using Microsoft.AspNetCore.Mvc;
using MVCCrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCrudDemo.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL product = new ProductDAL();
        public IActionResult Index()
        {
            List<ProductInfo> productsList = new List<ProductInfo>();
            productsList = product.GetAllProducts().ToList();
            return View(productsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] ProductInfo obj)
        {
            if (ModelState.IsValid)
            {
                product.AddProduct(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) {
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
        public IActionResult Edit(int? id, [Bind] ProductInfo objProd)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid) {
                product.UpdateProduct(objProd);
                return RedirectToAction("Index");   
            }

            return View(objProd);
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
