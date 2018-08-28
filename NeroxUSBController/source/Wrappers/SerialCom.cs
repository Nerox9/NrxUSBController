using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace NeroxUSBController
{
    class SerialCom
    {
        private SerialPort port = new SerialPort("COM1",
      9600, Parity.None, 8, StopBits.One);

        public SerialCom()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            Console.WriteLine(port);
        }
    }
}
