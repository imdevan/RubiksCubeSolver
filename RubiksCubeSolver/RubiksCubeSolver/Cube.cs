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
     * http://www.codeproject.com/Articles/34362/Rubik-s-Cube-in-a-C-Console-Program
     * *********************************************************************************************************************************************/

namespace RubiksCubeSolver
{

    /* Face Layout
    /**********************************************************************************************************************************************/

    // Specify the Surrounding neighbors of each Face.
    // This is the description of 2D layout of a Cube.
    class FaceLayout2D
    {
        public sbyte self, right, up, left, down;
        public FaceLayout2D(sbyte s, sbyte r, sbyte u, sbyte l, sbyte d)
        {
            self = s; 
            right = r;
            up = u;
            left = l;
            down = d;
        }
        
        public static Dictionary<sbyte, FaceLayout2D> layout = new Dictionary<sbyte, FaceLayout2D>();
        static FaceLayout2D() {
            
        }
    }


    class CubiePosition
    {
        /*
         * for Position:
         * 1. When a1 = a2 = a3, the cubie is center
         * 2. when a1 == a2 < a3, the cubie is no an edge
         * 3. when a1<a2<a3, the cubie is on a corner
         */
        public sbyte a1, a2, a3;

        public CubiePosition(sbyte b1, sbyte b2, sbyte b3)
        {
            a1 = b1; 
            a2 = b2;
            a3 = b3;
            AdjustOrder();
        }

        private void AdjustOrder(){
            // a1 <= a2 <= a3
            sbyte b1 = a1;
            sbyte b2 = a2;
            sbyte b3 = a3;
            a1 = Math.Min(b1, Math.Min(b2,b3));
            a3 = Math.Max(b1, Math.Max(b2,b3));
            a2 = (sbyte)(b1 + b2 + b3 - a1 - a3); // middle
            if(a2 == a3)
            {
                // only keep the smaller
                a2 = a1;
            }
        }

        public override string ToString(){
            return String.Format("{0}, {1}, {2})", a1, a2, a3);
        }
        public CubiePosition Clone() 
        {
            return new CubiePosition(a1, a2, a3);
        }

        public int CompareTo(CubiePosition p){
            if(p.a1 != a1){
                return a1 - p.a1;
            }
            if(p.a2 != a2){
                return a2 - p.a2;
            }
            return a3 - p.a3;
        }

        public bool IsCenter(){
            return a1 == a2 && a2 == a3;
        }

        public bool IsEdge(){
            return (a1 == a2 || a2 == a3 );
        }
        
        public bool IsCorner(){
            return a1 < a2 && a2 < a3;
        }

        public void RatateFrontClockwise90Degrees(){
            //a1 = Face.RotateFrontClockwise90Degree(a1);
            //a2 = Face.RotateFrontClockwise90Degree(a2);
            //a3 = Face.RotateFrontClockwise90Degree(a3);
        } 

        public void MapFrontFrom(sbyte side)
        {

        }

    }

    /* Rubiks Cube Object Definitions
    /**********************************************************************************************************************************************/
    class Face
    {
        /*
         * A cube has six faces
         * 0 F = front face
         * 1 R = right face
         * 2 U = up face
         * 3 L = left face
         * 4 D = down face
         * 5 B = back face
         * */
        public const sbyte Front = 0;
        public const sbyte Right = 1;
        public const sbyte Up = 2;
        public const sbyte Left = 3;
        public const sbyte Down = 4;
        public const sbyte Back = 5;

        public static readonly Dictionary<int, string> FaceNames = new Dictionary<int,string>(); // { "Front", "Right", "Up", "Left", "Down", "Back" };

    }
}
