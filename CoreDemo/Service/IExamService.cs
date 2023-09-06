using CoreDemo.Model;

namespace CoreDemo.Service
{
	public interface IExamService
	{
		Task<bool> SaveUpdateExam(Exam exam);
		Task<Exam> GetExamById(int ID);

		Task<List<Category>> GetCategoryList();

		Task<List<Subject>> GetSubjectByCategoryID(int ID);
		Task<List<ExamVM>> GetExamList();
	}
}
