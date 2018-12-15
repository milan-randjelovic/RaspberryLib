# RaspberryLib
Smple .Net Raspbery PI Library.

```
//set pin direction to output
RaspberryDevice.Instance.SetPinDirection (PinCode.PIN11_GPIO_17, PinDirection.Out);

//get pin value
pinValue = RaspberryDevice.Instance.GetPinValue (PinCode.PIN11_GPIO_17);

//set pin value
RaspberryDevice.Instance.SetPinValue (PinCode.PIN11_GPIO_17, PinValue.High);
```

