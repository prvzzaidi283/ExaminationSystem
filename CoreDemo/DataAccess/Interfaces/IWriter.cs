namespace CoreDemo.DataAccess.Interfaces
{
	public interface IWriter<TWriter>
	{
		Task<T> UpdateDb<T, TProc>(IDbProc<TProc> procedure);

		Task<T> Update<T, TProc>(IDbProc<TProc> procedure);
	}
}
