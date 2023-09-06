using CoreDemo.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;

namespace CoreDemo.DataAccess.Constructs
{
	public class MsSqlConnection : IConnection<MsSqlConnection>
	{
		const string APPLICATIONNAME = "Online Examination System";

		///<inheritdoc />
		public string DataBase { get; set; }

		///<inheritdoc />
		public string Catalog { get; set; }

		///<inheritdoc />
		public string User { get; set; }

		///<inheritdoc />
		public string UserPassword { get; set; }

		///<inheritdoc />
		public bool UseIntegratedSecurity { get; set; }

		///<inheritdoc />
		public string ConnectionString
		{
			get
			{
				var builder = new SqlConnectionStringBuilder
				{
					DataSource = DataBase,
					InitialCatalog = Catalog,
					ApplicationName = APPLICATIONNAME,
					ConnectTimeout = 30,
					IntegratedSecurity = UseIntegratedSecurity,
					Encrypt = false
				};
				if (UseIntegratedSecurity) return builder.ToString();
				builder.UserID = User;
				builder.Password = UserPassword;

				return builder.ToString();
			}
		}
	}
}
