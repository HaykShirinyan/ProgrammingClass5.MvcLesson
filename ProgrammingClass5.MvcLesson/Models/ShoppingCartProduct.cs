using Microsoft.AspNetCore.Identity;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class ShoppingCartProduct
    {
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
