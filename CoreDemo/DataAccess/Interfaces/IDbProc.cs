using Dapper;

namespace CoreDemo.DataAccess.Interfaces
{
	public interface IDbProc<TProc>
	{
		/// <summary>
		///     the procedure name
		/// </summary>
		string ProcedureName { get; }

		/// <summary>
		///     gets the objects internal properties and converts to a DynamicParameters object for Dapper
		///     <see cref="DynamicParameters" />
		///     <seealso cref="Dapper" />
		/// </summary>
		DynamicParameters Parameters { get; }
	}
}
