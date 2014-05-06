

public void movement(string move){
	switch (move){
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
							front[0,0] = front0[2,0];	front[0,1] = front0[1,0];	front[0,2] = front0[0,0];
							front[1,0] = front0[2,1];	front[1,1] = front0[1,1];	front[1,2] = front0[0,1];
							front[2,0] = front0[2,2];	front[2,1] = front0[1,2];	front[2,2] = front0[0,2];
				
						//FRONT CW side rotations
							upper[2,0] = left0[2,2];	upper[2,1] = left0[1,2];	upper[2,2] = left0[0,2];	
							right[0,0] = upper0[2,0];	right[1,0] = upper0[2,1];	right[2,0] = upper0[2,2];	
							down[0,0] = right0[2,0];	down[0,1] = right0[1,0];	down[0,2] = right0[0,0];	
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
							upper[0,0] = back0[2,2];	upper[1,0] = back0[1,2];	upper[2,0] = back0[0,2];
							front[0,0] = upper0[0,0];	front[1,0] = upper0[1,0];	front[2,0] = upper0[2,0];	
							down[0,0] = front0[0,0];	down[1,0] = front0[1,0];	down[2,0] = front0[2,0];	
							back[0,2] = down0[2,0];		back[1,2] = down0[1,0];		back[2,2] = down0[0,0];	
						break;
						
						case "l":
						case "5":
						//CCW rotation of LEFT face
							left[0,0] = left0[0,2];		left[0,1] = left0[1,2];		left[0,2] = left0[2,2];
							left[1,0] = left0[0,1];		left[1,1] = left0[1,1];		left[1,2] = left0[2,1];
							left[2,0] = left0[0,0];		left[2,1] = left0[1,0];		left[2,2] = left0[2,0];
				
						//LEFT CCW side rotations
							upper[0,0] = front0[0,0];	upper[1,0] = front0[1,0];	upper[2,0] = front0[2,0];
							back[0,2] = upper0[2,0];	back[1,2] = upper0[1,0];	back[2,2] = upper0[0,0];
							down[0,0] = back0[2,2];		down[1,0] = back0[1,2];		down[2,0] = back0[0,2];
							front[0,0] = down0[0,0];	front[1,0] = down0[1,0];	front[2,0] = down0[2,0];
						break;
				
						case "R":
						case "6":
						//clockwise rotation of RIGHT face
						//LEFT unaffected
							right[0,0] = right0[2,0];	right[0,1] = right0[1,0];	right[0,2] = right0[0,0];
							right[1,0] = right0[2,1];	right[1,1] = right0[1,1];	right[1,2] = right0[0,1];
							right[2,0] = right0[2,2];	right[2,1] = right0[1,2];	right[2,2] = right0[0,2];
				
						//RIGHT CW side rotations
							upper[0,2] = front0[0,2]; 	upper[1,2] = front0[1,2];	upper[2,2] = front0[2,2];	
							back[0,0] = upper0[2,2];	back[1,0] = upper0[1,2];	back[2,0] = upper0[0,2];	
							down[0,2] = back0[2,0];		down[1,2] = back0[1,0];		down[2,2] = back0[0,0];
							front[0,2] = down0[0,2];	front[1,2] = down0[1,2];	front[2,2] = down0[2,2];	
						break;
						
						case "r":
						case "7":
						//counter-clockwise rotation of RIGHT face
							right[0,0] = right0[0,2];	right[0,1] = right0[1,2];	right[0,2] = right0[2,2];
							right[1,0] = right0[0,1];	right[1,1] = right0[1,1];	right[1,2] = right0[2,1];
							right[2,0] = right0[0,0];	right[2,1] = right0[1,0];	right[2,2] = right0[2,0];
				
						//RIGHT CCW side rotations
							upper[0,2] = back0[2,0];	upper[1,2] = back0[1,0];	upper[2,2] = back0[0,0];
							front[0,2] = upper0[0,2];	front[1,2] = upper0[1,2];	front[2,2] = upper0[2,2];
							down[0,2] = front0[0,2];	down[1,2] = front0[1,2];	down[2,2] = front0[2,2];
							back[0,0] = down0[2,2];		back[1,0] = down0[1,2];		back[2,0] = down0[0,2];
						break;
			
						case "U":
						case "8":
						//clockwise rotation of UPPER face
						//DOWN unaffected
							upper[0,0] = upper0[2,0];	upper[0,1] = upper0[1,0];	upper[0,2] = upper0[0,0];
							upper[1,0] = upper0[2,1];	upper[1,1] = upper0[1,1];	upper[1,2] = upper0[0,1];
							upper[2,0] = upper0[2,2];	upper[2,1] = upper0[1,2];	upper[2,2] = upper0[0,2];
				
						//UPPER CW side rotations
							back[0,0] = left0[0,0]; 	back[0,1] = left0[0,1];		back[0,2] = left0[0,2];	
							right[0,0] = back0[0,0];	right[0,1] = back0[0,1];	right[0,2] = back0[0,2];
							front[0,0] = right0[0,0];	front[0,1] = right0[0,1];	front[0,2] = right0[0,2];
							left[0,0] = front0[0,0];	left[0,1] = front0[0,1];	left[0,2] = front0[0,2];	
						break;
						
						case "u":
						case "9":
						//counter-clockwise rotation of UPPER face
							upper[0,0] = upper0[0,2];	upper[0,1] = upper0[1,2];	upper[0,2] = upper0[2,2];
							upper[1,0] = upper0[0,1];	upper[1,1] = upper0[1,1];	upper[1,2] = upper0[2,1];
							upper[2,0] = upper0[0,0];	upper[2,1] = upper0[1,0];	upper[2,2] = upper0[2,0];
				
						//UPPER CCW side rotations
							back[0,0] = right0[0,0];	back[0,1] = right0[0,1];	back[0,2] = right0[0,2];
							left[0,0] = back0[0,0];		left[0,1] = back0[0,1];		left[0,2] = back0[0,2];
							front[0,0] = left0[0,0];	front[0,1] = left0[0,1];	front[0,2] = left0[0,2];
							right[0,0] = front0[0,0];	right[0,1] = front0[0,1];	right[0,2] = front0[0,2];
						break;
				
						case "D":
						case "10":
						//clockwise rotation of DOWN (bottom) face
						//UPPER unaffected
							down[0,0] = down0[2,0];		down[0,1] = down0[1,0];		down[0,2] = down0[0,0];
							down[1,0] = down0[2,1];		down[1,1] = down0[1,1];		down[1,2] = down0[0,1];
							down[2,0] = down0[2,2];		down[2,1] = down0[1,2];		down[2,2] = down0[0,2];
				
						//DOWN CW side rotations
							front[2,0] = left0[2,0];	front[2,1] = left0[2,1];	front[2,2] = left0[2,2];
							right[2,0] = front0[2,0];	right[2,1] = front0[2,1];	right[2,2] = front0[2,2];
							back[2,0] = right0[2,0];	back[2,1] = right0[2,1];	back[2,2] = right0[2,2];
							left[2,0] = back0[2,0];		left[2,1] = back0[2,1];		left[2,2] = back0[2,2];
						break;
				
						case "d":
						case "11":
						//counter-clockwise rotation of DOWN (bottom) face
							down[0,0] = down0[0,2];		down[0,1] = down0[1,2];		down[0,2] = down0[2,2];
							down[1,0] = down0[0,1];		down[1,1] = down0[1,1];		down[1,2] = down0[2,1];
							down[2,0] = down0[0,0];		down[2,1] = down0[1,0];		down[2,2] = down0[2,0];

						//DOWN CCW side rotations
							front[2,0] = right0[2,0];	front[2,1] = right0[2,1];	front[2,2] = right0[2,2];
							right[2,0] = back0[2,0];	right[2,1] = back0[2,1];	right[2,2] = back0[2,2];
							back[2,0] = left0[2,0]; 	back[2,1] = left0[2,1];		back[2,2] = left0[2,2];	
							left[2,0] = front0[2,0];	left[2,1] = front0[2,1];	left[2,2] = front0[2,2];	
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

static int findColor(int[,] arr, int value)
{
    for (int i = 0; i < arr.Length; i++)
    {
		if (arr[i] == value)
	{
	    return i;
	}
    }
		return -1;
}	//int index = findColor(_array, 7);

if(front[0,1] != 3 && front[1,0] != 3 && front[1,1] != 3 && front[1,2] != 3 && front[2,1] != 3){


}

//PHASE I ALGO
while(front[0,1] != 3 && front[1,0] != 3 && front[1,1] != 3 && front[1,2] != 3 && front[2,1]){
	phase = (int)Phase.first;
	
	while(front[1,0] !=  3 && left[,] != 2){
	if(front[1,0] !=  3 && left[,] != 2){	//SOLVE BLUE (LEFT)
	
	
	
	
	}/*else if(left[1,0] ==  2){
	
	}*/
	}
	
	if(front[2,1] != 3 && down[,] != 6){	//SOLVE ORANGE (DOWN)
	
	
	}/*else if(down[2,1] == 6){
	
	
	}*/
	
	if(front[1,2] != 3 && right[,] != 4){	//SOLVE GREEN (RIGHT)
	
	
	}/*else if(right[1,2] == 4){
	
	
	}*/
	
	if(front[0,1] != 3 && upper[,] != 1){	//SOLVE RED (UPPER)
	
	
	}/*else if(upper[0,1] == 1){
	
	
	}*/
	
	if(){	//SOLVE ???
	
	
	}else if(){
	
	
	}





}
