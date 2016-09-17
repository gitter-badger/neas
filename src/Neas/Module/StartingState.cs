using System;

namespace Neas.Module
{
    /// <summary>
    /// Class that represents a modules state during start up
    /// </summary>
    internal sealed class StartingState : ModuleStateBase
    {
        /// <summary>
        /// Create a new instance of the <see cref="StartingState"/>
        /// </summary>
        internal StartingState(ModuleBase module) : base(module)
        {
        }
    }
}

