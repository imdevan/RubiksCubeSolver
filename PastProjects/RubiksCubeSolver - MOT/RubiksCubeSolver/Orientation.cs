using System;
using System.Collections.Generic;
using System.Text;

namespace RubiksCubeSolver
{
   ///<summary>
    /*  --------OBJECTIVE OF ORIENTATION:
     *  Associates squares of cube with elements of a three-dimensional array.
     *  Array: cubeArray[face number, x position, y position]
     * 
     *  --------FACES:
     * (default colors:)
     *  1. Red
     *  2. Green
     *  3. White
     *  4. Blue
     *  5. Orange
     *  6. Yellow
     * 
     *  --------VARIABLES:
     *  currentFace: face user sees in front.
     *  x: x position on cube.
     *  y: y position on cube.
     *                                        x1   x2   x3 
     *                                      .--------------.
     *                                      |    |    |    | y1
     *                                      |--------------|
     *                                      |    | 2! |    | y2
     *                                      |--------------|
     *                         x1   x2   x3 |    |    |    | y3
     *  ,--------------.     ,--------------.--------------.--------------.--------------.
     *  | r1---------> |  y1 |    |    |    |    |    |    |    |    |    |    |    |    |
     *  |--------------|     |--------------|--------------|--------------|--------------|
     *  |    |  ^ |    |  y2 |    | 1! |    |    | 3! |    |    | 5! |    |    | 6! |    |
     *  |-------|------|     |--------------|--------------|--------------|--------------|
     *  |    | c2 |    |  y3 |    |    |    |    |    |    |    |    |    |    |    |    |
     *  `--------------'     `--------------'--------------'--------------'--------------'
     *                                      |    |    |    |
     *                                      |--------------|
     *                                      |    | 4! |    |
     *                                      |--------------|
     *                                      |    |    |    |
     *                                      '--------------'
     */
    /// </summary>

    public class Orientation
    {
        public String[,,] cubeArray;

        public override String ToString()
        {
            String result = "";
            for (int f = 1; f <= 6; f++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    for (int y = 1; y <= 3; y++)
                    {
                        result += cubeArray[f, x, y];
                    }
                }
            }
            return result;
        }

