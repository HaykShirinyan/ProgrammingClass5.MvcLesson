using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
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

        public IActionResult Index()
        {
            List<ProductManufacturer> productManufacturers = _dbContext.ProductManufacturers.ToList();
            return View(productManufacturers);

        }
    }
}
