using CoreDemo.Model;

namespace CoreDemo.Service
{
	public interface ISubjectService
	{
		Task<List<Category>> GetCategoriesAsync();
		Task<bool> SaveUpdateSubject(Subject subject);
		Task<List<SubjectVM>> GetSubjectListAsync();
		Task<Subject> GetSubjectById(int id);	
	}
}
