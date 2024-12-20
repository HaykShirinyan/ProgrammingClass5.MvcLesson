using System.Drawing;
using ProgrammingClass5.MvcLesson.Models;
using Color = ProgrammingClass5.MvcLesson.Models.Color;

namespace ProgrammingClass5.MvcLesson.ViewModels
{
    public class ProductColorViewModel
    {
        public ProductColor ProductColor { get; set; }
        public List<Color> Colors { get; set; }
    }
}
