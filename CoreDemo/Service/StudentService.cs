using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.DataAccess.Procedure;
using CoreDemo.Model;
using Microsoft.Data.SqlClient;

namespace CoreDemo.Service
{
	public class StudentService : IStudentService
	{
		private readonly IReader<MsSqlReader> _reader;
		private readonly IWriter<MsSqlWriter> _writer;
		public StudentService(IReader<MsSqlReader> reader, IWriter<MsSqlWriter> writer) 
		{
			_reader = reader;
			_writer = writer;

		}
		public async Task<Student> GetStudentById(int id)
		{
            var student = new Student();

            var procedure = new GetStudentByID { ID = id };
            try
            {
                var response = await _reader
                              .GetDataItem<Student, GetStudentByID>(procedure)
                              .ConfigureAwait(false);
                if (response != null)
                {
                    student = response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return student;
        }

		public async Task<List<Student>> GetStudentListAsync()
		{
			var procedure = new GetStudentList();
			var result = new List<Student>();
			try
			{
				var list = await _reader

			  .GetDataList<Student, GetStudentList>(procedure)
			  .ConfigureAwait(false);
				if (list?.Count() > 0)
				{
					result = (List<Student>)list;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public async Task<bool> SaveUpdateStudent(Student student)
		{
			bool result = false;
			var procedure = 
				
			new SaveStudent { 
				ID = student.Id, 
				FirstName = student.FirstName,
				LastName = student.LastName, 
				DOB = student.DOB, 
				STUNUM = student.StudNum, 
				GenderID = student.GenderID, 
				PINCODE = student.PinCode, 
				EmailAddress = student.EmailAddress,
				Address = student.Address ,
				MobileNo = student.MobileNo
			};
			try
			{
				var response = await _writer
							  .UpdateDb<int, SaveStudent>(procedure)
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
