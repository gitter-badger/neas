using System;

namespace Neas.Drivers
{
    /// <summary>
    /// Driver interface for digital IO ports. This includes extension devices
    /// and onboard connections.
    /// </summary>
    /// <example>
    /// // Read value
    /// IDigitalIoDriver driver = DriverController.GetByName("Foo");
    /// var input = driver.In[3];
    /// if (input)
    ///    driver.Out[4] = true; // Assign value
    /// 
    /// // Read range or assign range
    /// var range = driver.From[3].To[8];
    /// driver.From[0].To[7] = 0x42;
    /// 
    /// // If you don't like the fance fluent API
    /// range = driver.GetRange(3, 8);
    /// driver.SetRange(0, 7, 0x42);
    /// </example>
    public interface IDigitalIoDriver
    {
        /// <summary>
        /// Access to the drivers digital inputs
        /// </summary>
        IDigitalInputs In { get; }

        /// <summary>
        /// Read or write outputs of the device
        /// </summary>
        IDigitalOutputs Out { get; }

        /// <summary>
        /// Initiate a fluent API call for range access
        /// </summary>
        AddressRangeStart From { get; }

        /// <summary>
        /// Get a maximum of 32bits in an adress range. The value is without offset. Bit at the start address
        /// is the first bit in the integer
        /// </summary>
        int GetRange(int startAddress, int endAddress);

        /// <summary>
        /// Set a number of bits in an address range. The value must be without offset.
        /// </summary>
        void SetRange(int startAddress, int endAddres, int value);
    }

    /// <summary>
    /// Interface that represents the digital inputs of an <see cref="IDigitalIoDriver"/>
    /// </summary>
    public interface IDigitalInputs
    {
        /// <summary>
        /// Get the binary value of the input at this adress
        /// </summary>
        bool this [int address] { get;}

        /// <summary>
        /// Get the binary value of the input with this generic name
        /// </summary>
        bool this [string name] { get; }
    }

    /// <summary>
    /// Interface that represents the digital inputs of an <see cref="IDigitalIoDriver"/>
    /// </summary>
    public interface IDigitalOutputs
    {
        /// <summary>
        /// Get the binary value of the input at this adress
        /// </summary>
        bool this [int address] { get; set; }

        /// <summary>
        /// Get the binary value of the input with this generic name
        /// </summary>
        bool this [string name] { get; set; }
    }

    /// <summary>
    /// Fluent API for a range of pins.
    /// </summary>
    public struct AddressRangeStart
    {
        /// <summary>
        /// Start range API with driver reference
        /// </summary>
        public AddressRangeStart(IDigitalIoDriver driver)
        {
            _driver = driver;
            _startAddress = 0;
        }

        /// <summary>
        /// Driver reference
        /// </summary>
        private readonly IDigitalIoDriver _driver;

        /// <summary>
        /// Start address of the range
        /// </summary>
        private int _startAddress;

        /// <summary>
        /// Set start address
        /// </summary>
        /// <param name="startAddress">Start address.</param>
        public AddressRangeStart this[int startAddress]
        {
            get 
            {
                _startAddress = startAddress;
                return this;
            }
        }

        /// <summary>
        /// Define end of range
        /// </summary>
        /// <value>To.</value>
        public AddressRange To
        {
            get { return new AddressRange(_startAddress, _driver); }
        }
    }

    /// <summary>
    /// Range of pins from start to end address
    /// </summary>
    public struct AddressRange
    {
        /// <summary>
        /// Create an instance of the struct with start and end value.
        /// </summary>
        internal AddressRange(int start, IDigitalIoDriver driver)
        {
            _driver = driver;
            _start = start;
        }

        /// <summary>
        /// Reference to the driver
        /// </summary>
        private readonly IDigitalIoDriver _driver;

        /// <summary>
        /// Start adress of the <see cref="AdressRange"/>
        /// </summary>
        private int _start;

        /// <summary>
        /// Start the range fluent API
        /// </summary>
        public int this[int endAddress]
        {
            get { return _driver.GetRange(_start, endAddress); }
            set { _driver.SetRange(_start, endAddress, value); }
        }
    }
}

