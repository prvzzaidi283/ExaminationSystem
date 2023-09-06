using CoreDemo.DataAccess.Constructs;
using Dapper;
using System.Reflection;

namespace CoreDemo.Extensions
{
	internal static class ParameterExtensions
	{
		static bool IsNotNull(object obj)
		{
			if (obj == null) return false;
			return !string.IsNullOrEmpty(obj.ToString());
		}

		static string AppendFor(this string toAppend, string whatToAppend)
		{
			return toAppend.StartsWith(whatToAppend) ? toAppend : $"{whatToAppend}{toAppend}";
		}

		/// <summary>
		///     converts the passed object's properties that have the MapsToParameterName decorator to a DynamicParameters object
		///     for Dapper
		/// </summary>
		/// <typeparam name="T">type of object</typeparam>
		/// <param name="obj">the object</param>
		/// <returns>instantiated object of DynamicParameters</returns>
		/// <seealso cref="DynamicParameters" />
		internal static DynamicParameters ToParameters<T>(this T obj)
		{
			var parameters = new Dictionary<string, object>();
			try
			{
				foreach (var prop in obj.GetType()
							 .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
				{
					if (prop.GetCustomAttributes(typeof(MapsToParameterName), false)
							.FirstOrDefault(x => x.GetType() == typeof(MapsToParameterName)) is not MapsToParameterName
						mapper) continue;
					if (mapper.IsRequired
						&& !IsNotNull(prop.GetValue(obj)))
						throw new MissingRequiredParameterException(prop.Name);

					if (!IsNotNull(prop.GetValue(obj)))
						continue;

					parameters.Add(prop.Name.AppendFor("@"), prop.GetValue(obj));
				}
			}
			catch
			{
				// usually here because of a property that is not included
			}

			return new DynamicParameters(parameters);
		}

		public sealed class MissingRequiredParameterException : ArgumentException
		{
			public MissingRequiredParameterException(string parameterName
				, string message = "Missing Required Parameter") : base(parameterName, message) { }
		}
	}
}
