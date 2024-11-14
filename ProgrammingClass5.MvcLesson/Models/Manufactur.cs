using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass5.MvcLesson.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        public string Country { get; set; }

        public int EstablishedYear { get; set; }

        public string  Website { get; set; }
    }
}
