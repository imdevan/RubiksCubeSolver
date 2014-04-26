using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RubiksCubeSolver
{
    ///<summary>
    /*  --------OBJECTIVE OF LAYER 3:
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

    class Layer3
    {
        ArrayList allMoves;
        Orientation tempCube;

        bool allPlusPositions, allPlusOrientations, 
            allCornerPositions, allCornerOrientations;

        String midColor, topColor, leftColor, rightColor, bottomColor, oppColor;

        public Layer3(Orientation oldCube)
        {
            allMoves = new ArrayList();
            tempCube = new Orientation(oldCube);

            midColor = tempCube.getFaceColor(3);
            topColor = tempCube.getFaceColor(2);
            leftColor = tempCube.getFaceColor(1);
            rightColor = tempCube.getFaceColor(5);
            bottomColor = tempCube.getFaceColor(4);
            oppColor = tempCube.getFaceColor(6);

            allPlusPositions = false;
            allPlusOrientations = false;
            allCornerPositions = false;
            allCornerOrientations = false;
        }

        public Orientation getCube()
        {
            return this.tempCube;
        }

        public ArrayList fixLayer3()
        {
            addMove(tempCube.getFaceColor(4));
            addMove(tempCube.getFaceColor(4));

            bestPlusPosition();

            allPlusPositions = checkPlusPositions();
            if (! allPlusPositions)
            {
                plusPosition();
            }

            allPlusOrientations = checkPlusOrientations();
            if (! allPlusOrientations)
            {
                plusOrientation();
            }

            allCornerPositions = checkCornerPositions();
            if (! allCornerPositions)
            {
                cornerPosition();
            }

            allCornerOrientations = checkCornerOrientations();
            if (! allCornerOrientations)
            {
                cornerOrientation();
            }
            return allMoves;
        }

        public void bestPlusPosition()
        {
            Orientation newCube = new Orientation(tempCube);
            ArrayList plusMoves = new ArrayList();
            int topScore = 0;
            int score = 0;
            score = countPlusPosMatches(newCube);
            topScore = score;

            newCube.rotateFace("counterclockwise");
            score = countPlusPosMatches(newCube);
            if (score > topScore)
            {
                topScore = score;
                Moves newMove = new Moves();
                newMove.setMove("f", 0, "counterclockwise");
                plusMoves.Add(newMove);
            }

            newCube.rotateFace("counterclockwise");
            score = countPlusPosMatches(newCube);
            if (score > topScore)
            {
                topScore = score;
                Moves newMove = new Moves();
                newMove.setMove("f", 0, "counterclockwise");
                plusMoves.Clear();
                plusMoves.Add(newMove);
                plusMoves.Add(newMove);
            }
            newCube.rotateFace("counterclockwise");
            score = countPlusPosMatches(newCube);
            if (score > topScore)
            {
                topScore = score;
                Moves newMove = new Moves();
                newMove.setMove("f", 0, "clockwise");
                plusMoves.Clear();
                plusMoves.Add(newMove);
            }

            for (int i = 0; i < plusMoves.ToArray().Length; i++)
            {
                Moves newMove = (Moves)plusMoves[i];
                allMoves.Add(newMove);
                makeTempMove(newMove);
            }
        }

        public int countPlusPosMatches(Orientation newCube)
        {
            int score = 0;
            score += plusPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(1), 1, 2, 1, 3, 2);
            score += plusPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(2), 2, 1, 2, 2, 3);
            score += plusPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(5), 3, 2, 5, 1, 2);
            score += plusPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(4), 2, 3, 4, 2, 1);
            return score;
        }

        public int countPlusOrientMatches(Orientation newCube)
        {
            int score = 0;
            score += plusOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(1), 1, 2, 1, 3, 2);
            score += plusOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(2), 2, 1, 2, 2, 3);
            score += plusOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(5), 3, 2, 5, 1, 2);
            score += plusOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(4), 2, 3, 4, 2, 1);
            return score;
        }

        public int countCornerPosMatches(Orientation newCube)
        {
            int score = 0;
            score += cornerPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(1), newCube.getFaceColor(2),
                1, 1,
                1, 3, 1,
                2, 1, 3);
            score += cornerPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(2), newCube.getFaceColor(5),
                3, 1,
                2, 3, 3,
                5, 1, 1);
            score += cornerPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(5), newCube.getFaceColor(4),
                3, 3,
                5, 1, 3,
                4, 3, 1);
            score += cornerPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(4), newCube.getFaceColor(1),
                1, 3,
                4, 1, 1,
                1, 3, 3);
            return score;
        }

        public int countCornerOrientMatches(Orientation newCube)
        {
            int score = 0;
            score += cornerOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(1), newCube.getFaceColor(2),
                1, 1,
                1, 3, 1,
                2, 1, 3);
            score += cornerOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(2), newCube.getFaceColor(5),
                3, 1,
                2, 3, 3,
                5, 1, 1);
            score += cornerOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(5), newCube.getFaceColor(4),
                3, 3,
                5, 1, 3,
                4, 3, 1);
            score += cornerOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(4), newCube.getFaceColor(1),
                1, 3,
                4, 1, 1,
                1, 3, 3);
            return score;
        }

        public int plusPosMatch(Orientation newCube, String opposite, String face, int x, int y, int f, int fx, int fy)
        {
            if ((newCube.getColor(3, x, y).Equals(opposite) && newCube.getColor(f, fx, fy).Equals(face)) 
                || (newCube.getColor(3, x, y).Equals(face) && newCube.getColor(f, fx, fy).Equals(opposite)))
            {
                return 1;
            }
            return 0;
        }

        public int plusOrientMatch(Orientation newCube, String opposite, String face, int x, int y, int f, int fx, int fy)
        {
            if (newCube.getColor(3, x, y).Equals(opposite) && newCube.getColor(f, fx, fy).Equals(face))
            {
                return 1;
            }
            return 0;
        }

        public int cornerPosMatch(Orientation newCube, String opposite, String face1, String face2, int x, int y, int f, int fx, int fy, int f2, int f2x, int f2y)
        {
            if ((newCube.getColor(3, x, y).Equals(opposite) && newCube.getColor(f, fx, fy).Equals(face1) && newCube.getColor(f2, f2x, f2y).Equals(face2))
                || (newCube.getColor(3, x, y).Equals(face2) && newCube.getColor(f, fx, fy).Equals(opposite) && newCube.getColor(f2, f2x, f2y).Equals(face1))
                || (newCube.getColor(3, x, y).Equals(face1) && newCube.getColor(f, fx, fy).Equals(face2) && newCube.getColor(f2, f2x, f2y).Equals(opposite)))
            {
                return 1;
            }
            return 0;
        }

        public int cornerOrientMatch(Orientation newCube, String opposite, String face1, String face2, int x, int y, int f, int fx, int fy, int f2, int f2x, int f2y)
        {
            if ((newCube.getColor(3, x, y).Equals(opposite) && newCube.getColor(f, fx, fy).Equals(face1) && newCube.getColor(f2, f2x, f2y).Equals(face2)))
            {
                return 1;
            }
            return 0;
        }

        public bool checkPlusPositions()
        {
            return (countPlusPosMatches(tempCube) == 4);
        }

        public bool checkPlusOrientations()
        {
            return (countPlusOrientMatches(tempCube) == 4);
        }

        public bool checkCornerPositions()
        {
            return (countCornerPosMatches(tempCube) == 4);
        }

        public bool checkCornerOrientations()
        {
            return (countCornerOrientMatches(tempCube) == 4);
        }

        public bool[] whichPlusPos(Orientation newCube)
        {
            bool[] t = new bool[5];
            t[1] = (plusPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(1), 1, 2, 1, 3, 2) == 1);
            t[2] = (plusPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(2), 2, 1, 2, 2, 3) == 1);
            t[3] = (plusPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(5), 3, 2, 5, 1, 2) == 1);
            t[4] = (plusPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(4), 2, 3, 4, 2, 1) == 1);
            return t;
        }

        public bool[] whichPlusOrient(Orientation newCube)
        {
            bool[] t = new bool[5];
            t[1] = (plusOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(1), 1, 2, 1, 3, 2) == 1);
            t[2] = (plusOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(2), 2, 1, 2, 2, 3) == 1);
            t[3] = (plusOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(5), 3, 2, 5, 1, 2) == 1);
            t[4] = (plusOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(4), 2, 3, 4, 2, 1) == 1);
            return t;
        }

        public bool[] whichCornerPos(Orientation newCube)
        {
            bool[] t = new bool[5];
            t[1] = (cornerPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(1), newCube.getFaceColor(2),
                1, 1, 
                1, 3, 1, 
                2, 1, 3) == 1);
            t[2] = (cornerPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(2), newCube.getFaceColor(5),
                3, 1, 
                2, 3, 3,
                5, 1, 1) == 1);
            t[3] = (cornerPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(5), newCube.getFaceColor(4),
                3, 3, 
                5, 1, 3,
                4, 3, 1) == 1);
            t[4] = (cornerPosMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(4), newCube.getFaceColor(1),
                1, 3, 
                4, 1, 1,
                1, 3, 3) == 1);
            return t;
        }

        public bool[] whichCornerOrient(Orientation newCube)
        {
            bool[] t = new bool[5];
            t[1] = (cornerOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(1), newCube.getFaceColor(2),
                1, 1,
                1, 3, 1,
                2, 1, 3) == 1);
            t[2] = (cornerOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(2), newCube.getFaceColor(5),
                3, 1,
                2, 3, 3,
                5, 1, 1) == 1);
            t[3] = (cornerOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(5), newCube.getFaceColor(4),
                3, 3,
                5, 1, 3,
                4, 3, 1) == 1);
            t[4] = (cornerOrientMatch(newCube, newCube.getFaceColor(3), newCube.getFaceColor(4), newCube.getFaceColor(1),
                1, 3,
                4, 1, 1,
                1, 3, 3) == 1);
            return t;
        }

        public void plusPosition()
        {
            bool[] plus = whichPlusPos(tempCube);
            if (countPlusPosMatches(tempCube) == 2)
            {
                if ((plus[1] && plus[3]) || (plus[2] && plus[4]))
                {
                    if (plus[1] && plus[3])
                    {
                        addMove("f", 0, "clockwise");
                        addMove("f", 0, "clockwise");
                    }
                    sequencePlusPos();
                    addMove("f", 0, "counterclockwise");
                    addMove(tempCube.getFaceColor(4));
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(2));
                    sequencePlusPos();
                }
                else // Two matching are not on opposite sides.
                {
                    if (plus[1] && plus[2])
                    {
                        addMove(tempCube.getFaceColor(4));
                        addMove(tempCube.getFaceColor(5));
                        addMove(tempCube.getFaceColor(2));
                    }
                    else if (plus[1] && plus[4])
                    {
                        addMove(tempCube.getFaceColor(4));
                        addMove(tempCube.getFaceColor(5));
                        addMove(tempCube.getFaceColor(5));
                        addMove(tempCube.getFaceColor(2));
                    }
                    else if (plus[3] && plus[4])
                    {
                        addMove(tempCube.getFaceColor(4));
                        addMove(tempCube.getFaceColor(1));
                        addMove(tempCube.getFaceColor(2));
                    }
                    sequencePlusPos();
                }
            }
        }

        public void plusOrientation()
        {
            bool[] plus = whichPlusOrient(tempCube);
            bool firstTime = true;
            int firstBlock = 0;

            if (!plus[1])
            {
                addMove(tempCube.getFaceColor(4));
                addMove(tempCube.getFaceColor(1));
                addMove(tempCube.getFaceColor(2));
                if (firstTime)
                {
                    firstBlock = 1;
                    firstTime = false;
                }
                sequencePlusOrient();
            }
            if (!plus[2])
            {
                if (firstTime)
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(2));
                    firstBlock = 2;
                    firstTime = false;
                }
                else
                {
                    if (firstBlock == 1)
                    {
                        addMove("f", 0, "counterclockwise");
                    }
                }
                sequencePlusOrient();
            }
            if (!plus[3])
            {
                if (firstTime)
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove(tempCube.getFaceColor(5));
                    addMove(tempCube.getFaceColor(2));
                    firstBlock = 3;
                    firstTime = false;
                }
                else
                {
                    if (firstBlock == 1)
                    {
                        addMove("f", 0, "counterclockwise");
                        addMove("f", 0, "counterclockwise");
                    }
                    else if (firstBlock == 2)
                    {
                        addMove("f", 0, "counterclockwise");
                    }
                }
                sequencePlusOrient();
            }
            if (!plus[4])
            {
                if (firstTime)
                {
                    firstBlock = 4;
                    firstTime = false;
                }
                else
                {
                    if (firstBlock == 1)
                    {
                        addMove("f", 0, "clockwise");
                    }
                    else if (firstBlock == 2)
                    {
                        addMove("f", 0, "counterclockwise");
                        addMove("f", 0, "counterclockwise");
                    }
                    else if (firstBlock == 3)
                    {
                        addMove("f", 0, "counterclockwise");
                    }
                }
                sequencePlusOrient();
            }
            bestPlusPosition();
        }

        public void cornerPosition()
        {
            int correct = countCornerPosMatches(tempCube);
            bool[] corner;
            int tries = 0;
            while ((correct < 4) && (tries < 200))
            {
                corner = whichCornerPos(tempCube);
                if (correct == 1)
                {
                    if (corner[2])
                    {
                        addMove(tempCube.getFaceColor(4));
                        addMove(tempCube.getFaceColor(1));
                        addMove(tempCube.getFaceColor(2));
                    }
                    else if (corner[3])
                    {
                        addMove(tempCube.getFaceColor(4));
                        addMove(tempCube.getFaceColor(1));
                        addMove(tempCube.getFaceColor(1));
                        addMove(tempCube.getFaceColor(2));
                    }
                    else if (corner[4])
                    {
                        addMove(tempCube.getFaceColor(4));
                        addMove(tempCube.getFaceColor(5));
                        addMove(tempCube.getFaceColor(2));
                    }
                }
                sequenceCornerPos();
                correct = countCornerPosMatches(tempCube);
                tries++;
            }
        }

        public void cornerOrientation()
        {
            bool[] corner = whichCornerOrient(tempCube);
            bool firstTime = true;
            int firstBlock = 0;

            if (!corner[3])
            {
                if (firstTime)
                {
                    firstTime = false;
                    firstBlock = 3;
                }
                bool solved = false;
                while (!solved)
                {
                    sequenceCornerOrient();
                    solved = !(tempCube.getColor(4, 3, 1).Equals(tempCube.getFaceColor(3)));
                }
            }
            if (!corner[2])
            {
                if (firstTime)
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove(tempCube.getFaceColor(5));
                    addMove(tempCube.getFaceColor(2));
                    firstTime = false;
                    firstBlock = 2;
                }
                else
                {
                    if (firstBlock == 3)
                    {
                        addMove("f", 0, "clockwise");
                    }
                }
                bool solved = false;
                while (!solved)
                {
                    sequenceCornerOrient();
                    solved = !(tempCube.getColor(4, 3, 1).Equals(tempCube.getFaceColor(3)));
                }
            }
            if (!corner[1])
            {
                if (firstTime)
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(2));
                    firstTime = false;
                    firstBlock = 1;
                }
                else
                {
                    if (firstBlock == 3)
                    {
                        if (!corner[2])
                        {
                            addMove("f", 0, "clockwise");
                        }
                        else // Corner 2 was fine, move twice.
                        {
                            addMove("f", 0, "clockwise");
                            addMove("f", 0, "clockwise");
                        }
                    }
                    else if (firstBlock == 2)
                    {
                        addMove("f", 0, "clockwise");
                    }
                }
                bool solved = false;
                while (!solved)
                {
                    sequenceCornerOrient();
                    solved = !(tempCube.getColor(4, 3, 1).Equals(tempCube.getFaceColor(3)));
                }
            }
            if (!corner[4])
            {
                if (firstTime)
                {
                    addMove(tempCube.getFaceColor(4));
                    addMove(tempCube.getFaceColor(1));
                    addMove(tempCube.getFaceColor(2));
                    firstTime = false;
                    firstBlock = 4;
                }
                else
                {
                    if (firstBlock == 1)
                    {
                        addMove("f", 0, "clockwise");
                    }
                    else if (firstBlock == 2)
                    {
                        if (!corner[1])
                        {
                            addMove("f", 0, "clockwise");
                        }
                        else
                        {
                            addMove("f", 0, "counterclockwise");
                            addMove("f", 0, "counterclockwise");
                        }
                    }
                    else if (firstBlock == 3)
                    {
                        if (!corner[2])
                        {
                            if (!corner[1])
                            {
                                addMove("f", 0, "clockwise");
                            }
                            else
                            {
                                addMove("f", 0, "clockwise");
                                addMove("f", 0, "clockwise");
                            }
                        }
                        else if (!corner[1])
                        {
                            addMove("f", 0, "clockwise");
                        }
                        else
                        {
                            addMove("f", 0, "counterclockwise");
                        }
                    }
                }
                bool solved = false;
                while (!solved)
                {
                    sequenceCornerOrient();
                    solved = !(tempCube.getColor(4, 3, 1).Equals(tempCube.getFaceColor(3)));
                }
            }
            bestPlusPosition();
        }

        public void sequencePlusPos()
        {
            addMove(tempCube.getFaceColor(4));
            addMove("r", 1, "left");
            addMove("f", 0, "clockwise");
            addMove("c", 3, "up");
            addMove("r", 1, "left");
            addMove("c", 3, "down");
            addMove("r", 1, "right");
            addMove("f", 0, "counterclockwise");
            addMove(tempCube.getFaceColor(2));
        }

        public void sequencePlusOrient()
        {
            addMove(tempCube.getFaceColor(4));
            addMove("f", 0, "counterclockwise");
            addMove("r", 2, "left");
            addMove("f", 0, "counterclockwise");
            addMove("r", 2, "left");
            addMove("f", 0, "counterclockwise");
            addMove("r", 2, "left");
            addMove("f", 0, "counterclockwise");
            addMove("r", 2, "left");
            addMove(tempCube.getFaceColor(2));
        }

        public void sequenceCornerPos()
        {
            addMove(tempCube.getFaceColor(4));
            addMove("f", 0, "clockwise");
            addMove("r", 3, "right");
            addMove("f", 0, "clockwise");
            addMove("f", 0, "clockwise");
            addMove("r", 3, "right");
            addMove("r", 3, "right");
            addMove("f", 0, "clockwise");
            addMove("f", 0, "clockwise");
            addMove("r", 3, "left");
            addMove("f", 0, "counterclockwise");
            addMove("r", 1, "left");

            addMove("f", 0, "clockwise");
            addMove("r", 3, "right");
            addMove("f", 0, "clockwise");
            addMove("f", 0, "clockwise");
            addMove("r", 3, "right");
            addMove("r", 3, "right");
            addMove("f", 0, "clockwise");
            addMove("f", 0, "clockwise");
            addMove("r", 3, "left");
            addMove("f", 0, "counterclockwise");
            addMove("r", 1, "right");
            addMove(tempCube.getFaceColor(2));
        }

        public void sequenceCornerOrient()
        {
            addMove(tempCube.getFaceColor(4));
            addMove("c", 3, "up");
            addMove("f", 0, "counterclockwise");
            addMove("c", 3, "down");
            addMove("f", 0, "clockwise");

            addMove("c", 3, "up");
            addMove("f", 0, "counterclockwise");
            addMove("c", 3, "down");
            addMove("f", 0, "clockwise");
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
