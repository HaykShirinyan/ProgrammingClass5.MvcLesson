using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Models;
using ProgrammingClass5.MvcLesson.ViewModels;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            var productCategories = _dbContext
                .ProductCategories
                .Include(productCategory => productCategory.Category)
                .Where(productCategory => productCategory.ProductId == productId)
                .ToList();

            var viewModel = new ProductCategoryListViewModel
            {
                ProductId = productId,
                ProductCategories = productCategories
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var model = new ProductCategory
            {
                ProductId = productId
            };

            var viewModel = new ProductCategoryViewModel
            {
                ProductCategory = model,
                Categories = _dbContext.Categories.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategoryViewModel viewModel)
        {
            _dbContext.ProductCategories.Add(viewModel.ProductCategory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new
            {
                productId = viewModel.ProductCategory.ProductId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int productId, int categoryId)
        {
            var productCategory = _dbContext
                .ProductCategories
                .SingleOrDefault(productCategory => productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            _dbContext.ProductCategories.Remove(productCategory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new
            {
                productId = productCategory.ProductId
            });
        }
    }
}
