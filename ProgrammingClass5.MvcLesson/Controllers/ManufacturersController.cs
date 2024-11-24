using Microsoft.AspNetCore.Mvc;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Data.Migrations;
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
        public IActionResult Index(ApplicationDbContext _dbContext)
        {
            List<Manufacturer> manufacturers = _dbContext.Manufacturers.ToList();

            return View(manufacturers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer manufacturers)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Manufacturers.Add(manufacturers);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(manufacturers);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manufacturers = _dbContext.ProductTypes.Find(id);
            return View(manufacturers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer manufacturers)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Manufacturers.Update(manufacturers);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(manufacturers);
        }
    }
}
