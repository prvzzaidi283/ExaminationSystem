using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Model
{
	[Table("AnswerMaster")]
	public class AnswerMaster
	{
		public AnswerMaster() { }
		public int Id { get; set; }
		public int QuizId { get; set; }
		public string Answer { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
