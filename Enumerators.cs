using System;
using System.Collections.Generic;

namespace RaspberryLib
{
    public class EnumeratorHelpers
    {
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

        public static bool IsGPIOPin(PinCode pinCode)
        {
            return pinCode.ToString().ToUpper().Contains("GPIO");
        }

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

        public static IEnumerable<PinCode> GetGPIOPins()
        {
            List<PinCode> result = new List<PinCode>();

            for (int i = 0; i < 40; i++)
            {
                if (IsGPIOPin((PinCode)i))
                {
                    result.Add((PinCode)i);
                }
            }

            return result;
        }
    }

    public enum PinDirection
    {
        In = 1,
        Out = 0,
    }

    public enum PinValue
    {
        High = 1,
        Low = 0
    }

    public enum PinCode
    {
        PIN1_3V3 = 1,
        PIN2_5V = 2,
        PIN3_GPIO_02 = 3,
        PIN4_5V = 4,
        PIN5_GPIO_03 = 5,
        PIN6_GND = 6,
        PIN7_GPIO_04 = 7,
        PIN8_GPIO_14 = 8,
        PIN9_GND = 9,
        PIN10_GPIO_15 = 10,
        PIN11_GPIO_17 = 11,
        PIN12_GPIO_18 = 12,
        PIN13_GPIO_27 = 13,
        PIN14_GND = 14,
        PIN15_GPIO_22 = 15,
        PIN16_GPIO_23 = 16,
        PIN17_3V3 = 17,
        PIN18_GPIO_24 = 18,
        PIN19_GPIO_10 = 19,
        PIN20_GND = 20,
        PIN21_GPIO_09 = 21,
        PIN22_GPIO_25 = 22,
        PIN23_GPIO_11 = 23,
        PIN24_GPIO_08 = 24,
        PIN25_GND = 25,
        PIN26_GPIO_27 = 26,
        PIN27_IDSD = 27,
        PIN28_IDSC = 28,
        PIN29_GPIO_05 = 29,
        PIN30_GND = 30,
        PIN31_GPIO_06 = 31,
        PIN32_GPIO_12 = 32,
        PIN33_GPIO_13 = 33,
        PIN34_GND = 34,
        PIN35_GPIO_19 = 35,
        PIN36_GPIO_16 = 36,
        PIN37_GPIO_26 = 37,
        PIN38_GPIO_20 = 38,
        PIN39_GND = 39,
        PIN40_GPIO_21 = 40,
    }

    public enum PinType
    {
        GPIO,
        GND,
        POWER
    }

    public enum PinGroup
    {
        V3,
        V5,
        GND,
        GPIO,
        UART,
        I2C,
        SPI
    }
}
