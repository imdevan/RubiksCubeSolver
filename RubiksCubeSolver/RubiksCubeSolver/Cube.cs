using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    /**********************************************************************************************************************************************
     * Notes:
     * 
     * This File contains the class definitions for the Rubik's Cube Object
     * 
     * The values for the rubiks cube are taken from the Rubiks Cube Interface 'Form1.cs', and rotations are sent from the Rubiks Cube Solver Class 'Solver.cs'
     * 
     * 
     * Author:
     * Devan Huapaya
     * 
     * Reference:
     * source:
     * http://www.codeproject.com/Articles/34362/Rubik-s-Cube-in-a-C-Console-Program
     * *********************************************************************************************************************************************/

namespace RubiksCubeSolver
{

    enum Color { RED, BLUE, WHITE, GREEN, YELLOW, ORANGE}
    enum FaceIndex {FRONT, BACK, RIGHT, UP, LEFT}

    class Cubie
    {
        Color color;
        Color [] adjacentColors; // size: 2-4

        sbyte index;
        sbyte [,,] position; // face, y, x
    }

    class Face
    {
        FaceIndex index;
        Cubie[,] cubies;
    }
    class Cube
    {
        Face[] faces;
    }
   
}
