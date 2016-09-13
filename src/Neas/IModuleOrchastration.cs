using System;

namespace Neas
{
	/// <summary>
	/// Extented interface of <see cref="IModule"/> required by the kernel to
	/// reference dependencies.
	/// </summary>
	public interface IModuleOrchastration : IModule
	{
        /// <summary>
        /// All modules receive access to the driver controller
        /// </summary>
        IDriverController DriverController { get; set; }

		/// <summary>
		/// Export all dependencies of the module
		/// </summary>
		DeclaredDependency[] GetDependencies();

		/// <summary>
		/// Return all dependencies with filled references to their modules
		/// </summary>
		void ResolveDependencies(ResolvedDependency[] moduleReferences);
	}
}

