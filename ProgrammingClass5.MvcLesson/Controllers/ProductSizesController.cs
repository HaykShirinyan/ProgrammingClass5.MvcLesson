using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Data.Migrations;
using ProgrammingClass5.MvcLesson.Models;
using ProgrammingClass5.MvcLesson.ViewModels;

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
				.Include(productSizes => productSizes.Size)
				.Where(productSizes => productSizes.ProductId == productId)
				.ToList();

			var viewModel = new ProductSizeListViewModel
			{
				ProductId = productId,
				ProductSizes = productSizes
			};

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult Create(int productId)
		{
			var model = new ProductSize
			{
				ProductId = productId
			};

			var viewModel = new ProductSizeViewModel
			{
				ProductSize = model,
				Sizes = _dbContext.Sizes.ToList()
			};

			return View(viewModel);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductSizeViewModel viewModel)
        {
            _dbContext.ProductSizes.Add(viewModel.ProductSize);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new
            {
                productId = viewModel.ProductSize.ProductId
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
