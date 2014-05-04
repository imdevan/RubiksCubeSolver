using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSolver
{
    class Solver
    {

        enum State { solved, unsolved };

        /*public static void vCube()
        {


        }*/

        public static void Run(Cube pCube)
        {
            int state;

            int[,] upper = new int[3, 3] 	{{1,1,1},
											 {1,1,1},
											 {1,1,1}};
            int[,] left = new int[3, 3] 	{{2,2,2},
											 {2,2,2},
											 {2,2,2}};
            int[,] front = new int[3, 3] 	{{3,3,3},
											 {3,3,3},
											 {3,3,3}};
            int[,] right = new int[3, 3] 	{{4,4,4},
											 {4,4,4},
											 {4,4,4}};
            int[,] back = new int[3, 3] 	{{5,5,5},
											 {5,5,5},
											 {5,5,5}};
            int[,] down = new int[3, 3] 	{{6,6,6},
											 {6,6,6},
											 {6,6,6}};

            // Set faces equal to cube being passed in.
            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    upper[xi, yi] = (int)pCube.faces[0].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    left[xi, yi] = (int)pCube.faces[1].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    front[xi, yi] = (int)pCube.faces[2].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    right[xi, yi] = (int)pCube.faces[3].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    back[xi, yi] = (int)pCube.faces[4].cubies[xi, yi].color;

            for (int yi = 0; yi < 3; yi++)
                for (int xi = 0; xi < 3; xi++)
                    down[xi, yi] = (int)pCube.faces[5].cubies[xi, yi].color;


            //PREVIOUS MOVE INDEX
            /*int [,] upper0 = new int[3,3]; 	//{{,,},{,,},{,,}};		//WHITE
            int [,] left0 = new int[3,3]; 	//{{2,2,2},{2,2,2},{2,2,2}};		//RED
            int [,] front0 = new int[3,3];	//{{3,3,3},{3,3,3},{3,3,3}};		//WHITE
            int [,] right0 = new int[3,3]; 	//{{4,4,4}, {4,4,4},{4,4,4}};	//GREEN
            int [,] back0 = new int[3,3]; 	//{{5,5,5}, {5,5,5},{5,5,5}};		//RED
            int [,] down0 = new int[3,3];	// {{6,6,6},{6,6,6},{6,6,6}};		//ORANGE*/

            int[,] upper0 = new int[3, 3] 	{{upper[0,0],upper[1,0],upper[2,0]},
											 {upper[0,1],upper[1,1],upper[2,1]},
											 {upper[0,2],upper[1,2],upper[2,2]}};
            int[,] left0 = new int[3, 3] 	{{left[0,0],left[1,0],left[2,0]},
											 {left[0,1],left[1,1],left[2,1]},
											 {left[0,2],left[1,2],left[2,2]}};
            int[,] front0 = new int[3, 3] 	{{front[0,0],front[1,0],front[2,0]},
											 {front[0,1],front[1,1],front[2,1]},
											 {front[0,2],front[1,2],front[2,2]}};
            int[,] right0 = new int[3, 3] 	{{right[0,0],right[1,0],right[2,0]},
											 {right[0,1],right[1,1],right[2,1]},
											 {right[0,2],right[1,2],right[2,2]}};
            int[,] back0 = new int[3, 3] 	{{back[0,0],back[1,0],back[2,0]},
											 {back[0,1],back[1,1],back[2,1]},
											 {back[0,2],back[1,2],back[2,2]}};
            int[,] down0 = new int[3, 3] 	{{down[0,0],down[1,0],down[2,0]},
											 {down[0,1],down[1,1],down[2,1]},
											 {down[0,2],down[1,2],down[2,2]}};

            while (true)
            {
                Console.Write("Welcome to VirtuaCube 1.0. Would you like to initialize the cube? ");     // <-- This writes the word.
                Console.WriteLine();       // <-- This writes a newline.
                string response = Console.ReadLine();
                if (response == "yes" || response == "y")
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
                        Console.Write("\t" + " " + " " + " " + " " + "|" + " " + upper[0, 2] + " " + "|" + " " + upper[1, 2] + " " + "|" + " " + upper[2, 2] + " " + "|");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + "|" + " " + upper[0, 1] + " " + "|" + " " + "U" + " " + "|" + " " + upper[2, 1] + " " + "|");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + "|" + " " + upper[0, 0] + " " + "|" + " " + upper[1, 0] + " " + "|" + " " + upper[2, 0] + " " + "|");
                        Console.WriteLine();

                        Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
                        Console.WriteLine();
                        Console.Write("|" + " " + left[0, 2] + " " + "|" + " " + left[1, 2] + " " + "|" + " " + left[2, 2] + " " + "|" + " " + front[0, 2] + " " + "|" + " " + front[1, 2] + " " + "|" + " " + front[2, 2] + " " + "|" + " " + right[0, 2] + " " + "|" + " " + right[1, 2] + " " + "|" + " " + right[2, 2] + " " + "|" + " " + back[0, 2] + " " + "|" + " " + back[1, 2] + " " + "|" + " " + back[2, 2] + " " + "|");
                        Console.WriteLine();
                        Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
                        Console.WriteLine();
                        Console.Write("|" + " " + left[0, 1] + " " + "|" + " " + "L" + " " + "|" + " " + left[2, 1] + " " + "|" + " " + front[0, 1] + " " + "|" + " " + "F" + " " + "|" + " " + front[2, 1] + " " + "|" + " " + right[0, 1] + " " + "|" + " " + "R" + " " + "|" + " " + right[2, 1] + " " + "|" + " " + back[0, 1] + " " + "|" + " " + "B" + " " + "|" + " " + back[2, 1] + " " + "|");
                        Console.WriteLine();
                        Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
                        Console.WriteLine();
                        Console.Write("|" + " " + left[0, 0] + " " + "|" + " " + left[1, 0] + " " + "|" + " " + left[2, 0] + " " + "|" + " " + front[0, 0] + " " + "|" + " " + front[1, 0] + " " + "|" + " " + front[2, 0] + " " + "|" + " " + right[0, 0] + " " + "|" + " " + right[1, 0] + " " + "|" + " " + right[2, 0] + " " + "|" + " " + back[0, 0] + " " + "|" + " " + back[1, 0] + " " + "|" + " " + back[2, 0] + " " + "|");
                        Console.WriteLine();
                        Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
                        Console.WriteLine();

                        Console.Write("\t" + " " + " " + " " + " " + "|" + " " + down[0, 2] + " " + "|" + " " + down[1, 2] + " " + "|" + " " + down[2, 2] + " " + "|");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + "|" + " " + down[0, 1] + " " + "|" + " " + "D" + " " + "|" + " " + down[2, 1] + " " + "|");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + "|" + " " + down[0, 0] + " " + "|" + " " + down[1, 0] + " " + "|" + " " + down[2, 0] + " " + "|");
                        Console.WriteLine();
                        Console.Write("\t" + " " + " " + " " + " " + " " + "---" + " " + "---" + " " + "---" + " ");
                        Console.WriteLine();
                        Console.WriteLine();


                        Console.Write("What move would you like to make?");
                        Console.WriteLine();
                        string move = Console.ReadLine();

                        /*upper0 = {{upper[0,0],upper[1,0],upper[2,0]},{upper[0,1],upper[1,1],upper[2,1]},{upper[0,2],upper[1,2],upper[2,2]}}; 		
                        left0 = {{left[0,0],left[1,0],left[2,0]},{left[0,1],left[1,1],left[2,1]},{left[0,2],left[1,2],left[2,2]}};  			
                        front0 = {{front[0,0],front[1,0],front[2,0]},{front[0,1],front[1,1],front[2,1]},{front[0,2],front[1,2],front[2,2]}};		
                        right0 = {{right[0,0],right[1,0],right[2,0]},{right[0,1],right[1,1],right[2,1]},{right[0,2],right[1,2],right[2,2]}}; 	
                        back0 = {{back[0,0],back[1,0],back[2,0]},{back[0,1],back[1,1],back[2,1]},{back[0,2],back[1,2],back[2,2]}}; 			
                        down0 = {{down[0,0],down[1,0],down[2,0]},{down[0,1],down[1,1],down[2,1]},{down[0,2],down[1,2],down[2,2]}};	*/

                        //insert moves HERE

                        // TODO: Re-insert 'move' switch statement.
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
}
