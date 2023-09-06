using CoreDemo.Model;

namespace CoreDemo.Service
{
	public interface IStudentService
	{
		Task<bool> SaveUpdateStudent(Student student);
		Task<List<Student>> GetStudentListAsync();
		Task<Student> GetStudentById(int id);
	}
}
