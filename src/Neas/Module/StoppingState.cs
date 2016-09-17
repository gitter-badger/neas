using System;

namespace Neas.Module
{
    /// <summary>
    /// Module is shutting down, but some parts may still be running.
    /// </summary>
    internal sealed class StoppingState : ModuleStateBase
    {
        /// <summary>
        /// Create a new instance of the <see cref="StoppingState"/> class
        /// </summary>
        public StoppingState(ModuleBase module) : base(module)
        {
        }
    }
}

