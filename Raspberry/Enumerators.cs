namespace PiSoftware.Raspberry
{
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