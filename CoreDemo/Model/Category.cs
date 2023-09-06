using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Model
{
	[Table("TBLCATEGORY")]
	public class Category
	{
		public Category() { }
		public int Id { get; set; }
		[StringLength(50, ErrorMessage = "Category Name can not be allow more than 50 characters")]
		public string CategoryName { get; set; }

	}
}
