using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDemo.Model
{
	[Table("TBLSUBJECT")]
	public class Subject
	{
		public Subject() { }
		public int Id { get; set; }
		public int CatID { get; set; }
		[StringLength(50, ErrorMessage = "Subject Name can not be allow more than 50 characters")]
		public string SubjectName { get; set; }
	}

    public class SubjectVM : Subject
    {
        public string CategoryName { get; set; }
	}
}
