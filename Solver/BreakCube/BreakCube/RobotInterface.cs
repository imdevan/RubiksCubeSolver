using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
        /* 
         * Notes:
         * 
         * This class includes the roatation maping from the perspective of the solver to the robot.
         * Since the solver only calls rotate UU'LL'FF'RR'BB'DD'
         * Theses commands are translated here so that the robot may excecute the operations 
         * while the solver only has to worry about simple commands.
         * 
         **/
namespace BreakCube
{
    
    public static class RobotInterface
    {
        static const string OPEN = " Open; ";
        static const string CLOSE = " Close; ";
        static const string RC = "Right Claw";
        static const string LC = "Left Claw";
        static const string C = " C; ";
        static const string CCW = " CCW; ";

        // 1x2 Array to store the direction of the top and front position of the cube
        static int[] cubeDirection; 
        static string cMove;
        public static void Parse(string pMove)
        {
            switch (pMove)
            {
                case "U":

                    // Move Claw
                    cMove = LC + OPEN + RC + C + RC + C +
                            LC + CLOSE + LC + C;

                    // Reset Position
                    cMove += LC + OPEN + LC + CCW;  
                    cMove += RC + CCW + RC + CCW + LC + CLOSE;
                               
                    break;
                case "u":

                    // Move Claw
                    cMove = LC + OPEN + RC + C + RC + C +
                            LC + CLOSE + LC + CCW;

                    // Reset Position
                    cMove += LC + OPEN + LC + C;
                    cMove += RC + CCW + RC + CCW + LC + CLOSE;

                    break;
                case "L":

                    // Move Claw
                    cMove = RC + OPEN + LC + C + LC + C + 
                            RC + CLOSE + RC + C;

                    // Reset Position
                    cMove += RC + OPEN + RC + CCW;
                    cMove += LC + CCW + LC + CCW + RC + CLOSE;

                    break;
                case "l":

                    // Move Claw
                    cMove = RC + OPEN  + LC + C + LC + C +
                            RC + CLOSE + RC + CCW;

                    // Reset Position
                    cMove += RC + OPEN + RC + C;
                    cMove += LC + CCW + LC + CCW + RC + CLOSE;

                    break;
                case "F":

                    // Move Claw
                    cMove = LC + C
                            + RC + C;

                    // Reset Position
                    cMove += RC + OPEN + RC + C;
                    cMove += LC + CCW + LC + CCW + RC + CLOSE;

                    break;
                case "f":

                    // Move Claw
                    cMove = LC + C
                            + RC + CCW;
                    break;
                case "R":

                    // Move Claw
                    cMove = RC + C;
                    break;
                case "r":

                    // Move Claw
                    cMove = RC + CCW;
                    break;
                case "B":

                    // Move Claw
                    cMove = RC + C
                            + LC + C;
                    break;
                case "b":

                    // Move Claw
                    cMove = RC + C
                            + LC + CCW;
                    break;
                case "D":

                    // Move Claw
                    cMove = LC + C;
                    break;
                case "d":

                    // Move Claw
                    cMove = LC + CCW;
                    break;
            }


            Console.WriteLine(cMove);
            // put back to initial position
            resetPosition();
        }
        public static void resetPosition()
        {

        }
    }
}
