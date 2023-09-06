using CoreDemo.Model;

namespace CoreDemo.Service
{
	public interface ICategoryService
	{
		Task<bool> AddUpdateCategory(Category category);
		Task<List<Category>> GetList();
		Task<Category> GetCategoryById(int id);
	}
}
