using System;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Neas.Base
{
	public abstract class ModuleBase<TConfig> : IModuleOrchastration
		where TConfig : IConfig, new()
	{
		protected ModuleBase ()
		{
			Config = new TConfig ();
		}

		#region IModule implementation

		/// <see cref="IModule"/>
		public abstract string Name { get; }

		/// <see cref="IModule"/>
		public IConfig Config { get; private set; }

		/// <see cref="IModule"/>
		public abstract void Start ();

		/// <see cref="IModule"/>
		public abstract void Stop ();

		#endregion

		#region IModuleOrchastration implementation

		/// <see cref="IModuleOrchastration"/>
		public IDriverController DriverController { get; set; }

		/// <see cref="IModuleOrchastration"/>
		public abstract DeclaredDependency[] GetDependencies ();

		private ResolvedDependency[] _dependencies;
		/// <see cref="IModuleOrchastration"/>
		public void ResolveDependencies (ResolvedDependency[] moduleReferences)
		{
			_dependencies = moduleReferences;
		}

		/// <summary>
		/// Get the referenced module dependency. If called from a property with matching name
		/// the argument can be left empty and is filled by the compiler.
		/// </summary>
		protected TModule GetDependency<TModule>([CallerMemberName]string name = null)
			where TModule : IModule
		{
			var dependency = _dependencies.FirstOrDefault(dep => dep.Name == name);
			return (TModule)dependency?.Module;
		}

		#endregion
	}
}

