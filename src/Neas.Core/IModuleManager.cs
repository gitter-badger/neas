using System;
using System.Collections.Generic;

namespace Neas.Core
{
    /// <summary>
    /// Kernel component that composes the module dependency tree and handles the start
    /// and stop sequence.
    /// </summary>
    internal interface IModuleManager
    {
        /// <summary>
        /// Compose the dependency tree and resolve all references
        /// </summary>
        void Compose();

        /// <summary>
        /// Start all modules
        /// </summary>
        void StartAll();

        /// <summary>
        /// Stop all modules
        /// </summary>
        void StopAll();

        /// <summary>
        /// Start a single module and its dependencies if necessary.
        /// </summary>
        void Start(IModule module);

        /// <summary>
        /// Stop a single module and its dependents if necessary.
        /// </summary>
        void Stop(IModule module);

        /// <summary>
        /// Get all module instances
        /// </summary>
        IEnumerable<IModuleOrchastration> GetAll();
    }
}

