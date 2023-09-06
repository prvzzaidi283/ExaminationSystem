using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.Extensions;
using Dapper;

namespace CoreDemo.DataAccess.Procedure
{
	public class SaveExam : IDbProc<SaveExam>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }

		[MapsToParameterName("CatID", false)]
		public int CatID { get; set; }

		[MapsToParameterName("SUBID", false)]
		public int SUBID { get; set; }


		[MapsToParameterName("ExamName", false)]
		public string ExamName { get; set; }

		[MapsToParameterName("ExamDate ", false)]
		public DateTime ExamDate { get; set; }

		[MapsToParameterName("ExamDescription", false)]
		public string ExamDescription { get; set; }

		[MapsToParameterName("ExamDuration", false)]
		public int ExamDuration { get; set; }

		[MapsToParameterName("TotalMarks", false)]
		public int TotalMarks { get; set; }

		[MapsToParameterName("PassingMarks", false)]
		public int PassingMarks { get; set; }
		public string ProcedureName => "dbo._spSaveExam";

		public DynamicParameters Parameters => this.ToParameters();
	}
	public class GetSubjectByCategoryID: IDbProc<GetSubjectByCategoryID>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }
		public string ProcedureName => "dbo._spGetSubjectByCatID";

		public DynamicParameters Parameters => this.ToParameters();
	}
	public class GetExamById : IDbProc<GetExamById>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }
		public string ProcedureName => "dbo._spGetExamID";

		public DynamicParameters Parameters => this.ToParameters();
	}
	public class GetExamList : IDbProc<GetExamList>
	{
		public string ProcedureName => "dbo.sp_GetExamList";

		public DynamicParameters Parameters => this.ToParameters();
	}
}
