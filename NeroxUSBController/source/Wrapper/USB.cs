using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using LibUsbDotNet;
using LibUsbDotNet.Main;
using LibUsbDotNet.WinUsb;
using System.Threading;

namespace NeroxUSBController
{
    class USB
    {
        Guid guid = new Guid("4cfe2948-ac67-4720-a341-e095b89f5d81");
        public static UsbDevice MyUsbDevice;
        private bool pressed = false;
        private Thread async_read_t;
        Dictionary<int, UserController> userController = new Dictionary<int, UserController>();

        public USB()
        {
            WinUsbDevice.OpenUsbDevice(ref guid, out MyUsbDevice);
            async_read_t = new Thread(async_read);

            if (MyUsbDevice.Info.ManufacturerString != "Nerox") throw new Exception("Device Not Found.");
            if (MyUsbDevice.Info.ProductString != "Nerox USB Controller") throw new Exception("Device Not Found.");

            // If the device is open and ready
            if (MyUsbDevice == null) throw new Exception("Device Not Found.");

            async_read_t.Start();
        }

        internal static void write()
        {
            // open write endpoint 1.
            ErrorCode ec = ErrorCode.None;
            UsbEndpointWriter writer = MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
            int bytesWritten;

            try
            {
                ec = writer.Write(Encoding.Default.GetBytes("ABC"), 200, out bytesWritten);
                if (ec != ErrorCode.None) throw new Exception(UsbDevice.LastErrorString);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }

        }

        private static void async_read()
        {

            ErrorCode ec = ErrorCode.None;
            UsbTransfer usbReadTransfer;
            byte[] readBuffer = new byte[5];
            int transferredIn;

            //MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);

            try
            {
                // open read endpoint 1.
                UsbEndpointReader reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);


                while (true)
                {

                    // Create and submit transfer
                    ec = reader.SubmitAsyncTransfer(readBuffer, 0, readBuffer.Length, 50, out usbReadTransfer);
                    if (ec != ErrorCode.None) throw new Exception("Submit Async Read Failed.");

                    if (!usbReadTransfer.IsCompleted) usbReadTransfer.Cancel();

                    ec = usbReadTransfer.Wait(out transferredIn);

                    usbReadTransfer.Dispose();

                    //Console.WriteLine("Read  :{0} ErrorCode:{1}", transferredIn, ec);
                    if (ec is ErrorCode.Success)
                    {
                        int address;
                        int value;
                        if (transferredIn == 1)
                        {
                            address = readBuffer[0];
                            Console.WriteLine("Address: " + address.ToString());
                        }
                        else if (transferredIn == 5)
                        {
                            address = readBuffer[0];
                            value = (readBuffer[4] << 24) +(readBuffer[3] << 16) + (readBuffer[2] << 8) + readBuffer[1];
                            Console.WriteLine("Address: " + address.ToString());
                            Console.WriteLine("Value: " + value.ToString());
                        }                        
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine((ec != ErrorCode.None ? ec + ":" : String.Empty) + ex.Message);
            }

            finally
            {
                if (MyUsbDevice != null)
                {
                    if (MyUsbDevice.IsOpen)
                    {
                        // If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                        // it exposes an IUsbDevice interface. If not (WinUSB) the 
                        // 'wholeUsbDevice' variable will be null indicating this is 
                        // an interface of a device; it does not require or support 
                        // configuration and interface selection.
                        IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                        if (!ReferenceEquals(wholeUsbDevice, null))
                        {
                            // Release interface #0.
                            wholeUsbDevice.ReleaseInterface(0);
                        }

                        MyUsbDevice.Close();
                    }
                    MyUsbDevice = null;

                    // Free usb resources
                    UsbDevice.Exit();

                }
            }
        }
    }
}
