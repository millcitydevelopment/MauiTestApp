using System;
namespace RoastPath.Client.MacOS.Phidget
{
    public class Phidget22Funcs : IDisposable
    {
        private Phidget22SafeHandle _handle;


        public bool IsLocal
        {
            get
            {
                int local = 0;
                int result = Phidget22Wrapper.Phidget_getIsLocal(_handle, ref local);
                return local > 0;
            }
            set
            {
                int result = Phidget22Wrapper.Phidget_setIsLocal(_handle, value ? 1 : 0);
            }
        }

        public int Channel
        {
            get
            {
                int cnl = -1;
                int result = Phidget22Wrapper.Phidget_getChannel(_handle, ref cnl);
                return cnl;
            }
            set
            {
                int result = Phidget22Wrapper.Phidget_setChannel(_handle, value);
            }
        }

        public bool Attached
        {
            get
            {
                int attachedStatus = 0;
                int result = Phidget22Wrapper.Phidget_getAttached(_handle, ref attachedStatus);

                return attachedStatus > 0;
            }
        }

        public Phidget22Funcs()
        {
            _handle = new Phidget22SafeHandle();
            int result = Phidget22Wrapper.PhidgetTemperatureSensor_create(ref _handle);
        }

        public void Dispose()
        {
            if (_handle != null && !_handle.IsInvalid)
            {
                int result = Phidget22Wrapper.PhidgetTemperatureSensor_delete(ref _handle);
                _handle.Dispose();
            }
        }

        public double GetTemperature()
        {
            double temp = 0;
            int result = Phidget22Wrapper.PhidgetTemperatureSensor_getTemperature(_handle, ref temp);
            return temp;
        }


        public void Open()
        {
            int result = Phidget22Wrapper.Phidget_open(_handle);
        }

        public void SetChannel(int channel)
        {
            int result = Phidget22Wrapper.Phidget_setChannel(_handle, channel);
        }
    }
}
