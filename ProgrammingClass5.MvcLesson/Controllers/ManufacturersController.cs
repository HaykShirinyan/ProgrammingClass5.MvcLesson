using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ManufacturersController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ManufacturersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Manufacturer> Manufacturers = _dbContext.Manufacturers.ToList();

            return View(Manufacturers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer Manufacturers)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Manufacturers.Add(Manufacturers);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Manufacturers);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Manufacturers.Find(id);


            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer Manufacturers)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Manufacturers.Update(Manufacturers);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(Manufacturers);
        }
    }
}
