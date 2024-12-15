using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
