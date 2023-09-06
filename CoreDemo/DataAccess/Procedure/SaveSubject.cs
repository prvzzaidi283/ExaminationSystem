using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.Extensions;
using Dapper;

namespace CoreDemo.DataAccess.Procedure
{
	public class SaveSubject : IDbProc<SaveSubject>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }

		[MapsToParameterName("CatID", false)]
		public int CatID { get; set; }

		[MapsToParameterName("SubjectName", false)]
		public string SubjectName { get; set; }

		public string ProcedureName => "dbo._spSaveSubject";

		public DynamicParameters Parameters => this.ToParameters();
	}
	public class GetSubjectList : IDbProc<GetSubjectList>
	{

		public string ProcedureName => "dbo._spGetSubjectList";

		public DynamicParameters Parameters => this.ToParameters();
	}
	public class GetSubjectById : IDbProc<GetSubjectById>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }
		public string ProcedureName => "dbo._spGetSubjectByID";

		public DynamicParameters Parameters => this.ToParameters();
	}
}
