using System;
using System.Collections.Generic;
using System.Linq;

namespace Neas.Core
{
	/// <summary>
	/// The kernel of the entire application that is created by the individual runner application
	/// and orchastrates the modules 
	/// </summary>
    public sealed class Kernel : IKernel
    {
		/// <summary>
		/// Config manage that composes the dependency tree and handles the life cylce
		/// </summary>
		private readonly IModuleManager _moduleManager;

		/// <summary>
		/// Config manager that helps <see cref="IConfig"/> objects read and write
		/// from and to the file system.
		/// </summary>
		private readonly IConfigManager _configManager;

        /// <summary>
        /// The driver controller.
        /// </summary>
        private readonly IDriverController _driverController;

		/// <summary>
		/// Initializes a new instance of the <see cref="Neas.Core.Kernel"/> class.
		/// </summary>
		/// <param name="configDir">Directory where config files are stored</param>
		/// <param name="modules">Instances of all modules</param>
		public Kernel(string configDir, IModuleOrchastration[] modules, IDriver[] drivers)
		{
			_configManager = new ConfigManager (configDir);
            _moduleManager = new ModuleManager(modules);
            _driverController = new DriverController(drivers);
		}

        /// <see cref="IKernel"/>
        public void Start()
        {
            // Step 1: Compose the dependency tree and link references
            _moduleManager.Compose();

            // Step 2: Load the configs
            foreach (var module in _moduleManager.GetAll())
            {
                _configManager.Read(module);
            }

            // Step 3: Provide driver controller
            foreach(var module in _moduleManager.GetAll())
            {
                module.DriverController = _driverController;
            }

            // Step 4: Start all drivers
            _driverController.Start();

            // Step 5: Link core modules and kernel
            foreach (var module in _moduleManager.GetAll().OfType<ICoreModule>())
            {
                module.Kernel = this;
            }

            // Step 6: Start all modules
            _moduleManager.StartAll();
        }

        /// <see cref="IKernel"/>
        public void Stop()
        {
            // Step 1: Stop all modules
            _moduleManager.StopAll();

            // Step 2: Stop all drivers
            _driverController.Stop();

            // Step 3: Save the current state of all configs if they were modified
            foreach(var module in _moduleManager.GetAll()) 
            {
                _configManager.Write(module);   
            }
        }

        /// <see cref="IKernel"/>
        public IEnumerable<IModule> GetAll()
        {
            return _moduleManager.GetAll();
        }
    }
}