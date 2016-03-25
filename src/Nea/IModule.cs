using System;

namespace Nea
{
    /// <summary>
    /// Standard API for modules within the application server
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Unique name of this module
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Config of this modules
        /// </summary>
        IConfig Config { get; }    
    }
}