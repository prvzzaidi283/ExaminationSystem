using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Model
{
	[Table("TBLEXAM")]
	public class Exam
	{
		public int ID { get; set; }	
		public int CATID { get; set; }
		public int SUBID { get; set; }
		[StringLength(100, ErrorMessage = "Subject Name can not be allow more than 100 characters")]
		public string ExamName { get; set; }
		public DateTime  ExamDate { get; set; }
		public string ExamDescription { get; set; }
		public int ExamDuration { get; set; }
		public int TotalMarks { get; set; }
		public int PassingMarks { get; set; }
		public DateTime DateCreated { get; set; }
		public string ExamDateFomatted { get; set; }


	}
	public class ExamVM :Exam 
	{
		public string CategoryName { get; set; }
		public string SubjectName { get; set; }
		public string ExamDateFomatted { get; set; }

	}
}
