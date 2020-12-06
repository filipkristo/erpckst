using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorePokus3.Models;

namespace CorePokus3.Controllers
{
    public class HomeController : Controller
    {
        private loginDbContext _context;

        public HomeController(loginDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
