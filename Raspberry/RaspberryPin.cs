namespace PiSoftware.Raspberry
{
    public class RaspberyPin
    {
        #region Properties

        /// <summary>
        /// Pin code.
        /// </summary>
        public PinCode PinCode { get; set; }
        /// <summary>
        /// Pin name.
        /// </summary>
        public string PinName { get; set; }
        /// <summary>
        /// Pin direction, can be input or output.
        /// </summary>
        public PinDirection PinDirection { get; set; }
        /// <summary>
        /// Pin value, can be high or low.
        /// </summary>
        public PinValue PinValue { get; set; }
        /// <summary>
        /// Pin initialization state.
        /// </summary>
        public bool Initialized { get; set; }
        /// <summary>
        /// Pin type.
        /// </summary>
        public PinType PinType { get; }
        /// <summary>
        /// pin group.
        /// </summary>
        public PinGroup PinGroup { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pinCode"></param>
        public RaspberyPin(PinCode pinCode)
        {
            this.PinCode = pinCode;
            this.PinName = GetGPIOName(pinCode);
            this.PinGroup = GetGPIOGroup(pinCode);

            if (pinCode.ToString().Contains("GPIO"))
            {
                this.PinType = PinType.GPIO;
                this.PinDirection = PinDirection.Out;
                this.PinValue = PinValue.Low;
            }
            else
            if (pinCode.ToString().Contains("GND"))
            {
                this.PinType = PinType.GND;
                this.PinDirection = PinDirection.Out;
                this.PinValue = PinValue.Low;
            }
            else
            if (pinCode.ToString().Contains("3V"))
            {
                this.PinType = PinType.POWER;
                this.PinDirection = PinDirection.Out;
                this.PinValue = PinValue.High;
            }
            else
            if (pinCode.ToString().Contains("5V"))
            {
                this.PinType = PinType.POWER;
                this.PinDirection = PinDirection.Out;
                this.PinValue = PinValue.High;
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
        /// Checks if pin is GPIO pin.
        /// </summary>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static bool IsGPIOPin(PinCode pinCode)
        {
            return pinCode.ToString().ToUpper().Contains("GPIO");
        }

        /// <summary>
        /// Gets pin name based on pin code.
        /// </summary>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        public static string GetGPIOName(PinCode pinCode)
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

        #endregion
    }
}