# XBoxController.Standard

.NET Standard library for quickly using XBox Controllers as input devices. 

<sup>Compatible with .NET Framework and .NET (aka .NET Core)</sup>

XBox Controllers make awesome input devices for Windows applications. Here's a library to make XBox Controller input simple and trivial, in about 1 minute.

To get started, install NuGet Package **XBoxController.Standard** (see https://www.nuget.org/packages/XBoxController.Standard for more info).

## Code Samples:

**Get Connected XBox Controllers**

```cs
var connectedControllers = XBox.XBoxController.GetConnectedControllers();
```

**Receive events when controllers are connected or disconnected**

```cs
XBox.XBoxControllerWatcher watcher = new XBox.XBoxControllerWatcher();
watcher.ControllerConnected += (c) => { Console.WriteLine("Controller " + c.PlayerIndex.ToString() + " connected"); };
watcher.ControllerDisconnected += (c) => { Console.WriteLine("Controller " + c.PlayerIndex.ToString() + " disconnected"); };
```

**Find out if Button A is pressed on the first connected controller**

```cs
var isPressed = XBox.XBoxController.GetConnectedControllers().FirstOrDefault().ButtonAPressed;
```

***Check XBox.DemoConsole project for quick testing this library with an XBox controller.***

---

## Remarks: 
This project was based on the previous work of BrandonPotter open source XBoxController library:
https://github.com/BrandonPotter/XBoxController

Unfortunately, it only supported .NET Framework and I couldn't get in touch with him to update it.
So I created this project, ported it to .NET Standard 2.0 and made some improvements.

Many thanks to BrandonPotter for his great work!