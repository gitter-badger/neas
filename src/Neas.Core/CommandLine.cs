using System;
using Neas;

namespace Neas.Core
{
    /// <summary>
    /// Command line interface for NEAS applications
    /// </summary>
    public class CommandLine
    {
        private readonly IKernel _kernel;

        /// <summary>
        /// Initialize the command line API with the kernel instance
        /// </summary>
        public CommandLine(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Run the application in command line mode
        /// </summary>
        public void Run()
        {
            _kernel.Start();
        }
    }
}

