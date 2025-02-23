using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class ShoppingCart
    {
             
            [Key]
            public int Id { get; set; }

            [Required]
            public string UserId { get; set; }
            public IdentityUser User { get; set; }

            [Required]
            public int ProductId { get; set; }
            public Product Product { get; set; }

            [Required]
            public int Quantity { get; set; }
        
    }
}
