using System;
using Microsoft.Win32.SafeHandles;

namespace RoastPath.Client.MacOS.Phidget
{
    public struct _PhidgetChannel { }

    public class Phidget22SafeHandle : SafeHandleMinusOneIsInvalid
    {
        public Phidget22SafeHandle() : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            try
            {
                Phidget22Wrapper.Phidget_release(this);
                return true;
            }
            catch (ObjectDisposedException exc)
            {
                //already disposed
                return true;
            }
            catch (Exception exc)
            {
                if (System.Diagnostics.Debugger.IsAttached) { System.Diagnostics.Debugger.Break(); }
                return true;
            }
        }
    }
}

