using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Model
{
	[Table("StudentAnswerTBL")]
	public class StudentAnswer
	{
		public StudentAnswer() { }
		public int Id { get; set; }
		public int StudID { get; set; }
		public int QuizID { get; set; }	
		public int AnswerID { get; set; }
		public string EssayDescription { get; set; }
		public DateTime DateCreated { get; set; }

	}
}
