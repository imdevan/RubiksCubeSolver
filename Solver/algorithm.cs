
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
		
		Console.Write("Welcome to VirtuaCube 1.0. What is the state of your cube? ");  
        Console.WriteLine();       
        state = Console.ReadLine();
		
		if(state == (int)State.unsolved){
			while(state == (int)State.unsolved){
				if(front[0,1] != 3 && front[1,0] != 3 && front[1,1] != 3 && front[1,2] != 3 && front[2,1]){
				
				
				
				
				
				
			
			
			
			
			
			
			
				} else if(front[0,1] == 3 && front[1,0] == 3 && front[1,1] == 3 && front[1,2] == 3 && front[2,1]) {
				
				
				
				}
			}	
		}	else if (state == (int)State.unsolved){
				Console.Write("Cool. See ya.");  
				break;
		}	else{
				break;
		}
		
		
		}	//MAIN
	}	//CLASS
}	//NAMESPACE