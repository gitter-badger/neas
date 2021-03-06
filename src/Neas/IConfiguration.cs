using System;

namespace Neas
{
    /// <summary>
    /// Common interface for all config objects 
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Read properties from a config file
        /// </summary>
        void Read(string[] configFile);
        
        /// <summary>
        /// Write properties to config file
        /// </summary>
        string[] Write();
    }
}