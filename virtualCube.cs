

using System;
//using ...;

namespace virtualCube
{
	class virtualCube{
	//6 colors:		RED, BLUE, GREEN, WHITE, YELLOW, ORANGE
	//6 faces: 		UPPER, LEFT, RIGHT, FRONT, BACK, DOWN
	//12 movements:	U =	UPPER clockwise;	u = UPPER counter-clockwise
	//				L =	LEFT clockwise;		l = LEFT counter-clockwise
	//				R =	RIGHT clockwise;	r = RIGHT counter-clockwise
	//				F =	FRONT clockwise;	f = FRONT counter-clockwise
	//				B =	BACK clockwise;		b = BACK counter-clockwise
	//				D =	DOWN clockwise;		d = DOWN counter-clockwise
	
		char move;
	
		//multidimensional array of chars
		/*char front [3][3] = {{"","",""},	//WHITE
							{"","w",""},
							{"","",""}};
						 
		char back [3][3] = {{"","",""},		//YELLOW
							{"","y",""},
							{"","",""}};
						
		char left [3][3] = {{"","",""},		//BLUE
							{"","b",""},
							{"","",""}};
						
		char right [3][3] = {{"","",""},	//GREEN
							{"","g",""},
							{"","",""}};
						
		char upper [3][3] = {{"","",""},	//RED
							{"","r",""},
							{"","",""}};
						 
		char down [3][3] = {{"","",""},		//ORANGE
							{"","o",""},
							{"","",""}};	*/
		
		/*char [,,] cube = new char[3,3,3];
		
		
		*/
							
		char [,] front = new char[3,3] = {{"w","w","w"},	//WHITE
										  {"w","w","w"},
										  {"w","w","w"}};	
						 
		char [,] back = new char[3,3] = {{"y","y","y"},	//"YELLOW"
										 {"y","y","y"},
									  	 {"y","y","y"}};
						
		char [,] left = new char[3,3] = {{"b","b","b"},	//"BLUE"
										 {"b","b","b"},
										 {"b","b","b"}};
						
		char [,] right = new char[3,3] = {{"g","g","g"},	//"GREEN"
										  {"g","g","g"},
										  {"g","g","g"}};
						
		char [,] upper = new char[3,3] = {{"r","r","r"},	//"RED"
										  {"r","r","r"},
										  {"r","r","r"}};
						 
		char [,] down = new char[3,3] = {{"o","o","o"},	//"ORANGE"
										 {"o","o","o"},
										 {"o","o","o"}};				


		//front[1,1]= "w"; 			//	assignments
		//front[2,2] = upper[1,1]; 	//	get/set 
		
		//var numbers = new int[3,3]



