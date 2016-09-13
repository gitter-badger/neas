using System;

namespace Neas
{
    /// <summary>
    /// Distribution component that resolves instances of <see cref="IDriver"/> by 
    /// name.
    /// </summary>
    public interface IDriverController
    {
        /// <summary>
        /// Get driver by name.
        /// </summary>
        TDriver GetByName<TDriver>(string driverName)
            where TDriver : IDriver;
    }
}

