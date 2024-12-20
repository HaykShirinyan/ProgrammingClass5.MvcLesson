using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Models;
using ProgrammingClass5.MvcLesson.ViewModels;
using System.Security.Claims;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _dbContext
                .Products
                .Include(product => product.UnitOfMeasure)
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                UnitOfMeasures = _dbContext.UnitOfMeasures.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(viewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            viewModel.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new ProductViewModel
            {
                Product = _dbContext.Products.Find(id),
                UnitOfMeasures = _dbContext.UnitOfMeasures.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(viewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            viewModel.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(viewModel);
        }
    }
}
