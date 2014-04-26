using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RubiksCubeSolver
{
    ///<summary>
    /*  --------OBJECTIVE OF LAYER 1:
     *  1.  Get four blocks, f3-x1-y2, f3-x2-y1, f3-x3-y2, and f3-x2-y3
     *      to be correctly oriented and positioned (the plus sign),
     *  2.  Then the remaining four blocks, f3-x1-y1, f3-x3-y1, f3-x1-y3, and f3-x3-y3
     *      to be correctly oriented and positioned.
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

    class Layer1
    {
        ArrayList allMoves;
        Orientation tempCube;

        String midColor, topColor, leftColor, rightColor, bottomColor, oppColor;

        public Layer1(Orientation oldCube)
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

        /// <summary>
        /// Goes through process of solving layer 1, returns a list of moves needed.
        /// </summary>
        /// <returns>an ArrayList of moves needed to solve layer 1.</returns>
        public ArrayList fixLayer1()
        {
            //Begin with plus sign.

            if (!(tempCube.getColor(3, 2, 1).Equals(midColor)) || !(tempCube.getColor(2, 2, 3).Equals(topColor)))
            {
                plusTop();
            }
            if (!(tempCube.getColor(3, 3, 2).Equals(midColor)) || !(tempCube.getColor(5, 1, 2).Equals(rightColor)))
            {
                plusRight();
            }
            if (!(tempCube.getColor(3, 2, 3).Equals(midColor)) || !(tempCube.getColor(4, 2, 1).Equals(bottomColor)))
            {
                plusBottom();
                
            }
            if (!(tempCube.getColor(3, 1, 2).Equals(midColor)) || !(tempCube.getColor(1, 3, 2).Equals(leftColor)))
            {
                plusLeft();
            }
            
            //Now for the corner pieces!

            if (!(tempCube.getColor(3, 1, 1).Equals(midColor)) || !(tempCube.getColor(1, 3, 1).Equals(leftColor))
                || !(tempCube.getColor(2, 1, 3).Equals(topColor)))
            {
                xTopLeft();
            }
            if (!(tempCube.getColor(3, 3, 1).Equals(midColor)) || !(tempCube.getColor(2, 3, 3).Equals(topColor))
                || !(tempCube.getColor(5, 1, 1).Equals(rightColor)))
            {
                xTopRight();
            }
            if (!(tempCube.getColor(3, 3, 3).Equals(midColor)) || !(tempCube.getColor(5, 1, 3).Equals(rightColor))
                || !(tempCube.getColor(4, 3, 1).Equals(bottomColor)))
            {
                xBottomRight();
            }
            if (!(tempCube.getColor(3, 1, 3).Equals(midColor)) || !(tempCube.getColor(4, 1, 1).Equals(bottomColor))
                || !(tempCube.getColor(1, 3, 3).Equals(leftColor)))
            {
                xBottomLeft();
            }

            return allMoves;
        }

        /// <summary>
        /// Carries out moves needed to correctly orient and position block 3, 2, 1.
        /// </summary>
        public void plusTop()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().

            //find the right block to fit into 3, 2, 1.
            //move it to 5,3,2.
            int[] t = tempCube.findEdge(midColor, topColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 1, l, 2, 1, t);

            if (block.getLayer() == 1)
            {
                // BLOCK FOUND IN LAYER 1 ***************************************************************************
                // First case, block is in correct position but wrong orientation:
                if (block.isRightPosWrongOrient())
                {
                    addMove("r", 1, "right");
                    addMove("r", 1, "right");
                    addMove(tempCube.getFaceColor(5));
                    addMove("c", 3, "down");
                    addMove(tempCube.getFaceColor(1));
                }
                // Block is at 3,1,2
                if (block.isOnLeft())
                {
                    addMove("c", 1, "down");
                    addMove("c", 1, "down");
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "down");
                    addMove("c", 1, "down");
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 3,2,3
                if (block.isOnBottom())
                {
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                    addMove(tempCube.getFaceColor(4));
                    addMove("r", 3, "right");
                    addMove(tempCube.getFaceColor(4));
                }
                // Block is at 3,3,2
                if (block.isOnRight())
                {
                    addMove("c", 3, "down");
                    addMove("c", 3, "down");
                }
            }

            else if (block.getLayer() == 2)
            {
                // BLOCK FOUND IN LAYER 2 ***************************************************************************

                // Block is at 1,2,1
                if (block.isLeftTop())
                {
                    addMove("c", 1, "up");
                }
                // Block is at 1,2,3
                if (block.isLeftBottom())
                {
                    addMove("c", 1, "down");
                }
                if (block.isLeftTop() || block.isLeftBottom())
                {
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "up");
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 5,2,1
                if (block.isRightTop())
                {
                    addMove("c", 3, "up");
                }
                // Block is at 5,2,3
                if (block.isRightBottom())
                {
                    addMove("c", 3, "down");
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************

                addMove(tempCube.getFaceColor(1));
                // Block is at 1,1,2
                if (block.isLeft())
                {
                    addMove("c", 1, "up");
                }
                // Block is at 2,2,1
                if (block.isLeft() || block.isTop())
                {
                    addMove("c", 1, "up");
                }
                // Block is at 4,2,3
                if (block.isBottom())
                {
                    addMove("c", 1, "down");
                }
                addMove(tempCube.getFaceColor(5));
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 5,3,2 (where opposite is 6,1,2).
            if (tempCube.getColor(6, 1, 2).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on bottom of cube.
                addMove(tempCube.getFaceColor(5));
                addMove("c", 3, "up");
                addMove("r", 1, "left");
                addMove("r", 1, "left");
                addMove(tempCube.getFaceColor(1));
            }


            else if (tempCube.getColor(5, 3, 2).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on side of cube.
                addMove("c", 2, "up");
                addMove(tempCube.getFaceColor(5));
                addMove("c", 3, "up");
                addMove(tempCube.getFaceColor(1));
                addMove("c", 2, "down");
            }
            else
            {
                Console.WriteLine("OOPS. Layer 1: Plus Top.");
            }
        }

        /// <summary>
        /// Carries out moves needed to correctly orient and position block 3, 3, 2.
        /// </summary>
        public void plusRight()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().
            //addMove("r", 1, "right");
            //addMove("c", 2, "up");

            //find the right block to fit into 3, 3, 2.
            //move it there.
            // block 3, 2, 1 is already in place! don't disturb!
            int[] t = tempCube.findEdge(midColor, rightColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 1, l, 3, 2, t);

            if (block.getLayer() == 1)
            {
                // BLOCK FOUND IN LAYER 1 ***************************************************************************
                // First case, block is in correct position but wrong orientation:
                if (block.isRightPosWrongOrient())
                {
                    addMove("c", 3, "up");
                    addMove("c", 3, "up");
                    addMove(tempCube.getFaceColor(4));
                    addMove("r", 3, "left");
                    addMove(tempCube.getFaceColor(2));
                }
                // Block is at 3,1,2
                if (block.isOnLeft())
                {
                    addMove("c", 1, "up");
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "down");
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 3,2,3
                if (block.isOnBottom())
                {
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                }
            }

            else if (block.getLayer() == 2)
            {
                // BLOCK FOUND IN LAYER 2 ***************************************************************************
                // Block is at 1,2,1
                if (block.isLeftTop())
                {
                    addMove("c", 1, "up");
                }
                // Block is at 1,2,3
                if (block.isLeftBottom())
                {
                    addMove("c", 1, "down");
                }
                if (block.isLeftTop() || block.isLeftBottom())
                {
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "down");
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 5,2,1
                if (block.isRightTop())
                {
                    addMove("c", 3, "up");
                }
                // Block is at 5,2,3
                if (block.isRightBottom())
                {
                    addMove("c", 3, "down");
                }
                if (block.isRightTop() || block.isRightBottom())
                {
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(5));
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************

                addMove(tempCube.getFaceColor(1));
                // Block is at 1,1,2
                if (block.isLeft())
                {
                    addMove("c", 1, "down");
                }
                // Block is at 2,2,1
                if (block.isTop())
                {
                    addMove("c", 1, "down");
                    addMove("c", 1, "down");
                }
                // Block is at 4,2,3
                if (block.isRight())
                {
                    addMove("c", 1, "up");
                }
                addMove(tempCube.getFaceColor(5));
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 4,2,3 (where opposite is 6,2,3).
            if (tempCube.getColor(6, 2, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 4), with top facecolor on bottom of cube.
                addMove(tempCube.getFaceColor(5));
                addMove("c", 3, "up");
                addMove("f", 0, "clockwise");
                addMove("f", 0, "clockwise");
                addMove(tempCube.getFaceColor(1));
            }


            else if (tempCube.getColor(4, 2, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 4), with top facecolor on side of cube.
                addMove("r", 2, "right");
                addMove(tempCube.getFaceColor(5));
                addMove("c", 3, "up");
                addMove(tempCube.getFaceColor(1));
                addMove("r", 2, "left");
            }
            else
            {
                Console.WriteLine("OOPS. Layer 1: Plus Right.");
            }
        }

        /// <summary>
        /// Carries out moves needed to correctly orient and position block 3, 2, 3.
        /// </summary>
        public void plusBottom()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().
            //addMove("r", 1, "right");
            //addMove("c", 2, "up");

            //find the right block to fit into 3, 2, 3.
            //move it there.
            // blocks 3, 2, 1 and 3, 3, 2 are already in place! don't disturb!
            int[] t = tempCube.findEdge(midColor, bottomColor);
            int l2 = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 1, l2, 2, 3, t);

            if (block.getLayer() == 1)
            {
                // BLOCK FOUND IN LAYER 1 ***************************************************************************
                // First case, block is in correct position but wrong orientation:
                if (block.isRightPosWrongOrient())
                {
                    addMove("r", 3, "left");
                    addMove("r", 3, "left");
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 3,1,2
                if (block.isOnLeft())
                {
                    addMove("c", 1, "up");
                    addMove("c", 1, "up");
                }
            }

            else if (block.getLayer() == 2)
            {
                // BLOCK FOUND IN LAYER 2 ***************************************************************************
                // Block is at 1,2,1
                if (block.isLeftTop())
                {
                    addMove("c", 1, "up");
                }
                // Block is at 1,2,3
                if (block.isLeftBottom())
                {
                    addMove("c", 1, "down");
                }
                // Block is at 5,2,1
                if (block.isRightTop())
                {
                    addMove(tempCube.getFaceColor(5));
                    addMove("f", 0, "clockwise");
                    addMove("c", 3, "down");
                    addMove("c", 3, "down");
                    addMove("f", 0, "counterclockwise");
                    addMove(tempCube.getFaceColor(1));
                }
                // Block is at 5,2,3
                if (block.isRightBottom())
                {
                    addMove(tempCube.getFaceColor(5));
                    addMove("f", 0, "counterclockwise");
                    addMove("c", 3, "down");
                    addMove("c", 3, "down");
                    addMove("f", 0, "clockwise");
                    addMove(tempCube.getFaceColor(1));
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************

                addMove(tempCube.getFaceColor(1));
                // Block is at 1,1,2
                if (block.isBottom())
                {
                    addMove("c", 1, "up");
                }
                // Block is at 2,2,1
                if (block.isTop())
                {
                    addMove("c", 1, "down");
                }
                // Block is at 4,2,3
                if (block.isRight())
                {
                    addMove("c", 1, "up");
                    addMove("c", 1, "up");
                }
                addMove(tempCube.getFaceColor(5));
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 4,2,3 (where opposite is 6,2,3).
            if (tempCube.getColor(6, 3, 2).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 4), with top facecolor on bottom of cube.
                addMove(tempCube.getFaceColor(1));
                addMove("c", 1, "down");
                addMove("r", 3, "right");
                addMove("r", 3, "right");
                addMove(tempCube.getFaceColor(5));
            }


            else if (tempCube.getColor(1, 1, 2).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 1), with top facecolor on side of cube.
                addMove("c", 2, "down");
                addMove(tempCube.getFaceColor(1));
                addMove("c", 1, "down");
                addMove(tempCube.getFaceColor(5));
                addMove("c", 2, "up");
            }
            else
            {
                Console.WriteLine("OOPS. Layer1: Plus Bottom.");
            }
        }

        /// <summary>
        /// Carries out moves needed to correctly orient and position block 3, 1, 2.
        /// </summary>
        public void plusLeft()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().
            //addMove("r", 1, "right");
            //addMove("c", 2, "up");

            //find the right block to fit into 3, 1, 2.
            //move it there.
            // blocks 3, 2, 1 --- 3, 3, 2 --- and 3, 2, 3 are already in place! don't disturb!
            int[] t = tempCube.findEdge(midColor, leftColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 1, l, 1, 2, t);

            if (block.getLayer() == 1)
            {
                // BLOCK FOUND IN LAYER 1 ***************************************************************************
                // First case, block is in correct position but wrong orientation:
                if (block.isRightPosWrongOrient())
                {
                    addMove("c", 1, "up");
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(5));
                }
            }

            else if (block.getLayer() == 2)
            {
                // BLOCK FOUND IN LAYER 2 ***************************************************************************
                // Block is at 1,2,1
                if (block.isLeftTop())
                {
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 1,2,3
                if (block.isLeftBottom())
                {
                    addMove("c", 1, "down");
                    addMove(tempCube.getFaceColor(1));
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(5));
                }
                // Block is at 5,2,1
                if (block.isRightTop())
                {
                    addMove(tempCube.getFaceColor(5));
                    addMove("f", 0, "clockwise");
                    addMove("c", 3, "up");
                    addMove("f", 0, "counterclockwise");
                    addMove(tempCube.getFaceColor(1));
                }
                // Block is at 5,2,3
                if (block.isRightBottom())
                {
                    addMove(tempCube.getFaceColor(5));
                    addMove("f", 0, "counterclockwise");
                    addMove("c", 3, "up");
                    addMove("f", 0, "clockwise");
                    addMove(tempCube.getFaceColor(1));
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************
                addMove(tempCube.getFaceColor(1));
                // Block is at 1,1,2
                if (block.isBottom())
                {
                    addMove("c", 1, "up");
                    addMove("c", 1, "up");
                }
                // Block is at 2,2,1
                if (block.isLeft())
                {
                    addMove("c", 1, "up");
                }
                // Block is at 4,2,3
                if (block.isRight())
                {
                    addMove("c", 1, "down");
                }
                addMove(tempCube.getFaceColor(5));
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 4,2,3 (where opposite is 6,2,3).
            if (tempCube.getColor(6, 2, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 4), with top facecolor on bottom of cube.
                addMove(tempCube.getFaceColor(2));
                addMove("r", 1, "left");
                addMove("c", 1, "down");
                addMove("c", 1, "down");
                addMove(tempCube.getFaceColor(4));
            }


            else if (tempCube.getColor(2, 2, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 1), with top facecolor on side of cube.
                addMove("r", 2, "left");
                addMove(tempCube.getFaceColor(1));
                addMove("c", 1, "down");
                addMove(tempCube.getFaceColor(5));
                addMove("r", 2, "right");
            }
            else
            {
                Console.WriteLine("OOPS. Layer1: Plus Left.");
            }
        }

        /// <summary>
        /// Carries out moves needed to correctly orient and position block 3, 1, 1.
        /// </summary>
        public void xTopLeft()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().

            //find the right block to fit into 3, 1, 1.
            //move it there.
            int[] t = tempCube.findCorner(midColor, leftColor, topColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 1, l, 1, 1, t);
            int blockFacing = t[0];

            if (block.getLayer() == 1)
            {
                // Position Found Block on third layer below correct position.

                // BLOCK FOUND IN LAYER 1 ***************************************************************************
                // First case, block is in correct position but wrong orientation:
                if (block.isRightPosWrongOrient())
                {
                    // ADDED TODAY:
                    if (blockFacing == 1)
                    {
                        addMove("c", 1, "up");
                        addMove(tempCube.getFaceColor(2));
                        addMove("r", 1, "right");
                        addMove("c", 1, "down");
                        addMove("r", 1, "left");
                        addMove(tempCube.getFaceColor(4));
                    }
                    else
                    {
                        addMove("r", 1, "left");
                        addMove(tempCube.getFaceColor(1));
                        addMove("c", 1, "down");
                        addMove("r", 1, "right");
                        addMove("c", 1, "up");
                        addMove(tempCube.getFaceColor(5));
                    }
                }
                else if (block.isTopTopRight())
                {
                    if (blockFacing == 2)
                    {
                        addMove("r", 1, "right");
                        addMove(tempCube.getFaceColor(5));
                        addMove("c", 3, "up");
                        addMove(tempCube.getFaceColor(1));
                        addMove("r", 1, "left");
                    }
                    else
                    {
                        addMove("c", 3, "up");
                        addMove(tempCube.getFaceColor(2));
                        addMove("r", 1, "left");
                        addMove(tempCube.getFaceColor(4));
                        addMove("c", 3, "down");
                    }
                }
                else if (block.isTopBottomRight())
                {
                    if (blockFacing == 4)
                    {
                        addMove("r", 3, "right");
                        addMove(tempCube.getFaceColor(4));
                        addMove("r", 3, "left");
                        addMove("r", 3, "left");
                        addMove(tempCube.getFaceColor(2));
                        addMove("r", 3, "left");
                    }
                    else
                    {
                        addMove("c", 3, "down");
                        addMove(tempCube.getFaceColor(1));
                        addMove("c", 1, "up");
                        addMove("c", 1, "up");
                        addMove(tempCube.getFaceColor(5));
                        addMove("c", 3, "up");
                    }
                }
                else if (block.isTopBottomLeft())
                {
                    if (blockFacing == 1)
                    {
                        addMove("c", 1, "down");
                        addMove(tempCube.getFaceColor(4));
                        addMove("r", 3, "right");
                        addMove("c", 1, "up");
                        addMove("r", 3, "left");
                        addMove("r", 3, "left");
                        addMove(tempCube.getFaceColor(2));
                    }
                    else
                    {
                        addMove("r", 3, "left");
                        addMove(tempCube.getFaceColor(1));
                        addMove("c", 1, "up");
                        addMove("r", 3, "right");
                        addMove(tempCube.getFaceColor(5));
                    }
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************

                if (block.isBottomTopRight())
                {
                    addMove(tempCube.getFaceColor(2));
                    addMove("r", 1, "left");
                    addMove(tempCube.getFaceColor(4));
                }
                else if (block.isBottomBottomRight())
                {
                    addMove(tempCube.getFaceColor(2));
                    addMove("r", 1, "left");
                    addMove("r", 1, "left");
                    addMove(tempCube.getFaceColor(4));
                }
                else if (block.isBottomBottomLeft())
                {
                    addMove(tempCube.getFaceColor(2));
                    addMove("r", 1, "right");
                    addMove(tempCube.getFaceColor(4));
                }
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 4,2,3 (where opposite is 6,2,3).
            if (tempCube.getColor(2, 1, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 4), with top facecolor on bottom of cube.
                addMove(tempCube.getFaceColor(2));
                addMove("r", 1, "right");
                addMove("c", 1, "up");
                addMove("r", 1, "left");
                addMove("c", 1, "down");
                addMove(tempCube.getFaceColor(4));
            }
            else if (tempCube.getColor(1, 1, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 1), with top facecolor on side of cube.
                addMove(tempCube.getFaceColor(1));
                addMove("c", 1, "down");
                addMove("r", 1, "left");
                addMove("c", 1, "up");
                addMove("r", 1, "right");
                addMove(tempCube.getFaceColor(5));
            }
            else if (tempCube.getColor(6, 3, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 6), with top facecolor on opposite side of cube.
                addMove(tempCube.getFaceColor(1));
                addMove("c", 1, "up");
                addMove("f", 0, "counterclockwise");
                addMove("c", 1, "down");
                addMove("f", 0, "clockwise");
                addMove("r", 1, "left");
                addMove("c", 1, "down");
                addMove("r", 1, "right");
                addMove("c", 1, "up");
                addMove("c", 1, "up");
                addMove("f", 0, "counterclockwise");
                addMove("c", 1, "down");
                addMove("f", 0, "clockwise");
                addMove(tempCube.getFaceColor(5));
            }
            else
            {
                Console.WriteLine("OOPS. Layer 1: Corners, Top Left.");
            }
        }

        /// <summary>
        /// Carries out moves needed to correctly orient and position block 3, 3, 1.
        /// </summary>
        public void xTopRight()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().
            //find the right block to fit into 3, 3, 1.
            //move it there.

            int[] t = tempCube.findCorner(midColor, topColor, rightColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 1, l, 3, 1, t);

            if (block.getLayer() == 1)
            {
                // Position Found Block on third layer below correct position.

                // BLOCK FOUND IN LAYER 1 ***************************************************************************
                // First case, block is in correct position but wrong orientation:
                if (block.isRightPosWrongOrient())
                {
                    addMove(tempCube.getFaceColor(5));
                    addMove("r", 1, "right");
                    addMove("c", 3, "down");
                    addMove("r", 1, "left");
                    addMove("c", 3, "up");
                    addMove(tempCube.getFaceColor(1));
                }
                else if (block.isTopBottomRight())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("f", 0, "clockwise");
                    addMove("r", 3, "right");
                    addMove("f", 0, "counterclockwise");
                    addMove(tempCube.getFaceColor(2));
                }
                else if (block.isTopBottomLeft())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("c", 1, "down");
                    addMove("r", 3, "right");
                    addMove("r", 3, "right");
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(2));
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************

                if (block.isBottomTopLeft())
                {
                    addMove(tempCube.getFaceColor(2));
                    addMove("r", 1, "right");
                    addMove(tempCube.getFaceColor(4));
                }
                else if (block.isBottomBottomRight())
                {
                    addMove(tempCube.getFaceColor(2));
                    addMove("r", 1, "left");
                    addMove(tempCube.getFaceColor(4));
                }
                else if (block.isBottomBottomLeft())
                {
                    addMove(tempCube.getFaceColor(2));
                    addMove("r", 1, "right");
                    addMove("r", 1, "right");
                    addMove(tempCube.getFaceColor(4));
                }
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 4,2,3 (where opposite is 6,2,3).
            if (tempCube.getColor(2, 3, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 4), with top facecolor on bottom of cube.
                addMove(tempCube.getFaceColor(2));
                addMove("r", 1, "left");
                addMove("c", 3, "up");
                addMove("r", 1, "right");
                addMove("c", 3, "down");
                addMove(tempCube.getFaceColor(4));
            }
            else if (tempCube.getColor(5, 3, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 1), with top facecolor on side of cube.
                addMove(tempCube.getFaceColor(5));
                addMove("c", 3, "down");
                addMove("r", 1, "right");
                addMove("c", 3, "up");
                addMove("r", 1, "left");
                addMove(tempCube.getFaceColor(1));
            }
            else if (tempCube.getColor(6, 1, 1).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 6), with top facecolor on opposite side of cube.
                addMove(tempCube.getFaceColor(5));
                addMove("c", 3, "up");
                addMove("f", 0, "clockwise");
                addMove("c", 3, "down");
                addMove("f", 0, "counterclockwise");
                addMove("r", 1, "right");
                addMove("c", 3, "down");
                addMove("r", 1, "left");
                addMove("c", 3, "up");
                addMove("c", 3, "up");
                addMove("f", 0, "clockwise");
                addMove("c", 3, "down");
                addMove("f", 0, "counterclockwise");
                addMove(tempCube.getFaceColor(1));
            }
            else
            {
                Console.WriteLine("OOPS. Layer 1: Corners, Top Right.");
            }
        }

        /// <summary>
        /// Carries out moves needed to correctly orient and position block 3, 3, 3.
        /// </summary>
        public void xBottomRight()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().

            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().
            //find the right block to fit into 3, 3, 3.
            //move it there.

            int[] t = tempCube.findCorner(midColor, rightColor, bottomColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 1, l, 3, 3, t);

            if (block.getLayer() == 1)
            {
                // Position Found Block on third layer below correct position.

                // BLOCK FOUND IN LAYER 1 ***************************************************************************
                // First case, block is in correct position but wrong orientation:
                if (block.isRightPosWrongOrient())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("c", 3, "down");
                    addMove("r", 3, "left");
                    addMove("c", 3, "up");
                    addMove("r", 3, "right");
                    addMove(tempCube.getFaceColor(2));
                }
                else if (block.isTopBottomLeft())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("c", 1, "down");
                    addMove("r", 3, "right");
                    addMove("c", 1, "up");
                    addMove(tempCube.getFaceColor(2));
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************
                if (block.isBottomTopLeft())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("r", 3, "left");
                    addMove("r", 3, "left");
                    addMove(tempCube.getFaceColor(2));
                }
                else if (block.isBottomTopRight())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("r", 3, "left");
                    addMove(tempCube.getFaceColor(2));
                }
                else if (block.isBottomBottomLeft())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("r", 3, "right");
                    addMove(tempCube.getFaceColor(2));
                }
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 4,2,3 (where opposite is 6,2,3).
            if (tempCube.getColor(5, 3, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on bottom of cube.
                addMove(tempCube.getFaceColor(5));
                addMove("c", 3, "up");
                addMove("r", 3, "right");
                addMove("c", 3, "down");
                addMove("r", 3, "left");
                addMove(tempCube.getFaceColor(1));
            }
            else if (tempCube.getColor(4, 3, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 1), with top facecolor on side of cube.
                addMove(tempCube.getFaceColor(4));
                addMove("r", 3, "left");
                addMove("c", 3, "down");
                addMove("r", 3, "right");
                addMove("c", 3, "up");
                addMove(tempCube.getFaceColor(2));
            }
            else if (tempCube.getColor(6, 1, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 6), with top facecolor on opposite side of cube.
                addMove(tempCube.getFaceColor(4));
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
                addMove("c", 3, "down");
                addMove("r", 3, "left");
                addMove("c", 3, "up");
                addMove("r", 3, "right");
                addMove("r", 3, "right");
                addMove("f", 0, "clockwise");
                addMove("r", 3, "left");
                addMove("f", 0, "counterclockwise");
                addMove(tempCube.getFaceColor(2));
            }
            else
            {
                Console.WriteLine("OOPS. Layer 1: Corners, Bottom Right.");
            }
        }

        /// <summary>
        /// Carries out moves needed to correctly orient and position block 3, 1, 3.
        /// </summary>
        public void xBottomLeft()
        {
            //r: row, c: col, f: face. for entire cube rotation, simply "newFaceColor" in setMove().
            //find the right block to fit into 3, 1, 3.
            //move it there.

            int[] t = tempCube.findCorner(midColor, bottomColor, leftColor);
            int l = tempCube.findLayer(t[0], t[1], t[2]);
            BlockInfo block = new BlockInfo(tempCube, 1, l, 1, 3, t);

            if (block.getLayer() == 1)
            {
                // Position Found Block on third layer below correct position.

                // BLOCK FOUND IN LAYER 1 ***************************************************************************
                // First case, block is in correct position but wrong orientation:
                if (block.isRightPosWrongOrient())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("c", 1, "down");
                    addMove("r", 3, "right");
                    addMove("c", 1, "up");
                    addMove("r", 3, "left");
                    addMove(tempCube.getFaceColor(2));
                }
            }

            else
            {
                // BLOCK FOUND IN LAYER 3 ***************************************************************************

                if (block.isBottomTopLeft())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("r", 3, "right");
                    addMove(tempCube.getFaceColor(2));
                }
                else if (block.isBottomTopRight())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("r", 3, "left");
                    addMove("r", 3, "left");
                    addMove(tempCube.getFaceColor(2));
                }
                else if (block.isBottomBottomRight())
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove("r", 3, "left");
                    addMove(tempCube.getFaceColor(2));
                }
            }


            // The two following if & else if statements are executed once correct edge is 
            //      moved into the spot 4,2,3 (where opposite is 6,2,3).
            if (tempCube.getColor(1, 1, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 5), with top facecolor on bottom of cube.
                addMove(tempCube.getFaceColor(1));
                addMove("c", 1, "up");
                addMove("r", 3, "left");
                addMove("c", 1, "down");
                addMove("r", 3, "right");
                addMove(tempCube.getFaceColor(5));
            }
            else if (tempCube.getColor(4, 1, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 1), with top facecolor on side of cube.
                addMove(tempCube.getFaceColor(4));
                addMove("r", 3, "right");
                addMove("c", 1, "down");
                addMove("r", 3, "left");
                addMove("c", 1, "up");
                addMove(tempCube.getFaceColor(2));
            }
            else if (tempCube.getColor(6, 3, 3).Equals(tempCube.getFaceColor(3)))
            {
                //if block is on bottom (face 6), with top facecolor on opposite side of cube.
                addMove(tempCube.getFaceColor(4));
                addMove("r", 3, "right");
                addMove("c", 1, "down");
                addMove("r", 3, "left");
                addMove("c", 1, "up");
                addMove("f", 0, "counterclockwise");
                addMove("r", 3, "left");
                addMove("f", 0, "clockwise");
                addMove("r", 3, "right");
                addMove("r", 3, "right");
                addMove("c", 1, "down");
                addMove("r", 3, "left");
                addMove("c", 1, "up");
                addMove(tempCube.getFaceColor(2));
            }
            else
            {
                Console.WriteLine("OOPS. Layer 1: Corners, Bottom Left.");
            }
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

