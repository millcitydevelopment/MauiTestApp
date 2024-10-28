using ObjCRuntime;
using UIKit;
using RoastPath.Client.Platforms;


namespace MauiApp1;

public class Program
{
	// This is the main entry point of the application.
	static void Main(string[] args)
	{
		MacPhidgetManager phdt = new MacPhidgetManager();
		phdt.Init();
		ServiceLocator.Phidget = phdt;

		// if you want to use a different Application Delegate class from "AppDelegate"
		// you can specify it here.
		UIApplication.Main(args, null, typeof(AppDelegate));
	}
}
