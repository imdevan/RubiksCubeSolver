using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RubiksCubeSolver
{
    ///<summary>
    /*  --------OBJECTIVE OF LAYER 2:
     *  Get four blocks, f1-x1-y2, f1-x3-y2, f6-x3-y2, and f6-x1-y2
     *  to be correctly oriented and positioned.
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
     *              
     *  r1-3: rows 1 through 3
     *  c1-3: cols 1 through 3                
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
    
    class Layer2
    {
        ArrayList allMoves;
        Orientation tempCube;

        String midColor, topColor, leftColor, rightColor, bottomColor, oppColor;

        public Layer2(Orientation oldCube)
        {
            allMoves = new ArrayList();
            tempCube = new Orientation(oldCube);

            midColor = tempCube.getFaceColor(3);
            topColor = tempCube.getFaceColor(2);
            leftColor = tempCube.getFaceColor(1);
            rightColor = tempCube.getFaceColor(5);
            bottomColor = tempCube.getFaceColor(4);
            oppColor = tempCube.getFaceColor(6);
        }

        public Orientation getCube()
        {
            return this.tempCube;
        }

        public ArrayList fixLayer2()
        {
            if (!(tempCube.getColor(4, 1, 2).Equals(bottomColor)) || !(tempCube.getColor(1, 2, 3).Equals(leftColor)))
            {
                midBottomLeft();
            }
            if (!(tempCube.getColor(4, 3, 2).Equals(bottomColor)) || !(tempCube.getColor(5, 2, 3).Equals(rightColor)))
            {
                midBottomRight();
            }
            if (!(tempCube.getColor(2, 1, 2).Equals(topColor)) || !(tempCube.getColor(1, 2, 1).Equals(leftColor)))
            {
                midTopLeft();
            }
            if (!(tempCube.getColor(2, 3, 2).Equals(topColor)) || !(tempCube.getColor(5, 2, 1).Equals(rightColor)))
            {
                midTopRight();
            }
            return allMoves;
        }

        /// <summary>
        /// Fixes the block 4, 1, 2.
        /// </summary>
        public void midBottomLeft()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().

            //find the right block to fit into 3, 2, 1.
            //move it to 5,3,2.
            int[] t = tempCube.findEdge(bottomColor, leftColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 2, l, 1, 2, t);

            // Change face of cube to bottom.
            addMove(tempCube.getFaceColor(4));

            if (block.getLayer() == 2)
            {
                // BLOCK FOUND IN LAYER 2 ***************************************************************************

                // Block is at 1,2,3
                if (block.isLeftBottom())
                {
                    addMove("c", 1, "down");
                    addMove("r", 3, "left");
                    addMove("c", 1, "up");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                }
                // Block is at 5,2,3
                if (block.isRightBottom())
                {
                    addMove("c", 3, "down");
                    addMove("r", 3, "right");
                    addMove("c", 3, "up");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                }
                // Block is at 1,2,1
                if (block.isLeftTop())
                {
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 3, "down");
                    addMove("r", 3, "right");
                    addMove("c", 3, "up");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove(tempCube.getFaceColor(5));
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 5,2,1
                if (block.isRightTop())
                {
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "down");
                    addMove("r", 3, "left");
                    addMove("c", 1, "up");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove(tempCube.getFaceColor(5));
                    addMove(tempCube.getFaceColor(5));
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************
                // Block is at 1,1,2
                if (block.isLeft())
                {
                    addMove("r", 3, "right");
                }
                // Block is at 2,2,1
                if (block.isTop())
                {
                    addMove("r", 3, "left");
                    addMove("r", 3, "left");
                }
                // Block is at 4,2,3
                if (block.isRight())
                {
                    addMove("r", 3, "left");
                }
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 3,2,3 (where opposite is 4,2,1).
            if (tempCube.getColor(3, 2, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on bottom of cube.
                addMove("r", 3, "right");
                addMove("c", 1, "down");
                addMove("r", 3, "left");
                addMove("c", 1, "up");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
            }


            else if (tempCube.getColor(4, 2, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on side of cube.
                addMove(tempCube.getFaceColor(1));
                addMove("r", 3, "left");
                addMove("r", 3, "left");
                addMove("c", 3, "down");
                addMove("r", 3, "right");
                addMove("c", 3, "up");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
                addMove(tempCube.getFaceColor(5));
            }
            else
            {
                Console.WriteLine("OOPS. Layer 2: Bottom Left.");
            }

            // Move back to center face.
            addMove(tempCube.getFaceColor(2));
        }

        /// <summary>
        /// Fixes block 4, 3, 2.
        /// </summary>
        public void midBottomRight()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().

            //find the right block to fit into 3, 3, 2.
            //move it to 3,2,3.
            int[] t = tempCube.findEdge(bottomColor, rightColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 2, l, 3, 2, t);

            // Change face of cube to bottom.
            addMove(tempCube.getFaceColor(4));

            if (block.getLayer() == 2)
            {
                // BLOCK FOUND IN LAYER 2 ***************************************************************************

                // Block is at 5,2,3
                if (block.isRightBottom())
                {
                    addMove("c", 3, "down");
                    addMove("r", 3, "right");
                    addMove("c", 3, "up");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                }
                // Block is at 1,2,1
                if (block.isLeftTop())
                {
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 3, "down");
                    addMove("r", 3, "right");
                    addMove("c", 3, "up");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove(tempCube.getFaceColor(5));
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 5,2,1
                if (block.isRightTop())
                {
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "down");
                    addMove("r", 3, "left");
                    addMove("c", 1, "up");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove(tempCube.getFaceColor(5));
                    addMove(tempCube.getFaceColor(5));
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************
                // Block is at 1,1,2
                if (block.isLeft())
                {
                    addMove("r", 3, "right");
                }
                // Block is at 2,2,1
                if (block.isTop())
                {
                    addMove("r", 3, "left");
                    addMove("r", 3, "left");
                }
                // Block is at 4,2,3
                if (block.isRight())
                {
                    addMove("r", 3, "left");
                }
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 3,2,3 (where opposite is 4,2,1).
            if (tempCube.getColor(3, 2, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on bottom of cube.
                addMove("r", 3, "left");
                addMove("c", 3, "down");
                addMove("r", 3, "right");
                addMove("c", 3, "up");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
            }


            else if (tempCube.getColor(4, 2, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on side of cube.
                addMove(tempCube.getFaceColor(5));
                addMove("r", 3, "right");
                addMove("r", 3, "right");
                addMove("c", 1, "down");
                addMove("r", 3, "left");
                addMove("c", 1, "up");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
                addMove(tempCube.getFaceColor(1));
            }
            else
            {
                Console.WriteLine("OOPS. Layer 2: Bottom Right.");
            }

            // Move back to center face.
            addMove(tempCube.getFaceColor(2));
        }

        /// <summary>
        /// Fixes block 2, 1, 2.
        /// </summary>
        public void midTopLeft()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().

            //find the right block to fit into 3, 3, 2.
            //move it to 3,2,3.
            int[] t = tempCube.findEdge(topColor, leftColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 2, l, 3, 2, t);

            // Change face of cube to bottom.
            addMove(tempCube.getFaceColor(4));
            addMove(tempCube.getFaceColor(1));
            addMove(tempCube.getFaceColor(1));

            if (block.getLayer() == 2)
            {
                // BLOCK FOUND IN LAYER 2 ***************************************************************************

                // Block is at 1,2,1
                if (block.isLeftTop())
                {
                    addMove("c", 3, "down");
                    addMove("r", 3, "right");
                    addMove("c", 3, "up");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                }
                // Block is at 5,2,1
                if (block.isRightTop())
                {
                    addMove("c", 1, "down");
                    addMove("r", 3, "left");
                    addMove("c", 1, "up");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************
                // Block is at 1,1,2
                if (block.isLeft())
                {
                    addMove("r", 3, "left");
                }
                // Block is at 2,2,1
                if (block.isBottom())
                {
                    addMove("r", 3, "left");
                    addMove("r", 3, "left");
                }
                // Block is at 4,2,3
                if (block.isRight())
                {
                    addMove("r", 3, "right");
                }
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 3,2,3 (where opposite is 4,2,1).
            if (tempCube.getColor(3, 2, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on bottom of cube.
                addMove("r", 3, "left");
                addMove("c", 3, "down");
                addMove("r", 3, "right");
                addMove("c", 3, "up");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
            }


            else if (tempCube.getColor(4, 2, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on side of cube.
                addMove(tempCube.getFaceColor(5));
                addMove("r", 3, "right");
                addMove("r", 3, "right");
                addMove("c", 1, "down");
                addMove("r", 3, "left");
                addMove("c", 1, "up");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
                addMove(tempCube.getFaceColor(1));
            }
            else
            {
                Console.WriteLine("OOPS. Layer 2: Top Left.");
            }

            // Move back to center face.
            addMove(tempCube.getFaceColor(5));
            addMove(tempCube.getFaceColor(5));
            addMove(tempCube.getFaceColor(2));
        }

        /// <summary>
        /// Fixes block 2, 3, 2.
        /// </summary>
        public void midTopRight()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().

            //find the right block to fit into 3, 3, 2.
            //move it to 3,2,3.
            int[] t = tempCube.findEdge(topColor, rightColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 2, l, 1, 2, t);

            // Change face of cube to bottom.
            addMove(tempCube.getFaceColor(4));
            addMove(tempCube.getFaceColor(1));
            addMove(tempCube.getFaceColor(1));

            if (block.getLayer() == 2)
            {
                // BLOCK FOUND IN LAYER 2 ***************************************************************************

                // Block is at 5,2,1
                if (block.isRightTop())
                {
                    addMove("c", 1, "down");
                    addMove("r", 3, "left");
                    addMove("c", 1, "up");
                    addMove("r", 3, "left");
                    addMove("f", 0, "counterclockwise");
                    addMove("r", 3, "right");
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************
                // Block is at 1,1,2
                if (block.isLeft())
                {
                    addMove("r", 3, "left");
                }
                // Block is at 2,2,1
                if (block.isBottom())
                {
                    addMove("r", 3, "left");
                    addMove("r", 3, "left");
                }
                // Block is at 4,2,3
                if (block.isRight())
                {
                    addMove("r", 3, "right");
                }
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 3,2,3 (where opposite is 4,2,1).
            if (tempCube.getColor(3, 2, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on bottom of cube.
                addMove("r", 3, "right");
                addMove("c", 1, "down");
                addMove("r", 3, "left");
                addMove("c", 1, "up");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
            }


            else if (tempCube.getColor(4, 2, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on side of cube.
                
                addMove(tempCube.getFaceColor(1));                
                addMove("r", 3, "left");
                addMove("r", 3, "left");
                addMove("c", 3, "down");
                addMove("r", 3, "right");
                addMove("c", 3, "up");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
                addMove(tempCube.getFaceColor(5));
            }
            else
            {
                Console.WriteLine("OOPS. Layer 2: Top Right.");
            }

            // Move back to center face.
            addMove(tempCube.getFaceColor(5));
            addMove(tempCube.getFaceColor(5));
            addMove(tempCube.getFaceColor(2));
        }

        /// <summary>
        /// Adds a move to the ArrayList allMoves.
        /// </summary>
        /// <param name="rc">"r", "c", or "f"</param>
        /// <param name="num">1-3, or 0 if "f"</param>
        /// <param name="dir">"left/right", "up/down", or "clockwise/counterclockwise".</param>
        public void addMove(String rc, int num, String dir)
        {
            Moves newMove = new Moves();
            newMove.setMove(rc, num, dir);
            allMoves.Add(newMove);
            makeTempMove(newMove);
        }

        /// <summary>
        /// Adds a move to the ArrayList allMoves
        /// </summary>
        /// <param name="dir">New face color.</param>
        public void addMove(String dir)
        {
            Moves newMove = new Moves();
            newMove.setMove(dir);
            allMoves.Add(newMove);
            makeTempMove(newMove);
        }

        /// <summary>
        /// Moves a copy of the block's orientation so that next move can be made.
        /// </summary>
        /// <param name="theMove">Move to be translated.</param>
        public void makeTempMove(Moves theMove)
        {
            String rowCol = "";
            rowCol = theMove.getRowCol();
            if (rowCol.Equals("R"))
            {
                tempCube.moveRow(theMove.getNum(), theMove.getDirection());
            }
            else if (rowCol.Equals("C"))
            {
                tempCube.moveCol(theMove.getNum(), theMove.getDirection());
            }
            else if (rowCol.Equals("F"))
            {
                tempCube.rotateFace(theMove.getDirection());
            }
            else
            { tempCube.changeFace(theMove.getDirection()); }
        }
    }
}
