using CoreDemo.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoreDemo.DataAccess.Constructs
{
	public class MsSqlContext : IContext<MsSqlContext>
	{
		const string SQL_DB_FACTORY = "System.Data.SqlClient";
		const int MIN_POOL_SIZE = 30;
		readonly IConnection<MsSqlConnection> _connection;
		IDbConnection _dbContext;

		///<inheritdoc />
		public void Close()
		{
			if (_dbContext != null
				&& _dbContext.State != ConnectionState.Closed)
				_dbContext.Close();
		}

		///<inheritdoc />
		public IDbConnection DbConnection
		{
			get
			{
				if (_dbContext == null)
					_dbContext = new SqlConnection { ConnectionString = _connection.ConnectionString };
				if (_dbContext.State == ConnectionState.Open) return _dbContext;
				_dbContext.Open();
				return _dbContext;
			}
		}

		public MsSqlContext(IConnection<MsSqlConnection> connection)
		{
			_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		}
	}
}
