using System;

namespace Neas
{
    /// <summary>
    /// Interface for all modules that provide core functionality and interact with
    /// the kernel. Kernel reference is linked before the module is started.
    /// </summary>
    public interface ICoreModule : IModule
    {
        /// <summary>
        /// Reference to the kernel
        /// </summary>
        IKernel Kernel { get; set; }
    }
}

