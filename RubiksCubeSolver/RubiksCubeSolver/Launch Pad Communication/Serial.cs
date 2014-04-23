using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
namespace Serial
{
     // Wrapper for serial port class
     class Serial
     {
          // The setting for the serial port
          private const int SERIAL_BAUD_RATE = 9600;
          private const Parity SERIAL_PARITY = Parity.None;
          private const int SERIAL_DATA_BITS = 8;
          private const StopBits SERIAL_STOP_BITS = StopBits.One;
          private const Handshake SERIAL_HANDSHAKE = Handshake.None;
          private const int SERIAL_WRITE_TIMEOUT = 1500;
          private const int SERIAL_READ_TIMEOUT = 1500;

          // Use .net serial port for opening, closing, reading, writing
          private System.IO.Ports.SerialPort _SerialPort;

          // Event for feeding data upward
          public event SerialDataRxHandler SerialDataRx;
          public delegate void SerialDataRxHandler(object Obj, RxEventData Args);
          public class RxEventData : EventArgs
          {
               private byte data;
               public RxEventData(byte Data)
               {
                    this.data = Data;
               }
               public byte Data
               {
                    get { return this.data; }
               }
          }

          // Constructor
          public Serial()
          {
               // Make a new port
               _SerialPort = new System.IO.Ports.SerialPort();
          }

          ~Serial()
          {
               // Make sure the port gets closed and resources released
               this.ClosePort();
          }

          // Get a list of available COM Ports
          static public string[] GetAvailablePorts()
          {
               return System.IO.Ports.SerialPort.GetPortNames();
          }

          // Check to see if the port is assocciated with a port
          public bool IsOpen()
          {
               return _SerialPort.IsOpen;
          }

          // Open the COM port with our settings
          public bool Open(string ComPort)   
          {
               try
               {
                    // If our port is open, close it
                    if (_SerialPort.IsOpen)
                    {
                         _SerialPort.Close();
                    }
                    // Set all our properties
                    _SerialPort.BaudRate = SERIAL_BAUD_RATE;
                    _SerialPort.PortName = ComPort;
                    _SerialPort.Parity = SERIAL_PARITY;
                    _SerialPort.StopBits = SERIAL_STOP_BITS;
                    _SerialPort.DataBits = SERIAL_DATA_BITS;
                    // Subscribe to the event handler
                    _SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                    // Actually open now
                    _SerialPort.Open();
                    // return successful
                    return true;
               }
               catch (Exception)
               {

               }
               // return failed
               return false;
          }

          // Create event
          private void OnRxDataReceived(byte Data)
          {
               // Make sure someone has subscribed
               if (this.SerialDataRx != null)
               {
                    SerialDataRx(this, new RxEventData(Data));
               }
          }

          // Read data from port
          private void DataReceived(object sender, SerialDataReceivedEventArgs e)
          {
               try
               {
                    // Read all the bytes from the port and send them to the upper layer
                    while ((_SerialPort != null) && (_SerialPort.BytesToRead > 0))
                    {
                         OnRxDataReceived((byte)_SerialPort.ReadByte());
                    }
               }
               catch (Exception)
               {

               }

          }

          // Close the COM port
          public void ClosePort()
          {
               // Make sure we have the port open 
               // to close
               if (_SerialPort.IsOpen)
               {
                    try
                    {
                         // Unsubscribe event handler
                         _SerialPort.DataReceived -= DataReceived;
                         // Close port
                         _SerialPort.Close();
                    }
                    catch (Exception)
                    {
                         // __RAVE__
                    }
               }
          }

          // Write message to port
          public bool Write(byte[] Message)
          {
               bool Return = false;
               // Check to see if port is open first
               if (_SerialPort.IsOpen)
               {
                    try
                    {
                         // Try writing message to port
                         _SerialPort.Write(Message, 0, Message.Length);
                         // return successful
                         Return = true;
                    }
                    catch (Exception)
                    {

                    }
               }
               // return failed
               return Return;
          }
     }
}
