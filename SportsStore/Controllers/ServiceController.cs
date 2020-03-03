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
    public class ServiceController : Controller
    {

        private IServiceRepository repository;


        public ServiceController(IServiceRepository repo)
        {
            repository = repo;
        }


        public IActionResult Index()
        {
            
            return View(repository.Services);
        }




    }
}
