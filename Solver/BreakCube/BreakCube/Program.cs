//enum Color {white, yellow, blue, green, red, orange};

using System;

namespace BreakCube
{
    internal class Program
    {
        private enum State { solved, unsolved };

        private enum Phase { first, second, third, fourth, fifth, sixth };

        private static int[,] upper = new int[3, 3] 	{{1,2,6},	//RED
									     {5,1,1},
										 {3,1,2}};

        private static int[,] left = new int[3, 3] 	{{3,1,6},	//BLUE
										 {5,2,4},
									     {1,3,6}};

        private static int[,] front = new int[3, 3] 	{{4,3,1},	//WHITE
									     {1,3,3},
									     {5,4,4}};

        private static int[,] right = new int[3, 3] 	{{5,2,5},	//GREEN
									     {6,4,2},
									     {3,2,3}};

        private static int[,] back = new int[3, 3] 	{{4,6,2},	//YELLOW
									     {3,5,6},
									     {6,4,4}};

        private static int[,] down = new int[3, 3] 	{{2,6,1},	//ORANGE
									{4,6,5},
										 {5,5,2}};

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

        public static void movement(string move)
        {
            switch (move)
            {
                //case "solve":
                //case "SOLVE":
                //case "run":
                //case "RUN":
                //state = (int)State.unsolved;
                //break;
                //==================================================================/
                // Test Cases
                //==================================================================/
                case "testge":
                    Console.Write("Input Cube Color and Adjacent Color no spaces \n > ");
                    string userinput =  Console.ReadLine();
                    int c = Convert.ToInt32(userinput[0].ToString());
                    int ac = Convert.ToInt32(userinput[1].ToString());
                    int  [] testIndex =  GetEdge(c, ac);
                    Console.WriteLine(string.Join(",", testIndex));
                    break;
                case "testgc":
                    Console.Write("Input Cube Color and Adjacent Color Set no spaces \n > ");
                    string userinput2 = Console.ReadLine();
                    int c2 = Convert.ToInt32(userinput2[0].ToString());
                    int ac1 = Convert.ToInt32(userinput2[1].ToString());
                    int ac2 = Convert.ToInt32(userinput2[2].ToString());
                    int[] testIndex2 = GetCorner(c2, new int[]{ac1, ac2});
                    Console.WriteLine(string.Join(",", testIndex2));
                    break;
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

            // Send command to robot.
            RobotInterface.Parse(move);

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

        /*
         * Checks Adjacent face of index [yi, xi]
         * fi specifies which cube the index is on NOT the adjacent face
         ******************************************/

        private static int GetAdjacentColor(int fi, int yi, int xi)
        {
            switch (fi)
            {
                case 1:
                    // upper
                    if (yi == 0 && xi == 1) return back[0, 1];  // top 
                    if (yi == 1 && xi == 0) return left[0, 1];  // left
                    if (yi == 1 && xi == 2) return right[0, 1]; // right
                    if (yi == 2 && xi == 1) return front[0, 1]; // bottom
                    break;

                case 2:
                    // left
                    if (yi == 0 && xi == 1) return upper[1, 0];
                    if (yi == 1 && xi == 0) return back[1, 2];
                    if (yi == 1 && xi == 2) return front[1, 0];
                    if (yi == 2 && xi == 1) return down[1, 0];
                    break;

                case 3:
                    // front
                    if (yi == 0 && xi == 1) return upper[2, 1];
                    if (yi == 1 && xi == 0) return left[1, 2];
                    if (yi == 1 && xi == 2) return right[1, 0];
                    if (yi == 2 && xi == 1) return down[0, 1];
                    break;

                case 4:
                    // right
                    if (yi == 0 && xi == 1) return upper[1, 2];
                    if (yi == 1 && xi == 0) return front[1, 2];
                    if (yi == 1 && xi == 2) return back[1, 0];
                    if (yi == 2 && xi == 1) return down[1, 2];
                    break;

                case 5:
                    // back
                    if (yi == 0 && xi == 1) return upper[0, 1];
                    if (yi == 1 && xi == 0) return right[1, 2];
                    if (yi == 1 && xi == 2) return left[1, 0];
                    if (yi == 2 && xi == 1) return down[2, 1];
                    break;

                case 6:
                    // bottom
                    if (yi == 0 && xi == 1) return front[2, 1];
                    if (yi == 1 && xi == 0) return left[2, 1];
                    if (yi == 1 && xi == 2) return right[2, 1];
                    if (yi == 2 && xi == 1) return front[2, 1];
                    break;

                default:
                    // default
                    Console.WriteLine("Bad Face index sent to checkAdjacent()");
                    break;
            }
            return 0;
        }

        /*
         * Returns 1x3 int array of the [face, y, x] of a specified color and adjacent cube
         * only works for edge NOT corner cubes
         ******************************************/

        public static int[] GetEdge(int searchColor, int searchColorAdjacent)
        {	//edge piece
            // Returns [face, yindex, xindex]
            int[] returnIndex;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Do not check corners.
                    if ((i == 0 && j == 0 )|| (i == 1 && j == 1 )||( i == 2 && j == 2) || (i == 0 && j == 2) || (i == 2 && j == 0))
                        continue;

                    if (upper[i, j] == searchColor)
                    {
                        if (GetAdjacentColor(1, i, j) == searchColorAdjacent)
                        {
                            returnIndex = new int[] { 1, i, j };
                            return returnIndex;
                        }
                    }
                    if (left[i, j] == searchColor)
                    {
                        if (GetAdjacentColor(2, i, j) == searchColorAdjacent)
                        {
                            returnIndex = new int[] { 2, i, j };
                            return returnIndex;
                        }
                    }

                    if (front[i, j] == searchColor)
                    {
                        if (GetAdjacentColor(3, i, j) == searchColorAdjacent)
                        {
                            returnIndex = new int[] { 3, i, j };
                            return returnIndex;
                        }
                    }
                    if (right[i, j] == searchColor)
                    {
                        if (GetAdjacentColor(4, i, j) == searchColorAdjacent)
                        {
                            returnIndex = new int[] { 4, i, j };
                            return returnIndex;
                        }
                    }
                    if (back[i, j] == searchColor)
                    {
                        if (GetAdjacentColor(5, i, j) == searchColorAdjacent)
                        {
                            returnIndex = new int[] { 5, i, j };
                            return returnIndex;
                        }
                    }
                    if (down[i, j] == searchColor)
                    {
                        if (GetAdjacentColor(6, i, j) == searchColorAdjacent)
                        {
                            returnIndex = new int[] { 6, i, j };
                            return returnIndex;
                        }
                    }
                }
            }
            // The color was not found on the rubiks cube:
            Console.WriteLine("no color found BAD CUBE INPUT -- ERROR LOCATION: GetEdge()");
            return new int[] { 0, 0, 0 };
        }

