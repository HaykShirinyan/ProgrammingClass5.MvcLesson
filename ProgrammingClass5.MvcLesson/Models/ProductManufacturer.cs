using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class ProductManufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Adress { get; set; }  

        [Required]
        public string City { get; set; }

        public string Country { get; set; }

        public double Rating { get; set; }
    }
}
