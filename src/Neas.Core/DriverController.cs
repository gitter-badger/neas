using System;

namespace Neas.Core
{
    internal sealed class DriverController : IDriverController
    {
        /// <summary>
        /// All managed drivers
        /// </summary>
        private readonly IDriver[] _drivers;

        /// <summary>
        /// Create driver controller with array of drivers
        /// </summary>
        public DriverController(IDriver[] drivers)
        {
            _drivers = drivers;
        }

        #region IDriverController implementation

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public TDriver GetByName<TDriver>(string driverName) where TDriver : IDriver
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

