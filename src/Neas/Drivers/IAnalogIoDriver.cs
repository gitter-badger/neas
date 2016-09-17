using System;

namespace Neas.Drivers
{
    /// <summary>
    /// Driver API for analog devices and connections of various types. While the <see cref="IDigitalIoDriver"/>
    /// allows access to multiple pins over one instance, analog drivers only represent a single device,
    /// </summary>
    public interface IAnalogIoDriver
    {
        /// <summary>
        /// Metric unit of the value
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// Read the analog input value.
        /// </summary>
        double In { get; }

        /// <summary>
        /// Read or write the analog output value.
        /// </summary>
        double Out { get; set; }
    }
}

