using System;

namespace Neas.Module
{
    /// <summary>
    /// Base class for the different states of a module
    /// </summary>
    internal abstract class ModuleStateBase : ModuleState
    {
        /// <summary>
        /// Set state on context
        /// </summary>
        protected ModuleStateBase(ModuleBase module)
        {
            Module = module;
        }

        /// <summary>
        /// Reference to the managed module
        /// </summary>
        protected ModuleBase Module { get; private set; }

        /// <summary>
        /// Create new instance of the state machine
        /// </summary>
        public static ModuleStateBase Create(ModuleBase target)
        {
            return new StoppedState(target);
        }

        #region Transitions

        public virtual void Start()
        {
        }

        public virtual void Stop()
        {
        }

        #endregion


        #region States

        /// <summary>
        /// Transition to the next state
        /// </summary>
        protected void NextState(int stateNumber)
        {
            ModuleStateBase state;
            switch(stateNumber)
            {
                case Stopped:
                    state = new StoppedState(Module);
                    break;
                case Starting:
                    state = new StartingState(Module);
                    break;
                case Running:
                    state = new RunningState(Module);
                    break;
                case Stopping:
                    state = new StoppingState(Module);
                    break;
                case Warning:
                    state = new WarningState(Module);
                    break;
                case Error:
                    state = new ErrorState(Module);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("stateNumber");
            }
            Module.CurrentState = state;
        }

        /// <summary>
        /// Module is stopped and currently not executing any code.
        /// </summary>
        protected const int Stopped = 1;

        /// <summary>
        /// Module is starting and prepares for execution.
        /// </summary>
        protected const int Starting = 2;

        /// <summary>
        /// Module is up and running. Module code is actively executed.
        /// </summary>
        protected const int Running = 3;

        /// <summary>
        /// Module is shutting down and all execution is terminated
        /// </summary>
        protected const int Stopping = 4;

        /// <summary>
        /// Module encountered a non critical error. Execution is resumed, but
        /// the error requires manual confirmation.
        /// </summary>
        protected const int Warning = 5;

        /// <summary>
        /// Module encountered a critical error. Safe execution is no longer possible and
        /// was therefor terminated.
        /// </summary>
        protected const int Error = 6;
        #endregion
    }
}

