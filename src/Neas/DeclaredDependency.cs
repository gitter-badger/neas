using System;

namespace Neas
{
	/// <summary>
	/// Class that represents a modules dependencies
	/// </summary>
	public class DeclaredDependency
	{
		/// <summary>
		/// Create a new dependency representation
		/// </summary>
		public DeclaredDependency (string name, DependencyType type)
		{
			Name = name;
			Type = type;
		}

		/// <summary>
		/// Name of the referenced module
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Type of dependency as flags
		/// </summary>
		public DependencyType Type { get; private set; }

		/// <summary>
		/// Resolved dependency assigned after resolution
		/// </summary>
        public ResolvedDependency Resolve(IModule module)
        {
            return new ResolvedDependency(this, module);
        }
	}
}

