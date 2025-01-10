using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.ViewModels
{
    public class ProductCategoryListViewModel
    {
        public int ProductId { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
