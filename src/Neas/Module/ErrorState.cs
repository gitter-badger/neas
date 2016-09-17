using System;

namespace Neas.Module
{
    /// <summary>
    /// Module encountered a crititcal error and is no longer operational. Execution is
    /// terminated and all dependents are stopped.
    /// </summary>
    internal sealed class ErrorState : ModuleStateBase
    {
        public ErrorState(ModuleBase module) : base(module)
        {
        }
    }
}

