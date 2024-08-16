using ObjCRuntime;
using UIKit;
using System.IO.Ports;
using RoastPath.Client.Platforms;

namespace MauiApp1;

public class Program
{
	// This is the main entry point of the application.
	static void Main(string[] args)
	{

		string[] ports = SerialPort.GetPortNames();
		if (ports.Length > 0)
		{
			if (System.Diagnostics.Debugger.IsAttached)
			{
				System.Diagnostics.Debug.WriteLine(ports[0]);
			}
		}

		MacPhidgetManager phdt = new MacPhidgetManager();
		phdt.Init();
		ServiceLocator.Phidget = phdt;
		var temp = phdt.GetTemp1();

		if (System.Diagnostics.Debugger.IsAttached)
		{
			System.Diagnostics.Debug.WriteLine(temp);
		}

		// if you want to use a different Application Delegate class from "AppDelegate"
		// you can specify it here.
		UIApplication.Main(args, null, typeof(AppDelegate));
	}
}
