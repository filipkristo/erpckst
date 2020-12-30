using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorePokus3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;


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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string Login, string Password)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();

            User loginUser = _context.Users.Where(User => User.Login == Login).SingleOrDefault();
            if (loginUser != null)
            {
                var hashedPw = hasher.VerifyHashedPassword(loginUser, loginUser.Password, Password);
                if (hashedPw == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("CurrentUserKey", loginUser.Login);
                    return RedirectToAction("Account", "Bank", new { userKey = loginUser.Login });
                }
            }
            ViewBag.Error = "Email or Password is not matching";
            return View("index");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person newPerson = new Person
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    IsEmployee = model.IsEmployee,
                    Address = model.Address,
                    City = model.City,
                    DateOfBirth = model.DateOfBirth,
                    IsOutsorced = model.IsOutsorced,
                    IsVolunteer = model.IsVolunteer,
                    PIN = model.PIN


                };


                _context.Persons.Add(newPerson);
                _context.SaveChanges();

                User newUser = new User
                {
                    Password = model.Password,
                    Login = model.Login,
                    
                    

                    
                };

                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);

                _context.Users.Add(newUser);
                
                _context.SaveChanges();

                

                return RedirectToAction("Login");
            }
                return View("Index");
        }

       


    }
}
