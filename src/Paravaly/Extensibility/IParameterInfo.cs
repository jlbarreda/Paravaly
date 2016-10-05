namespace Paravaly.Extensibility
{
	/// <summary>
	/// Provides access to the parameter information.
	/// </summary>
	/// <typeparam name="T">The parameter type.</typeparam>
	public interface IParameterInfo<out T>
	{
		/// <summary>
		/// Gets the parameter name.
		/// </summary>
		/// <value>
		/// The parameter name.
		/// </value>
		string Name { get; }

		/// <summary>
		/// Gets the parameter value.
		/// </summary>
		/// <value>
		/// The parameter value.
		/// </value>
		T Value { get; }
	}
}