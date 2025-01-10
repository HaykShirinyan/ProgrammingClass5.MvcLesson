using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public double Width { get; set; } 

        [Required]
        public double Height { get; set; } 

        [Required]
        public double Depth { get; set; } 

        [StringLength(500)]
        public string Description { get; set; }
    }
}
