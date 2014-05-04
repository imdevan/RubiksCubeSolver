//enum Color {white, yellow, blue, green, red, orange};

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rubiks
{
    class Program
    {
		enum State {solved ,unsolved};

        /*public static void vCube()
        {


        }*/
		
        static void Main(string[] args)
        {
			int state;
			            
            int [,] upper = new int[3,3] 	{{1,1,1},
											 {1,1,1},
											 {1,1,1}};		
			int [,] left = new int[3,3] 	{{2,2,2},
											 {2,2,2},
											 {2,2,2}};		
			int [,] front = new int[3,3] 	{{3,3,3},
											 {3,3,3},
											 {3,3,3}};		
			int [,] right = new int[3,3] 	{{4,4,4},
											 {4,4,4},
											 {4,4,4}};	
			int [,] back = new int[3,3] 	{{5,5,5},
											 {5,5,5},
											 {5,5,5}};		
			int [,] down = new int[3,3] 	{{6,6,6},
											 {6,6,6},
											 {6,6,6}};		
			
			//PREVIOUS MOVE INDEX
			/*int [,] upper0 = new int[3,3]; 	//{{,,},{,,},{,,}};		//WHITE
			int [,] left0 = new int[3,3]; 	//{{2,2,2},{2,2,2},{2,2,2}};		//RED
			int [,] front0 = new int[3,3];	//{{3,3,3},{3,3,3},{3,3,3}};		//WHITE
			int [,] right0 = new int[3,3]; 	//{{4,4,4}, {4,4,4},{4,4,4}};	//GREEN
			int [,] back0 = new int[3,3]; 	//{{5,5,5}, {5,5,5},{5,5,5}};		//RED
			int [,] down0 = new int[3,3];	// {{6,6,6},{6,6,6},{6,6,6}};		//ORANGE*/
			
			int [,] upper0 = new int[3,3] 	{{upper[0,0],upper[1,0],upper[2,0]},
											 {upper[0,1],upper[1,1],upper[2,1]},
											 {upper[0,2],upper[1,2],upper[2,2]}}; 		
			int [,] left0 = new int[3,3] 	{{left[0,0],left[1,0],left[2,0]},
											 {left[0,1],left[1,1],left[2,1]},
											 {left[0,2],left[1,2],left[2,2]}};  			
			int [,] front0 = new int[3,3] 	{{front[0,0],front[1,0],front[2,0]},
											 {front[0,1],front[1,1],front[2,1]},
											 {front[0,2],front[1,2],front[2,2]}};		
			int [,] right0 = new int[3,3] 	{{right[0,0],right[1,0],right[2,0]},
											 {right[0,1],right[1,1],right[2,1]},
											 {right[0,2],right[1,2],right[2,2]}}; 	
			int [,] back0 = new int[3,3] 	{{back[0,0],back[1,0],back[2,0]},
											 {back[0,1],back[1,1],back[2,1]},
											 {back[0,2],back[1,2],back[2,2]}}; 			
			int [,] down0 = new int[3,3] 	{{down[0,0],down[1,0],down[2,0]},
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
				   while (state == (int)State.unsolved){
					
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
                    Console.Write("\t"+" "+" "+" "+" " + " " + "---" + " " + "---" + " " + "---" + " ");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + "|" + " " + upper[0,2] + " " + "|" + " " + upper[1,2] + " " + "|" + " " + upper[2,2] + " " + "|");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + " " + "---" + " " + "---" + " " + "---" + " ");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + "|" + " " + upper[0,1] + " " + "|" + " " + "U" + " " + "|" + " " + upper[2,1] + " " + "|");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + " " + "---" + " " + "---" + " " + "---" + " ");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + "|" + " " + upper[0,0] + " " + "|" + " " + upper[1,0] + " " + "|" + " " + upper[2,0] + " " + "|");
					Console.WriteLine();
					
                    Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
					Console.WriteLine();
					Console.Write("|" + " " + left[0,2] + " " + "|" + " " + left[1,2] + " " + "|" + " " + left[2,2] + " " + "|" + " " + front[0,2] + " " + "|" + " " + front[1,2] + " " + "|" + " " + front[2,2] + " " + "|" + " " + right[0,2] + " " + "|" + " " + right[1,2] + " " + "|" + " " + right[2,2] + " " + "|" + " " + back[0,2] + " " + "|" + " " + back[1,2] + " " + "|" + " " + back[2,2] + " " + "|");
					Console.WriteLine();
					Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
					Console.WriteLine();
					Console.Write("|" + " " + left[0,1] + " " + "|" + " " + "L" + " " + "|" + " " + left[2,1] + " " + "|" + " " + front[0,1] + " " + "|" + " " + "F" + " " + "|" + " " + front[2,1] + " " + "|" + " " + right[0,1] + " " + "|" + " " + "R" + " " + "|" + " " + right[2,1] + " " + "|" + " " + back[0,1] + " " + "|" + " " + "B" + " " + "|" + " " + back[2,1] + " " + "|");
					Console.WriteLine();
					Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
					Console.WriteLine();
					Console.Write("|" + " " + left[0,0] + " " + "|" + " " + left[1,0] + " " + "|" + " " + left[2,0] + " " + "|" + " " + front[0,0] + " " + "|" + " " + front[1,0] + " " + "|" + " " + front[2,0] + " " + "|" + " " + right[0,0] + " " + "|" + " " + right[1,0] + " " + "|" + " " + right[2,0] + " " + "|" + " " + back[0,0] + " " + "|" + " " + back[1,0] + " " + "|" + " " + back[2,0] + " " + "|");
					Console.WriteLine();
					Console.Write(" " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---" + " " + "---");
					Console.WriteLine();
				
					Console.Write("\t"+" "+" "+" "+" " + "|" + " " + down[0,2] + " " + "|" + " " + down[1,2] + " " + "|" + " " + down[2,2] + " " + "|");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + " " + "---" + " " + "---" + " " + "---" + " ");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + "|" + " " + down[0,1] + " " + "|" + " " + "D" + " " + "|" + " " + down[2,1] + " " + "|");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + " " + "---" + " " + "---" + " " + "---" + " ");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + "|" + " " + down[0,0] + " " + "|" + " " + down[1,0] + " " + "|" + " " + down[2,0] + " " + "|");
					Console.WriteLine();
					Console.Write("\t"+" "+" "+" "+" " + " " + "---" + " " + "---" + " " + "---" + " ");
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
					
					switch (move){
		            	case "F":
						case "0":
						//CW rotation of FRONT face
						//BACK unaffected
							front[0,0] = front0[2,0];	front[0,1] = front0[1,0];	front[0,2] = front0[0,0];
							front[1,0] = front0[2,1];	front[1,1] = front0[1,1];	front[1,2] = front0[0,1];
							front[2,0] = front0[2,2];	front[2,1] = front0[1,2];	front[2,2] = front0[0,2];
				
						//FRONT CW side rotations
							upper[2,0] = left0[2,2];	upper[2,1] = left0[1,2];	upper[2,2] = left0[0,2];	
							right[0,0] = upper0[2,0];	right[1,0] = upper0[2,1];	right[2,0] = upper0[2,2];	
							down[0,0] = right0[0,0];	down[0,1] = right0[1,0];	down[0,2] = right0[2,0];	
							left[0,2] = down0[0,0];		left[1,2] = down0[0,1];		left[2,2] = down0[0,2];	
						break;
				
						case "f":
						case "1":
						//CCW rotation of BACK face
							front[0,0] = front0[0,2];	front[0,1] = front0[1,2];	front[0,2] = front0[2,2];
							front[1,0] = front0[0,1];	front[1,1] = front0[1,1];	front[1,2] = front0[2,1];
							front[2,0] = front0[0,0];	front[2,1] = front0[1,0];	front[2,2] = front0[2,0];
				
						//FRONT CCW side rotations
							upper[2,0] = right0[0,0];	upper[2,1] = right0[1,0];	upper[2,2] = right0[2,0];
							left[0,2] = upper0[2,2];	left[1,2] = upper0[2,1];	left[2,2] = upper0[2,0];
							down[0,0] = left0[0,2];		down[0,1] = left0[1,2];		down[0,2] = left0[2,2];
							right[0,0] = down0[0,2];	right[1,0] = down0[0,1];	right[2,0] = down0[0,0];
						break;
				
						case "B":
						case "2":
						//CW rotation of BACK face
						//FRONT unaffected
							back[0,0] = back0[2,0];		back[0,1] = back0[1,0];		back[0,2] = back0[0,0];
							back[1,0] = back0[2,1];		back[1,1] = back0[1,1];		back[1,2] = back0[0,1];
							back[2,0] = back0[2,2];		back[2,1] = back0[1,2];		back[2,2] = back0[0,2];
				
						//BACK CW side rotations
							upper[0,0] = right0[0,2];	upper[0,1] = right0[1,2];	upper[0,2] = right0[2,2];	
							left[0,0] = upper0[0,2];	left[1,0] = upper0[0,1];	left[2,0] = upper0[0,0];
							down[2,0] = left0[0,0];		down[2,1] = left0[1,0];		down[2,2] = left0[2,0];
							right[0,2] = down0[2,2];	right[1,2] = down0[2,1];	right[2,2] = down0[2,0];	
						break;
						
						case "b":
						case "3":
						//CCW rotation of BACK face
							back[0,0] = back0[0,2];		back[0,1] = back0[1,2];		back[0,2] = back0[2,2];
							back[1,0] = back0[0,1];		back[1,1] = back0[1,1];		back[1,2] = back0[2,1];
							back[2,0] = back0[0,0];		back[2,1] = back0[1,0];		back[2,2] = back0[2,0];
				
						//BACK CCW side rotations
							upper[0,0] = left0[2,0];	upper[0,1] = left0[1,0];	upper[0,2] = left0[0,0];
							right[0,2] = upper0[0,0];	right[1,2] = upper0[0,1];	right[2,2] = upper0[0,2];
							down[2,0] = right0[2,2];	down[2,1] = right0[1,2];	down[2,2] = right0[0,2];
							left[0,0] = down0[2,0];		left[1,0] = down0[2,1];		left[2,0] = down0[2,2];
						break;
				
						case "L":
						case "4":
						//CW rotation of LEFT face
						//RIGHT unaffected
							left[0,0] = left0[2,0];		left[0,1] = left0[1,0];		left[0,2] = left0[0,0];
							left[1,0] = left0[2,1];		left[1,1] = left0[1,1];		left[1,2] = left0[0,1];
							left[2,0] = left0[2,2];		left[2,1] = left0[1,2];		left[2,2] = left0[0,2];
				
						//LEFT CW side rotations
							upper[,] = back0[,];		upper[,] = back0[,];		upper[,] = back0[,];
							front[,] = upper0[,];		front[,] = upper0[,];		front[,] = upper0[,];	
							down[,] = front0[,];		down[,] = front0[,];		down[,] = front0[,];	
							back[,] = down0[,];			back[,] = down0[,];			back[,] = down0[,];	
						break;
						
						case "l":
						case "5":
						//CCW rotation of LEFT face
							left[0,0] = left0[0,2];		left[0,1] = left0[1,2];		left[0,2] = left0[2,2];
							left[1,0] = left0[0,1];		left[1,1] = left0[1,1];		left[1,2] = left0[2,1];
							left[2,0] = left0[0,0];		left[2,1] = left0[1,0];		left[2,2] = left0[2,0];
				
						//LEFT CCW side rotations
							upper[,] = front0[,];		upper[,] = front0[,];		upper[,] = front0[,];
							back[,] = upper0[,];		back[,] = upper0[,];		back[,] = upper0[,];
							down[,] = back0[,];			down[,] = back0[,];			down[,] = back0[,];
							front[,] = down0[,];		front[,] = down0[,];		front[,] = down0[,];
						break;
				
						case "R":
						case "6":
						//clockwise rotation of RIGHT face
						//LEFT unaffected
							right[0,0] = right0[2,0];	right[0,1] = right0[1,0];	right[0,2] = right0[0,0];
							right[1,0] = right0[2,1];	right[1,1] = right0[1,1];	right[1,2] = right0[0,1];
							right[2,0] = right0[2,2];	right[2,1] = right0[1,2];	right[2,2] = right0[0,2];
				
						//RIGHT CW side rotations
							upper[,] = front0[,]; 		upper[,] = front0[,];		upper[,] = front0[,];	
							back[,] = upper0[,];		back[,] = upper0[,];		back[,] = upper0[,];	
							down[,] = back0[,];			down[,] = back0[,];			down[,] = back0[,];
							front[,] = down0[,];		front[,] = down0[,];		front[,] = down0[,];	
						break;
						
						case "r":
						case "7":
						//counter-clockwise rotation of RIGHT face
							right[0,0] = right0[0,2];	right[0,1] = right0[1,2];	right[0,2] = right0[2,2];
							right[1,0] = right0[0,1];	right[1,1] = right0[1,1];	right[1,2] = right0[2,1];
							right[2,0] = right0[0,0];	right[2,1] = right0[1,0];	right[2,2] = right0[2,0];
				
						//RIGHT CCW side rotations
							upper[,] = back0[,];		upper[,] = back0[,];		upper[,] = back0[,];
							front[,] = upper0[,];		front[,] = upper0[,];		front[,] = upper0[,];
							down[,] = front0[,];		down[,] = front0[,];		down[,] = front0[,];
							back[,] = down0[,];			back[,] = down0[,];			back[,] = down0[,];
						break;
			
						case "U":
						case "8":
						//clockwise rotation of UPPER face
						//DOWN unaffected
							upper[0,0] = upper0[2,0];	upper[0,1] = upper0[1,0];	upper[0,2] = upper0[0,0];
							upper[1,0] = upper0[2,1];	upper[1,1] = upper0[1,1];	upper[1,2] = upper0[0,1];
							upper[2,0] = upper0[2,2];	upper[2,1] = upper0[1,2];	upper[2,2] = upper0[0,2];
				
						//UPPER CW side rotations
							back[,] = left0[,]; 		back[,] = left0[,];			back[,] = left0[,];	
							right[,] = back0[,];		right[,] = back0[,];		right[,] = back0[,];
							front[,] = right0[,];		front[,] = right0[,];		front[,] = right0[,];
							left[,] = front0[,];		left[,] = front0[,];		left[,] = front0[,];	
						break;
						
						case "u":
						case "9":
						//counter-clockwise rotation of UPPER face
							upper[0,0] = upper0[0,2];	upper[0,1] = upper0[1,2];	upper[0,2] = upper0[2,2];
							upper[1,0] = upper0[0,1];	upper[1,1] = upper0[1,1];	upper[1,2] = upper0[2,1];
							upper[2,0] = upper0[0,0];	upper[2,1] = upper0[1,0];	upper[2,2] = upper0[2,0];
				
						//UPPER CCW side rotations
							back[,] = right0[,];		back[,] = right0[,];		back[,] = right0[,];
							left[,] = back0[,];			left[,] = back0[,];			left[,] = back0[,];
							front[,] = left0[,];		front[,] = left0[,];		front[,] = left0[,];
							right[,] = front0[,];		right[,] = front0[,];		right[,] = front0[,];
						break;
				
						case "D":
						case "10":
						//clockwise rotation of DOWN (bottom) face
						//UPPER unaffected
							down[0,0] = down0[2,0];		down[0,1] = down0[1,0];		down[0,2] = down0[0,0];
							down[1,0] = down0[2,1];		down[1,1] = down0[1,1];		down[1,2] = down0[0,1];
							down[2,0] = down0[2,2];		down[2,1] = down0[1,2];		down[2,2] = down0[0,2];
				
						//DOWN CW side rotations
							front[,] = left0[,];		front[,] = left0[,];		front[,] = left0[,];
							right[,] = front0[,];		right[,] = front0[,];		right[,] = front0[,];
							back[,] = right0[,];		back[,] = right0[,];		back[,] = right0[,];
							left[,] = back0[,];			left[,] = back0[,];			left[,] = back0[,];
						break;
				
						case "d":
						case "11":
						//counter-clockwise rotation of DOWN (bottom) face
							down[0,0] = down0[0,2];		down[0,1] = down0[1,2];		down[0,2] = down0[2,2];
							down[1,0] = down0[0,1];		down[1,1] = down0[1,1];		down[1,2] = down0[2,1];
							down[2,0] = down0[0,0];		down[2,1] = down0[1,0];		down[2,2] = down0[2,0];

						//DOWN CCW side rotations
							front[,] = right0[,];		front[,] = right0[,];	front[,] = right0[,];
							right[,] = back0[,];		right[,] = back0[,];	right[,] = back0[,];
							back[,] = left0[,]; 		back[,] = left0[,];		back[,] = left0[,];	
							left[,] = front0[,];		left[,] = front0[,];	left[,] = front0[,];	
						break;
					}//switch
					
						upper0[0,0] = upper[0,0];	upper0[1,2] = upper[1,2];	upper0[2,2] = upper[2,2];
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
						down0[0,0] = down[0,0];		down0[1,0] = down[1,0];		down0[2,0] = down[2,0];
				//rubiks.Close();
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

