using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Data.Migrations;
using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductSizesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSizesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            var productSizes = _dbContext
                .ProductSizes
                .Include(productSize => productSize.Size)
                .Where(productSize => productSize.ProductId == productId)
                .ToList();

            ViewBag.ProductId = productId;

            return View(productSizes);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var model = new ProductSize
            {
                ProductId = productId
            };

            ViewBag.Sizes = _dbContext.Sizes.ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductSize productSize)
        {
            _dbContext.ProductSizes.Add(productSize);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new
            {
                productId = productSize.ProductId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int productId, int sizeId)
        {
            var productSize = _dbContext
                .ProductSizes
                .SingleOrDefault(productSize => productSize.ProductId == productId && productSize.SizeId == sizeId);

            _dbContext.ProductSizes.Remove(productSize);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new
            {
                productId = productSize.ProductId
            });
        }
    }
}
