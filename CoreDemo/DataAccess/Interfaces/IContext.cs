using System.Data;

namespace CoreDemo.DataAccess.Interfaces
{
	public interface IContext<TContext>
	{
		/// <summary>
		///     gets the database connection
		/// </summary>
		IDbConnection DbConnection { get; }

		/// <summary>
		///     closes the connection
		/// </summary>
		void Close();
	}
}
