using Azure;
using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.DataAccess.Procedure;
using CoreDemo.Model;
using System.Linq;

namespace CoreDemo.Service
{
	public class CategoryService : ICategoryService
	{
		private readonly IReader<MsSqlReader> _reader;
		private readonly IWriter<MsSqlWriter> _writer;
		public CategoryService(IReader<MsSqlReader> reader, IWriter<MsSqlWriter> writer) {
		  _reader = reader;
		  _writer = writer;
		}

		public async Task<bool> AddUpdateCategory(Category category)
		{
			bool result = false;
			var procedure = new SaveCategory { ID = category.Id, CategoryName = category.CategoryName };
			try
			{
				var response = await _writer
							  .UpdateDb<int, SaveCategory>(procedure)
							  .ConfigureAwait(false);
				if(response ==1)
				{
					result = true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			

			return true;
		}

		public async Task<Category> GetCategoryById(int id)
		{
			var category = new Category();

			var procedure = new GetCategoryById { ID = id };
			try
			{
				var response = await _reader
							  .GetDataItem<Category, GetCategoryById>(procedure)
							  .ConfigureAwait(false);
				if (response !=null)
				{
					category = response;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return category;
		}

		public async Task<List<Category>> GetList()
		{
			var procedure = new GetCategoryList();
			var result = new List<Category>();
			try
			{
				var list = await _reader

			  .GetDataList<Category, GetCategoryList>(procedure)
			  .ConfigureAwait(false);
				if(list?.Count()>0)
				{
					result =(List<Category>)list;
				}
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}
}