        /*
         * Returns the two adjacent colors of a corner
         * { left adjacent color, right adjacent color }
         * ******************************************************************/
        private static int [] GetAdjacentColorSet(int fi, int yi, int xi)
        {
            switch (fi)
            {
                case 1:
                    // upper
                    if (yi == 0 && xi == 0) return new int[] { left[0, 0], back[0, 2] };    // top left
                    if (yi == 0 && xi == 2) return new int[] { back[0, 0], right[0, 2] };   // top right
                    if (yi == 2 && xi == 0) return new int[] { front[0, 0], left[0, 2] };   // bottom left
                    if (yi == 2 && xi == 2) return new int[] { right[0, 0], front[0, 2] };  // bottom right
                    break;

                case 2:
                    // left
                    if (yi == 0 && xi == 0) return new int[] { back[0, 2], upper[0, 0] };    // top left
                    if (yi == 0 && xi == 2) return new int[] { upper[2, 0], front[0, 0] };   // top right
                    if (yi == 2 && xi == 0) return new int[] { down[2, 0], back[2, 2] };   // bottom left
                    if (yi == 2 && xi == 2) return new int[] { front[2, 0], down[0, 0] };  // bottom right
                    break;

                case 3:
                    // front
                    if (yi == 0 && xi == 0) return new int[] { left[0, 2], upper[2, 0] };    // top left
                    if (yi == 0 && xi == 2) return new int[] { upper[2,2], right[0, 0] };   // top right
                    if (yi == 2 && xi == 0) return new int[] { down[0, 0], left[2, 2] };   // bottom left
                    if (yi == 2 && xi == 2) return new int[] { right[2, 0], down[0, 2] };  // bottom right
                    break;

                case 4:
                    // right
                    if (yi == 0 && xi == 0) return new int[] { front[2,0], upper[2, 2] };    // top left
                    if (yi == 0 && xi == 2) return new int[] { upper[0, 2], back[0, 0] };   // top right
                    if (yi == 2 && xi == 0) return new int[] { down[0, 2], front[2, 2] };   // bottom left
                    if (yi == 2 && xi == 2) return new int[] { back[2, 0], down[2, 2] };  // bottom right
                    break;

                case 5:
                    // back
                    if (yi == 0 && xi == 0) return new int[] { right[0,2], upper[0, 2] };    // top left
                    if (yi == 0 && xi == 2) return new int[] { upper[0, 0], left[0, 0] };   // top right
                    if (yi == 2 && xi == 0) return new int[] { down[0, 2], right[2, 2] };   // bottom left
                    if (yi == 2 && xi == 2) return new int[] { down[2, 0], left[2, 0] };  // bottom right
                    break;

                case 6:
                    // bottom
                    if (yi == 0 && xi == 0) return new int[] { left[2,2], front[2, 0] };    // top left
                    if (yi == 0 && xi == 2) return new int[] { front[2,2], right[2,0] };   // top right
                    if (yi == 2 && xi == 0) return new int[] { back[2,2], left[2,0] };   // bottom left
                    if (yi == 2 && xi == 2) return new int[] {  right[2,2],  back[2, 0] };  // bottom right
                    break;

                default:
                    // default
                    Console.WriteLine("Bad Face index sent to checkAdjacentSet()");
                    break;
            }
            return new int[]{0,0};
        }

