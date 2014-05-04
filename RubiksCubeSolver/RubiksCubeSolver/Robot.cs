using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;


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
    enum Arm : byte
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

    //byte [] message;
    //message[0] = command; //1 for Robot
    //message[1] = (byte) Arm;
    //message[2] = (byte) ArmAction;
    //message[3] = (byte) ArmRotate;
}