		//switch statements for all 12 movements
		switch (char){
			case 'F':
				//CW rotation of FRONT face
				//BACK unaffected
				front[0,0] = front[2,0];
				front[1,0] = front[2,1];
				front[2,0] = front[2,2];
				front[0,1] = front[1,0];
				//front[1,1] = front[1,1]; CENTER
				front[2,1] = front[1,2];
				front[0,2] = front[0,0];
				front[1,2] = front[0,1];
				front[2,2] = front[0,2];
				
				//FRONT CW side rotations
				left[2,0] = down[2,2];	
				left[2,1] = down[1,2];	
				left[2,2] = down[0,2];	
				
				upper[0,0] = left[2,0];	
				upper[1,0] = left[2,1];	
				upper[2,0] = left[2,2];	
				
				right[0,0] = upper[2,0];
				right[0,1] = upper[1,0];	
				right[0,2] = upper[0,0];	
								
				down[0,2] = right[0,0];	
				down[1,2] = right[0,1];	
				down[2,2] = right[0,2];	
				
				break;
				
			case 'f':
				//CCW rotation of BACK face
				front[0,0] = front[0,2];
				front[1,0] = front[0,1];
				front[2,0] = front[0,0];
				front[0,1] = front[1,2];
				//front[1,1] = front[1,1]; CENTER
				front[2,1] = front[1,0];
				front[0,2] = front[2,2];
				front[1,2] = front[2,1];
				front[2,2] = front[2,0];
				
				//FRONT CCW side rotations
				left[2,0] = upper[0,0];
				left[2,1] = upper[1,0];
				left[2,2] = upper[2,0];
				
				upper[0,0] = right[0,2];
				upper[1,0] = right[0,1];
				upper[2,0] = right[0,0];
				
				right[0,0] = down[0,2];
				right[0,1] = down[1,2];
				right[0,2] = down[2,2];
								
				down[0,2] = left[2,2];
				down[1,2] = left[2,1];
				down[2,2] = left[2,0];
				
				break;
				
			case 'B':
				//CW rotation of BACK face
				//FRONT unaffected
				back[0,0] = back[2,0];
				back[1,0] = back[2,1];
				back[2,0] = back[2,2];
				back[0,1] = back[1,0];
				//back[1,1] = back[1,1]; CENTER
				back[2,1] = back[1,2];
				back[0,2] = back[0,0];
				back[1,2] = back[0,1];
				back[2,2] = back[0,2];
				
				//BACK CW side rotations
				right[2,0] = down[2,0];	
				right[2,1] = down[1,0];	
				right[2,2] = down[0,0];	
				
				upper[0,2] = right[2,2];	
				upper[1,2] = right[2,1];	
				upper[2,2] = right[2,0];	
				
				left[0,0] = upper[2,0];
				left[0,1] = upper[1,0];	
				left[0,2] = upper[0,0];	
								
				down[0,0] = left[0,2];	
				down[1,0] = left[0,1];	
				down[2,0] = left[0,0];
				
				break;
			case 'b':
				//CCW rotation of BACK face
				back[0,0] = back[0,2];
				back[1,0] = back[0,1];
				back[2,0] = back[0,0];
				back[0,1] = back[1,2];
				//back[1,1] = back[1,1]; //CENTER
				back[2,1] = back[1,0];
				back[0,2] = back[2,2];
				back[1,2] = back[2,1];
				back[2,2] = back[2,0];
				
				//BACK CCW side rotations
				right[2,0] = upper[2,2];
				right[2,1] = upper[1,2];
				right[2,2] = upper[0,2];
				
				down[0,0] = right[2,0];
				down[1,0] = right[2,1];
				down[2,0] = right[2,2];
				
				left[0,0] = down[2,0];
				left[0,1] = down[1,0];
				left[0,2] = down[0,0];
				
				upper[0,2] = left[0,0];
				upper[1,2] = left[0,1];
				upper[2,2] = left[0,2];
				
				break;
				
			case 'L':
				//CW rotation of LEFT face
				//RIGHT unaffected
				left[0,0] = left[2,0];
				left[1,0] = left[2,1];
				left[2,0] = left[2,2];
				left[0,1] = left[1,0];
				//left[1,1] = left[1,1]; CENTER
				left[2,1] = left[1,2];
				left[0,2] = left[0,0];
				left[1,2] = left[0,1];
				left[2,2] = left[0,2];
				
				//LEFT CW side rotations
				back[2,0] = down[2,2];	
				back[2,1] = down[0,1];	
				back[2,2] = down[0,0];	
				
				upper[0,0] = back[2,2];	
				upper[0,1] = back[2,1];	
				upper[0,2] = back[2,0];	
				
				front[0,0] = upper[0,0];
				front[0,1] = upper[0,1];	
				front[0,2] = upper[0,2];	
								
				down[0,0] = front[0,0];	
				down[0,1] = front[0,1];	
				down[0,2] = front[0,2];	
				
				break;
			case 'l':
				//CCW rotation of LEFT face
				left[0,0] = left[0,2];
				left[1,0] = left[0,1];
				left[2,0] = left[0,0];
				left[0,1] = left[1,2];
				//left[1,1] = left[1,1]; //CENTER
				left[2,1] = left[1,0];
				left[0,2] = left[2,2];
				left[1,2] = left[2,1];
				left[2,2] = left[2,0];
				
				//LEFT CCW side rotations
				back[2,0] = upper[0,2];
				back[2,1] = upper[0,1];
				back[2,2] = upper[0,0];
				
				down[0,0] = back[2,2];
				down[0,1] = back[2,1];
				down[0,2] = back[2,0];
				
				front[0,0] = down[0,0];
				front[0,1] = down[0,1];
				front[0,2] = down[0,2];
								
				upper[0,0] = front[0,0];
				upper[0,1] = front[0,1];
				upper[0,2] = front[0,2];
				
				break;
				
			case 'R':
				//clockwise rotation of RIGHT face
				//LEFT unaffected
				right[0,0] = right[2,0];
				right[1,0] = right[2,1];
				right[2,0] = right[2,2];
				right[0,1] = right[1,0];
				//right[1,1] = right[1,1]; CENTER
				right[2,1] = right[1,2];
				right[0,2] = right[0,0];
				right[1,2] = right[0,1];
				right[2,2] = right[0,2];
				
				//RIGHT CW side rotations
				front[2,0] = down[2,0];		
				front[2,1] = down[2,1];	
				front[2,2] = down[2,2];	
			
				upper[2,0] = front[2,0]; 	
				upper[2,1] = front[2,1];	
				upper[2,2] = front[2,2];	
				
				back[0,0] = upper[2,2];		
				back[0,1] = upper[2,1];	
				back[0,2] = upper[2,0];	
								
				down[2,0] = back[0,2];	
				down[2,1] = back[0,1];	
				down[2,2] = back[0,0];
				
				break;
			case 'r':
				//counter-clockwise rotation of RIGHT face
				right[0,0] = right[0,2];
				right[1,0] = right[0,1];
				right[2,0] = right[0,0];
				right[0,1] = right[1,2];
				//right[1,1] = right[1,1]; //CENTER
				right[2,1] = right[1,0];
				right[0,2] = right[2,2];
				right[1,2] = right[2,1];
				right[2,2] = right[2,0];
				
				//RIGHT CCW side rotations
				front[2,0] = upper[2,0];
				front[2,1] = upper[2,1];
				front[2,2] = upper[2,2];
			
				down[2,0] = front[2,0];
				down[2,1] = front[2,1];
				down[2,2] = front[2,2];
				
				back[0,0] = down[0,0];
				back[0,1] = down[0,1];
				back[0,2] = down[0,2];
								
				upper[2,0] = back[0,2];
				upper[2,1] = back[0,1];
				upper[2,2] = back[0,0];
				
				break;
			
			case 'U':
				//clockwise rotation of UPPER face
				//DOWN unaffected
				upper[0,0] = upper[2,0];
				upper[1,0] = upper[2,1];
				upper[2,0] = upper[2,2];
				upper[0,1] = upper[1,0];
				//upper[1,1] = upper[1,1]; CENTER
				upper[2,1] = upper[1,2];
				upper[0,2] = upper[0,0];
				upper[1,2] = upper[0,1];
				upper[2,2] = upper[0,2];
				
				//UPPER CW side rotations
				left[0,2] = front[0,2];		
				left[1,2] = front[1,2];	
				left[2,2] = front[2,2];	
			
				back[0,2] = left[0,2]; 	
				back[1,2] = left[1,2];	
				back[2,2] = left[2,2];	
				
				right[0,2] = back[0,2];		
				right[1,2] = back[1,2];	
				right[2,2] = back[2,2];	
								
				front[0,2] = right[0,2];	
				front[1,2] = right[1,2];	
				front[2,2] = right[2,2];	
				
				break;
			case 'u':
				//counter-clockwise rotation of UPPER face
				upper[0,0] = upper[0,2];
				upper[1,0] = upper[0,1];
				upper[2,0] = upper[0,0];
				upper[0,1] = upper[1,2];
				//upper[1,1] = upper[1,1]; //CENTER
				upper[2,1] = upper[1,0];
				upper[0,2] = upper[2,2];
				upper[1,2] = upper[2,1];
				upper[2,2] = upper[2,0];
				
				//UPPER CCW side rotations
				left[0,2] = back[0,2];
				left[1,2] = back[1,2];
				left[2,2] = back[2,2];
			
				front[0,2] = left[0,2];
				front[1,2] = left[1,2];
				front[2,2] = left[2,2];
				
				right[0,2] = front[0,2];
				right[1,2] = front[1,2];
				right[2,2] = front[2,2];
							
				back[0,2] = right[0,2];
				back[1,2] = right[1,2];
				back[2,2] = right[2,2];
				
				break;
				
			case 'D':
				//clockwise rotation of DOWN (bottom) face
				//UPPER unaffected
				down[0,0] = down[2,0];
				down[1,0] = down[2,1];
				down[2,0] = down[2,2];
				down[0,1] = down[1,0];
				//down[1,1] = down[1,1]; CENTER
				down[2,1] = down[1,2];
				down[0,2] = down[0,0];
				down[1,2] = down[0,1];
				down[2,2] = down[0,2];
				
				//DOWN CW side rotations
				left[0,0] = front[0,0];		
				left[1,0] = front[1,0];	
				left[2,0] = front[2,0];	
			
				back[0,0] = left[0,0]; 	
				back[1,0] = left[1,0];	
				back[2,0] = left[2,0];	
				
				right[0,0] = back[0,0];		
				right[1,0] = back[1,0];	
				right[2,0] = back[2,0];	
								
				front[0,0] = right[0,0];	
				front[1,0] = right[1,0];	
				front[2,0] = right[2,0];
				
				break;
				
			case 'd':
				//counter-clockwise rotation of DOWN (bottom) face
				down[0,0] = down[0,2];
				down[1,0] = down[0,1];
				down[2,0] = down[0,0];
				down[0,1] = down[1,2];
				//down[1,1] = down[1,1]; //CENTER
				down[2,1] = down[1,0];
				down[0,2] = down[2,2];
				down[1,2] = down[2,1];
				down[2,2] = down[2,0];

				//DOWN CCW side rotations
				left[0,0] = back[0,0];
				left[1,0] = back[1,0];
				left[2,0] = back[2,0];
			
				front[0,0] = left[0,0];
				front[1,0] = left[1,0];
				front[2,0] = left[2,0];
				
				right[0,0] = front[0,0];
				right[1,0] = front[1,0];
				right[2,0] = front[2,0];
								
				back[0,0] = right[0,0];
				back[1,0] = right[1,0];
				back[2,0] = right[2,0];
				
				break;
			}//switch

		}	//main
	}		//class
}			//namespace