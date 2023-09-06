using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Model
{
	public class Student
	{
		public int Id { get; set; }

		[StringLength(100, ErrorMessage = "First Name can not be allow more than 100 characters")]
		public string FirstName { get; set; }
		[StringLength(100, ErrorMessage = "Last Name can not be allow more than 100 characters")]
		public string LastName { get; set; }
		public string DOB { get; set; }
		[StringLength(10, ErrorMessage = "Student Number can not be allow more than 10 characters")]
		public string StudNum { get; set; }
		public int GenderID { get; set; }
		[StringLength(10, ErrorMessage = "Pin Code can not be allow more than 10 characters")]
		public string PinCode { get; set; }

		[EmailAddress(ErrorMessage ="Please enter valid email.")]
		[StringLength(255, ErrorMessage = "Email Address can not be allow more than 10 characters")]
		public string EmailAddress { get; set; }
		public string Address { get; set; }
		[StringLength(10, ErrorMessage = "Mobile No can not be allow more than 10 characters")]
		public string MobileNo { get; set; }
		public DateTime DateCreated { get; set; }

	}
	public class Gender
	{
		public int Id { get; set; }
		public string GenderName { get; set; }


	}
}
