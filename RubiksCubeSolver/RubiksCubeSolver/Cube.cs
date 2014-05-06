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

    public enum Color { RED = 1,     BLUE, WHITE, GREEN, YELLOW, ORANGE}
    public enum FaceIndex {FRONT, BACK, RIGHT, UP, LEFT}

    public class Cubie
    {
        public Color color;
        public Color[] adjacentColors; // size: 2-4

        public int index;
        public int[] position; // face, y, x

        public Cubie()
        {
            color = (Color) 0;
            index = 0;

            adjacentColors = new Color[4];
            for (int i = 0; i < 4; i++)
                adjacentColors[i] = (Color)0;

            position = new int[3];
            for (int i = 0; i < 3; i++)
                position[i] = 0;
        }
        public Cubie(int pindex, Color c, int fi, int xi, int yi)
        {   
            index = pindex;
            color = c;

            adjacentColors = new Color[4];
            for (int i = 0; i < 4; i++)
                adjacentColors[i] = (Color)0;

           position = new int[3];
           position = new int[] { fi, xi, yi };
          /* position[0] = fi;
           position[1] = xi;
           position[2] = yi;*/
        }

        public override string ToString()
        {
            return "Index: " + index + " Color: " + color + " Position: " + position[0] + " " + position[1] + " " + position[2] + "\n";
        }
    }

    public class Face
    {
        public FaceIndex index;
        public Cubie[,] cubies;

        public Face()
        {
            index = 0;
            cubies = new Cubie[3, 3];
        }
        public Face(int fi, Cubie[,] c)
        {
            cubies = new Cubie[3, 3];
            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    cubies[xi, yi] = c[xi, yi];

            index = (FaceIndex)fi;
        }
    }
    public class Cube
    {
        public Face[] faces;

        public Cube()
        {
            faces = new Face[6];
        }
        public Cube(Face[] f)
        {
            faces = new Face[6];
            for (int fi = 0; fi < 6; fi++)
                faces[fi] = f[fi];
        }
    }

   
}
