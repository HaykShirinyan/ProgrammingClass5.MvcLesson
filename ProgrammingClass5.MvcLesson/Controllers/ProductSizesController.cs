using Microsoft.AspNetCore.Mvc;
using ProgrammingClass5.MvcLesson.Data;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductSizesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSizesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
