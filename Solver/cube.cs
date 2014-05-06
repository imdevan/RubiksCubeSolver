//http://www.codeproject.com/Articles/34362/Rubik-s-Cube-in-a-C-Console-Program

class Face{
Cubie[,] cubies=new Cubie[3,3];
}

class Position{
	sbyte a1, a2, a3;
}

/*
The Position has 3 numbers: a1, a2, a3. where a1<=a2<=a3. If a1==a2==a3, then the cubie is in the center. If a1==a2<a3, then the cubie is on the Edge. If a1<a2<a3, then the cubie is on the corner. So, we can further implement the rotation of a Cubie:
*/
class CubeColor{
	sbyte color, neighbor1, neighbor3;
}
class Cube{
	CubiePosition position;
	CubieColor color;
}
class FaceList{
	List<cubie> cubies;
}

class edge{	//12 edge cubes
	int color1;
	int color2;
	
	public void GetEdge(){
		Console.WriteLine("<" + color1 + "," + color2 + ">");
	}
}

/*
	edge edge0 = new edge();
		edge0.color1 = ; 
		edge0.color2 = ;
	edge edge1 = new edge();
		edge1.color1 = ; 
		edge1.color2 = ;
	edge edge2 = new edge();
		edge2.color1 = ; 
		edge2.color2 = ;
	edge edge3 = new edge();
		edge3.color1 = ; 
		edge3.color2 = ;
	edge edge4 = new edge();
		edge4.color1 = ; 
		edge4.color2 = ;
	edge edge5 = new edge();
		edge5.color1 = ; 
		edge5.color2 = ;
	edge edge6 = new edge();
		edge6.color1 = ; 
		edge6.color2 = ;
	edge edge7 = new edge();
		edge7.color1 = ; 
		edge7.color2 = ;
	edge edge8 = new edge();
		edge8.color1 = ; 
		edge8.color2 = ;
	edge edge9 = new edge();
		edge9.color1 = ; 
		edge9.color2 = ;
	edge edge10 = new edge();
		edge10.color1 = ; 
		edge10.color2 = ;
	edge edge11 = new edge();
		edge11.color1 = ; 
		edge11.color2 = ;

*/
public class Pair{
	public Pair(){
	}
	
	public Pair(int first, int second){
		this.First = first;
		this.Second = second;
	}
	
	public int First  { get; set;}
	public int Second { get; set; }

};
class corner{	//8 corner cubes
	int color1;
	int color2;
	int color3;
	
	public void GetEdge(){
		Console.WriteLine("<" + color1 + "," + color2 + "," + color3 + ">");
	}

}
/*
	corner corner0 = new corner();		//top left corner
		corner0.color1 = upper[0,0]; 	
		corner0.color2 = back[0,2];
		corner0.color3 = left[0,0];		if(corner0 != )
	corner corner1 = new corner();		//top right corner
		corner1.color1 = upper[0,2]; 	
		corner1.color2 = back[0,0];
		corner1.color3 = right[0,2];
	corner corner2 = new corner();		//bottom left corner
		corner2.color1 = upper[2,0]; 	
		corner2.color2 = front[0,0];
		corner2.color3 = left[,];
	corner corner3 = new corner();		//bottom right corner
		corner3.color1 = upper[2,2]; 	
		corner3.color2 = front[0,2];
		corner3.color3 = right[,];
	corner corner4 = new corner();		//top left corner
		corner4.color1 = down[0,0]; 	
		corner4.color2 = front[2,0];
		corner4.color3 = left[,];
	corner corner5 = new corner();		//top right corner
		corner5.color1 = down[0,2]; 		
		corner5.color2 = front[2,2];
		corner5.color3 = right[,];
	corner corner6 = new corner();		//bottom left corner
		corner6.color1 = down[2,0]; 		
		corner6.color2 = back[2,2];
		corner6.color3 = left[,];
	corner corner7 = new corner();		//bottom right corner
		corner7.color1 = down[2,2]; 
		corner7.color2 = back[2,0];
		corner7.color3 = right[,];

*/

while(phase == 1){
for(int i = 0; i++; i<3){
	for(int j = 0; j++; j<3){
		if (front[i,j] != 3)
	
	
	}	
}
}
if(front[1,0] != 3){
		
	}
int checkAdjacent(int fi, int yi, int xi){
	switch(fi)
	{
		case 1:
			// upper
			if()
			break;
		case 2:
			// left
			break;
		case 3:
			// front
			break;
		case 4:
			// right
			break;
		case 5:
			// back
			break;
		case 6:
			// bottom
			break;
		default:
			// default
			cout << "Bad Face index sent to checkAdjacent()";
			break;
	}
			
			
}
public int [] cubeToSolveOnFace ( int searchColor, int searchColorAdjacent){	//edge piece

	// Returns [face, yindex, xindex]
	int [3] returnIndex[]; 

	for(int i = 0; i++; i<3){
		for(int j = 0; j++; j<3){
			if(upper[i,j] == searchColor){
				if(checkAdjacent(1, i, j) == searchColorAdjacent){ 
					returnIndex[0] = 1;
					returnIndex[1] = i;
					returnIndex[2] = j;
				}
				return returnIndex;
			}
			if(left[i,j] == searchColor){
			
			]
			
			if(front[i,j] == searchColor)
			if(right[i,j] == searchColor)
			if(back[i,j] == searchColor)
			if(bottom[i,j] == searchColor)
		}	
	}
}

while(phase == 1){
	if(upper[1,0] != 3){
		Pair cubeTosolveOnFace = searchCube(3,2) // search cube for whit and blue edge piece
		solve(cubeTosolve);
	}	
	
	if(front[2,1] != 3){
	
	
	}	
	
	if(front[1,2] != 3){
	
	
	}	
	
	if(front[0,1] != 3){
	
	
	}	
}









