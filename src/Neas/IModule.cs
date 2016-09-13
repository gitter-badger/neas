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
        IConfig Config { get; }

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