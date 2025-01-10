using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.ViewModels
{
    public class ProductCategoryViewModel
    {
        public ProductCategory ProductCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}
