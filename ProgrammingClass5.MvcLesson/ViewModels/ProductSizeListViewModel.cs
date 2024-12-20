using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.ViewModels
{
	public class ProductSizeListViewModel
	{
		public int ProductId {  get; set; }
		public List<ProductSize> ProductSizes{ get; set; }
	}
}
