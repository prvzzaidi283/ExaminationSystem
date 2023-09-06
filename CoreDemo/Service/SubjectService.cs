using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.DataAccess.Procedure;
using CoreDemo.Model;
using Microsoft.Data.SqlClient;

namespace CoreDemo.Service
{
	public class SubjectService : ISubjectService
	{
		private readonly IReader<MsSqlReader> _reader;
		private readonly IWriter<MsSqlWriter> _writer;
		public SubjectService(IReader<MsSqlReader> reader, IWriter<MsSqlWriter> writer) 
		{
			_reader = reader;
			_writer = writer;
		}

		public async Task<List<Category>> GetCategoriesAsync()
		{
			var procedure = new GetCategoryList();
			var result = new List<Category>();
			try
			{
				var list = await _reader

			  .GetDataList<Category, GetCategoryList>(procedure)
			  .ConfigureAwait(false);
				if (list?.Count() > 0)
				{
					result = (List<Category>)list;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public async Task<Subject> GetSubjectById(int id)
		{
			var category = new Subject();

			var procedure = new GetSubjectById { ID = id };
			try
			{
				var response = await _reader
							  .GetDataItem<Subject, GetSubjectById>(procedure)
							  .ConfigureAwait(false);
				if (response != null)
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

		public async Task<List<SubjectVM>> GetSubjectListAsync()
		{
			var procedure = new GetSubjectList();
			var result = new List<SubjectVM>();
			try
			{
				var list = await _reader

			  .GetDataList<SubjectVM, GetSubjectList>(procedure)
			  .ConfigureAwait(false);
				if (list?.Count() > 0)
				{
					result = (List<SubjectVM>)list;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public async Task<bool> SaveUpdateSubject(Subject subject)
		{
			bool result = false;
			var procedure = new SaveSubject { ID = subject.Id, SubjectName = subject.SubjectName,CatID= subject.CatID };
			try
			{
				var response = await _writer
							  .UpdateDb<int, SaveSubject>(procedure)
							  .ConfigureAwait(false);
				if (response == 1)
				{
					result = true;
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}


			return true;
		}
	}
}
