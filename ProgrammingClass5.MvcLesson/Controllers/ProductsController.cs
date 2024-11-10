using Microsoft.AspNetCore.Mvc;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Product> products = _dbContext.Products.ToList();

            return View(products);
        }
    }
}
