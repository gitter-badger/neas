using System;
using Nea.Core;

namespace Nea.Server
{
    public static class Program
    {
        private static IKernel _kernel;
        
        public static void Main()
        {
            // Create the kernel and resolve modules
            _kernel = new Kernel();
            foreach (var module in _kernel.ResolveModules())
            {
                
            }
            
            
            Console.WriteLine("Hello world!");
        }        
    }
}