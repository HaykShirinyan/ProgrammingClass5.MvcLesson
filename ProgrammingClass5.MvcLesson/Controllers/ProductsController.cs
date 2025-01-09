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

        [HttpPost]
        [Authorize]
        public IActionResult AddToCart(int productId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();

            var cartItem = _dbContext.CartItems
                .FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                _dbContext.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    UserId = userId,
                    Quantity = 1
                });
            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();

            var cartItem = _dbContext.CartItems
                .FirstOrDefault(c => c.Id == cartItemId && c.UserId == userId);

            if (cartItem != null)
            {
                _dbContext.CartItems.Remove(cartItem);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Cart");
        }


        [HttpGet]
        [Authorize]
        public IActionResult Cart()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItems = _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ThenInclude(p => p.UnitOfMeasure)
                .ToList();

            return View(cartItems);
        }
    }
}
