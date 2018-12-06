using System;
using System.Collections.Generic;
using System.Linq;

namespace RaspberryLib
{
    public static class Raspberry
    {
        public static bool IsInitialized { get; private set; }
        public static List<Pin> Pins { get; set; }

        public static void Initialize()
        {
            if (!IsInitialized)
            {
                Pins = new List<Pin>();

                foreach (PinCode p in Enum.GetValues(typeof(PinCode)))
                {
                    Pin pin = new Pin(p);
                    Pins.Add(pin);
                    InitializePin(pin);
                }
            }
            IsInitialized = true;
        }

        public static void Dispose()
        {
            if (IsInitialized)
            {
                foreach (Pin pin in Pins)
                {
                    DisposePin(pin);
                }

                Pins.Clear();
                Pins = null;

                IsInitialized = false;
            }
        }

        private static void InitializePin(Pin pin)
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
                Pins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().Initialized = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetPinDirection(PinCode pinCode, PinDirection pinDirection)
        {
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
                Pins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinDirection = pinDirection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetPinDirection(Pin pin, PinDirection pinDirection)
        {
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
                Pins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinDirection = pinDirection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetPinValue(PinCode pinCode, PinValue pinValue)
        {
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
                Pins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinValue = pinValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetPinValue(Pin pin, PinValue pinValue)
        {
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
                Pins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinValue = pinValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PinValue GetPinValue(PinCode pinCode)
        {
            try
            {
                string pinAddress = pinCode.ToString().Split('_').Last().Replace("0", "");
                double value = 0;
                if (Environment.OSVersion.Platform == PlatformID.Unix)
                {
                    value = double.Parse(("cat /sys/class/gpio/gpio" + pinAddress + "/value").Bash());
                    if (value > 0)
                    {
                        Pins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinValue = PinValue.High;
                    }
                    else
                    {
                        Pins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinValue = PinValue.Low;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Pins.Where(p => p.PinCode == pinCode).SingleOrDefault().PinValue;
        }

        public static PinValue GetPinValue(Pin pin)
        {
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
                    Pins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinValue = PinValue.High;
                }
                else
                {
                    Pins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinValue = PinValue.Low;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Pins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().PinValue;
        }

        private static void DisposePin(Pin pin)
        {
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
                Pins.Where(p => p.PinCode == pin.PinCode).SingleOrDefault().Initialized = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
