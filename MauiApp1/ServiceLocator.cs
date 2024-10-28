using System;

namespace MauiApp1;

public static class ServiceLocator
{
    public static IPhidget Phidget {get; set;}
}

public interface IPhidget
{
    double GetTemp1();
}
