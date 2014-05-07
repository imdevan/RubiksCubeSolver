using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
namespace RubiksCubeSolver
{
     class SerialComm
     {
          // These are the Commands for communication
          // Commands are usually paired with a message (byte[])
          public enum SerialCommand : byte
          {
               Debug = 0,
               Robot,
               RobotConfig
          };
       
          // Serial Port we are using
          private Serial           _Port;
          // Serial message framing module
          private SerialFramer     _Framer;
          // Did send receive response
          private bool             _Responded;
          private bool             _Timedout;
          private Timer            _Timer;
          private Object           _ResponseLock;
          private Object           _SendLock;
          // The response of the message
          private byte[]           _Response;


          public SerialComm()
          {
               _Port = new Serial();
               _Framer = new SerialFramer();
               _Timer = new Timer();
               _Timer.Elapsed += new ElapsedEventHandler(MessageTimedout);
               _SendLock = new Object();
               _ResponseLock = new Object();
               // The framer must subscribe to the serial port to receive data
               _Port.SerialDataRx += _Framer.SerialPortDataRxHandler;
               _Framer._SerialMessageRx += new SerialFramer.SerialMessageReceived(HandleMessage);
          }

          // Opens the COM port for the serial port
          public bool OpenPort(string ComPort)
          {
               return _Port.Open(ComPort);
          }

          // Closes the COM port for the serial port
          public void ClosePort()
          {
               _Port.ClosePort();
          }

          // Sends a command and message to controller
          public byte[] Send(SerialComm.SerialCommand Command, byte[] Message, UInt16 Timeout)
          {
               // Set lock so multiple threads don't try to use port at same time
               lock (_SendLock)
               {
                    // Create the message to send (frame message)
                    byte[] serialMessage = MakeMessage(Command, Message);
                    // Set flags to false
                    _Responded = false;
                    _Timedout = false;
                    // Disable timer while we configure it
                    _Timer.Stop();
                    // Attempt to write message
                    if (_Port.Write(serialMessage))
                    {
                         // If sucessful, start timeout
                         _Timer.Interval = Timeout;
                         _Timer.Start();
                         // Loop while we wait for a response or timeout
                         while (!_Responded && !_Timedout);
                         // If we got a response, return it
                         if (_Responded)
                         {
                              return _Response;
                         }
                    }
                    // Otherwise, return null;
                    return null;
               }
          }

          void MessageTimedout(object sender, ElapsedEventArgs e)
          {
               // Lock the response to prevent a message coming in at
               // the same time timer expires
               lock (_ResponseLock)
               {
                    // Disable timer
                    _Timer.Stop();
                    // Check to see if somehow the message was received, 
                    // but the timer did not get handled in time
                    if (!_Responded)
                    {
                         // Set response as nothing
                         _Response = null;


                         // This must occur last in the sequence
                         // Set as timed out
                         _Timedout = true;
                    }
               }
          }


          private void HandleMessage(object Obj, SerialFramer.SerialMessageArgs Args)
          {
               // Lock the response to prevent a timeout coming in at
               // the same time we receive a message
               lock (_ResponseLock)
               {
                    // Disable timer
                    _Timer.Stop();
                    // If we received the message after a timeout occured
                    if (!_Timedout)
                    {
                         // Make sure the message isn't garbage
                         if (Args.Message != null)
                         {
                              // Copy message to new array
                              _Response = new byte[Args.Message.Length];
                              Array.Copy(Args.Message, _Response, Args.Message.Length);
                         }
                         // This must occur last in the sequence
                         // Set as message received
                         _Responded = true;
                    }
               }
          }
          private byte[] MakeMessage(SerialComm.SerialCommand Command, byte[] Message)
          {
               // Stuff command in payload
               byte[] rawMessage = new byte[Message.Length + 1];
               rawMessage[0] = (byte)Command;
               //Array.Copy(rawMessage, 1, Message, 0, Message.Length);
               for (int i = 0; i < Message.Length; i++)
               {
                    rawMessage[i + 1] = Message[i];
               }
               // Send to framer to create full message
               return _Framer.FrameMessage(rawMessage); 
          }
     }
}
