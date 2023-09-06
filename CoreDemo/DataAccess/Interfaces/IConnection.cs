namespace CoreDemo.DataAccess.Interfaces
{
	public interface IConnection<TConnection>
	{
		/// <summary>
		///     the database server
		/// </summary>
		string DataBase { get; set; }

		/// <summary>
		///     the catalog to use
		/// </summary>
		string Catalog { get; set; }

		/// <summary>
		///     user name for connection, if used
		/// </summary>
		string User { get; set; }

		/// <summary>
		///     password for connection, if used
		/// </summary>
		string UserPassword { get; set; }

		/// <summary>
		///     set to true to use integrated security
		/// </summary>
		bool UseIntegratedSecurity { get; set; }

		/// <summary>
		///     parses the object and returns the fully formed connection string
		/// </summary>
		string ConnectionString { get; }
	}
}
