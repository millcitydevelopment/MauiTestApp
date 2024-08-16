using System;
using System.Collections.Generic;
using RoastPath.Client.MacOS.Phidget;
using System.Threading;
using System.Linq;
using MauiApp1;

namespace RoastPath.Client.Platforms
{
    public class MacPhidgetManager : IPhidget
    {
        private Phidget22Funcs _phidget0;
        public bool IsPhidgetConnected { get; internal set; }

        public double GetTemp1()
        {
            return _phidget0.GetTemperature();
        }

        public void Init()
        {
            _phidget0 = ConnectPhidget(0);
        }

        private Phidget22Funcs ConnectPhidget(int channel)
        {
            // try
            // {
                Phidget22Funcs phidget;
                phidget = new Phidget22Funcs();
                phidget.IsLocal = true;
                phidget.Channel = channel;
                phidget.Open();
                DateTime start = DateTime.UtcNow;
                while (!phidget.Attached && (DateTime.UtcNow - start).TotalSeconds < 5)
                {
                    System.Diagnostics.Debug.WriteLine("PHIDGET WAITING: " + DateTime.UtcNow.ToString());
                    Thread.Sleep(100);
                }
                if (phidget.Attached)
                {
                    System.Diagnostics.Debug.WriteLine("PHIDGET TEMP: " + phidget.GetTemperature());
                    /*
                    if (!_eventSet)
                    {
                        //_temp.TemperatureChange += Temp_TemperatureChange;
                        StatusLabel.StringValue = "EVENT SET: " + DateTime.UtcNow.ToString();
                        _eventSet = true;
                        StatusLabel.StringValue = "TEMP: " + phidget.GetTemperature();
                    }
                    else
                    {
                        StatusLabel.StringValue = "ALREADY SETUP: " + DateTime.UtcNow.ToString();
                    }
                    */
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("PHIDGET WAITING: NOT ATTACHED: " + DateTime.UtcNow.ToString());
                }
                return phidget;
            // }
            // catch (Exception exc)
            // {
            //     System.Diagnostics.Debug.WriteLine("PHIDGET CRITICAL: Failed to create Phidget - " + exc.Message);
            //     return null;
            // }
        }
    }
}
