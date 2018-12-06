# RaspberryLib
Smple .Net Raspbery PI Library.

#Usage

```
//initialize raspberry device
Raspberry.Initialize();

//sets pin direction to output
Raspberry.SetPinDirection(PinCode.PIN11_GPIO_17, PinDirection.Out);

//set pin value to logical 1
Raspberry.SetPinValue(PinCode.PIN11_GPIO_17, PinValue.High);

//reads pin value
var pinValue = Raspberry.GetPinValue(PinCode.PIN11_GPIO_17);
```

