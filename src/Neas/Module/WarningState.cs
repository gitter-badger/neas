using System;

namespace Neas.Module
{
    /// <summary>
    /// Module is still running, but encountered an error that requires user attention
    /// </summary>
    internal sealed class WarningState : ModuleStateBase
    {
        /// <summary>
        /// Create a new instance of the <see cref="WarningState"/> class
        /// </summary>
        /// <param name="module">Module.</param>
        public WarningState(ModuleBase module) : base(module)
        {
        }
    }
}

