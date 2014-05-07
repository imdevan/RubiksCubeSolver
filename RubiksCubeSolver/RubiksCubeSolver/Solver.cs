using System;
using System.Collections.Generic;

namespace RubiksCubeSolver
{
    internal class Solver
    {
        private static List<string> MoveSet = new List<string>();

        private enum State { solved, unsolved };

        private enum Phase { first, second, third, fourth, fifth, sixth, final };

        private enum Color { none, red, blue, white, green, yellow, orange };

        private static int phase;
        private static int state;
        private static string move;

        //PHASE III DEMO
        private static int[,] upper = new int[3, 3] 	{{3,1,5},	//RED
                                                    {1,1,1},
                                                    {2,1,2}};

        private static int[,] left = new int[3, 3] 	    {{4,2,5},	//BLUE
                                                    {2,2,4},
                                                    {3,2,1}};

        private static int[,] front = new int[3, 3] 	{{6,3,3},	//WHITE
                                                    {3,3,3},
                                                    {3,6,4}};

        private static int[,] right = new int[3, 3] 	{{4,4,4},	//GREEN
                                                    {2,4,5},
                                                    {5,2,6}};

        private static int[,] back = new int[3, 3] 	    {{5,5,5},	//YELLOW
                                                    {6,5,5},
                                                    {3,3,2}};

        private static int[,] down = new int[3, 3] 	    {{2,4,6},	//ORANGE
                                                    {2,6,5},
                                                    {6,6,4}};

        //PREVIOUS MOVE INDEXES
        private static int[,] upper0 = new int[3, 3] 	{{upper[0,0],upper[0,1],upper[0,2]},
  											 {upper[1,0],upper[1,1],upper[1,2]},
  											 {upper[2,0],upper[2,1],upper[2,2]}};

        private static int[,] left0 = new int[3, 3] 	{{left[0,0],left[0,1],left[0,2]},
  											 {left[1,0],left[1,1],left[1,2]},
  											 {left[2,0],left[2,1],left[2,2]}};

        private static int[,] front0 = new int[3, 3] 	{{front[0,0],front[0,1],front[0,2]},
  											 {front[1,0],front[1,1],front[1,2]},
  											 {front[2,0],front[2,1],front[2,2]}};

        private static int[,] right0 = new int[3, 3] 	{{right[0,0],right[0,1],right[0,2]},
  											 {right[1,0],right[1,1],right[1,2]},
  											 {right[2,0],right[2,1],right[2,2]}};

        private static int[,] back0 = new int[3, 3] 	{{back[0,0],back[0,1],back[0,2]},
  											 {back[1,0],back[1,1],back[1,2]},
  											 {back[2,0],back[2,1],back[2,2]}};

        private static int[,] down0 = new int[3, 3] 	{{down[0,0],down[0,1],down[0,2]},
  											 {down[1,0],down[1,1],down[1,2]},
  											 {down[2,0],down[2,1],down[2,2]}};

