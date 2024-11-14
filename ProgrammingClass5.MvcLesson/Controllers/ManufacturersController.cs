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

        public IActionResult Index()
        {
            List<Manufacturer> manufacturers = _dbContext.Manufacturers.ToList();
            return View(manufacturers);
        }
    }
}