        private static int[] GetCorner(int searchColor, int[] adjacentColorSet)
        {
            int[] returnIndex;
            Console.WriteLine(string.Join(",", adjacentColorSet));
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Do not check edges. 01,10,21,12
                    if ((i == 0 && j == 1) || (i == 1 && j == 1) || (i == 1 && j == 0) || (i == 1 && j == 2) || (i == 2 && j == 1))
                        continue;

                    if (upper[i, j] == searchColor)
                    {
                        int[] test = GetAdjacentColorSet(1, i, j);
                        if (test[0] == adjacentColorSet[0] && test[1] == adjacentColorSet[1])
                        {
                            returnIndex = new int[] { 1, i, j };
                            return returnIndex;
                        }
                    }
                    if (left[i, j] == searchColor)
                    {
                        int[] test = GetAdjacentColorSet(2, i, j);
                        if (test[0] == adjacentColorSet[0] && test[1] == adjacentColorSet[1])
                        {
                            returnIndex = new int[] { 2, i, j };
                            return returnIndex;
                        }
                    }

                    if (front[i, j] == searchColor)
                    {
                        int[] test = GetAdjacentColorSet(3, i, j);
                        if (test[0] == adjacentColorSet[0] && test[1] == adjacentColorSet[1])
                        {
                            returnIndex = new int[] { 3, i, j };
                            return returnIndex;
                        }
                    }
                    if (right[i, j] == searchColor)
                    {
                        int[] test = GetAdjacentColorSet(4, i, j);
                        if (test[0] == adjacentColorSet[0] && test[1] == adjacentColorSet[1])
                        {
                            returnIndex = new int[] { 4, i, j };
                            return returnIndex;
                        }
                    }
                    if (back[i, j] == searchColor)
                    {
                        int[] test = GetAdjacentColorSet(5, i, j);
                        if (test[0] == adjacentColorSet[0] && test[1] == adjacentColorSet[1])
                        {
                            returnIndex = new int[] { 5, i, j };
                            return returnIndex;
                        }
                    }
                    if (down[i, j] == searchColor)
                    {
                        int[] test = GetAdjacentColorSet(3, i, j);
                        if (test[0] == adjacentColorSet[0] && test[1] == adjacentColorSet[1])
                        {
                            returnIndex = new int[] { 6, i, j };
                            return returnIndex;
                        }
                    }
                }
            }


