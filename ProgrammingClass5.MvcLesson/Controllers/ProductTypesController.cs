using Microsoft.AspNetCore.Mvc;
using ProgrammingClass5.MvcLesson.Models;
using ProgrammingClass5.MvcLesson.Data;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ProductTypesController : Controller    
    {
        public  ApplicationDbContext _dbContext;

        public ProductTypesController (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductType> productTypes = _dbContext.ProductTypes.ToList();

            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductType productType)
        {
            if(ModelState.IsValid)
            {
                _dbContext.ProductTypes.Add(productType);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(productType);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productType = _dbContext.ProductTypes.Find(id);
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductType productType)
        {
            if(ModelState.IsValid)
            {
                _dbContext.ProductTypes.Update(productType);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(productType);
        }
    }
}
