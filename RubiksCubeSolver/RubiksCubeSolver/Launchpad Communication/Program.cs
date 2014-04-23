 /*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RubiksCubeSolver
{
    
     class Program
     {
          static void Main(string[] args)
          {
               SerialComm comm = new SerialComm();
               string comPort;
               foreach (string s in Serial.GetAvailablePorts())
               {
                    Console.WriteLine(s);
               }

               Console.WriteLine("Enter COM Port: ");
               comPort = Console.ReadLine();
               if (comm.OpenPort(comPort))
               {
                  
                    byte[] message = new byte[] { 0x01, 0x02, 0x03, 0x04};
                    Console.WriteLine("Sending message...");
                    UInt16 time = 50;
                    // Send a debug message, with payload in "message", and timeout after 5000 milliseconds
                    comm.Send(SerialComm.SerialCommand.Debug, message, time);
                    comm.Send(SerialComm.SerialCommand.Robot, message, time);
                    comm.ClosePort();
                    Console.WriteLine("COM Port closed. ");
                    comPort = Console.ReadLine();
               }
          }
     }
}
*/