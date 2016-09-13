using System;

namespace Neas
{
	/// <summary>
	/// Different types of dependency declaration
	/// </summary>
	[Flags]
	public enum DependencyType
	{
		/// <summary>
		/// The referenced module is required to start this module
		/// </summary>
		StartDependency,

		/// <summary>
		/// The referenced module is optional and does not have to be present at runtime.
		/// If not found the reference property remains null.
		/// </summary>
		OptionalDependency,
	}
}

