using System;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Neas.Module
{
    /// <summary>
    /// Module base restricted to this assembly that shall only be used by internal components like the state machine.
    /// </summary>
    public abstract class ModuleBase : IModuleOrchastration
    {
        /// <summary>
        /// Internal constructor to prevent usage of the class outside this assembly. Please
        /// derive from <see cref="ModuleBase{TConfig}"/> instead.
        /// </summary>
        internal ModuleBase() 
        {
            CurrentState = ModuleStateBase.Create(this);
        }

		#region IModule implementation

		/// <see cref="IModule"/>
		public abstract string Name { get; }

		/// <see cref="IModule"/>
        public abstract IConfiguration Configuration { get; }

        /// <see cref="IModule"/>
        ModuleState IModule.State { get { return CurrentState; } }
        /// <summary>
        /// Current state engine object reference
        /// </summary>
        internal ModuleStateBase CurrentState { get; set; }

		/// <see cref="IModule"/>
        void IModule.Start()
        {
            CurrentState.Start();   
        }

		/// <see cref="IModule"/>
        void IModule.Stop()
        {
            CurrentState.Stop();
        }

		#endregion

		#region IModuleOrchastration implementation

        /// <see cref="IModuleOrchastration"/>
        int IModuleOrchastration.ModuleIndex { get; set; }

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

        #region Transitions

        /// <summary>
        /// Execute the startup routine
        /// </summary>
        protected internal abstract void OnStart();

        /// <summary>
        /// Execute the shutdown routine
        /// </summary>
        protected internal abstract void OnStop();

        #endregion
	}

    /// <summary>
    /// Mandatory base class for all implementations of <see cref="IModule"/>
    /// </summary>
    public abstract class ModuleBase<TConfig> : ModuleBase
        where TConfig : IConfiguration, new()
    {
        /// <summary>
        /// Prepare the typed <see cref="IConfig"/> implementation and the class
        /// </summary>
        protected ModuleBase ()
        {
            Config = new TConfig ();
        }

        /// <summary>
        /// Typed access to the config
        /// </summary>
        protected TConfig Config { get; private set;}

        public override IConfiguration Configuration
        {
            get { return Config; }
        }
    }
}

