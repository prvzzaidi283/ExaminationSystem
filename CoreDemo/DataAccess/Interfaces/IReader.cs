using static Dapper.SqlMapper;

namespace CoreDemo.DataAccess.Interfaces
{
	public interface IReader<TReader>
	{
		
		Task<T> GetDataItem<T, TProc>(IDbProc<TProc> procedure);

		Task<IEnumerable<T>> GetDataList<T, TProc>(IDbProc<TProc> procedure);

		
	}
}
