using crudsample.Data;
using crudsample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace crudsample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _ctx;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Home home)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.time.Add(home);
                _ctx.SaveChanges();
                TempData["Msg"] = "Added Succesfully";
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Read()
        {
            var home=_ctx.time.ToList();
            return View(home);
        }
     
        public IActionResult Edit(int id)
        {
            var home=_ctx.time.Find(id);
            return View(home);
        }
        [HttpPost]
        public IActionResult Edit(Home home)
        {
            if (!ModelState.IsValid)
            {
                return View(home);
            }
            try
            {
                _ctx.time.Update(home);
                _ctx.SaveChanges();
                return RedirectToAction("Read");
            }
            catch(Exception ex)
            {
                return View();
            }
        }



        public IActionResult Delete(int Id)
        {
            var home = _ctx.time.Find();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Home home)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.time.Remove(home);
                _ctx.SaveChanges();
                return RedirectToAction("Read");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            var home=_ctx.time.Find(id);
            return View(home);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
