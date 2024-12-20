using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Data.Migrations;
using ProgrammingClass5.MvcLesson.Models;
using ProgrammingClass5.MvcLesson.ViewModels;

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

            var viewModel = new ProductColorListViewModel
            {
                ProductId = productId,
                ProductColors = productColors
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var model = new ProductColor
            {
                ProductId = productId
            };

            var viewModel = new ProductColorViewModel
            {
                ProductColor = model,
                Colors = _dbContext.Colors.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductColorViewModel viewModel)
        {
            var product = _dbContext.Products.Find(viewModel.ProductColor.ProductId);
            if (product == null)
            {
                ModelState.AddModelError("", "Invalid ProductId.");
                return View(viewModel);
            }

            _dbContext.Attach(viewModel.ProductColor);

            _dbContext.ProductColors.Add(viewModel.ProductColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = viewModel.ProductColor.ProductId });
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
