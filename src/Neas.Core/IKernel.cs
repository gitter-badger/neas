using System;
using System.Collections.Generic;

namespace Neas.Core
{
    /// <summary>
    /// API of the central kernel
    /// </summary>
    public interface IKernel
    {
		/// <summary>
		/// Start the kernel and all modules
		/// </summary>
		void Start();

        /// <summary>
        /// Stop execution and prepare for shutdown
        /// </summary>
        void Stop();
    }
}