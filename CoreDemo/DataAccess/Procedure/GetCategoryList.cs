using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.Extensions;
using Dapper;

namespace CoreDemo.DataAccess.Procedure
{
	public class GetCategoryList : IDbProc<GetCategoryList>
	{
		public string ProcedureName => "dbo._spGetCategoryList";

		public DynamicParameters Parameters => this.ToParameters();
	}

	public class GetCategoryById : IDbProc<GetCategoryById>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }

		public string ProcedureName => "dbo._spGetCategoryByID";

		public DynamicParameters Parameters => this.ToParameters();
	}
}
