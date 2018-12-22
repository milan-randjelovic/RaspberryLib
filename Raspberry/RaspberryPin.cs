using System;

namespace PiSoftware.Raspberry
{
    public class RaspberyPin
    {
        #region Properties

        /// <summary>
        /// Pin code.
        /// </summary>
        public PinCode Code { get; set; }
        /// <summary>
        /// Pin code label.
        /// </summary>
        public string Label
        {
            get
            {
                return GetGPIOLabel(this.Code);
            }
        }
        /// <summary>
        /// Pin direction, can be input or output.
        /// </summary>
        public PinDirection Direction { get; set; }
        /// <summary>
        /// Pin direction label.
        /// </summary>
        public string DirectionLabel
        {
            get
            {
                return Enum.GetName(typeof(PinDirection), this.Direction);
            }
        }
        /// <summary>
        /// Pin value, can be high or low.
        /// </summary>
        public PinValue Value { get; set; }
         /// <summary>
        /// Pin value label.
        /// </summary>
        public string ValueLabel
        {
            get
            {
                return Enum.GetName(typeof(PinValue), this.Value);
            }
        }
        /// <summary>
        /// Pin initialization state.
        /// </summary>
        public bool Initialized { get; set; }
        /// <summary>
        /// Pin type.
        /// </summary>
        public PinType Type { get; }
        /// <summary>
        /// Pin type label.
        /// </summary>
        public string TypeLabel
        {
            get
            {
                return Enum.GetName(typeof(PinType), this.Type);
            }
        }
        /// <summary>
        /// pin group.
        /// </summary>
        public PinGroup Group { get; set; }
        /// <summary>
        /// pin group label
        /// </summary>
        public string groupLabel
        {
            get
            {
                return Enum.GetName(typeof(PinGroup),this.Group);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pinCode"></param>
        public RaspberyPin(PinCode pinCode)
        {
            this.Code = pinCode;
            this.Group = GetGPIOGroup(pinCode);

            if (pinCode.ToString().Contains("GPIO"))
            {
                this.Type = PinType.GPIO;
                this.Direction = PinDirection.Out;
                this.Value = PinValue.Low;
            }
            else
            if (pinCode.ToString().Contains("GND"))
            {
                this.Type = PinType.GND;
                this.Direction = PinDirection.Out;
                this.Value = PinValue.Low;
            }
            else
            if (pinCode.ToString().Contains("3V"))
            {
                this.Type = PinType.POWER;
                this.Direction = PinDirection.Out;
                this.Value = PinValue.High;
            }
            else
            if (pinCode.ToString().Contains("5V"))
            {
                this.Type = PinType.POWER;
                this.Direction = PinDirection.Out;
                this.Value = PinValue.High;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets pin code enum based on pin code string value.
        /// </summary>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static PinCode GetPinCode(string pinCode)
        {
            for (int i = 0; i < 40; i++)
            {
                if (((PinCode)i).ToString().ToUpper() == pinCode.ToUpper())
                {
                    return (PinCode)i;
                }
            }

            return 0;
        }

        /// <summary>
        /// Gets GPIO group based on pin code.
        /// </summary>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static PinGroup GetGPIOGroup(PinCode pinCode)
        {
            if (pinCode.ToString().Contains("GPIO"))
            {
                switch (pinCode)
                {
                    case PinCode.PIN3_GPIO_02:
                    case PinCode.PIN5_GPIO_03:
                    case PinCode.PIN27_IDSD:
                    case PinCode.PIN28_IDSC:
                        return PinGroup.I2C;

                    case PinCode.PIN8_GPIO_14:
                    case PinCode.PIN10_GPIO_15:
                        return PinGroup.UART;

                    case PinCode.PIN19_GPIO_10:
                    case PinCode.PIN21_GPIO_09:
                    case PinCode.PIN23_GPIO_11:
                    case PinCode.PIN24_GPIO_08:
                    case PinCode.PIN26_GPIO_27:
                    case PinCode.PIN35_GPIO_19:
                    case PinCode.PIN38_GPIO_20:
                    case PinCode.PIN40_GPIO_21:
                        return PinGroup.SPI;

                    default:
                        return PinGroup.GPIO;
                }
            }
            else
            if (pinCode.ToString().Contains("GND"))
            {
                return PinGroup.GND;
            }
            else
            if (pinCode.ToString().Contains("3V"))
            {
                return PinGroup.V3;
            }
            else
            if (pinCode.ToString().Contains("5V"))
            {
                return PinGroup.V5;
            }
            else
            {
                return PinGroup.GPIO;
            }
        }

        /// <summary>
        /// Gets pin name based on pin code.
        /// </summary>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static string GetGPIOLabel(PinCode pinCode)
        {
            string result = "";
            string[] parts = pinCode.ToString().Split('_');
            parts[0] = "";
            for (int i = 0; i < parts.Length; i++)
            {
                result += parts[i];
            }
            return result;
        }

        /// <summary>
        /// Checks if pin is GPIO pin.
        /// </summary>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static bool IsGPIOPin(PinCode pinCode)
        {
            return pinCode.ToString().ToUpper().Contains("GPIO");
        }

        #endregion
    }
}