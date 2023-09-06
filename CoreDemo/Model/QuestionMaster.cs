using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Model
{
	[Table("QuestionMasterTBL")]
	public class QuestionMaster
	{
		public QuestionMaster() { }
		public int Id { get; set; }
		public int Type { get; set; }

		public string Question { get; set; }
		public DateTime DateCreated { get; set; }

	}
}
