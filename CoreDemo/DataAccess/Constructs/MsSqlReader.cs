using CoreDemo.DataAccess.Interfaces;
using static Dapper.SqlMapper;
using System.Data;
using System.Dynamic;

namespace CoreDemo.DataAccess.Constructs
{
	public class MsSqlReader : IReader<MsSqlReader>
	{
		readonly IContext<MsSqlContext> _context;

		public async Task<T> GetDataItem<T, TProc>(IDbProc<TProc> procedure)
		{
			try
			{
				return (await _context.DbConnection.QueryAsync<T>(procedure.ProcedureName
							, procedure.Parameters
							, commandType: CommandType.StoredProcedure)
						.ConfigureAwait(false))
					.ToList()
					.FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_context.Close();
			}
		}

		public async Task<IEnumerable<T>> GetDataList<T, TProc>(IDbProc<TProc> procedure)
		{
			try
			{
				return (await _context.DbConnection.QueryAsync<T>(procedure.ProcedureName
							, procedure.Parameters
							, commandType: CommandType.StoredProcedure)
						.ConfigureAwait(false))
					.ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				_context.Close();
			}
		}



		
		public MsSqlReader(IContext<MsSqlContext> context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		

		private async Task<List<object>> getMultiple<TProc, Toutput>(IDbProc<TProc> procedure, Toutput readerFuncs)
		{

			try
			{
				var returnResults = new List<object>();

				var gridReader = (await _context.DbConnection.QueryMultipleAsync(procedure.ProcedureName
							, procedure.Parameters
							, commandType: CommandType.StoredProcedure)
						.ConfigureAwait(false));
				
				return returnResults;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				_context.Close();
			}
		}

		
	}
}
