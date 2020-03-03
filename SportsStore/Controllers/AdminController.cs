using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Products);
        }

        public IActionResult Edit(int productId)
        {
            var list = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(list);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                //there is something wrong with the data values

                return View(product);
            }
        }

        public IActionResult Create()
        {
           return View("Edit", new Product());
        }        

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deleteProduct = repository.DeleteProduct(productId);
            if(deleteProduct != null)
            {
                TempData["message"] = $"{deleteProduct.Name} was deleted";
            }

            return RedirectToAction("Index");
        }



    }
}
