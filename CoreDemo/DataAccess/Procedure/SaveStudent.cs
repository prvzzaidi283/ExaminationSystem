using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.Extensions;
using Dapper;

namespace CoreDemo.DataAccess.Procedure
{
	public class SaveStudent : IDbProc<SaveStudent>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }

		[MapsToParameterName("FirstName", false)]
		public string FirstName { get; set; }

		[MapsToParameterName("LastName", false)]
		public string LastName { get; set; }

		[MapsToParameterName("DOB", false)]
		public string DOB { get; set; }

		[MapsToParameterName("STUNUM  ", false)]
		public string STUNUM { get; set; }

		[MapsToParameterName("GenderID", false)]
		public int GenderID { get; set; }

		[MapsToParameterName("PINCODE", false)]
		public string PINCODE { get; set; }

		[MapsToParameterName("EmailAddress", false)]
		public string EmailAddress { get; set; }

		[MapsToParameterName("Address", false)]
		public string Address { get; set; }

		[MapsToParameterName("MobileNo", false)]
		public string MobileNo { get; set; }
		public string ProcedureName => "dbo._spSaveStudent";

		public DynamicParameters Parameters => this.ToParameters();
	}

	public class GetStudentByID : IDbProc<GetStudentByID>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }
		public string ProcedureName => "dbo._spGetStudentById";

		public DynamicParameters Parameters => this.ToParameters();
	}
	public class GetStudentList : IDbProc<GetStudentList>
	{
		public string ProcedureName => "dbo._spGetStudentList";

		public DynamicParameters Parameters => this.ToParameters();
	}
}
