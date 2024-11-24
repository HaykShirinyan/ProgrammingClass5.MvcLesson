using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
