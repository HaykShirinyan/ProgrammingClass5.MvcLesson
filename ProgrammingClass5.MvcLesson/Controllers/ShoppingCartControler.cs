using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Data;
using ProgrammingClass5.MvcLesson.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace ProgrammingClass5.MvcLesson.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = await _context.ShoppingCarts
                                          .Include(sc => sc.Product)
                                          .Where(sc => sc.UserId == userId)
                                          .ToListAsync();
            return View(cartItems);
        }

        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = await _context.ShoppingCarts
            .FirstOrDefaultAsync(sc => sc.UserId == userId && sc.ProductId == productId);

            if (cartItem == null)
            {
                cartItem = new ShoppingCart
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                };
                _context.ShoppingCarts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await _context.ShoppingCarts.FindAsync(id);
            if (cartItem != null)
            {
                _context.ShoppingCarts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            return Content("You bought the product!");
        }
    }
}
