using System;
using System.Collections.Generic;

namespace Neas
{
    /// <summary>
    /// API of the central kernel
    /// </summary>
    public interface IKernel
    {
        /// <summary>
        /// Reference to the config manager
        /// </summary>
        IConfigManager ConfigManager { get; }
        
        /// <summary>
        /// Get all installed modules
        /// </summary>
        IEnumerable<IModule> ResolveModules();
    }
}