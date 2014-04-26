using System;

namespace RubiksCubeSolver
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class BlockInfo
    {
        private int layerSolving, layerFound;

        private bool rightPosWrongOrient, onLeft, onRight, onTop, onBottom;
        private bool leftTop, leftBottom, rightTop, rightBottom;
        private bool left, right, top, bottom;

        private bool topTopRight, topBottomLeft, topBottomRight;
        private bool bottomTopLeft, bottomTopRight, bottomBottomLeft, bottomBottomRight;

        private String midColor, topColor, leftColor, rightColor, bottomColor, oppColor;

        private int[] t;

        private Orientation cube;

        /// <summary>
        /// Creates BlockInfo object with relevant positional info.
        /// </summary>
        /// <param name="theCube">Current cube orientation.</param>
        /// <param name="lSolve">Layer attempting to be solved.</param>
        /// <param name="lFound">Layer present block is found.</param>
        /// <param name="x">X position of block needed to be solved.</param>
        /// <param name="y">Y position of block needed to be solved.</param>
        /// <param name="t">Block position info.</param>
        public BlockInfo(Orientation theCube, int lSolve, int lFound, int x, int y, int[] thing)
        {
            layerSolving = lSolve;
            layerFound = lFound;
            rightPosWrongOrient = false;

            // Edge Variables
            onLeft = false;
            onRight = false;
            onTop = false;
            onBottom = false;
            leftTop = false;
            leftBottom = false;
            rightTop = false;
            rightBottom = false;
            left = false;
            right = false;
            top = false;
            bottom = false;

            // Corner Variables
            topTopRight = false;
            topBottomLeft = false;
            topBottomRight = false;
            bottomTopLeft = false;
            bottomTopRight = false;
            bottomBottomLeft = false;
            bottomBottomRight = false;

            cube = theCube;
            t = thing;

            midColor = cube.getFaceColor(3);
            topColor = cube.getFaceColor(2);
            leftColor = cube.getFaceColor(1);
            rightColor = cube.getFaceColor(5);
            bottomColor = cube.getFaceColor(4);
            oppColor = cube.getFaceColor(6);

            if (layerSolving == 1)
            {
                if ((x == 2) && (y == 1))
                {
                    solveL1X2Y1();
                }
                else if ((x == 3) && (y == 2))
                {
                    solveL1X3Y2();
                }
                else if ((x == 2) && (y == 3))
                {
                    solveL1X2Y3();
                }
                else if ((x == 1) && (y == 2))
                {
                    solveL1X1Y2();
                }
                else if ((x == 1) && (y == 1))
                {
                    solveL1X1Y1();
                }
                else if ((x == 3) && (y == 1))
                {
                    solveL1X3Y1();
                }
                else if ((x == 3) && (y == 3))
                {
                    solveL1X3Y3();
                }
                else if ((x == 1) && (y == 3))
                {
                    solveL1X1Y3();
                }
            }

            else if (layerSolving == 2)
            {
                solveL2();
            }

            else
            {
            }
        }

        public int getLayer()
        { return layerFound; }

        public int getLayerBeingSolved()
        { return layerSolving; }

        public bool isRightPosWrongOrient()
        { return rightPosWrongOrient; }

        public bool isOnLeft()
        { return onLeft; }

        public bool isOnRight()
        { return onRight; }

        public bool isOnTop()
        { return onTop; }

        public bool isOnBottom()
        { return onBottom; }

        public bool isLeftTop()
        { return leftTop; }

        public bool isLeftBottom()
        { return leftBottom; }

        public bool isRightTop()
        { return rightTop; }

        public bool isRightBottom()
        { return rightBottom; }

        public bool isLeft()
        { return left; }

        public bool isRight()
        { return right; }

        public bool isTop()
        { return top; }

        public bool isBottom()
        { return bottom; }

        public bool isTopTopRight()
        { return topTopRight; }

        public bool isTopBottomRight()
        { return topBottomRight; }

        public bool isTopBottomLeft()
        { return topBottomLeft; }

        public bool isBottomTopLeft()
        { return bottomTopLeft; }

        public bool isBottomTopRight()
        { return bottomTopRight; }

        public bool isBottomBottomRight()
        { return bottomBottomRight; }

        public bool isBottomBottomLeft()
        { return bottomBottomLeft; }

        public void solveL1X2Y1()
        {
            if (layerFound == 1)
            {
                rightPosWrongOrient = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(midColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 1));
                onLeft = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(midColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                onLeft = onLeft || ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                onBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(midColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 3));
                onBottom = onBottom || ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 1));
                onRight = ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(midColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                onRight = onRight || ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
            }
            else if (layerFound == 2)
            {
                leftTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                leftTop = leftTop || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 1) && (t[5] == 2));
                leftBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                leftBottom = leftBottom || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 3) && (t[5] == 2));
                rightTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                rightTop = rightTop || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 1) && (t[5] == 2));
                rightBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                rightBottom = rightBottom || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 3) && (t[5] == 2));
            }
            else if (layerFound == 3)
            {
                left = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                left = left || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                top = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                top = top || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                right = ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                right = right || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                bottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
                bottom = bottom || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
            }
        }

        public void solveL1X3Y2()
        {
            if (layerFound == 1)
            {
                rightPosWrongOrient = ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(midColor))
                        && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                onLeft = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(midColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                onLeft = onLeft || ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                onBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(midColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 3));
                onBottom = onBottom || ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 1));
            }
            else if (layerFound == 2)
            {
                leftTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor))
                        && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                leftTop = leftTop || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 1) && (t[5] == 2));
                leftBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                leftBottom = leftBottom || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 3) && (t[5] == 2));
                rightTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                rightTop = rightTop || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 1) && (t[5] == 2));
                rightBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                rightBottom = rightBottom || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 3) && (t[5] == 2));
            }
            else
            {
                left = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor))
                        && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                left = left || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                top = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                top = top || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                right = ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                right = right || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                bottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
                bottom = bottom || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
            }
        }

        public void solveL1X2Y3()
        {
            if (layerFound == 1)
            {
                rightPosWrongOrient = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(midColor))
                        && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 3));
                onLeft = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(midColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                onLeft = onLeft || ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
            }
            else if (layerFound == 2)
            {
                leftTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor))
                        && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                leftTop = leftTop || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 1) && (t[5] == 2));
                leftBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                leftBottom = leftBottom || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 3) && (t[5] == 2));
                rightTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                rightTop = rightTop || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 1) && (t[5] == 2));
                rightBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                rightBottom = rightBottom || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 3) && (t[5] == 2));
            }
            else
            {
                left = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor))
                        && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                left = left || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                top = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                top = top || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                right = ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                right = right || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                bottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
                bottom = bottom || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
            }
        }

        public void solveL1X1Y2()
        {
            if (layerFound == 1)
            {
                rightPosWrongOrient = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(midColor))
                        && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
            }
            else if (layerFound == 2)
            {
                leftTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor))
                        && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                leftTop = leftTop || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 1) && (t[5] == 2));
                leftBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                leftBottom = leftBottom || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 3) && (t[5] == 2));
                rightTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                rightTop = rightTop || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 1) && (t[5] == 2));
                rightBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                rightBottom = rightBottom || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 3) && (t[5] == 2));
            }
            else
            {
                left = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor))
                        && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                left = left || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                top = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                top = top || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                right = ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                right = right || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                bottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
                bottom = bottom || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
            }
        }

        public void solveL1X1Y1()
        {
            if (layerFound == 1)
            {
                rightPosWrongOrient = 
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 1));
                rightPosWrongOrient = rightPosWrongOrient ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 1));
                topTopRight = 
                    ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 1));
                topTopRight = topTopRight ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 1));
                topTopRight = topTopRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 3));
                topBottomRight =
                    ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 1));
                topBottomRight = topBottomRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 3));
                topBottomRight = topBottomRight ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 3));
                topBottomLeft =
                    ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 3));
                topBottomLeft = topBottomLeft ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 3));
                topBottomLeft = topBottomLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 1));
            }
            else if (layerFound == 3)
            {
                bottomTopLeft =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopLeft = bottomTopLeft ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopLeft = bottomTopLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight = bottomTopRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight = bottomTopRight ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomBottomRight =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomRight = bottomBottomRight ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomRight = bottomBottomRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft = bottomBottomLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft = bottomBottomLeft ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
            }
        }

        public void solveL1X3Y1()
        {
            if (layerFound == 1)
            {
                rightPosWrongOrient =
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 1));
                rightPosWrongOrient = rightPosWrongOrient ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 3));
                topBottomRight =
                    ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 1));
                topBottomRight = topBottomRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 3));
                topBottomRight = topBottomRight ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 3));
                topBottomLeft =
                    ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 3));
                topBottomLeft = topBottomLeft ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 3));
                topBottomLeft = topBottomLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 1));
            }
            else if (layerFound == 3)
            {
                bottomTopLeft =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopLeft = bottomTopLeft ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopLeft = bottomTopLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight = bottomTopRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight = bottomTopRight ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomBottomRight =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomRight = bottomBottomRight ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomRight = bottomBottomRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft = bottomBottomLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft = bottomBottomLeft ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
            }
        }

        public void solveL1X3Y3()
        {
            if (layerFound == 1)
            {
                rightPosWrongOrient =
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 3));
                rightPosWrongOrient = rightPosWrongOrient ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 3));
                topBottomLeft =
                    ((t[0] == cube.getFaceNum(midColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 1) && (t[8] == 3));
                topBottomLeft = topBottomLeft ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 3));
                topBottomLeft = topBottomLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 1));
            }
            else if (layerFound == 3)
            {
                bottomTopLeft =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopLeft = bottomTopLeft ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopLeft = bottomTopLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight = bottomTopRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight = bottomTopRight ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomBottomRight =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomRight = bottomBottomRight ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomRight = bottomBottomRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft = bottomBottomLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft = bottomBottomLeft ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
            }
        }

        public void solveL1X1Y3()
        {
            if (layerFound == 1)
            {
                rightPosWrongOrient =
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(midColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 3) && (t[8] == 3));
                rightPosWrongOrient = rightPosWrongOrient ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(midColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 1));
            }
            else if (layerFound == 3)
            {
                bottomTopLeft =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopLeft = bottomTopLeft ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopLeft = bottomTopLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(topColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight = bottomTopRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomTopRight = bottomTopRight ||
                    ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 1) && (t[5] == 1) && (t[8] == 1));
                bottomBottomRight =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomRight = bottomBottomRight ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 3) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomRight = bottomBottomRight ||
                    ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft =
                    ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor)) && (t[6] == cube.getFaceNum(bottomColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft = bottomBottomLeft ||
                    ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor)) && (t[6] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 1) && (t[7] == 3) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
                bottomBottomLeft = bottomBottomLeft ||
                    ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor)) && (t[6] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[7] == 1) && (t[2] == 3) && (t[5] == 3) && (t[8] == 3));
            }
        }

        public void solveL2()
        {
            if (layerFound == 2)
            {
                leftTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                leftTop = leftTop || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 1) && (t[5] == 2));
                leftBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 1) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                leftBottom = leftBottom || ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 1) && (t[2] == 3) && (t[5] == 2));
                rightTop = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 1));
                rightTop = rightTop || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 1) && (t[5] == 2));
                rightBottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 3) && (t[4] == 2) && (t[2] == 2) && (t[5] == 3));
                rightBottom = rightBottom || ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 3) && (t[2] == 3) && (t[5] == 2));
            }
            else if (layerFound == 3)
            {
                left = ((t[0] == cube.getFaceNum(leftColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                left = left || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(leftColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                top = ((t[0] == cube.getFaceNum(topColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                top = top || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(topColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 1) && (t[5] == 1));
                right = ((t[0] == cube.getFaceNum(rightColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 3) && (t[4] == 1) && (t[2] == 2) && (t[5] == 2));
                right = right || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(rightColor))
                    && (t[1] == 1) && (t[4] == 3) && (t[2] == 2) && (t[5] == 2));
                bottom = ((t[0] == cube.getFaceNum(bottomColor)) && (t[3] == cube.getFaceNum(oppColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
                bottom = bottom || ((t[0] == cube.getFaceNum(oppColor)) && (t[3] == cube.getFaceNum(bottomColor))
                    && (t[1] == 2) && (t[4] == 2) && (t[2] == 3) && (t[5] == 3));
            }
        }
    }
}