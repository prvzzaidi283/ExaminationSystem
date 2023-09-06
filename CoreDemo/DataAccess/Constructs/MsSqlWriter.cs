using CoreDemo.DataAccess.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoreDemo.DataAccess.Constructs
{
	public class MsSqlWriter : IWriter<MsSqlWriter>
	{
		readonly IContext<MsSqlContext> _context;

		public async Task<T> UpdateDb<T, TProc>(IDbProc<TProc> procedure)
		{
			try
			{

				var dbResponse = await _context.DbConnection.ExecuteScalarAsync(procedure.ProcedureName
						, procedure.Parameters
						, commandType: CommandType.StoredProcedure)
					.ConfigureAwait(false);
				return (T)Convert.ChangeType(dbResponse, typeof(T));
			}
			catch (SqlException ex)
			{
			
				throw ex;
			}
			catch (Exception ex)
			{
				
				return default;
			}
		}


		public MsSqlWriter(IContext<MsSqlContext> context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}


		public async Task<T> Update<T, TProc>(IDbProc<TProc> procedure)
		{
			try
			{

				var dbResponse = await _context.DbConnection.ExecuteScalarAsync(procedure.ProcedureName
						, procedure.Parameters
						, commandType: CommandType.StoredProcedure)
					.ConfigureAwait(false);
				return (T)Convert.ChangeType(dbResponse, typeof(T));
			}
			catch (SqlException ex)
			{

				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		
	}
}
