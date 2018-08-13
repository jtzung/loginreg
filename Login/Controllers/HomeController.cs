
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login.Models;
using Microsoft.AspNetCore.Http;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
       

        public HomeController(UserContext context){ 
            _context=context; 
            
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           
           return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(ValidateUser NewUser)
        {
            
            
            if(ModelState.IsValid){
                User DBUser = _context.user.SingleOrDefault(u => u.Email == NewUser.Email);
                if (DBUser != null)
                {
                    ViewBag.Error = "Email already exists";
                    return View("Index");
                }



                User RealUser= new User();
                RealUser.Name = NewUser.Name;
                RealUser.Email = NewUser.Email;
                RealUser.Password = NewUser.Password;
                RealUser.Age = NewUser.Age;
                HttpContext.Session.SetString("UserName", NewUser.Name);

                
                _context.user.Add(RealUser);
                _context.SaveChanges();
                
                return RedirectToAction("About", NewUser);
                
            }

            return View("Index");
        }

        public IActionResult Login(string LogEmail, string LogPass){

            User DBUser = _context.user.SingleOrDefault(u => u.Email == LogEmail);
            if(DBUser == null){
                ViewBag.Error="Invalid Login";
                return View("Index");
            }
            if(LogPass != DBUser.Password){
                ViewBag.Error="Invalid Login";
                return View("Index");

            }
          
            HttpContext.Session.SetString("UserName", DBUser.Name);
            return RedirectToAction("About");

        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page";
            ViewBag.Name= HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
