using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Red { get; set; }

        [Required]
        public int Green { get; set; }

        [Required]
        public int Black { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}

