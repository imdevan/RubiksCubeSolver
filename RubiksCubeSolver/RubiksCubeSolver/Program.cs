using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubiksCubeSolver
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SerialComm comm;
        [STAThread]
        static void Main()
        {



            /* Serial Communicator
             * ***********************************************************/
            comm = new SerialComm();
            string comPort;
            foreach (string s in Serial.GetAvailablePorts())
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Enter COM Port: ");
            comPort = Console.ReadLine();
            if (comm.OpenPort(comPort))
            {
                /* 
                 * In order to open communction - 'check device manager for com port "COM<integer>"'
                 * TODO: find fix for launchpad to work on windows.
                 * 
                 * GREEN wires goes to: 3.4
                 * WHITE wire goes to:  3.3
                */
                byte[] message = new byte[] { 0x01, 0x02, 0x03, 0x04 };
                Console.WriteLine("Sending message...");
                UInt16 time = 50;
                // Send a debug message, with payload in "message", and timeout after 5000 milliseconds
                comm.Send(SerialComm.SerialCommand.Debug, message, time);   
                comm.Send(SerialComm.SerialCommand.Robot, message, time);
                Console.WriteLine("COM Port closed. ");
            }


            /* Create Rubiks Cube Object
             * ***********************************************************/
            Cube rubiksCube = new Cube();

            /* Create User Interface
             * ***********************************************************/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new rubiksCubeInterfaceForm());


            comm.ClosePort();

        }
    }
}
