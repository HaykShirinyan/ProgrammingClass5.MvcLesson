using Microsoft.AspNetCore.Mvc;
using ProgrammingClass5.MvcLesson.Data;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductColorsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
