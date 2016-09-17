using System;

namespace Neas
{
    /// <summary>
    /// Standard API for modules within the application server
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Unique name of this module
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Config of this modules
        /// </summary>
        IConfiguration Configuration { get; }

        /// <summary>
        /// Current state of the module
        /// </summary>
        /// <value>The state.</value>
        ModuleState State { get; }

		/// <summary>
		/// Start the module after the kernel has resolved all dependencies and
		/// loaded the config
		/// </summary>
		void Start();

		/// <summary>
		/// Stop exeuction and prepare for application shutdown
		/// </summary>
		void Stop();
    }
}