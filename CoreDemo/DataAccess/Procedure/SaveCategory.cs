using CoreDemo.DataAccess.Constructs;
using CoreDemo.DataAccess.Interfaces;
using CoreDemo.Extensions;
using Dapper;

namespace CoreDemo.DataAccess.Procedure
{
	public class SaveCategory : IDbProc<SaveCategory>
	{
		[MapsToParameterName("ID", false)]
		public int ID { get; set; }

		[MapsToParameterName("CategoryName", false)]
		public string CategoryName { get; set; }


		public string ProcedureName => "dbo._spSaveCategory";

		public DynamicParameters Parameters => this.ToParameters();
	}
}
