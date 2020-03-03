using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;

        public OrderController(IOrderRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        [Authorize]
        public IActionResult List()
        {
            var list = repository.Orders.Where(o => !o.Shipped);
            return View(list);
        }

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = repository.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if(order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }


        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }

            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, Your cart is empty");
            }



            else
            {
                
                ModelState.AddModelError("", "Sorry");
                //return View("No product is select!");
            }


            return View(order);
        }

        public IActionResult Completed()
        {
            cart.Clear();
            return View();
        }

    }
}
