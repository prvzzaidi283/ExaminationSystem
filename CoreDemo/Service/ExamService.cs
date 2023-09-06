using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.DataAccess.Procedure;
using CoreDemo.Model;
using Microsoft.Data.SqlClient;

namespace CoreDemo.Service
{
	public class ExamService : IExamService
	{
		private readonly IReader<MsSqlReader> _reader;
		private readonly IWriter<MsSqlWriter> _writer;
		public ExamService(IReader<MsSqlReader> reader, IWriter<MsSqlWriter> writer)
		{
			_reader = reader;
			_writer = writer;
		}
		public async Task<List<Category>> GetCategoryList()
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

		public async Task<Exam> GetExamById(int ID)
		{
			var category = new Exam();

			var procedure = new GetExamById { ID = ID };
			try
			{
				var response = await _reader
							  .GetDataItem<Exam, GetExamById>(procedure)
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

		public async Task<List<ExamVM>> GetExamList()
		{
			var procedure = new GetExamList();
			var result = new List<ExamVM>();
			try
			{
				var list = await _reader

			  .GetDataList<ExamVM, GetExamList>(procedure)
			  .ConfigureAwait(false);
				if (list?.Count() > 0)
				{
					result = (List<ExamVM>)list;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public async Task<List<Subject>> GetSubjectByCategoryID(int ID)
		{
			var subjectList = new List<Subject>();

			var procedure = new GetSubjectByCategoryID { ID = ID };
			try
			{
				var response = await _reader
							  .GetDataList<Subject, GetSubjectByCategoryID>(procedure)
							  .ConfigureAwait(false);
				if (response != null)
				{
					subjectList =(List<Subject>)response;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return subjectList;
		}

		public async Task<bool> SaveUpdateExam(Exam exam)
		{
			bool result = false;
			var procedure = new SaveExam { ID = exam.ID, CatID = exam.CATID, SUBID = exam.SUBID,ExamName= exam.ExamName,ExamDate=exam.ExamDate,ExamDescription=exam.ExamDescription,ExamDuration = exam.ExamDuration, TotalMarks=exam.TotalMarks,PassingMarks= exam.PassingMarks };
			try
			{
				var response = await _writer
							  .UpdateDb<int, SaveExam>(procedure)
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
