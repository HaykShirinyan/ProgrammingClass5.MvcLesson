using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<UnitOfMeasure> UnitOfMeasures { get; set; }

        public ProductViewModel()
        {
            Product = new Product();
        }
    }
}
