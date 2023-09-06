namespace CoreDemo.DataAccess.Constructs
{
	public class MapsToParameterName : Attribute
	{
		public string ParameterName { get; }

		public bool IsRequired { get; }

		/// <summary>
		///     Associates the decorated property name to the configured procedure parameter
		/// </summary>
		/// <param name="parameterName">The name of the database procedure parameter</param>
		/// <param name="isRequired">True if the parameter is required, default is false</param>
		public MapsToParameterName(string parameterName
			, bool isRequired = false)
		{
			ParameterName = parameterName;
			IsRequired = isRequired;
		}
	}
}
