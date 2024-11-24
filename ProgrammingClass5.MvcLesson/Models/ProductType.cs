using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(500)]
        [Required]
        public string Description { get; set; }
    }
}
