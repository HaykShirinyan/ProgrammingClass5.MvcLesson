using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Models;
using System.Security.Claims;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ShoppingCartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        [ActionName("Index")]
        public async Task<IActionResult> IndexAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartProducts = await _dbContext
                .ShoppingCartProducts
                .Include(cartProduct => cartProduct.Product)
                .Where(cartProduct => cartProduct.UserId == userId)
                .ToListAsync();

            return View(cartProducts);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Add")]
        public async Task<IActionResult> AddAsync(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartProduct = await _dbContext
                .ShoppingCartProducts
                .SingleOrDefaultAsync(cartProduct => cartProduct.UserId == userId && cartProduct.ProductId == productId);

            if (cartProduct == null)
            {
                cartProduct = new ShoppingCartProduct
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 0
                };

                _dbContext.Add(cartProduct);
            }

            cartProduct.Quantity = cartProduct.Quantity + 1;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAsync(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartProduct = await _dbContext
                .ShoppingCartProducts
                .SingleOrDefaultAsync(cartProduct => cartProduct.UserId == userId && cartProduct.ProductId == productId);

            if (cartProduct != null)
            {
                _dbContext.ShoppingCartProducts.Remove(cartProduct);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
