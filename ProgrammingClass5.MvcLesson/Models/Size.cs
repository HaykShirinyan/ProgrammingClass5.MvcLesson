using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public decimal Length { get; set; }
        [Required]
        public decimal Height { get; set; }
        [Required]
        public decimal Width { get; set; }



    }
}
