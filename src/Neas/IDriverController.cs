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
        /// Start driver controller and all drivers
        /// </summary>
        void Start();

        /// <summary>
        /// Stop driver controller and terminate connection of all drivers
        /// </summary>
        void Stop();

        /// <summary>
        /// Get driver by name.
        /// </summary>
        TDriver GetByName<TDriver>(string driverName)
            where TDriver : IDriver;
    }
}

