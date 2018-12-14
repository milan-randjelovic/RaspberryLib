using PiSoftware.Raspberry;
using System;
using System.Threading;

namespace PiSoftwareTest.RaspberryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Raspberry.Initialize();

            PinValue pinValue = PinValue.Low;

            Raspberry.SetPinDirection(PinCode.PIN11_GPIO_17, PinDirection.Out);
            pinValue = Raspberry.GetPinValue(PinCode.PIN11_GPIO_17);
            Console.WriteLine(PinCode.PIN11_GPIO_17.ToString() + ":" + pinValue.ToString());
            Thread.Sleep(1000);

            Raspberry.SetPinValue(PinCode.PIN11_GPIO_17, PinValue.High);
            pinValue = Raspberry.GetPinValue(PinCode.PIN11_GPIO_17);
            Console.WriteLine(PinCode.PIN11_GPIO_17.ToString() + ":" + pinValue.ToString());
            Thread.Sleep(1000);

            Raspberry.SetPinValue(PinCode.PIN11_GPIO_17, PinValue.Low);
            pinValue = Raspberry.GetPinValue(PinCode.PIN11_GPIO_17);
            Console.WriteLine(PinCode.PIN11_GPIO_17.ToString() + ":" + pinValue.ToString());
            Thread.Sleep(1000);

            Raspberry.SetPinValue(PinCode.PIN11_GPIO_17, PinValue.High);
            pinValue = Raspberry.GetPinValue(PinCode.PIN11_GPIO_17);
            Console.WriteLine(PinCode.PIN11_GPIO_17.ToString() + ":" + pinValue.ToString());
            Thread.Sleep(1000);

            Raspberry.SetPinValue(PinCode.PIN11_GPIO_17, PinValue.Low);
            pinValue = Raspberry.GetPinValue(PinCode.PIN11_GPIO_17);
            Console.WriteLine(PinCode.PIN11_GPIO_17.ToString() + ":" + pinValue.ToString());
            Thread.Sleep(1000);

            Raspberry.Dispose();
        }
    }
}
