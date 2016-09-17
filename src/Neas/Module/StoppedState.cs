using System;

namespace Neas.Module
{
    /// <summary>
    /// Class that represents the stopped state of the module
    /// </summary>
    internal sealed class StoppedState : ModuleStateBase
    {
        /// <summary>
        /// Create a new instance of the stopped state
        /// </summary>
        internal StoppedState(ModuleBase module) : base(module)
        {
        }
    }
}

