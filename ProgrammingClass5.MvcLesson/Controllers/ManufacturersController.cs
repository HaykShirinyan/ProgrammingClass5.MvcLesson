using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(Manufacturer manufacturer)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Manufacturers.Add(manufacturer);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manufacturer = _dbContext.Manufacturers.Find(id);
            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Manufacturers.Update(manufacturer);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }
    }
}
