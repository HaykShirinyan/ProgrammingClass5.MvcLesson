using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class SizesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public SizesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
