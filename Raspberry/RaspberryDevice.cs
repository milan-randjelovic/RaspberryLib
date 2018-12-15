using System;
using System.Collections.Generic;
using System.Linq;

namespace PiSoftware.Raspberry
{
    public class RaspberryDevice
    {
        #region Fields

        /// <summary>
        /// Raspbery device instance.
        /// </summary>
        private static RaspberryDevice _instance;
        /// <summary>
        /// Raspbery device pins.
        /// </summary>
        private List<RaspberyPin> _devicePins;

        #endregion

        #region Properties

        /// <summary>
        /// Raspberry device instance getter.
        /// </summary>
        public static RaspberryDevice Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RaspberryDevice();
                }
                if (!_instance.IsInitialized)
                {
                    _instance.Initialize();
                }
                return _instance;
            }
        }
        /// <summary>
        /// Indicates if raspberry device is initialized.
        /// </summary>
        public bool IsInitialized { get; private set; }
        /// <summary>
        /// Gets all raspbery device pins.
        /// </summary>
        public List<RaspberyPin> AllPins
        {
            get
            {
                if (!this.IsInitialized)
                    throw new Exception("Raspberry device not initialized");

                return this._devicePins;
            }
        }
        /// <summary>
        /// Gets all raspberry device GPIO pins.
        /// </summary>
        public List<RaspberyPin> GPIOPins
        {
            get
            {
                if (!this.IsInitialized)
                    throw new Exception("Raspberry device not initialized");

                return this._devicePins.Where(pin => RaspberyPin.IsGPIOPin(pin.PinCode)).ToList();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        private RaspberryDevice()
        {
            this.Initialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize raspberry device.
        /// </summary>
        public void Initialize()
        {
            if (!IsInitialized)
            {
                this._devicePins = new List<RaspberyPin>();

                foreach (PinCode p in Enum.GetValues(typeof(PinCode)))
                {
                    RaspberyPin pin = new RaspberyPin(p);
                    this._devicePins.Add(pin);
                    this.InitializePin(pin);
                }
            }
            this.IsInitialized = true;
        }

        /// <summary>
        /// Dispose raspberry device.
        /// </summary>
        public void Dispose()
        {
            if (this.IsInitialized)
            {
                foreach (RaspberyPin pin in this._devicePins)
                {
                    this.DisposePin(pin);
                }

                this._devicePins.Clear();
                this._devicePins = null;

                this.IsInitialized = false;
            }
        }

        /// <summary>
        /// Initialize raspberry device pin.
        /// </summary>
        /// <param name="pin">Raspberry pin</param>
        private void InitializePin(RaspberyPin pin)
        {
            try
            {
                string pinAddress = pin.PinCode.ToString().Split('_').Last().Replace("0", "");
                if (pin.PinType == PinType.GPIO)
                {
                    if (Environment.OSVersion.Platform == PlatformID.Unix)
                    {
                        ("echo " + pinAddress + " > /sys/class/gpio/export").Bash();
                    }
                }
                this._devicePins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().Initialized = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets raspbery device pin direction.
        /// </summary>
        /// <param name="pinCode">Raspberry pin code</param>
        /// <param name="pinDirection">Raspberry pin direction</param>
        public void SetPinDirection(PinCode pinCode, PinDirection pinDirection)
        {
            if (!this.IsInitialized)
                throw new Exception("Raspberry device not initialized");

            try
            {
                string pinAddress = pinCode.ToString().Split('_').Last().Replace("0", "");
                string direction = "";
                switch (pinDirection)
                {
                    case PinDirection.In:
                        direction = "in";
                        break;
                    case PinDirection.Out:
                        direction = "out";
                        break;
                }
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    ("echo " + direction + " > /sys/class/gpio/gpio" + pinAddress + "/direction").Bash();
                }
                this._devicePins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinDirection = pinDirection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets raspbery device pin direction.
        /// </summary>
        /// <param name="pin">Raspberry pin</param>
        /// <param name="pinDirection">Raspberry pin direction</param>
        public void SetPinDirection(RaspberyPin pin, PinDirection pinDirection)
        {
            if (!this.IsInitialized)
                throw new Exception("Raspberry device not initialized");

            try
            {
                string pinAddress = pin.PinCode.ToString().Split('_').Last().Replace("0", "");
                string direction = "";
                switch (pinDirection)
                {
                    case PinDirection.In:
                        direction = "in";
                        break;
                    case PinDirection.Out:
                        direction = "out";
                        break;
                }
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    ("echo " + direction + " > /sys/class/gpio/gpio" + pinAddress + "/direction").Bash();
                }
                this._devicePins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinDirection = pinDirection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets raspberry device pin value.
        /// </summary>
        /// <param name="pinCode">Raspberry pin</param>
        /// <param name="pinValue">Raspberry pin value</param>
        public void SetPinValue(PinCode pinCode, PinValue pinValue)
        {
            if (!this.IsInitialized)
                throw new Exception("Raspberry device not initialized");

            try
            {
                string pinAddress = pinCode.ToString().Split('_').Last().Replace("0", "");
                string value = "";
                switch (pinValue)
                {
                    case PinValue.High:
                        value = "1";
                        break;
                    case PinValue.Low:
                        value = "0";
                        break;
                }
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    ("echo " + value + " > /sys/class/gpio/gpio" + pinAddress + "/value").Bash();
                }
                this._devicePins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinValue = pinValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets raspberry device pin value.
        /// </summary>
        /// <param name="pin">Raspberry pin</param>
        /// <param name="pinValue">Raspberry pin value</param>
        public void SetPinValue(RaspberyPin pin, PinValue pinValue)
        {
            if (!this.IsInitialized)
                throw new Exception("Raspberry device not initialized");

            try
            {
                string pinAddress = pin.PinCode.ToString().Split('_').Last().Replace("0", "");
                string value = "";
                switch (pinValue)
                {
                    case PinValue.High:
                        value = "1";
                        break;
                    case PinValue.Low:
                        value = "0";
                        break;
                }
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    ("echo " + value + " > /sys/class/gpio/gpio" + pinAddress + "/value").Bash();
                }
                this._devicePins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinValue = pinValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets raspberry device pin value.
        /// </summary>
        /// <param name="pinCode">Raspberry pin code</param>
        /// <returns></returns>
        public PinValue GetPinValue(PinCode pinCode)
        {
            if (!this.IsInitialized)
                throw new Exception("Raspberry device not initialized");

            try
            {
                string pinAddress = pinCode.ToString().Split('_').Last().Replace("0", "");
                double value = 0;
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    value = double.Parse(("cat /sys/class/gpio/gpio" + pinAddress + "/value").Bash());
                    if (value > 0)
                    {
                        this._devicePins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinValue = PinValue.High;
                    }
                    else
                    {
                        this._devicePins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinValue = PinValue.Low;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return this._devicePins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinValue;
        }

        /// <summary>
        /// Gets raspberry device pin value.
        /// </summary>
        /// <param name="pin">Raspberry pin</param>
        /// <returns></returns>
        public PinValue GetPinValue(RaspberyPin pin)
        {
            if (!this.IsInitialized)
                throw new Exception("Raspberry device not initialized");

            try
            {
                string pinAddress = pin.PinCode.ToString().Split('_').Last().Replace("0", "");
                double value = 0;
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    value = double.Parse(("cat /sys/class/gpio/gpio" + pinAddress + "/value").Bash());
                }
                if (value > 0)
                {
                    this._devicePins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinValue = PinValue.High;
                }
                else
                {
                    this._devicePins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinValue = PinValue.Low;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return this._devicePins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinValue;
        }

        /// <summary>
        /// Dipose raspbery pin.
        /// </summary>
        /// <param name="pin">Raspberry pin</param>
        private void DisposePin(RaspberyPin pin)
        {
            if (!this.IsInitialized)
                throw new Exception("Raspberry device not initialized");

            try
            {
                string pinAddress = pin.PinCode.ToString().Split('_').Last().Replace("0", "");
                if (pin.PinType == PinType.GPIO)
                {
                    if (Environment.OSVersion.Platform == PlatformID.Unix)
                    {
                        ("echo " + pinAddress + " > /sys/class/gpio/unexport").Bash();
                    }
                }
                this._devicePins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().Initialized = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}