﻿using Microsoft.AspNetCore.Mvc;
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
            productsList = product.GetAllProducts().OrderBy(o => o.ID).ToList();
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
                bool isDuplicate = product.IsProductDuplicate(model.ProductInfo.ID);

                if(isDuplicate)
                {
                    ModelState.AddModelError("", "Product with the same ID already exists! Please change it.");
                    model.ProductInfo.ID = 0;
                }
                else
                {
                    product.AddProduct(model);
                    return RedirectToAction("Index");
                }
            }
            return View("CreateOrEdit", model);
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
        public IActionResult Edit(int? id, ProductViewModel objProd)
        {
            var model = new ProductViewModel();

            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid) {
                product.UpdateProduct(objProd.ProductInfo);
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
