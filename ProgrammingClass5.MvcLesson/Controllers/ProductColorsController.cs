using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductColorsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            var productColors = _dbContext
                .ProductColors
                .Include(productColor => productColor.Color)
                .Where(productColor => productColor.ProductId == productId)
                .ToList();

            ViewBag.ProductId = productId;

            return View(productColors);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var model = new ProductColor
            {
                ProductId = productId
            };

            ViewBag.Colors = _dbContext.Colors.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductColor productColor)
        {
            _dbContext.ProductColors.Add(productColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new
            {
                productId = productColor.ProductId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int productId, int colorId)
        {
            var productColor = _dbContext
                .ProductColors
                .SingleOrDefault(productColor => productColor.ProductId == productId && productColor.ColorId == colorId);

            _dbContext.ProductColors.Remove(productColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new
            {
                productId = productColor.ProductId
            });
        }
    }
}
