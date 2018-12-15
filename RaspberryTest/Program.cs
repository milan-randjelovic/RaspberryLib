using System;
using System.Threading;
using PiSoftware.Raspberry;

namespace PiSoftwareTest.RaspberryTest {
    class Program {
        static void Main (string[] args) {

            PinValue pinValue = PinValue.Low;

            RaspberryDevice.Instance.SetPinDirection (PinCode.PIN11_GPIO_17, PinDirection.Out);
            pinValue = RaspberryDevice.Instance.GetPinValue (PinCode.PIN11_GPIO_17);
            Console.WriteLine (PinCode.PIN11_GPIO_17.ToString () + ":" + pinValue.ToString ());
            Thread.Sleep (1000);

            RaspberryDevice.Instance.SetPinValue (PinCode.PIN11_GPIO_17, PinValue.High);
            pinValue = RaspberryDevice.Instance.GetPinValue (PinCode.PIN11_GPIO_17);
            Console.WriteLine (PinCode.PIN11_GPIO_17.ToString () + ":" + pinValue.ToString ());
            Thread.Sleep (1000);

            RaspberryDevice.Instance.SetPinValue (PinCode.PIN11_GPIO_17, PinValue.Low);
            pinValue = RaspberryDevice.Instance.GetPinValue (PinCode.PIN11_GPIO_17);
            Console.WriteLine (PinCode.PIN11_GPIO_17.ToString () + ":" + pinValue.ToString ());
            Thread.Sleep (1000);

            RaspberryDevice.Instance.SetPinValue (PinCode.PIN11_GPIO_17, PinValue.High);
            pinValue = RaspberryDevice.Instance.GetPinValue (PinCode.PIN11_GPIO_17);
            Console.WriteLine (PinCode.PIN11_GPIO_17.ToString () + ":" + pinValue.ToString ());
            Thread.Sleep (1000);

            RaspberryDevice.Instance.SetPinValue (PinCode.PIN11_GPIO_17, PinValue.Low);
            pinValue = RaspberryDevice.Instance.GetPinValue (PinCode.PIN11_GPIO_17);
            Console.WriteLine (PinCode.PIN11_GPIO_17.ToString () + ":" + pinValue.ToString ());
            Thread.Sleep (1000);

            RaspberryDevice.Instance.Dispose ();
        }
    }
}