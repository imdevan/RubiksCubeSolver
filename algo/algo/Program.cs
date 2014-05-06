
//enum Color {white, yellow, blue, green, red, orange};

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakCube
{
    class Program
    {
        static List<string> MoveSet = new List<string>();

        enum State { solved, unsolved };
        enum Phase { first, second, third, fourth, fifth, sixth };
        enum Color { none, red, blue, white, green, yellow, orange };

        static int phase;
        static int state;
        static string move;

        /* static int[,] upper = new int[3, 3] 	{{1,2,6},	//RED
                                                  {5,1,1},
                                                  {3,1,2}};
         static int[,] left = new int[3, 3] 	    {{3,1,6},	//BLUE
                                                  {5,2,4},
                                                  {1,3,6}};
         static int[,] front = new int[3, 3] 	{{4,3,1},	//WHITE
                                                  {1,3,3},
                                                  {5,4,4}};
         static int[,] right = new int[3, 3] 	{{5,2,5},	//GREEN
                                                  {6,4,2},
                                                  {3,2,3}};
         static int[,] back = new int[3, 3] 	    {{4,6,2},	//YELLOW
                                                  {3,5,6},
                                                  {6,4,4}};
         static int[,] down = new int[3, 3] 	    {{2,6,1},	//ORANGE
                                                  {4,6,5},
                                                  {5,5,2}};*/

        /*static int [,] upper = new int[3,3] 	{{1,1,1},	//RED
                                          {1,1,1},
                                          {1,1,1}};
        static int[,] left = new int[3, 3] 	{{2,2,2},	//BLUE
                                          {2,2,2},
                                          {2,2,2}};
        static int[,] front = new int[3, 3] 	{{3,3,3},	//WHITE
                                          {3,3,3},
                                          {3,3,3}};
        static int[,] right = new int[3, 3] 	{{4,4,4},	//GREEN
                                          {4,4,4},
                                          {4,4,4}};
        static int[,] back = new int[3, 3] 	{{5,5,5},	//YELLOW
                                          {5,5,5},
                                          {5,5,5}};
        static int[,] down = new int[3, 3] 	{{6,6,6},	//ORANGE
                                          {6,6,6},
                                          {6,6,6}};*/
        /*static int[,] upper = new int[3, 3] 	{{1,1,6},	//RED
                                            {3,1,6},
                                            {3,5,4}};
        static int[,] left = new int[3, 3] 	{{5,1,1},	//BLUE
                                            {2,2,2},
                                            {6,1,1}};
        static int[,] front = new int[3, 3] 	{{2,4,1},	//WHITE
                                            {6,3,6},
                                            {2,3,6}};
        static int[,] right = new int[3, 3] 	{{3,4,5},	//GREEN
                                            {5,4,3},
                                            {3,2,6}};
        static int[,] back = new int[3, 3] 	{{4,4,4},	//YELLOW
                                            {4,5,5},
                                            {5,3,3}};
        static int[,] down = new int[3, 3] 	{{5,2,4},	//ORANGE
                                            {5,6,1},
                                            {2,6,2}};*/
        static int[,] upper = new int[3, 3] 	{{1,3,6},	//RED
                                            {4,1,3},
                                            {3,5,4}};
        static int[,] left = new int[3, 3] 	{{5,1,1},	//BLUE
                                            {2,2,2},
                                            {6,1,1}};
        static int[,] front = new int[3, 3] 	{{2,4,1},	//WHITE
                                            {6,3,6},
                                            {2,3,6}};
        static int[,] right = new int[3, 3] 	{{3,4,5},	//GREEN
                                            {5,4,3},
                                            {3,2,6}};
        static int[,] back = new int[3, 3] 	{{4,4,4},	//YELLOW
                                            {4,5,5},
                                            {5,3,3}};
        static int[,] down = new int[3, 3] 	{{5,1,4},	//ORANGE
                                            {1,6,1},
                                            {2,1,2}};

        //PREVIOUS MOVE INDEXES
        static int[,] upper0 = new int[3, 3] 	{{upper[0,0],upper[0,1],upper[0,2]},
											 {upper[1,0],upper[1,1],upper[1,2]},
											 {upper[2,0],upper[2,1],upper[2,2]}};
        static int[,] left0 = new int[3, 3] 	{{left[0,0],left[0,1],left[0,2]},
											 {left[1,0],left[1,1],left[1,2]},
											 {left[2,0],left[2,1],left[2,2]}};
        static int[,] front0 = new int[3, 3] 	{{front[0,0],front[0,1],front[0,2]},
											 {front[1,0],front[1,1],front[1,2]},
											 {front[2,0],front[2,1],front[2,2]}};
        static int[,] right0 = new int[3, 3] 	{{right[0,0],right[0,1],right[0,2]},
											 {right[1,0],right[1,1],right[1,2]},
											 {right[2,0],right[2,1],right[2,2]}};
        static int[,] back0 = new int[3, 3] 	{{back[0,0],back[0,1],back[0,2]},
											 {back[1,0],back[1,1],back[1,2]},
											 {back[2,0],back[2,1],back[2,2]}};
        static int[,] down0 = new int[3, 3] 	{{down[0,0],down[0,1],down[0,2]},
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

        //solveCross
        public static void solveCross()
        {

            if ((upper[0, 1] == (int)Color.red) && (upper[1, 0] == (int)Color.red) && (upper[2, 1] == (int)Color.red) && (upper[1, 2] == (int)Color.red))
            {
                phase = (int)Phase.second;
                Console.Write("PHASE II");
                Console.WriteLine();
            }
            else if ((down[0, 1] == (int)Color.red) || (down[1, 0] == (int)Color.red) || (down[2, 1] == (int)Color.red) || (down[1, 2] == (int)Color.red))
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
                        move = "U";
                        movement(move);
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
                        move = "U";
                        movement(move);
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
                        move = "U";
                        movement(move);
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
                        move = "U";
                        movement(move);
                    }
                }

            }
            /*else if (left[0, 1] == (int)Color.red || left[1, 0] == (int)Color.red || left[2, 1] == (int)Color.red || left[1, 2] == (int)Color.red)
            {
                if (upper[1, 0] != (int)Color.red)
                {
                    if (left[0, 1] == (int)Color.red)
                    {
                        move = "l";
                        movement(move);
                        MoveSet.Add(move);
                        move = "b";
                        movement(move);
                        MoveSet.Add(move);
                        move = "u";
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (left[1, 0] == (int)Color.red)
                    {
                        move = "L";
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (left[2, 1] == (int)Color.red)
                    {
                        move = "L";
                        movement(move);
                        MoveSet.Add(move);
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (left[1, 2] == (int)Color.red)
                    {
                        move = "l";
                        movement(move);
                        MoveSet.Add(move);
                    }
                }
                else
                {
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                }
            }
            else if (right[0, 1] == (int)Color.red || right[1, 0] == (int)Color.red || right[2, 1] == (int)Color.red || right[1, 2] == (int)Color.red)
            {
                if (upper[1, 2] != (int)Color.red)
                {
                    if (right[0, 1] == (int)Color.red)
                    {
                        move = "r";
                        movement(move);
                        MoveSet.Add(move);
                        move = "f";
                        movement(move);
                        MoveSet.Add(move);
                        move = "u";
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (right[1, 0] == (int)Color.red)
                    {
                        move = "R";
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (right[2, 1] == (int)Color.red)
                    {
                        move = "R";
                        movement(move);
                        MoveSet.Add(move);
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (right[1, 2] == (int)Color.red)
                    {
                        move = "r";
                        movement(move);
                        MoveSet.Add(move);
                    }
                }
                else
                {
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                }
            }
            else if (front[0, 1] == (int)Color.red || front[1, 0] == (int)Color.red || front[2, 1] == (int)Color.red || front[1, 2] == (int)Color.red)
            {
                if (upper[2, 1] != (int)Color.red)
                {
                    if (front[0, 1] == (int)Color.red)
                    {
                        move = "f";
                        movement(move);
                        MoveSet.Add(move);
                        move = "l";
                        movement(move);
                        MoveSet.Add(move);
                        move = "u";
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (front[1, 0] == (int)Color.red)
                    {
                        move = "F";
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (front[2, 1] == (int)Color.red)
                    {
                        move = "F";
                        movement(move);
                        MoveSet.Add(move);
                        movement(move);
                        MoveSet.Add(move);
                    }
                    else if (front[1, 2] == (int)Color.red)
                    {
                        move = "f";
                        movement(move);
                        MoveSet.Add(move);
                    }
                }
                else
                {
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                }
            }
            else if (back[0, 1] == (int)Color.red || back[1, 0] == (int)Color.red || back[2, 1] == (int)Color.red || back[1, 2] == (int)Color.red)
            {
                if (upper[0, 1] != (int)Color.red)
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
                    else if (back[1, 0] == (int)Color.red)
                    {
                        move = "B";
                        movement(move);
                        MoveSet.Add(move);

                    }
                    else if (back[2, 1] == (int)Color.red)
                    {
                        move = "B";
                        movement(move);
                        MoveSet.Add(move);
                        movement(move);
                        MoveSet.Add(move);

                    }
                    else if (back[1, 2] == (int)Color.red)
                    {
                        move = "b";
                        movement(move);
                        MoveSet.Add(move);
                    }
                }
                else
                {
                    move = "U";
                    movement(move);
                    MoveSet.Add(move);
                }
            }*/

            else
            {
                phase = (int)Phase.first;
            }


        }

        public static void moveSetList()
        {
            foreach (string newMove in MoveSet)
            {
                Console.WriteLine(newMove);
            }

        }


        static void Main(string[] args)
        {
            //string move;

            //int a = 1;
            //int b = 2;
            //int c = 3;
            //int d = 4;
            //int e = 5;
            //int f = 6;

            while (true)
            {
                Console.Write("Welcome to VirtuaCube 2.3; would you like to initialize the cube? ");     // <-- This writes the word.
                Console.WriteLine();       // <-- This writes a newline.
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
                                solveCross();
                                Console.WriteLine();
                                moveSetList();
                                Console.WriteLine();

                                //move = Console.ReadLine();
                                // movement(move);
                                // movement(move);
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



                            }//PHASE 'while' I loop
                        }//PHASE I 'if' loop

                        if (phase == (int)Phase.second)
                        {
                            break;
                            /*while (phase == (int)Phase.second)
                            {


                            }//PHASE 'while' II loop*/
                        }//PHASE II 'if' loop

                        if (phase == (int)Phase.third)
                        {
                            break;
                            /*while (phase == (int)Phase.third)
                            {


                            }//PHASE 'while' III loop*/
                        }//PHASE III 'if' loop

                        if (phase == (int)Phase.fourth)
                        {
                            break;
                            /* while (phase == (int)Phase.fourth)
                             {


                             }//PHASE 'while' IV loop*/
                        }//PHASE IV 'if' loop
                    }	//UNSOLVED loop
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