            // The color was not found on the rubiks cube:
            Console.WriteLine("no color found BAD CUBE INPUT -- ERROR LOCATION: GetCorner()");
            return new int[] { 0, 0, 0 };
        }
        private static void Main(string[] args)
        {
            //string move;
            int state;
            int phase;
            int a = 1;
            int b = 2;
            int c = 3;
            int d = 4;
            int e = 5;
            int f = 6;

            /*int [,] upper = new int[3,3] 	{{1,1,1},	//RED
                                             {1,1,1},
                                             {1,1,1}};
            int [,] left = new int[3,3] 	{{2,2,2},	//BLUE
                                             {2,2,2},
                                             {2,2,2}};
            int [,] front = new int[3,3] 	{{3,3,3},	//WHITE
                                             {3,3,3},
                                             {3,3,3}};
            int [,] right = new int[3,3] 	{{4,4,4},	//GREEN
                                             {4,4,4},
                                             {4,4,4}};
            int [,] back = new int[3,3] 	{{5,5,5},	//YELLOW
                                             {5,5,5},
                                             {5,5,5}};
            int [,] down = new int[3,3] 	{{6,6,6},	//ORANGE
                                             {6,6,6},
                                             {6,6,6}};		*/

            /*int[,] upper = new int[3, 3] 	{{1,2,6},	//RED
											 {5,1,1},
											 {3,1,2}};
            int[,] left = new int[3, 3] 	{{3,1,6},	//BLUE
											 {5,2,4},
											 {1,3,6}};
            int[,] front = new int[3, 3] 	{{4,3,1},	//WHITE
											 {1,3,3},
											 {5,4,4}};
            int[,] right = new int[3, 3] 	{{5,2,5},	//GREEN
											 {6,4,2},
											 {3,2,3}};
            int[,] back = new int[3, 3] 	{{4,6,2},	//YELLOW
											 {3,5,6},
											 {6,4,4}};
            int[,] down = new int[3, 3] 	{{2,6,1},	//ORANGE
											 {4,6,5},
											 {5,5,2}};*/

            /*if (front[0, 1] != c && front[1, 0] != c && front[1, 1] != c && front[1, 2] != c && front[2, 1] != c)
            {
                Console.Write("what?");
            }*/

            //PREVIOUS MOVE INDEX
            /*int [,] upper0 = new int[3,3]; 	//{{,,},{,,},{,,}};		//WHITE
            int [,] left0 = new int[3,3]; 	//{{2,2,2},{2,2,2},{2,2,2}};		//RED
            int [,] front0 = new int[3,3];	//{{3,3,3},{3,3,3},{3,3,3}};		//WHITE
            int [,] right0 = new int[3,3]; 	//{{4,4,4}, {4,4,4},{4,4,4}};	//GREEN
            int [,] back0 = new int[3,3]; 	//{{5,5,5}, {5,5,5},{5,5,5}};		//RED
            int [,] down0 = new int[3,3];	// {{6,6,6},{6,6,6},{6,6,6}};		//ORANGE*/

            /*int[,] upper0 = new int[3, 3] 	{{upper[0,0],upper[0,1],upper[0,2]},
                                              {upper[1,0],upper[1,1],upper[1,2]},
                                              {upper[2,0],upper[2,1],upper[2,2]}};
             int[,] left0 = new int[3, 3] 	{{left[0,0],left[0,1],left[0,2]},
                                              {left[1,0],left[1,1],left[1,2]},
                                              {left[2,0],left[2,1],left[2,2]}};
             int[,] front0 = new int[3, 3] 	{{front[0,0],front[0,1],front[0,2]},
                                              {front[1,0],front[1,1],front[1,2]},
                                              {front[2,0],front[2,1],front[2,2]}};
             int[,] right0 = new int[3, 3] 	{{right[0,0],right[0,1],right[0,2]},
                                              {right[1,0],right[1,1],right[1,2]},
                                              {right[2,0],right[2,1],right[2,2]}};
             int[,] back0 = new int[3, 3] 	{{back[0,0],back[0,1],back[0,2]},
                                              {back[1,0],back[1,1],back[1,2]},
                                              {back[2,0],back[2,1],back[2,2]}};
             int[,] down0 = new int[3, 3] 	{{down[0,0],down[0,1],down[0,2]},
                                              {down[1,0],down[1,1],down[1,2]},
                                              {down[2,0],down[2,1],down[2,2]}};*/

            while (true)
            {
                Console.Write("Welcome to VirtuaCube 1.0. Would you like to initialize the cube? ");     // <-- This writes the word.
                Console.WriteLine();       // <-- This writes a newline.
                string response = Console.ReadLine();
                if (response == "yes" || response == "y" || response == "Y")
                {
                    state = (int)State.unsolved;
                    while (state == (int)State.unsolved)
                    {
                        /*upper0[0,0] = upper[0,0];	upper0[1,2] = upper[1,2];	upper0[2,2] = upper[2,2];
                        upper0[0,0] = upper[0,0];	upper0[1,1] = upper[1,1];	upper0[2,1] = upper[2,1];
                        upper0[0,0] = upper[0,0];	upper0[1,0] = upper[1,0];	upper0[2,0] = upper[2,0];

                        left0[0,0] = left[0,0];		left0[1,2] = left[1,2];		left0[2,2] = left[2,2];
                        left0[0,0] = left[0,0];		left0[1,1] = left[1,1];		left0[2,1] = left[2,1];
                        left0[0,0] = left[0,0];		left0[1,0] = left[1,0];		left0[2,0] = left[2,0];

                        front0[0,0] = front[0,0];	front0[1,2] = front[1,2];	front0[2,2] = front[2,2];
                        front0[0,0] = front[0,0];	front0[1,1] = front[1,1];	front0[2,1] = front[2,1];
                        front0[0,0] = front[0,0];	front0[1,0] = front[1,0];	front0[2,0] = front[2,0];

                        right0[0,0] = right[0,0];	right0[1,2] = right[1,2];	right0[2,2] = right[2,2];
                        right0[0,0] = right[0,0];	right0[1,1] = right[1,1];	right0[2,1] = right[2,1];
                        right0[0,0] = right[0,0];	right0[1,0] = right[1,0];	right0[2,0] = right[2,0];

                        back0[0,0] = back[0,0];		back0[1,2] = back[1,2];		back0[2,2] = back[2,2];
                        back0[0,0] = back[0,0];		back0[1,1] = back[1,1];		back0[2,1] = back[2,1];
                        back0[0,0] = back[0,0];		back0[1,0] = back[1,0];		back0[2,0] = back[2,0];

                        down0[0,0] = down[0,0];		down0[1,2] = down[1,2];		down0[2,2] = down[2,2];
                        down0[0,0] = down[0,0];		down0[1,1] = down[1,1];		down0[2,1] = down[2,1];
                        down0[0,0] = down[0,0];		down0[1,0] = down[1,0];		down0[2,0] = down[2,0];*/

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

                        Console.Write("What move would you like to make?");
                        Console.WriteLine();
                        string move = Console.ReadLine();
                        movement(move);
                        /*if(front[0,1] != c && front[1,0] != c && front[1,1] != c && front[1,2] != c && front[2,1] != c){
                            Console.Write("What?");
                            Console.Write(c);
                            Console.Write("What move would you like to make?");
                            Console.WriteLine();
                            move = Console.ReadLine();
                        }*/

                        /*Console.Write("What move would you like to make?");
                        Console.WriteLine();
                        move = Console.ReadLine();*/

                        /*upper0 = {{upper[0,0],upper[1,0],upper[2,0]},{upper[0,1],upper[1,1],upper[2,1]},{upper[0,2],upper[1,2],upper[2,2]}};
                        left0 = {{left[0,0],left[1,0],left[2,0]},{left[0,1],left[1,1],left[2,1]},{left[0,2],left[1,2],left[2,2]}};
                        front0 = {{front[0,0],front[1,0],front[2,0]},{front[0,1],front[1,1],front[2,1]},{front[0,2],front[1,2],front[2,2]}};
                        right0 = {{right[0,0],right[1,0],right[2,0]},{right[0,1],right[1,1],right[2,1]},{right[0,2],right[1,2],right[2,2]}};
                        back0 = {{back[0,0],back[1,0],back[2,0]},{back[0,1],back[1,1],back[2,1]},{back[0,2],back[1,2],back[2,2]}};
                        down0 = {{down[0,0],down[1,0],down[2,0]},{down[0,1],down[1,1],down[2,1]},{down[0,2],down[1,2],down[2,2]}};	*/

                        //insert moves HERE

                        /*rubiks.Close();*/
                    }	//"unsolved" while loop
                } if (response == "no")
                {
                    Console.Write("Thank you for your time, and please enjoy your day.");
                    break;
                }
                else
                {
                    Console.Write("I'm sorry, could you please try again?");
                    Console.WriteLine();
                    response = Console.ReadLine();
                }
            }
        }
    }
}