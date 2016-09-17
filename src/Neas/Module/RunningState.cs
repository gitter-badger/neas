using System;

namespace Neas.Module
{
    /// <summary>
    /// Module is in running state and fully functional
    /// </summary>
    internal sealed class RunningState : ModuleStateBase
    {
        /// <summary>
        /// Create a new instance of the <see cref="RunningState"/> class
        /// </summary>
        public RunningState(ModuleBase module) : base(module)
        {
        }

        public override bool IsRunning
        {
            get { return true; }
        }

        public override void Stop()
        {
            NextState(Stopping);
            try
            {
                Module.OnStop();

                NextState(Stopped);
            }
            catch (Exception ex)
            {
                NextState(Error);
            }
        }
    }
}

