using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Model
{
	[Table("QuestionTypeMaster")]
	public class QuestionTypeMaster
	{
		public QuestionTypeMaster() { }
		public int Id { get; set; }	
		public string QuestionType { get; set; }

	}
}