        public static void printCube()
        {
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + "|" + " " + upper[0, 0] + " " + "|" + " " + upper[0, 1] + " " + "|" + " " + upper[0, 2] + " " + "|");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + "|" + " " + upper[1, 0] + " " + "|" + " " + "U" + " " + "|" + " " + upper[1, 2] + " " + "|");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + "|" + " " + upper[2, 0] + " " + "|" + " " + upper[2, 1] + " " + "|" + " " + upper[2, 2] + " " + "|");
            Console.WriteLine();

            Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
            Console.WriteLine();
            Console.Write("|" + " " + left[0, 0] + " " + "|" + " " + left[0, 1] + " " + "|" + " " + left[0, 2] + " " + "|" + " " + front[0, 0] + " " + "|" + " " + front[0, 1] + " " + "|" + " " + front[0, 2] + " " + "|" + " " + right[0, 0] + " " + "|" + " " + right[0, 1] + " " + "|" + " " + right[0, 2] + " " + "|" + " " + back[0, 0] + " " + "|" + " " + back[0, 1] + " " + "|" + " " + back[0, 2] + " " + "|");
            Console.WriteLine();
            Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
            Console.WriteLine();
            Console.Write("|" + " " + left[1, 0] + " " + "|" + " " + "L" + " " + "|" + " " + left[1, 2] + " " + "|" + " " + front[1, 0] + " " + "|" + " " + "F" + " " + "|" + " " + front[1, 2] + " " + "|" + " " + right[1, 0] + " " + "|" + " " + "R" + " " + "|" + " " + right[1, 2] + " " + "|" + " " + back[1, 0] + " " + "|" + " " + "B" + " " + "|" + " " + back[1, 2] + " " + "|");
            Console.WriteLine();
            Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
            Console.WriteLine();
            Console.Write("|" + " " + left[2, 0] + " " + "|" + " " + left[2, 1] + " " + "|" + " " + left[2, 2] + " " + "|" + " " + front[2, 0] + " " + "|" + " " + front[2, 1] + " " + "|" + " " + front[2, 2] + " " + "|" + " " + right[2, 0] + " " + "|" + " " + right[2, 1] + " " + "|" + " " + right[2, 2] + " " + "|" + " " + back[2, 0] + " " + "|" + " " + back[2, 1] + " " + "|" + " " + back[2, 2] + " " + "|");
            Console.WriteLine();
            Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
            Console.WriteLine();

            Console.Write("\t" + " " + " " + " " + " " + "|" + " " + down[0, 0] + " " + "|" + " " + down[0, 1] + " " + "|" + " " + down[0, 2] + " " + "|");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + "|" + " " + down[1, 0] + " " + "|" + " " + "D" + " " + "|" + " " + down[1, 2] + " " + "|");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + "|" + " " + down[2, 0] + " " + "|" + " " + down[2, 1] + " " + "|" + " " + down[2, 2] + " " + "|");
            Console.WriteLine();
            Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
            Console.WriteLine();
            Console.WriteLine();
        }

        // Sets previous move indexes to current cube.
        private static void updatePreviousMoveIndexes()
        {
            upper0[0, 0] = upper[0, 0]; upper0[0, 1] = upper[0, 1]; upper0[0, 2] = upper[0, 2];
            upper0[1, 0] = upper[1, 0]; upper0[1, 1] = upper[1, 1]; upper0[1, 2] = upper[1, 2];
            upper0[2, 0] = upper[2, 0]; upper0[2, 1] = upper[2, 1]; upper0[2, 2] = upper[2, 2];

            left0[0, 0] = left[0, 0]; left0[0, 1] = left[0, 1]; left0[0, 2] = left[0, 2];
            left0[1, 0] = left[1, 0]; left0[1, 1] = left[1, 1]; left0[1, 2] = left[1, 2];
            left0[2, 0] = left[2, 0]; left0[2, 1] = left[2, 1]; left0[2, 2] = left[2, 2];

            front0[0, 0] = front[0, 0]; front0[0, 1] = front[0, 1]; front0[0, 2] = front[0, 2];
            front0[1, 0] = front[1, 0]; front0[1, 1] = front[1, 1]; front0[1, 2] = front[1, 2];
            front0[2, 0] = front[2, 0]; front0[2, 1] = front[2, 1]; front0[2, 2] = front[2, 2];

            right0[0, 0] = right[0, 0]; right0[0, 1] = right[0, 1]; right0[0, 2] = right[0, 2];
            right0[1, 0] = right[1, 0]; right0[1, 1] = right[1, 1]; right0[1, 2] = right[1, 2];
            right0[2, 0] = right[2, 0]; right0[2, 1] = right[2, 1]; right0[2, 2] = right[2, 2];

            back0[0, 0] = back[0, 0]; back0[0, 1] = back[0, 1]; back0[0, 2] = back[0, 2];
            back0[1, 0] = back[1, 0]; back0[1, 1] = back[1, 1]; back0[1, 2] = back[1, 2];
            back0[2, 0] = back[2, 0]; back0[2, 1] = back[2, 1]; back0[2, 2] = back[2, 2];

            down0[0, 0] = down[0, 0]; down0[0, 1] = down[0, 1]; down0[0, 2] = down[0, 2];
            down0[1, 0] = down[1, 0]; down0[1, 1] = down[1, 1]; down0[1, 2] = down[1, 2];
            down0[2, 0] = down[2, 0]; down0[2, 1] = down[2, 1]; down0[2, 2] = down[2, 2];
        }

        // Initiate faces based on Rubik's passed to solver in Run().
        private static void initCube(Cube pCube)
        {
            // Set faces equal to cube being passed in.
            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    upper[yi, xi] = (int)pCube.faces[0].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    left[yi, xi] = (int)pCube.faces[1].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    front[yi, xi] = (int)pCube.faces[2].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    right[yi, xi] = (int)pCube.faces[3].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    back[yi, xi] = (int)pCube.faces[4].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    down[yi, xi] = (int)pCube.faces[5].cubies[xi, yi].color;

            updatePreviousMoveIndexes();
        }

        public static void movement(string move)
        {
            switch (move)
            {
                case "F":
                case "0":
                    //CW rotation of FRONT face
                    //BACK unaffected
                    front[0, 0] = front0[2, 0]; front[0, 1] = front0[1, 0]; front[0, 2] = front0[0, 0];
                    front[1, 0] = front0[2, 1]; front[1, 1] = front0[1, 1]; front[1, 2] = front0[0, 1];
                    front[2, 0] = front0[2, 2]; front[2, 1] = front0[1, 2]; front[2, 2] = front0[0, 2];

                    //FRONT CW side rotations
                    upper[2, 0] = left0[2, 2]; upper[2, 1] = left0[1, 2]; upper[2, 2] = left0[0, 2];
                    right[0, 0] = upper0[2, 0]; right[1, 0] = upper0[2, 1]; right[2, 0] = upper0[2, 2];
                    down[0, 0] = right0[2, 0]; down[0, 1] = right0[1, 0]; down[0, 2] = right0[0, 0];
                    left[0, 2] = down0[0, 0]; left[1, 2] = down0[0, 1]; left[2, 2] = down0[0, 2];
                    break;

                case "f":
                case "1":
                    //CCW rotation of BACK face
                    front[0, 0] = front0[0, 2]; front[0, 1] = front0[1, 2]; front[0, 2] = front0[2, 2];
                    front[1, 0] = front0[0, 1]; front[1, 1] = front0[1, 1]; front[1, 2] = front0[2, 1];
                    front[2, 0] = front0[0, 0]; front[2, 1] = front0[1, 0]; front[2, 2] = front0[2, 0];

                    //FRONT CCW side rotations
                    upper[2, 0] = right0[0, 0]; upper[2, 1] = right0[1, 0]; upper[2, 2] = right0[2, 0];
                    left[0, 2] = upper0[2, 2]; left[1, 2] = upper0[2, 1]; left[2, 2] = upper0[2, 0];
                    down[0, 0] = left0[0, 2]; down[0, 1] = left0[1, 2]; down[0, 2] = left0[2, 2];
                    right[0, 0] = down0[0, 2]; right[1, 0] = down0[0, 1]; right[2, 0] = down0[0, 0];
                    break;

                case "B":
                case "2":
                    //CW rotation of BACK face
                    //FRONT unaffected
                    back[0, 0] = back0[2, 0]; back[0, 1] = back0[1, 0]; back[0, 2] = back0[0, 0];
                    back[1, 0] = back0[2, 1]; back[1, 1] = back0[1, 1]; back[1, 2] = back0[0, 1];
                    back[2, 0] = back0[2, 2]; back[2, 1] = back0[1, 2]; back[2, 2] = back0[0, 2];

                    //BACK CW side rotations
                    upper[0, 0] = right0[0, 2]; upper[0, 1] = right0[1, 2]; upper[0, 2] = right0[2, 2];
                    left[0, 0] = upper0[0, 2]; left[1, 0] = upper0[0, 1]; left[2, 0] = upper0[0, 0];
                    down[2, 0] = left0[0, 0]; down[2, 1] = left0[1, 0]; down[2, 2] = left0[2, 0];
                    right[0, 2] = down0[2, 2]; right[1, 2] = down0[2, 1]; right[2, 2] = down0[2, 0];
                    break;

                case "b":
                case "3":
                    //CCW rotation of BACK face
                    back[0, 0] = back0[0, 2]; back[0, 1] = back0[1, 2]; back[0, 2] = back0[2, 2];
                    back[1, 0] = back0[0, 1]; back[1, 1] = back0[1, 1]; back[1, 2] = back0[2, 1];
                    back[2, 0] = back0[0, 0]; back[2, 1] = back0[1, 0]; back[2, 2] = back0[2, 0];

                    //BACK CCW side rotations
                    upper[0, 0] = left0[2, 0]; upper[0, 1] = left0[1, 0]; upper[0, 2] = left0[0, 0];
                    right[0, 2] = upper0[0, 0]; right[1, 2] = upper0[0, 1]; right[2, 2] = upper0[0, 2];
                    down[2, 0] = right0[2, 2]; down[2, 1] = right0[1, 2]; down[2, 2] = right0[0, 2];
                    left[0, 0] = down0[2, 0]; left[1, 0] = down0[2, 1]; left[2, 0] = down0[2, 2];
                    break;

                case "L":
                case "4":
                    //CW rotation of LEFT face
                    //RIGHT unaffected
                    left[0, 0] = left0[2, 0]; left[0, 1] = left0[1, 0]; left[0, 2] = left0[0, 0];
                    left[1, 0] = left0[2, 1]; left[1, 1] = left0[1, 1]; left[1, 2] = left0[0, 1];
                    left[2, 0] = left0[2, 2]; left[2, 1] = left0[1, 2]; left[2, 2] = left0[0, 2];

                    //LEFT CW side rotations
                    upper[0, 0] = back0[2, 2]; upper[1, 0] = back0[1, 2]; upper[2, 0] = back0[0, 2];
                    front[0, 0] = upper0[0, 0]; front[1, 0] = upper0[1, 0]; front[2, 0] = upper0[2, 0];
                    down[0, 0] = front0[0, 0]; down[1, 0] = front0[1, 0]; down[2, 0] = front0[2, 0];
                    back[0, 2] = down0[2, 0]; back[1, 2] = down0[1, 0]; back[2, 2] = down0[0, 0];
                    break;

                case "l":
                case "5":
                    //CCW rotation of LEFT face
                    left[0, 0] = left0[0, 2]; left[0, 1] = left0[1, 2]; left[0, 2] = left0[2, 2];
                    left[1, 0] = left0[0, 1]; left[1, 1] = left0[1, 1]; left[1, 2] = left0[2, 1];
                    left[2, 0] = left0[0, 0]; left[2, 1] = left0[1, 0]; left[2, 2] = left0[2, 0];

                    //LEFT CCW side rotations
                    upper[0, 0] = front0[0, 0]; upper[1, 0] = front0[1, 0]; upper[2, 0] = front0[2, 0];
                    back[0, 2] = upper0[2, 0]; back[1, 2] = upper0[1, 0]; back[2, 2] = upper0[0, 0];
                    down[0, 0] = back0[2, 2]; down[1, 0] = back0[1, 2]; down[2, 0] = back0[0, 2];
                    front[0, 0] = down0[0, 0]; front[1, 0] = down0[1, 0]; front[2, 0] = down0[2, 0];
                    break;

                case "R":
                case "6":
                    //clockwise rotation of RIGHT face
                    //LEFT unaffected
                    right[0, 0] = right0[2, 0]; right[0, 1] = right0[1, 0]; right[0, 2] = right0[0, 0];
                    right[1, 0] = right0[2, 1]; right[1, 1] = right0[1, 1]; right[1, 2] = right0[0, 1];
                    right[2, 0] = right0[2, 2]; right[2, 1] = right0[1, 2]; right[2, 2] = right0[0, 2];

                    //RIGHT CW side rotations
                    upper[0, 2] = front0[0, 2]; upper[1, 2] = front0[1, 2]; upper[2, 2] = front0[2, 2];
                    back[0, 0] = upper0[2, 2]; back[1, 0] = upper0[1, 2]; back[2, 0] = upper0[0, 2];
                    down[0, 2] = back0[2, 0]; down[1, 2] = back0[1, 0]; down[2, 2] = back0[0, 0];
                    front[0, 2] = down0[0, 2]; front[1, 2] = down0[1, 2]; front[2, 2] = down0[2, 2];
                    break;

                case "r":
                case "7":
                    //counter-clockwise rotation of RIGHT face
                    right[0, 0] = right0[0, 2]; right[0, 1] = right0[1, 2]; right[0, 2] = right0[2, 2];
                    right[1, 0] = right0[0, 1]; right[1, 1] = right0[1, 1]; right[1, 2] = right0[2, 1];
                    right[2, 0] = right0[0, 0]; right[2, 1] = right0[1, 0]; right[2, 2] = right0[2, 0];

                    //RIGHT CCW side rotations
                    upper[0, 2] = back0[2, 0]; upper[1, 2] = back0[1, 0]; upper[2, 2] = back0[0, 0];
                    front[0, 2] = upper0[0, 2]; front[1, 2] = upper0[1, 2]; front[2, 2] = upper0[2, 2];
                    down[0, 2] = front0[0, 2]; down[1, 2] = front0[1, 2]; down[2, 2] = front0[2, 2];
                    back[0, 0] = down0[2, 2]; back[1, 0] = down0[1, 2]; back[2, 0] = down0[0, 2];
                    break;

                case "U":
                case "8":
                    //clockwise rotation of UPPER face
                    //DOWN unaffected
                    upper[0, 0] = upper0[2, 0]; upper[0, 1] = upper0[1, 0]; upper[0, 2] = upper0[0, 0];
                    upper[1, 0] = upper0[2, 1]; upper[1, 1] = upper0[1, 1]; upper[1, 2] = upper0[0, 1];
                    upper[2, 0] = upper0[2, 2]; upper[2, 1] = upper0[1, 2]; upper[2, 2] = upper0[0, 2];

                    //UPPER CW side rotations
                    back[0, 0] = left0[0, 0]; back[0, 1] = left0[0, 1]; back[0, 2] = left0[0, 2];
                    right[0, 0] = back0[0, 0]; right[0, 1] = back0[0, 1]; right[0, 2] = back0[0, 2];
                    front[0, 0] = right0[0, 0]; front[0, 1] = right0[0, 1]; front[0, 2] = right0[0, 2];
                    left[0, 0] = front0[0, 0]; left[0, 1] = front0[0, 1]; left[0, 2] = front0[0, 2];
                    break;

                case "u":
                case "9":
                    //counter-clockwise rotation of UPPER face
                    upper[0, 0] = upper0[0, 2]; upper[0, 1] = upper0[1, 2]; upper[0, 2] = upper0[2, 2];
                    upper[1, 0] = upper0[0, 1]; upper[1, 1] = upper0[1, 1]; upper[1, 2] = upper0[2, 1];
                    upper[2, 0] = upper0[0, 0]; upper[2, 1] = upper0[1, 0]; upper[2, 2] = upper0[2, 0];

                    //UPPER CCW side rotations
                    back[0, 0] = right0[0, 0]; back[0, 1] = right0[0, 1]; back[0, 2] = right0[0, 2];
                    left[0, 0] = back0[0, 0]; left[0, 1] = back0[0, 1]; left[0, 2] = back0[0, 2];
                    front[0, 0] = left0[0, 0]; front[0, 1] = left0[0, 1]; front[0, 2] = left0[0, 2];
                    right[0, 0] = front0[0, 0]; right[0, 1] = front0[0, 1]; right[0, 2] = front0[0, 2];
                    break;

                case "D":
                case "10":
                    //clockwise rotation of DOWN (bottom) face
                    //UPPER unaffected
                    down[0, 0] = down0[2, 0]; down[0, 1] = down0[1, 0]; down[0, 2] = down0[0, 0];
                    down[1, 0] = down0[2, 1]; down[1, 1] = down0[1, 1]; down[1, 2] = down0[0, 1];
                    down[2, 0] = down0[2, 2]; down[2, 1] = down0[1, 2]; down[2, 2] = down0[0, 2];

                    //DOWN CW side rotations
                    front[2, 0] = left0[2, 0]; front[2, 1] = left0[2, 1]; front[2, 2] = left0[2, 2];
                    right[2, 0] = front0[2, 0]; right[2, 1] = front0[2, 1]; right[2, 2] = front0[2, 2];
                    back[2, 0] = right0[2, 0]; back[2, 1] = right0[2, 1]; back[2, 2] = right0[2, 2];
                    left[2, 0] = back0[2, 0]; left[2, 1] = back0[2, 1]; left[2, 2] = back0[2, 2];
                    break;

                case "d":
                case "11":
                    //counter-clockwise rotation of DOWN (bottom) face
                    down[0, 0] = down0[0, 2]; down[0, 1] = down0[1, 2]; down[0, 2] = down0[2, 2];
                    down[1, 0] = down0[0, 1]; down[1, 1] = down0[1, 1]; down[1, 2] = down0[2, 1];
                    down[2, 0] = down0[0, 0]; down[2, 1] = down0[1, 0]; down[2, 2] = down0[2, 0];

                    //DOWN CCW side rotations
                    front[2, 0] = right0[2, 0]; front[2, 1] = right0[2, 1]; front[2, 2] = right0[2, 2];
                    right[2, 0] = back0[2, 0]; right[2, 1] = back0[2, 1]; right[2, 2] = back0[2, 2];
                    back[2, 0] = left0[2, 0]; back[2, 1] = left0[2, 1]; back[2, 2] = left0[2, 2];
                    left[2, 0] = front0[2, 0]; left[2, 1] = front0[2, 1]; left[2, 2] = front0[2, 2];
                    break;
            }//switch

            updatePreviousMoveIndexes();
        }

        //solveCross ==> PHASE I
        public static void solveCross()
        {
            if ((upper[0, 1] == (int)Color.red) && (upper[1, 0] == (int)Color.red) && (upper[2, 1] == (int)Color.red) && (upper[1, 2] == (int)Color.red))
            {
                phase = (int)Phase.second;
                Console.Write("PHASE II");
                Console.WriteLine();
            }
            else if ((upper[0, 1] != (int)Color.red) || (upper[1, 0] != (int)Color.red) || (upper[2, 1] != (int)Color.red) || (upper[1, 2] != (int)Color.red))
            {
                if ((down[0, 1] == (int)Color.red) || (down[1, 0] == (int)Color.red) || (down[2, 1] == (int)Color.red) || (down[1, 2] == (int)Color.red))
                {
                    if (down[0, 1] == (int)Color.red)   //handles front
                    {
                        if (upper[2, 1] != (int)Color.red)
                        {
                            move = "F";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    else if (down[1, 0] == (int)Color.red)  //handles left
                    {
                        if (upper[1, 0] != (int)Color.red)
                        {
                            move = "L";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    else if (down[2, 1] == (int)Color.red)  //handles back
                    {
                        if (upper[0, 1] != (int)Color.red)
                        {
                            move = "B";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    else if (down[1, 2] == (int)Color.red)  //handles right
                    {
                        if (upper[1, 2] != (int)Color.red)
                        {
                            move = "R";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                }
                /*initial BREAK*/  else if ((down[0, 1] != (int)Color.red) && (down[1, 0] != (int)Color.red) && (down[2, 1] != (int)Color.red) && (down[1, 2] != (int)Color.red))
                {
                    if ((left[0, 1] == (int)Color.red) || (left[1, 0] == (int)Color.red) || (left[2, 1] == (int)Color.red) || (left[1, 2] == (int)Color.red))
                    {
                        if (left[0, 1] == (int)Color.red)
                        {
                            move = "l";
                            movement(move);
                            MoveSet.Add(move);
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                            move = "b";
                            movement(move);
                            MoveSet.Add(move);
                            move = "u";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else if (left[0, 1] != (int)Color.red)
                        {
                            /*else*/
                            if ((left[1, 0] == (int)Color.red))
                            {
                                if (upper[1, 0] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "L";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((left[2, 1] == (int)Color.red))
                            {
                                if (upper[1, 0] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "L";
                                    movement(move);
                                    MoveSet.Add(move);
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((left[1, 2] == (int)Color.red))
                            {
                                if (upper[1, 0] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "l";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                        }
                    }
                    else if ((front[0, 1] == (int)Color.red) || (front[1, 0] == (int)Color.red) || (front[2, 1] == (int)Color.red) || (front[1, 2] == (int)Color.red))
                    {
                        if (front[0, 1] == (int)Color.red)
                        {
                            move = "f";
                            movement(move);
                            MoveSet.Add(move);
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                            move = "l";
                            movement(move);
                            MoveSet.Add(move);
                            move = "u";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else if (front[0, 1] != (int)Color.red)
                        {
                            if ((front[1, 0] == (int)Color.red))
                            {
                                if (upper[2, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "F";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((front[2, 1] == (int)Color.red))
                            {
                                if (upper[2, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "F";
                                    movement(move);
                                    MoveSet.Add(move);
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((front[1, 2] == (int)Color.red))
                            {
                                if (upper[2, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "f";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                        }
                    }
                    else if ((right[0, 1] == (int)Color.red) || (right[1, 0] == (int)Color.red) || (right[2, 1] == (int)Color.red) || (right[1, 2] == (int)Color.red))
                    {
                        if (right[0, 1] == (int)Color.red)
                        {
                            move = "r";
                            movement(move);
                            MoveSet.Add(move);
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                            move = "f";
                            movement(move);
                            MoveSet.Add(move);
                            move = "u";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else if (right[0, 1] != (int)Color.red)
                        {
                            if ((right[1, 0] == (int)Color.red))
                            {
                                if (upper[1, 2] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "R";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((right[2, 1] == (int)Color.red))
                            {
                                if (upper[1, 2] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "R";
                                    movement(move);
                                    MoveSet.Add(move);
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((right[1, 2] == (int)Color.red))
                            {
                                if (upper[1, 2] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "r";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                        }
                    }
                    else if ((back[0, 1] == (int)Color.red) || (back[1, 0] == (int)Color.red) || (back[2, 1] == (int)Color.red) || (back[1, 2] == (int)Color.red))
                    {
                        if (back[0, 1] == (int)Color.red)
                        {
                            move = "b";
                            movement(move);
                            MoveSet.Add(move);
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                            move = "r";
                            movement(move);
                            MoveSet.Add(move);
                            move = "u";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else if (back[0, 1] != (int)Color.red)
                        {
                            if ((back[1, 0] == (int)Color.red))
                            {
                                if (upper[0, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "B";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((back[2, 1] == (int)Color.red))
                            {
                                if (upper[0, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "B";
                                    movement(move);
                                    MoveSet.Add(move);
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((back[1, 2] == (int)Color.red))
                            {
                                if (upper[0, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "b";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                        }
                    }
                }//HERE
            }
            else
            {
                phase = (int)Phase.first;
            }
        }

        //completeCross ==> PHASE II
        public static void completeCross()
        {
            if ((left[0, 1] == left[1, 1]) && (front[0, 1] == front[1, 1]) && (right[0, 1] == right[1, 1]) && (back[0, 1] == back[1, 1]))
            {
                phase = (int)Phase.third;
                Console.Write("PHASE III");
                Console.WriteLine();
            }
            else if ((left[0, 1] != left[1, 1]) || (front[0, 1] != front[1, 1]) || (right[0, 1] != right[1, 1]) || (back[0, 1] != back[1, 1]))
            {
                if ((left[0, 1] == right[1, 1]) || (right[0, 1] == left[1, 1]))
                {
                    move = "L";
                    movement(move);
                    MoveSet.Add(move);
                    move = "F";
                    movement(move);
                    MoveSet.Add(move);
                    move = "F";
                    movement(move);
                    MoveSet.Add(move);
                    move = "R";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "r";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "f";
                    movement(move);
                    MoveSet.Add(move);
                    move = "f";
                    movement(move);
                    MoveSet.Add(move);
                }
                else if ((front[0, 1] == back[1, 1]) || (back[0, 1] == front[1, 1]))
                {
                    move = "F";
                    movement(move);
                    MoveSet.Add(move);
                    move = "R";
                    movement(move);
                    MoveSet.Add(move);
                    move = "R";
                    movement(move);
                    MoveSet.Add(move);
                    move = "B";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "b";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "r";
                    movement(move);
                    MoveSet.Add(move);
                    move = "r";
                    movement(move);
                    MoveSet.Add(move);
                }
                else if ((front[0, 1] == left[1, 1]) || (left[0, 1] == front[1, 1]))
                {
                    move = "l";
                    movement(move);
                    MoveSet.Add(move);
                    move = "f";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "F";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "L";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                }
                else if ((front[0, 1] == right[1, 1]) || (right[0, 1] == front[1, 1]))
                {
                    move = "R";
                    movement(move);
                    MoveSet.Add(move);
                    move = "F";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "f";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "r";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                }
                else if ((back[0, 1] == left[1, 1]) || (left[0, 1] == back[1, 1]))
                {
                    move = "L";
                    movement(move);
                    MoveSet.Add(move);
                    move = "B";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "b";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "l";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                }
                else if ((back[0, 1] == right[1, 1]) || (right[0, 1] == back[1, 1]))
                {
                    move = "r";
                    movement(move);
                    MoveSet.Add(move);
                    move = "b";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                    move = "B";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                    move = "R";
                    movement(move);
                    MoveSet.Add(move);
                    move = "u";
                    movement(move);
                    MoveSet.Add(move);
                }
                /*else
                {
                    break;
                }*/
            }
            else
            {
                phase = (int)Phase.second;
            }
        }

        //completeUpper ==> PHASE III
        public static void completeUpper()
        {
            if ((upper[0, 0] == (int)Color.red && left[0, 0] == (int)Color.blue && back[0, 2] == (int)Color.yellow)
             && (upper[0, 2] == (int)Color.red && right[0, 2] == (int)Color.green && back[0, 0] == (int)Color.yellow)
             && (upper[2, 0] == (int)Color.red && left[0, 2] == (int)Color.blue && front[0, 0] == (int)Color.white)
             && (upper[2, 2] == (int)Color.red && right[0, 0] == (int)Color.green && front[0, 2] == (int)Color.white))
            {
                phase = (int)Phase.fourth;
                Console.Write("PHASE IV");
                Console.WriteLine();
            }
            else if ((upper[0, 0] != (int)Color.red && left[0, 0] != (int)Color.blue && back[0, 2] != (int)Color.yellow)
            || (upper[0, 2] != (int)Color.red && right[0, 2] != (int)Color.green && back[0, 0] != (int)Color.yellow)
            || (upper[2, 0] != (int)Color.red && left[0, 2] != (int)Color.blue && front[0, 0] != (int)Color.white)
            || (upper[2, 2] != (int)Color.red && right[0, 0] != (int)Color.green && front[0, 2] != (int)Color.white))
            {
                /*phase = (int)Phase.fifth;
                Console.Write("PHASE V");
                Console.WriteLine();*/
                if ((front[0, 0] == (int)Color.red) || (left[0, 2] == (int)Color.red))
                {
                    move = "L";
                    movement(move);
                    MoveSet.Add(move);
                    move = "d";
                    movement(move);
                    MoveSet.Add(move);
                    move = "l";
                    movement(move);
                    MoveSet.Add(move);
                }
                else if ((front[0, 2] == (int)Color.red) || (right[0, 0] == (int)Color.red))
                {
                    move = "r";
                    movement(move);
                    MoveSet.Add(move);
                    move = "d";
                    movement(move);
                    MoveSet.Add(move);
                    move = "R";
                    movement(move);
                    MoveSet.Add(move);
                }
                else if ((back[0, 0] == (int)Color.red) || (right[0, 2] == (int)Color.red))
                {
                    move = "R";
                    movement(move);
                    MoveSet.Add(move);
                    move = "d";
                    movement(move);
                    MoveSet.Add(move);
                    move = "r";
                    movement(move);
                    MoveSet.Add(move);
                }
                else if ((back[0, 2] == (int)Color.red) || (left[0, 0] == (int)Color.red))
                {
                    move = "l";
                    movement(move);
                    MoveSet.Add(move);
                    move = "d";
                    movement(move);
                    MoveSet.Add(move);
                    move = "L";
                    movement(move);
                    MoveSet.Add(move);
                }
            }
            else if ((down[0, 0] == (int)Color.red || left[2, 2] == (int)Color.red || front[2, 0] == (int)Color.red)
                  && (down[0, 2] == (int)Color.red || right[2, 0] == (int)Color.red || front[2, 2] == (int)Color.red)
                  && (down[2, 0] == (int)Color.red || left[2, 0] == (int)Color.red || back[2, 2] == (int)Color.red)
                  && (down[2, 2] == (int)Color.red || right[2, 2] == (int)Color.red || back[2, 0] == (int)Color.red))
            {
                phase = (int)Phase.fifth;
                Console.Write("PHASE V");
                Console.WriteLine();
            }
            /*else if ((upper[0, 0] == (int)Color.red || left[0, 0] == (int)Color.red || back[0, 2] == (int)Color.red)
                 || (upper[0, 2] == (int)Color.red || right[0, 2] == (int)Color.red || back[0, 0] == (int)Color.red)
                 || (upper[2, 0] == (int)Color.red || left[0, 2] == (int)Color.red || front[0, 0] == (int)Color.red)
                 || (upper[2, 2] == (int)Color.red || right[0, 0] == (int)Color.red || front[0, 2] == (int)Color.red))
            {
                if (upper[0, 0] == (int)Color.red || left[0, 0] == (int)Color.red || back[0, 2] == (int)Color.red)
                {	//top left corner
                    if (down[2, 0] == (int)Color.red || left[2, 0] == (int)Color.red || back[2, 2] == (int)Color.red)
                    {	//DOWN opposite
                        move = "D";
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else
                    {
                        move = "l";
                        movement(move);
                        MoveSet.Add(move);
                        move = "D";
                        movement(move);
                        MoveSet.Add(move);
                        move = "L";
                        movement(move);
                        MoveSet.Add(move);
                    }
                }
            }*//*else if (upper[0,2] == (int)Color.red || right[0,2] == (int)Color.red || back[0,0] == (int)Color.red){	//top right corner
  		if(down[2,2] == (int)Color.red || right[2,2] == (int)Color.red || back[2,0] == (int)Color.red){	//DOWN opposite
  				move = "D";
  				movement(move);
  				MoveSet.Add(move);
  			}else{
  				move = "R";
  				movement(move);
  				MoveSet.Add(move);
  				move = "D";
  				movement(move);
  				MoveSet.Add(move);
  				move = "r";
  				movement(move);
  				MoveSet.Add(move);
  			}
  	}else if (upper[2,0] == (int)Color.red || left[0,2] == (int)Color.red || front[0,0] == (int)Color.red){	//bottom left corner
  		if(down[0,0] == (int)Color.red || left[2,2] == (int)Color.red || front[2,0] == (int)Color.red){	//DOWN opposite
  				move = "D";
  				movement(move);
  				MoveSet.Add(move);
  			}else{
  				move = "L";
  				movement(move);
  				MoveSet.Add(move);
  				move = "D";
  				movement(move);
  				MoveSet.Add(move);
  				move = "l";
  				movement(move);
  				MoveSet.Add(move);
  			}
  	}else if (upper[2,2] == (int)Color.red || right[0,0] == (int)Color.red || front[0,2] == (int)Color.red){	//bottom right corner
  		if(down[0,2] == (int)Color.red || right[2,0] == (int)Color.red || front[2,2] == (int)Color.red){	//DOWN opposite
  				move = "D";
  				movement(move);
  				MoveSet.Add(move);
  			}else{
  				move = "r";
  				movement(move);
  				MoveSet.Add(move);
  				move = "D";
  				movement(move);
  				MoveSet.Add(move);
  				move = "R";
  				movement(move);
  				MoveSet.Add(move);
  			}
  	}
  	}*/
            /*else if((down[0,0] == (int)Color.red || left[2,2] == (int)Color.red || front[2,0] == (int)Color.red)
              && (down[0,2] == (int)Color.red || right[2,0] == (int)Color.red || front[2,2] == (int)Color.red)
              && (down[2,0] == (int)Color.red || left[2,0] == (int)Color.red || back[2,2] == (int)Color.red)
              && (down[2,2] == (int)Color.red || right[2,2] == (int)Color.red || back[2,0] == (int)Color.red)){
              while((upper[0, 0] != (int)Color.red && left[0,0] != (int)Color.blue && back[0,2] != (int)Color.yellow)
                 || (upper[0, 2] != (int)Color.red && right[0,2] != (int)Color.green && back[0,0] != (int)Color.yellow)
                 || (upper[2, 0] != (int)Color.red && left[0,2] != (int)Color.blue && front[0,0] != (int)Color.white)
                 || (upper[2, 2] != (int)Color.red && right[0,0] != (int)Color.green && front[0,2] != (int)Color.white)){
                 if((upper[0, 0] != (int)Color.red) && (left[0,0] != (int)Color.blue) && (back[0,2] != (int)Color.yellow)){
                    if((down[2, 0] == (int)Color.red		&&		left[2,0] == (int)Color.blue	&&		back[2,2] == (int)Color.yellow)
                    || (down[2, 0] == (int)Color.red		&&		left[2,0] == (int)Color.yellow	&&		back[2,2] == (int)Color.blue)
                    || (down[2, 0] == (int)Color.blue		&&		left[2,0] == (int)Color.yellow	&&		back[2,2] == (int)Color.red)
                    || (down[2, 0] == (int)Color.blue 		&&		left[2,0] == (int)Color.red		&&		back[2,2] == (int)Color.yellow)
                    || (down[2, 0] == (int)Color.yellow		&&		left[2,0] == (int)Color.red		&&		back[2,2] == (int)Color.blue)
                    || (down[2, 0] == (int)Color.yellow		&&		left[2,0] == (int)Color.blue	&&		back[2,2] == (int)Color.red)){
                        while((upper[0, 0] != (int)Color.red) && (left[0,0] != (int)Color.blue) && (back[0,2] != (int)Color.yellow)){
                            move = "l";
                            movement(move);
                            MoveSet.Add(move);
                            move = "d";
                            movement(move);
                            MoveSet.Add(move);
                            move = "L";
                            movement(move);
                            MoveSet.Add(move);
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }else{
                        move = "D";
                        movement(move);
                        MoveSet.Add(move);
                    }
                 }else if((upper[0, 2] != (int)Color.red) && (right[0,2] != (int)Color.green) && (back[0,0] != (int)Color.yellow)){
                    if((down[2, 2] == (int)Color.red		&&		right[2,2] == (int)Color.green	&&		back[2,0] == (int)Color.yellow)
                    || (down[2, 2] == (int)Color.red		&&		right[2,2] == (int)Color.yellow	&&		back[2,0] == (int)Color.green)
                    || (down[2, 2] == (int)Color.green		&&		right[2,2] == (int)Color.yellow	&&		back[2,0] == (int)Color.red)
                    || (down[2, 2] == (int)Color.green 		&&		right[2,2] == (int)Color.red	&&		back[2,0] == (int)Color.yellow)
                    || (down[2, 2] == (int)Color.yellow		&&		right[2,2] == (int)Color.red	&&		back[2,0] == (int)Color.green)
                    || (down[2, 2] == (int)Color.yellow		&&		right[2,2] == (int)Color.green	&&		back[2,0] == (int)Color.red)){
                        while((upper[0, 2] != (int)Color.red) && (right[0,2] != (int)Color.green) && (back[0,0] != (int)Color.yellow)){
                            move = "R";
                            movement(move);
                            MoveSet.Add(move);
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                            move = "r";
                            movement(move);
                            MoveSet.Add(move);
                            move = "d";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }else{
                        move = "D";
                        movement(move);
                        MoveSet.Add(move);
                    }
                 }else if((upper[2, 0] != (int)Color.red) && (left[0,2] != (int)Color.blue) && (front[0,0] != (int)Color.white)){
                    if((down[0, 0] == (int)Color.red		&&		left[2,2] == (int)Color.blue	&&		front[2,0] == (int)Color.white)
                    || (down[0, 0] == (int)Color.red		&&		left[2,2] == (int)Color.white	&&		front[2,0] == (int)Color.blue)
                    || (down[0, 0] == (int)Color.blue		&&		left[2,2] == (int)Color.white	&&		front[2,0] == (int)Color.red)
                    || (down[0, 0] == (int)Color.blue 		&&		left[2,2] == (int)Color.red		&&		front[2,0] == (int)Color.white)
                    || (down[0, 0] == (int)Color.white		&&		left[2,2] == (int)Color.red		&&		front[2,0] == (int)Color.blue)
                    || (down[0, 0] == (int)Color.white		&&		left[2,2] == (int)Color.blue	&&		front[2,0] == (int)Color.red)){
                        while((upper[2, 0] != (int)Color.red) && (left[0,2] != (int)Color.blue) && (front[0,0] != (int)Color.white)){
                            move = "L";
                            movement(move);
                            MoveSet.Add(move);
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                            move = "l";
                            movement(move);
                            MoveSet.Add(move);
                            move = "l";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }else{
                        move = "D";
                        movement(move);
                        MoveSet.Add(move);
                    }
                 }else if((upper[2, 2] != (int)Color.red) && (right[0,0] != (int)Color.green) && (front[0,2] != (int)Color.white)){
                    if((down[0, 2] == (int)Color.red		&&		right[2,0] == (int)Color.green	&&		front[2,2] == (int)Color.white)
                    || (down[0, 2] == (int)Color.red		&&		right[2,0] == (int)Color.white	&&		front[2,2] == (int)Color.green)
                    || (down[0, 2] == (int)Color.green		&&		right[2,0] == (int)Color.white	&&		front[2,2] == (int)Color.red)
                    || (down[0, 2] == (int)Color.green 		&&		right[2,0] == (int)Color.red	&&		front[2,2] == (int)Color.white)
                    || (down[0, 2] == (int)Color.white		&&		right[2,0] == (int)Color.red	&&		front[2,2] == (int)Color.green)
                    || (down[0, 2] == (int)Color.white		&&		right[2,0] == (int)Color.green	&&		front[2,2] == (int)Color.red)){
                        while((upper[2, 2] != (int)Color.red) && (right[0,0] != (int)Color.green) && (front[0,2] != (int)Color.white)){
                            move = "r";
                            movement(move);
                            MoveSet.Add(move);
                            move = "d";
                            movement(move);
                            MoveSet.Add(move);
                            move = "R";
                            movement(move);
                            MoveSet.Add(move);
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }else{
                        move = "D";
                        movement(move);
                        MoveSet.Add(move);
                    }
                 }
              }
        }*/else
            {
                phase = (int)Phase.third;
            }
        }

        //completeMiddle ==> PHASE IV

        public static void moveSetList()
        {
            foreach (string newMove in MoveSet)
            {
                Console.WriteLine(newMove);
            }
        }

        public static void Run(Cube pCube)
        {
            initCube(pCube);

            // Call following line if not using initCube()
            // updatePreviousMoveIndexes();

            while (true)
            {
                Console.Write("Welcome to VirtuaCube 6.9.7; would you like to initialize the cube? ");
                Console.WriteLine();
                string response = Console.ReadLine();
                if (response == "yes" || response == "y" || response == "Y")
                {
                    phase = (int)Phase.first;
                    state = (int)State.unsolved;
                    while (state == (int)State.unsolved)
                    {
                        if (phase == (int)Phase.first)
                        {
                            while (phase == (int)Phase.first)
                            {
                                printCube();
                                solveCross();
                                Console.WriteLine();
                                moveSetList();
                                Console.WriteLine();
                            }//PHASE 'while' I loop
                        }//PHASE I 'if' loop
                        else if (phase == (int)Phase.second)
                        {
                            //break;
                            while (phase == (int)Phase.second)
                            {
                                printCube();
                                completeCross();
                                Console.WriteLine();
                                moveSetList();
                                Console.WriteLine();
                            }//PHASE 'while' II loop
                        }//PHASE II 'if' loop
                        else if (phase == (int)Phase.third)
                        {
                            break;
                            //while (phase == (int)Phase.third)
                            //{
                            //    printCube();
                            //    completeUpper();
                            //    Console.WriteLine();
                            //    moveSetList();
                            //    Console.WriteLine();
                            //}//PHASE 'while' III loop
                        }//PHASE III 'if' loop
                        else if (phase == (int)Phase.fourth)
                        {
                            break;
                            /* while (phase == (int)Phase.fourth)
                             {
                                printCube();
                                //FUNCTION HERE
                                Console.WriteLine();
                                moveSetList();
                                Console.WriteLine();
                             }//PHASE 'while' IV loop*/
                        }//PHASE IV 'if' loop
                        else if (phase == (int)Phase.fifth)
                        {
                            break;
                            /* while (phase == (int)Phase.fifth)
                             {
                                printCube();
                                //FUNCTION HERE
                                Console.WriteLine();
                                moveSetList();
                                Console.WriteLine();
                             }//PHASE 'while' IV loop*/
                        }//PHASE V 'while' loop*/
                        else if (phase == (int)Phase.sixth)
                        {
                            break;
                            /* while (phase == (int)Phase.sixth)
                             {
                                printCube();
                                //FUNCTION HERE
                                Console.WriteLine();
                                moveSetList();
                                Console.WriteLine();
                             }//PHASE 'while' IV loop*/
                        }//PHASE VI 'while' loop*/
                        else if (phase == (int)Phase.final)
                        {
                            break;
                            /* while (phase == (int)Phase.final)
                             {
                                printCube();
                                //FUNCTION HERE
                                Console.WriteLine();
                                moveSetList();
                                Console.WriteLine();
                             }//PHASE 'while' IV loop*/
                        }//FINAL PHASE 'while'  loop*/
                    }
                }	//UNSOLVED loop
                
                // Send Solved move list to Robot Interface
                Robot.ExecuteMoveList(MoveSet);
            }
        }
    }
}