using System;

namespace Neas.Core
{
    /// <summary>
    /// Class reading/Writing properties to/from config object
    /// </summary>
    internal interface IConfigManager
    {
        /// <summary>
        /// Read properties and write them to the modules config object
        /// </summary>
        void Read(IModule module);
        
        /// <summary>
        /// Write module config properties to file
        /// </summary>
        void Write(IModule module);
    }
}