        public Orientation()
        {
            // String[face number, x value, y value]
            String[] colorArray = new String[7];
            colorArray[0] = "";
            colorArray[1] = "red";
            colorArray[2] = "green";
            colorArray[3] = "white";
            colorArray[4] = "blue";
            colorArray[5] = "orange";
            colorArray[6] = "yellow";
            int z = 1;
            cubeArray = new String[7, 4, 4];
            for (int f = 1; f <= 6; f++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    for (int y = 1; y <= 3; y++)
                    {
                        this.setColor(colorArray[z], f, x, y);
                    }
                }
                z += 1;
            }
        }

        public Orientation(Orientation oldCube)
        {
            // String[face number, x value, y value]
            cubeArray = new String[7, 4, 4];
            for (int f = 1; f <= 6; f++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    for (int y = 1; y <= 3; y++)
                    {
                        cubeArray[f, x, y] = oldCube.getColor(f, x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Sets color to a specific face.
        /// </summary>
        /// <param name="color">String of color passed in.</param>
        /// <param name="f">Face number.</param>
        /// <param name="x">x position coordinate.</param>
        /// <param name="y">y position coordinate.</param>
        /// <remarks>(For testing purposes, only).</remarks>
        public void setColor(String color, int f, int x, int y)
        {
            cubeArray[f,x,y] = color;
        }

        /// <summary>
        /// Returns a string representation of the color of the face indicated.
        /// </summary>
        /// <param name="f">Face number.</param>
        /// <param name="x">x position coordinate.</param>
        /// <param name="y">y position coordinate.</param>
        /// <returns>Color of the face indicated.</returns>
        public String getColor(int f, int x, int y)
        {
            String theColor = "";
            theColor = cubeArray[f, x, y];
            return theColor;
        }

        /// <summary>
        /// Returns color of the face indicated.
        /// </summary>
        /// <param name="num">number of face desired.</param>
        /// <returns>Color of face indicated.</returns>
        public String getFaceColor(int num)
        {
            return getColor(num, 2, 2);
        }

        /// <summary>
        /// Returns number of the color face indicated.
        /// </summary>
        /// <param name="num">number of face desired.</param>
        /// <returns>Number of face indicated.</returns>
        public int getFaceNum(String face)
        {
            int faceNum = 0;
            for (int f = 1; f <= 6; f++)
            {
                if (cubeArray[f, 2, 2].Equals(face))
                {
                    faceNum = f;
                }
            }
            return faceNum;
        }

        /// <summary>
        /// Checks if indicated square matches indicated color.
        /// </summary>
        /// <param name="color">Color to check for.</param>
        /// <param name="f">Face number.</param>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// <returns>True if color is what is expected, False if not.</returns>
        public bool isColor(String color, int f, int x, int y)
        {
            return (cubeArray[f, x, y].Equals(color));
        }

        /// <summary>
        /// Checks if indicated block is in fact, an edge block (as opposed to center or corner).
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// <returns>True if block is edge, False if not.</returns>
        public bool isEdge(int x, int y)
        {
            if ((x == 2) || (y == 2))
            {
                if (!((x == 2) && (y == 2)))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if indicated block is in fact, a corner block (as opposed to center or edge).
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// <returns>True if block is edge, False if not.</returns>
        public bool isCorner(int x, int y)
        {
            if (!(isEdge(x, y)))
            {
                if (!((x == 2) && (y == 2)))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns face, x and y values of the edge's other side.
        /// </summary>
        /// <param name="f">Face number</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>ArrayList [0] = face#, [1] = x, [2] = y.</returns>
        public int[] getOppositeEdge(int f, int x, int y)
        {
            int[] opp = new int[3];
            if (f == 1)
            {
                if (x == 2) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 2;
                        opp[1] = 1;
                        opp[2] = 2;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 4;
                        opp[1] = 1;
                        opp[2] = 2;
                    }
                }
                else if (y == 2) //left or right
                {
                    if (x == 1) // left
                    {
                        opp[0] = 6;
                        opp[1] = 3;
                        opp[2] = 2;
                    }
                    else if (x == 3) // right
                    {
                        opp[0] = 3;
                        opp[1] = 1;
                        opp[2] = 2;
                    }
                }
            }
            else if (f == 2)
            {
                if (x == 2) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 6;
                        opp[1] = 2;
                        opp[2] = 1;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 3;
                        opp[1] = 2;
                        opp[2] = 1;
                    }
                }
                else if (y == 2) //left or right
                {
                    if (x == 1) // left
                    {
                        opp[0] = 1;
                        opp[1] = 2;
                        opp[2] = 1;
                    }
                    else if (x == 3) // right
                    {
                        opp[0] = 5;
                        opp[1] = 2;
                        opp[2] = 1;
                    }
                }
            }
            else if (f == 3)
            {
                if (x == 2) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 2;
                        opp[1] = 2;
                        opp[2] = 3;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 4;
                        opp[1] = 2;
                        opp[2] = 1;
                    }
                }
                else if (y == 2) //left or right
                {
                    if (x == 1) // left
                    {
                        opp[0] = 1;
                        opp[1] = 3;
                        opp[2] = 2;
                    }
                    else if (x == 3) // right
                    {
                        opp[0] = 5;
                        opp[1] = 1;
                        opp[2] = 2;
                    }
                }
            }
            else if (f == 4)
            {
                if (x == 2) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 3;
                        opp[1] = 2;
                        opp[2] = 3;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 6;
                        opp[1] = 2;
                        opp[2] = 3;
                    }
                }
                else if (y == 2) //left or right
                {
                    if (x == 1) // left
                    {
                        opp[0] = 1;
                        opp[1] = 2;
                        opp[2] = 3;
                    }
                    else if (x == 3) // right
                    {
                        opp[0] = 5;
                        opp[1] = 2;
                        opp[2] = 3;
                    }
                }
            }
            else if (f == 5)
            {
                if (x == 2) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 2;
                        opp[1] = 3;
                        opp[2] = 2;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 4;
                        opp[1] = 3;
                        opp[2] = 2;
                    }
                }
                else if (y == 2) //left or right
                {
                    if (x == 1) // left
                    {
                        opp[0] = 3;
                        opp[1] = 3;
                        opp[2] = 2;
                    }
                    else if (x == 3) // right
                    {
                        opp[0] = 6;
                        opp[1] = 1;
                        opp[2] = 2;
                    }
                }
            }
            else if (f == 6)
            {
                if (x == 2) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 2;
                        opp[1] = 2;
                        opp[2] = 1;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 4;
                        opp[1] = 2;
                        opp[2] = 3;
                    }
                }
                else if (y == 2) //left or right
                {
                    if (x == 1) // left
                    {
                        opp[0] = 5;
                        opp[1] = 3;
                        opp[2] = 2;
                    }
                    else if (x == 3) // right
                    {
                        opp[0] = 1;
                        opp[1] = 1;
                        opp[2] = 2;
                    }
                }
            }
            return opp;
        }

        /// <summary>
        /// Returns face, x and y values of the corner's other sides in clockwise order.
        /// </summary>
        /// <param name="f">Face number</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>ArrayList [0] = face#, [1] = x, [2] = y.
        ///                     3 = face2, 4 = x2, 5 = y2.</returns>
        public int[] getOppositeCorners(int f, int x, int y)
        {
            int[] opp = new int[6];
            if (f == 1)
            {
                if (x == 1) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 6;
                        opp[1] = 3;
                        opp[2] = 1;
                        opp[3] = 2;
                        opp[4] = 1;
                        opp[5] = 1;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 4;
                        opp[1] = 1;
                        opp[2] = 3;
                        opp[3] = 6;
                        opp[4] = 3;
                        opp[5] = 3;
                    }
                }
                else if (x == 3) //up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 2;
                        opp[1] = 1;
                        opp[2] = 3;
                        opp[3] = 3;
                        opp[4] = 1;
                        opp[5] = 1;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 3;
                        opp[1] = 1;
                        opp[2] = 3;
                        opp[3] = 4;
                        opp[4] = 1;
                        opp[5] = 1;
                    }
                }
            }
            else if (f == 2)
            {
                if (x == 1) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 1;
                        opp[1] = 1;
                        opp[2] = 1;
                        opp[3] = 6;
                        opp[4] = 3;
                        opp[5] = 1;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 3;
                        opp[1] = 1;
                        opp[2] = 1;
                        opp[3] = 1;
                        opp[4] = 3;
                        opp[5] = 1;
                    }
                }
                else if (x == 3) //left or right
                {
                    if (y == 1) // left
                    {
                        opp[0] = 6;
                        opp[1] = 1;
                        opp[2] = 1;
                        opp[3] = 5;
                        opp[4] = 3;
                        opp[5] = 1;
                    }
                    else if (y == 3) // right
                    {
                        opp[0] = 5;
                        opp[1] = 1;
                        opp[2] = 1;
                        opp[3] = 3;
                        opp[4] = 3;
                        opp[5] = 1;
                    }
                }
            }
            else if (f == 3)
            {
                if (x == 1) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 1;
                        opp[1] = 3;
                        opp[2] = 1;
                        opp[3] = 2;
                        opp[4] = 1;
                        opp[5] = 3;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 4;
                        opp[1] = 1;
                        opp[2] = 1;
                        opp[3] = 1;
                        opp[4] = 3;
                        opp[5] = 3;
                    }
                }
                else if (x == 3) //left or right
                {
                    if (y == 1) // left
                    {
                        opp[0] = 2;
                        opp[1] = 3;
                        opp[2] = 3;
                        opp[3] = 5;
                        opp[4] = 1;
                        opp[5] = 1;
                    }
                    else if (y == 3) // right
                    {
                        opp[0] = 5;
                        opp[1] = 1;
                        opp[2] = 3;
                        opp[3] = 4;
                        opp[4] = 3;
                        opp[5] = 1;
                    }
                }
            }
            else if (f == 4)
            {
                if (x == 1) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 1;
                        opp[1] = 3;
                        opp[2] = 3;
                        opp[3] = 3;
                        opp[4] = 1;
                        opp[5] = 3;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 6;
                        opp[1] = 3;
                        opp[2] = 3;
                        opp[3] = 1;
                        opp[4] = 1;
                        opp[5] = 3;
                    }
                }
                else if (x == 3) //left or right
                {
                    if (y == 1) // left
                    {
                        opp[0] = 3;
                        opp[1] = 3;
                        opp[2] = 3;
                        opp[3] = 5;
                        opp[4] = 1;
                        opp[5] = 3;
                    }
                    else if (y == 3) // right
                    {
                        opp[0] = 5;
                        opp[1] = 3;
                        opp[2] = 3;
                        opp[3] = 6;
                        opp[4] = 1;
                        opp[5] = 3;
                    }
                }
            }
            else if (f == 5)
            {
                if (x == 1) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 3;
                        opp[1] = 3;
                        opp[2] = 1;
                        opp[3] = 2;
                        opp[4] = 3;
                        opp[5] = 3;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 4;
                        opp[1] = 3;
                        opp[2] = 1;
                        opp[3] = 3;
                        opp[4] = 3;
                        opp[5] = 3;
                    }
                }
                else if (x == 3) //left or right
                {
                    if (y == 1) // left
                    {
                        opp[0] = 2;
                        opp[1] = 3;
                        opp[2] = 1;
                        opp[3] = 6;
                        opp[4] = 1;
                        opp[5] = 1;
                    }
                    else if (y == 3) // right
                    {
                        opp[0] = 6;
                        opp[1] = 1;
                        opp[2] = 3;
                        opp[3] = 4;
                        opp[4] = 3;
                        opp[5] = 3;
                    }
                }
            }
            else if (f == 6)
            {
                if (x == 1) // up or down
                {
                    if (y == 1) // up
                    {
                        opp[0] = 5;
                        opp[1] = 3;
                        opp[2] = 1;
                        opp[3] = 2;
                        opp[4] = 3;
                        opp[5] = 1;
                    }
                    else if (y == 3) // down
                    {
                        opp[0] = 4;
                        opp[1] = 3;
                        opp[2] = 3;
                        opp[3] = 5;
                        opp[4] = 3;
                        opp[5] = 3;
                    }
                }
                else if (x == 3) //left or right
                {
                    if (y == 1) // left
                    {
                        opp[0] = 2;
                        opp[1] = 1;
                        opp[2] = 1;
                        opp[3] = 1;
                        opp[4] = 1;
                        opp[5] = 1;
                    }
                    else if (y == 3) // right
                    {
                        opp[0] = 1;
                        opp[1] = 1;
                        opp[2] = 3;
                        opp[3] = 4;
                        opp[4] = 1;
                        opp[5] = 3;
                    }
                }
            }
            return opp;
        }

        /// <summary>
        /// Returns an int array (element 0 = face, 1 = x position, 2 = y position) of the specified
        ///     edge piece.
        /// </summary>
        /// <param name="color1">Color one specified.</param>
        /// <param name="color2">Color two specified.</param>
        /// <returns>Returns an int array (element 0 = current face num, 1 = x position, 2 = y position)
        ///             (element 3 = current face2 num, 4 = x2, 5 = y2)</returns>
        public int[] findEdge(String color1, String color2)
        {
            int[] theArray = new int[6];
            for (int f = 1; f <= 6; f++)
            {
                for (int y = 1; y <= 3; y++)
                {
                    for (int x = 1; x <= 3; x++)
                    {
                        if ((getColor(f, x, y).Equals(color1)) && isEdge(x, y))
                        {
                            int oppFace = getOppositeEdge(f, x, y)[0];
                            int oppX = getOppositeEdge(f, x, y)[1];
                            int oppY = getOppositeEdge(f, x, y)[2];

                            if (getColor(oppFace, oppX, oppY).Equals(color2))
                            {
                                theArray[0] = f;
                                theArray[1] = x;
                                theArray[2] = y;
                                theArray[3] = oppFace;
                                theArray[4] = oppX;
                                theArray[5] = oppY;
                            }
                        }
                    }
                }
            }
            return theArray;
        }

        /// <summary>
        /// Returns an int array (element 0 = face, 1 = x position, 2 = y position) of the specified
        ///     corner piece.
        /// </summary>
        /// <param name="color1">Color one specified.</param>
        /// <param name="color2">Color two specified.</param>
        /// <param name="color3">Color three specified.</param>
        /// <returns>Returns an int array CLOCKWISE (element 0 = current face num, 1 = x position, 2 = y position)
        ///             (element 3 = current face2 num, 4 = x2, 5 = y2)
        ///             (element 6 = current face3 num, 7 = x3, 8 = y3)</returns>
        public int[] findCorner(String color1, String color2, String color3)
        {
            int[] theArray = new int[9];
            for (int f = 1; f <= 6; f++)
            {
                for (int y = 1; y <= 3; y++)
                {
                    for (int x = 1; x <= 3; x++)
                    {
                        if ((getColor(f, x, y).Equals(color1)) && isCorner(x, y))
                        {
                            int[] o = getOppositeCorners(f, x, y);
                            int oppFace1 = o[0];
                            int oppX1 = o[1];
                            int oppY1 = o[2];
                            int oppFace2 = o[3];
                            int oppX2 = o[4];
                            int oppY2 = o[5];

                            if (getColor(oppFace1, oppX1, oppY1).Equals(color2))
                            {
                                if (getColor(oppFace2, oppX2, oppY2).Equals(color3))
                                {
                                    theArray[0] = f;
                                    theArray[1] = x;
                                    theArray[2] = y;
                                    theArray[3] = oppFace1;
                                    theArray[4] = oppX1;
                                    theArray[5] = oppY1;
                                    theArray[6] = oppFace2;
                                    theArray[7] = oppX2;
                                    theArray[8] = oppY2;
                                }
                            }
                            else if (getColor(oppFace2, oppX2, oppY2).Equals(color2))
                            {
                                if (getColor(oppFace1, oppX1, oppY1).Equals(color3))
                                {
                                    theArray[0] = f;
                                    theArray[1] = x;
                                    theArray[2] = y;
                                    theArray[3] = oppFace2;
                                    theArray[4] = oppX2;
                                    theArray[5] = oppY2;
                                    theArray[6] = oppFace1;
                                    theArray[7] = oppX1;
                                    theArray[8] = oppY1;
                                }
                            }
                        }
                    }
                }
            }
            return theArray;
        }

        /// <summary>
        /// Returns an int value of specified piece, depending on which layer it is to be found.
        /// </summary>
        /// <param name="f">Face number.</param>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// <returns>What layer block is found.</returns>
        public int findLayer(int f, int x, int y)
        {
            if ((f == 3) || ((f == 1) && (x == 3)) || ((f == 2) && (y == 3)) || 
                ((f == 5) && (x == 1)) || ((f == 4) && (y == 1)))
            {
                return 1;
            }
            else if (((f == 1) && (x == 2)) || ((f == 2) && (y == 2)) || 
                ((f == 5) && (x == 2)) || ((f == 4) && (y == 2)))
            {
                return 2;
            }
            return 3;
        }

        /// <summary>
        /// Changes the face that is in front of the user.
        /// </summary>
        /// <param name="newFace">String of new color face desired.</param>
        public void changeFace(String newFace)
        {
            if (! cubeArray[3, 2, 2].Equals(newFace))
            {
                if (cubeArray[5, 2, 2].Equals(newFace))
                {
                    moveRow(1, "left");
                    moveRow(2, "left");
                    moveRow(3, "left");
                }
                else if (cubeArray[6, 2, 2].Equals(newFace))
                {
                    moveRow(1, "left");
                    moveRow(2, "left");
                    moveRow(3, "left");

                    moveRow(1, "left");
                    moveRow(2, "left");
                    moveRow(3, "left");
                }
                else if (cubeArray[1, 2, 2].Equals(newFace))
                {
                    moveRow(1, "right");
                    moveRow(2, "right");
                    moveRow(3, "right");
                }
                else if (cubeArray[2, 2, 2].Equals(newFace))
                {
                    moveCol(1, "down");
                    moveCol(2, "down");
                    moveCol(3, "down");
                }
                else if (cubeArray[4, 2, 2].Equals(newFace))
                {
                    moveCol(1, "up");
                    moveCol(2, "up");
                    moveCol(3, "up");
                }
            }
        }

        /// <summary>
        /// Overload, Changes the face that is in front of the user.
        /// </summary>
        /// <param name="newFace">Integer of face desired.</param>
        public void changeFace(int newFace)
        {
            if (!cubeArray[3, 2, 2].Equals(getColor(newFace, 2, 2)))
            {
                if (cubeArray[5, 2, 2].Equals(getColor(newFace, 2, 2)))
                {
                    moveRow(1, "left");
                    moveRow(2, "left");
                    moveRow(3, "left");
                }
                else if (cubeArray[6, 2, 2].Equals(getColor(newFace, 2, 2)))
                {
                    moveRow(1, "left");
                    moveRow(2, "left");
                    moveRow(3, "left");

                    moveRow(1, "left");
                    moveRow(2, "left");
                    moveRow(3, "left");
                }
                else if (cubeArray[1, 2, 2].Equals(getColor(newFace, 2, 2)))
                {
                    moveRow(1, "right");
                    moveRow(2, "right");
                    moveRow(3, "right");
                }
                else if (cubeArray[2, 2, 2].Equals(getColor(newFace, 2, 2)))
                {
                    moveCol(1, "down");
                    moveCol(2, "down");
                    moveCol(3, "down");
                }
                else if (cubeArray[4, 2, 2].Equals(getColor(newFace, 2, 2)))
                {
                    moveCol(1, "up");
                    moveCol(2, "up");
                    moveCol(3, "up");
                }
            }
        }

        /// <summary>
        /// Flips cube over.
        /// </summary>
        /// <remarks>(For use with solving the third layer).</remarks>
        public void flipCube()
        {
            moveCol(1, "down");
            moveCol(2, "down");
            moveCol(3, "down");

            moveCol(1, "down");
            moveCol(2, "down");
            moveCol(3, "down");
        }

        /// <summary>
        /// Rotates fore-face either clockwise or counter-clockwise.
        /// </summary>
        /// <param name="dir">Either "clockwise" or "counterclockwise"</param>
        public void rotateFace(String dir)
        {
            changeFace(getColor(1, 2, 2));
            if (dir.Equals("clockwise"))
            {
                moveCol(3, "up");
            }
            else
            {
                moveCol(3, "down");
            }
            changeFace(getColor(5, 2, 2));
        }

        /// <summary>
        /// Turns a specific row on the cube.
        /// </summary>
        /// <param name="row">Row number, either 1, 2, or 3.</param>
        /// <param name="direction">"left" or "right."</param>
        public void moveRow(int row, String direction)
        {
            //Save colors of facing row:
            String temp1 = cubeArray[3, 1, row];
            String temp2 = cubeArray[3, 2, row];
            String temp3 = cubeArray[3, 3, row];

            String temp4 = cubeArray[2, 1, 3];
            String temp5 = cubeArray[2, 1, 2];

            String temp6 = cubeArray[4, 1, 3];
            String temp7 = cubeArray[4, 1, 2];

            if (direction.Equals("left"))
            {
                cubeArray[3, 1, row] = cubeArray[5, 1, row];
                cubeArray[3, 2, row] = cubeArray[5, 2, row];
                cubeArray[3, 3, row] = cubeArray[5, 3, row];
                cubeArray[5, 1, row] = cubeArray[6, 1, row];
                cubeArray[5, 2, row] = cubeArray[6, 2, row];
                cubeArray[5, 3, row] = cubeArray[6, 3, row];
                cubeArray[6, 1, row] = cubeArray[1, 1, row];
                cubeArray[6, 2, row] = cubeArray[1, 2, row];
                cubeArray[6, 3, row] = cubeArray[1, 3, row];
                cubeArray[1, 1, row] = temp1;
                cubeArray[1, 2, row] = temp2;
                cubeArray[1, 3, row] = temp3;

                //TOP FACE (clockwise):
                if (row == 1)
                {
                    cubeArray[2, 1, 3] = cubeArray[2, 3, 3];
                    cubeArray[2, 3, 3] = cubeArray[2, 3, 1];
                    cubeArray[2, 3, 1] = cubeArray[2, 1, 1];
                    cubeArray[2, 1, 1] = temp4;
                    cubeArray[2, 1, 2] = cubeArray[2, 2, 3];
                    cubeArray[2, 2, 3] = cubeArray[2, 3, 2];
                    cubeArray[2, 3, 2] = cubeArray[2, 2, 1];
                    cubeArray[2, 2, 1] = temp5;
                }

                //BOTTOM FACE (counterclockwise):
                if (row == 3)
                {
                    cubeArray[4, 1, 3] = cubeArray[4, 1, 1];
                    cubeArray[4, 1, 1] = cubeArray[4, 3, 1];
                    cubeArray[4, 3, 1] = cubeArray[4, 3, 3];
                    cubeArray[4, 3, 3] = temp6;
                    cubeArray[4, 1, 2] = cubeArray[4, 2, 1];
                    cubeArray[4, 2, 1] = cubeArray[4, 3, 2];
                    cubeArray[4, 3, 2] = cubeArray[4, 2, 3];
                    cubeArray[4, 2, 3] = temp7;
                }
            }

            if (direction.Equals("right"))
            {
                cubeArray[3, 1, row] = cubeArray[1, 1, row];
                cubeArray[3, 2, row] = cubeArray[1, 2, row];
                cubeArray[3, 3, row] = cubeArray[1, 3, row];
                cubeArray[1, 1, row] = cubeArray[6, 1, row];
                cubeArray[1, 2, row] = cubeArray[6, 2, row];
                cubeArray[1, 3, row] = cubeArray[6, 3, row];
                cubeArray[6, 1, row] = cubeArray[5, 1, row];
                cubeArray[6, 2, row] = cubeArray[5, 2, row];
                cubeArray[6, 3, row] = cubeArray[5, 3, row];
                cubeArray[5, 1, row] = temp1;
                cubeArray[5, 2, row] = temp2;
                cubeArray[5, 3, row] = temp3;

                //TOP FACE (counterclockwise):
                if (row == 1)
                {
                    cubeArray[2, 1, 3] = cubeArray[2, 1, 1];
                    cubeArray[2, 1, 1] = cubeArray[2, 3, 1];
                    cubeArray[2, 3, 1] = cubeArray[2, 3, 3];
                    cubeArray[2, 3, 3] = temp4;
                    cubeArray[2, 1, 2] = cubeArray[2, 2, 1];
                    cubeArray[2, 2, 1] = cubeArray[2, 3, 2];
                    cubeArray[2, 3, 2] = cubeArray[2, 2, 3];
                    cubeArray[2, 2, 3] = temp5;
                }

                //BOTTOM FACE (clockwise):
                if (row == 3)
                {
                    cubeArray[4, 1, 3] = cubeArray[4, 3, 3];
                    cubeArray[4, 3, 3] = cubeArray[4, 3, 1];
                    cubeArray[4, 3, 1] = cubeArray[4, 1, 1];
                    cubeArray[4, 1, 1] = temp6;
                    cubeArray[4, 1, 2] = cubeArray[4, 2, 3];
                    cubeArray[4, 2, 3] = cubeArray[4, 3, 2];
                    cubeArray[4, 3, 2] = cubeArray[4, 2, 1];
                    cubeArray[4, 2, 1] = temp7;
                }
            }
        }

        /// <summary>
        /// Moves a specific column on a cube.
        /// </summary>
        /// <param name="col">Column number, either 1, 2, or 3.</param>
        /// <param name="direction">"up" or "down."</param>
        public void moveCol(int col, String direction)
        {
            String temp1 = cubeArray[3, col, 1];
            String temp2 = cubeArray[3, col, 2];
            String temp3 = cubeArray[3, col, 3];

            String temp4 = cubeArray[1, 1, 3];
            String temp5 = cubeArray[1, 1, 2];

            String temp6 = cubeArray[5, 1, 3];
            String temp7 = cubeArray[5, 1, 2];

            if (direction.Equals("up"))
            {
                cubeArray[3, col, 1] = cubeArray[4, col, 1];
                cubeArray[3, col, 2] = cubeArray[4, col, 2];
                cubeArray[3, col, 3] = cubeArray[4, col, 3];
                int newCol = col;
                if (col == 3)
                { newCol = 1; }
                else if (col == 1)
                { newCol = 3; }
                cubeArray[4, col, 1] = cubeArray[6, newCol, 3];
                cubeArray[4, col, 2] = cubeArray[6, newCol, 2];
                cubeArray[4, col, 3] = cubeArray[6, newCol, 1];
                cubeArray[6, newCol, 3] = cubeArray[2, col, 1];
                cubeArray[6, newCol, 2] = cubeArray[2, col, 2];
                cubeArray[6, newCol, 1] = cubeArray[2, col, 3];
                cubeArray[2, col, 1] = temp1;
                cubeArray[2, col, 2] = temp2;
                cubeArray[2, col, 3] = temp3;

                //LEFT FACE (counterclockwise):
                if (col == 1)
                {
                    cubeArray[1, 1, 3] = cubeArray[1, 1, 1];
                    cubeArray[1, 1, 1] = cubeArray[1, 3, 1];
                    cubeArray[1, 3, 1] = cubeArray[1, 3, 3];
                    cubeArray[1, 3, 3] = temp4;
                    cubeArray[1, 1, 2] = cubeArray[1, 2, 1];
                    cubeArray[1, 2, 1] = cubeArray[1, 3, 2];
                    cubeArray[1, 3, 2] = cubeArray[1, 2, 3];
                    cubeArray[1, 2, 3] = temp5;
                }

                //RIGHT FACE (clockwise):
                if (col == 3)
                {
                    cubeArray[5, 1, 3] = cubeArray[5, 3, 3];
                    cubeArray[5, 3, 3] = cubeArray[5, 3, 1];
                    cubeArray[5, 3, 1] = cubeArray[5, 1, 1];
                    cubeArray[5, 1, 1] = temp6;
                    cubeArray[5, 1, 2] = cubeArray[5, 2, 3];
                    cubeArray[5, 2, 3] = cubeArray[5, 3, 2];
                    cubeArray[5, 3, 2] = cubeArray[5, 2, 1];
                    cubeArray[5, 2, 1] = temp7;
                }
            }
            if (direction.Equals("down"))
            {
                cubeArray[3, col, 1] = cubeArray[2, col, 1];
                cubeArray[3, col, 2] = cubeArray[2, col, 2];
                cubeArray[3, col, 3] = cubeArray[2, col, 3];
                int newCol = col;
                if (col == 3)
                { newCol = 1; }
                else if (col == 1)
                { newCol = 3; }
                cubeArray[2, col, 1] = cubeArray[6, newCol, 3];
                cubeArray[2, col, 2] = cubeArray[6, newCol, 2];
                cubeArray[2, col, 3] = cubeArray[6, newCol, 1];
                cubeArray[6, newCol, 3] = cubeArray[4, col, 1];
                cubeArray[6, newCol, 2] = cubeArray[4, col, 2];
                cubeArray[6, newCol, 1] = cubeArray[4, col, 3];
                cubeArray[4, col, 1] = temp1;
                cubeArray[4, col, 2] = temp2;
                cubeArray[4, col, 3] = temp3;

                //LEFT FACE (clockwise):
                if (col == 1)
                {
                    cubeArray[1, 1, 3] = cubeArray[1, 3, 3];
                    cubeArray[1, 3, 3] = cubeArray[1, 3, 1];
                    cubeArray[1, 3, 1] = cubeArray[1, 1, 1];
                    cubeArray[1, 1, 1] = temp4;
                    cubeArray[1, 1, 2] = cubeArray[1, 2, 3];
                    cubeArray[1, 2, 3] = cubeArray[1, 3, 2];
                    cubeArray[1, 3, 2] = cubeArray[1, 2, 1];
                    cubeArray[1, 2, 1] = temp5;
                }

                //RIGHT FACE (counterclockwise):
                if (col == 3)
                {
                    cubeArray[5, 1, 3] = cubeArray[5, 1, 1];
                    cubeArray[5, 1, 1] = cubeArray[5, 3, 1];
                    cubeArray[5, 3, 1] = cubeArray[5, 3, 3];
                    cubeArray[5, 3, 3] = temp6;
                    cubeArray[5, 1, 2] = cubeArray[5, 2, 1];
                    cubeArray[5, 2, 1] = cubeArray[5, 3, 2];
                    cubeArray[5, 3, 2] = cubeArray[5, 2, 3];
                    cubeArray[5, 2, 3] = temp7;
                }
            }
        }
    }
}
