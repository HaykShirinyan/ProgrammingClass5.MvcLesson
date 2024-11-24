using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Data.Migrations;
using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductManufacturersController : Controller

    {
        private ApplicationDbContext _dbContext;

        public ProductManufacturersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductManufacturer> productManufacturers = _dbContext.ProductManufacturers.ToList();
            return View(productManufacturers);

        }

        [HttpGet]
        public IActionResult Create()

        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductManufacturer productManufacturer)
        {
            if (ModelState.IsValid)
            {

                _dbContext.ProductManufacturers.Add(productManufacturer);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(productManufacturer);
        }


            [HttpGet]
             public IActionResult Edit(int id)

            { 
                var productManufacturer = _dbContext.ProductManufacturers.Find(id);
                return View(productManufacturer);
            
            }

            [HttpPost]
            [ValidateAntiForgeryToken]

            public IActionResult Edit(ProductManufacturer productManufacturer) 
        {
            if (ModelState.IsValid)
            { 
                _dbContext.ProductManufacturers.Update(productManufacturer);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            
            }

            return View(productManufacturer);




        }
        
    }
}
