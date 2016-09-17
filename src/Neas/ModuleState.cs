using System;

namespace Neas
{
    /// <summary>
    /// CLass that represents the modules state. This uses the state pattern.
    /// </summary>
    public abstract class ModuleState
    {
        /// <summary>
        /// Internal constructor to prevent inheritance outside of this assembly
        /// </summary>
        internal ModuleState()
        {
        }

        /// <summary>
        /// Indicate if the module is currently running
        /// </summary>
        public virtual bool IsRunning { get { return false; } }

        /// <summary>
        /// Indicate that the module has encountered an error
        /// </summary>
        public virtual bool ErrorOccured { get { return false; } }
    }
}

