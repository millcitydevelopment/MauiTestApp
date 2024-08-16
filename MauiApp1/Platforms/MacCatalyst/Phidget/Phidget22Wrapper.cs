using System;
using System.Runtime.InteropServices;

namespace RoastPath.Client.MacOS.Phidget
{
    internal static class Phidget22Wrapper
    {
        private const string DLL_NAME = "__Internal";

        //PhidgetReturnCode Phidget_open(PhidgetHandle phid);
        [DllImport(DLL_NAME, EntryPoint = nameof(Phidget_open))]
        internal static extern Int32 Phidget_open(Phidget22SafeHandle phid);

        //PhidgetReturnCode Phidget_openWaitForAttachment(PhidgetHandle phid, uint32_t timeoutMs);
        //PhidgetReturnCode Phidget_close(PhidgetHandle phid);

        //PhidgetReturnCode Phidget_release (PhidgetHandle *phid);
        [DllImport(DLL_NAME, EntryPoint = nameof(Phidget_release))]
        internal static extern Int32 Phidget_release(Phidget22SafeHandle phid);

        //PhidgetReturnCode Phidget_getAttached(PhidgetHandle phid, int* attached);
        [DllImport(DLL_NAME, EntryPoint = nameof(Phidget_getAttached))]
        internal static extern Int32 Phidget_getAttached(Phidget22SafeHandle phid, ref int attached);

        //PhidgetReturnCode Phidget_getIsChannel(PhidgetHandle phid, int* isChannel);

        //PhidgetReturnCode Phidget_getIsLocal(PhidgetHandle phid, int* isLocal);
        [DllImport(DLL_NAME, EntryPoint = nameof(Phidget_getIsLocal))]
        internal static extern Int32 Phidget_getIsLocal(Phidget22SafeHandle phid, ref int isLocal);

        //PhidgetReturnCode Phidget_setIsLocal(PhidgetHandle phid, int isLocal);
        [DllImport(DLL_NAME, EntryPoint = nameof(Phidget_setIsLocal))]
        internal static extern Int32 Phidget_setIsLocal(Phidget22SafeHandle phid, int isLocal);

        //PhidgetReturnCode Phidget_getChannel(PhidgetHandle phid, int* channel);
        [DllImport(DLL_NAME, EntryPoint = nameof(Phidget_getChannel))]
        internal static extern Int32 Phidget_getChannel(Phidget22SafeHandle phid, ref int channel);

        //PhidgetReturnCode Phidget_setChannel(PhidgetHandle phid, int channel);
        [DllImport(DLL_NAME, EntryPoint = nameof(Phidget_setChannel))]
        internal static extern Int32 Phidget_setChannel(Phidget22SafeHandle phid, int channel);


        /*******************************
         * Temperature Sensor
         ******************************/
        //PhidgetReturnCode PhidgetTemperatureSensor_create(PhidgetTemperatureSensorHandle* ch);
        [DllImport(DLL_NAME, EntryPoint = nameof(PhidgetTemperatureSensor_create))]
        internal static extern Int32 PhidgetTemperatureSensor_create(ref Phidget22SafeHandle phid);

        //PhidgetReturnCode PhidgetTemperatureSensor_delete(PhidgetTemperatureSensorHandle* ch);
        [DllImport(DLL_NAME, EntryPoint = nameof(PhidgetTemperatureSensor_delete))]
        internal static extern Int32 PhidgetTemperatureSensor_delete(ref Phidget22SafeHandle phid);

        //PhidgetReturnCode PhidgetTemperatureSensor_getTemperature(PhidgetTemperatureSensorHandle ch, double* temperature);
        [DllImport(DLL_NAME, EntryPoint = nameof(PhidgetTemperatureSensor_getTemperature))]
        internal static extern Int32 PhidgetTemperatureSensor_getTemperature(Phidget22SafeHandle phid, ref double temperature);

        //PhidgetReturnCode PhidgetTemperatureSensor_setOnTemperatureChangeHandler(PhidgetTemperatureSensorHandle ch, PhidgetTemperatureSensor_OnTemperatureChangeCallback fptr, void* ctx);
        [DllImport(DLL_NAME, EntryPoint = nameof(PhidgetTemperatureSensor_setOnTemperatureChangeHandler))]
        internal static extern Int32 PhidgetTemperatureSensor_setOnTemperatureChangeHandler(Phidget22SafeHandle phid, ref ctx ctx, PhidgetTemperatureSensor_OnTemperatureChangeCallback callback);

        public delegate void ctx();
        public delegate void PhidgetTemperatureSensor_OnTemperatureChangeCallback(Phidget22SafeHandle phid, ref ctx ctx, double temperature);

    }
}
