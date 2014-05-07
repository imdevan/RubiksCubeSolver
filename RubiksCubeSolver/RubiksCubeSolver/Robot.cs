using System;

/**********************************************************************************************************************************************
 * Notes:
 *
 * This File contains the class definitions and implementation for the Rubik's Cube Solver Robot
 *
 * At the moment we are unsure as to the directional axis which we will be using to rotate to the cube.
 * Considerations to take into account are: that the cube can only be rotated by one column, or the entire cube.
 *
 * Authors:
 * Andrew King III
 * Devan Huapaya
 *
 * Commands:
 *
 * enum Arm : byte
{
     Left,
     Right
};

enum ArmAction : byte
{
     FACE_CW, 	// Rotates the face in front of the arm clockwise
     FACE_CCW,	// Rotates the face in front of the arm counter clockwise
     CUBE_CW, 	// Rotates the cube about the arm's axis clockwise
     CUBE_CCW 	// Rotates the cube about the arm's axis counter clockwise
};

enum ArmRotate : byte
{
     D0,
     D90,
     D180
};

byte[] message = new byte[4];

message[0] = command; //1 for Robot
message[1] = (byte) Arm;
message[2] = (byte) ArmAction;
message[3] = (byte) ArmRotate;

 * *********************************************************************************************************************************************/

namespace RubiksCubeSolver
{
    public enum Arm : byte
    {
        Left,
        Right
    };

    public enum ArmAction : byte
    {
        FACE_CW, 	// Rotates the face in front of the arm clockwise
        FACE_CCW,	// Rotates the face in front of the arm counter clockwise
        CUBE_CW, 	// Rotates the cube about the arm's axis clockwise
        CUBE_CCW 	// Rotates the cube about the arm's axis counter clockwise
    };

    public enum ArmRotate : byte
    {
        D0,
        D90,
        D180
    };

    public static class Robot
    {
        //static byte [] message;
        //message[0] = command; //1 for Robot
        //message[1] = (byte) Arm;
        //message[2] = (byte) ArmAction;
        //message[3] = (byte) ArmRotate;

        private static string cMove;

        public static void Parse(string move)
        {
        byte[] message = new byte[3];

            switch (move)
            {
                case "U":

                    // Move cube into position
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.CUBE_CW, (byte)ArmRotate.D180 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    
                    // Rotate Face
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.FACE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Move cube back to default position
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.CUBE_CCW, (byte)ArmRotate.D180 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    
                    break;

                case "u":

                    // Move cube into position
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.CUBE_CW, (byte)ArmRotate.D180 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.FACE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Move cube back to default position
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.CUBE_CCW, (byte)ArmRotate.D180 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    
                    break;

                case "L":


                    // Move cube into position
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.CUBE_CW, (byte)ArmRotate.D180 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.FACE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Move cube back to default position
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.CUBE_CCW, (byte)ArmRotate.D180 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    
                    break;

                case "l":

                    // Move cube into position
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.CUBE_CW, (byte)ArmRotate.D180 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.FACE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Move cube back to default position
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.CUBE_CCW, (byte)ArmRotate.D180 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    
                    break;

                case "F":

                    // Move cube into position
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.CUBE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.FACE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Move cube back to default position
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.CUBE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    

                    break;

                case "f":

                    // Move cube into position
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.CUBE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.FACE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Move cube back to default position
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.CUBE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    
                    break;

                case "R":

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.FACE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    break;

                case "r":

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.FACE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    break;

                case "B":

                    // Move cube into position
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.CUBE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.FACE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Move cube back to default position
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.CUBE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    
                    break;

                case "b":

                    // Move cube into position
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.CUBE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.FACE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    // Move cube back to default position
                    message = new byte[] { (byte)Arm.Right, (byte)ArmAction.CUBE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);
                    
                    break;

                case "D":

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.FACE_CW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

                    break;

                case "d":

                    // Rotate Face
                    message = new byte[] { (byte)Arm.Left, (byte)ArmAction.FACE_CCW, (byte)ArmRotate.D90 };
                    Program.comm.Send(SerialComm.SerialCommand.RobotConfig, message, 2000);

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