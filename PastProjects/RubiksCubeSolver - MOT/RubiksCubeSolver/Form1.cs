using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RubiksCubeSolver
{
    public partial class Form1 : Form
    {
        Label[] block;
        Label[] smBlock;
        Button r1r, r2r, r3r, r1l, r2l, r3l,
            c1u, c2u, c3u, c1d, c2d, c3d,
            white, green, red, blue, yellow, orange,
            clockwise, counterclockwise,
            solveL1, solveL2, solveL3,
            rowButton, resetButton;
        Orientation cube;
        Label actionsTaken, actionsTaken2, actionsTaken3, actionsTaken4, actionsTaken5, 
            changeForeFace, rotateFrontFace, 
            solve, movesTaken, movesBox;
        int numActions, numMoves;
        ArrayList step1, step2, step3;

        MainForm main;

        int moveTemp;

        public Form1(MainForm m)
        {
            this.main = m;

            moveTemp = 0;

            numMoves = 0;
            numActions = 0;
            cube = new Orientation();
            InitializeComponent();
            Size blockSize = new Size(50, 50);
            Size smBlockSize = new Size(20, 20);
            Size newFaceSize = new Size(50, 30);
            block = new Label[10];
            smBlock = new Label[55];
            actionsTaken = new Label();
            actionsTaken2 = new Label();
            actionsTaken3 = new Label();
            actionsTaken4 = new Label();
            actionsTaken5 = new Label();
            movesTaken = new Label();
            movesBox = new Label();
            changeForeFace = new Label();
            rotateFrontFace = new Label();
            solve = new Label();
            white = new Button();
            green = new Button();
            red = new Button();
            blue = new Button();
            yellow = new Button();
            orange = new Button();
            clockwise = new Button();
            counterclockwise = new Button();
            solveL1 = new Button();
            solveL2 = new Button();
            solveL3 = new Button();

            rotateFrontFace.Text = "Rotate Front Face:";
            rotateFrontFace.Size = new Size(150, 20);
            rotateFrontFace.Location = new Point(320, 10);
            Bitmap cw = new Bitmap("c:\\clockwise.bmp");
            clockwise.Text = "";
            clockwise.BackgroundImage = cw;
            clockwise.BackgroundImageLayout = ImageLayout.Center;
            clockwise.Size = new Size(48, 48);
            clockwise.Click += new EventHandler(CRotate_Clicked);
            clockwise.Location = new Point(320, 30);
            Bitmap ccw = new Bitmap("c:\\counter-clockwise.bmp"); 
            counterclockwise.Text = "";
            counterclockwise.BackgroundImage = ccw;
            counterclockwise.BackgroundImageLayout = ImageLayout.Center;
            counterclockwise.Size = new Size(48, 48);
            counterclockwise.Click += new EventHandler(CCRotate_Clicked);
            counterclockwise.Location = new Point(375, 30);
            this.Controls.Add(clockwise);
            this.Controls.Add(counterclockwise);

            changeForeFace.Text = "Change Front Face:";
            changeForeFace.Size = new Size(150, 20);
            changeForeFace.Location = new Point(320, 100);
            white.Text = "White";
            white.Size = newFaceSize;
            white.Click += new EventHandler(FaceChange_Clicked);
            white.Location = new Point(320, 120);
            green.Text = "Green";
            green.Size = newFaceSize;
            green.Click += new EventHandler(FaceChange_Clicked);
            green.Location = new Point(370, 120);
            red.Text = "Red";
            red.Size = newFaceSize;
            red.Click += new EventHandler(FaceChange_Clicked);
            red.Location = new Point(420, 120);
            blue.Text = "Blue";
            blue.Size = newFaceSize;
            blue.Click += new EventHandler(FaceChange_Clicked);
            blue.Location = new Point(320, 150);
            yellow.Text = "Yellow";
            yellow.Size = newFaceSize;
            yellow.Click += new EventHandler(FaceChange_Clicked);
            yellow.Location = new Point(370, 150);
            orange.Text = "Orange";
            orange.Size = newFaceSize;
            orange.Click += new EventHandler(FaceChange_Clicked);
            orange.Location = new Point(420, 150);

            solve.Text = "Solve Cube, Step by Step:";
            solve.Size = new Size(150, 20);
            solve.Location = new Point(320, 200);
            solveL1.Text = "Layer 1";
            solveL1.Size = new Size(150, 30);
            solveL1.Click += new EventHandler(Solve1_Clicked);
            solveL1.Location = new Point(320, 220);
            solveL1.Enabled = true;
            solveL2.Text = "Layer 2";
            solveL2.Size = new Size(150, 30);
            solveL2.Click += new EventHandler(Solve2_Clicked);
            solveL2.Location = new Point(320, 250);
            solveL2.Enabled = false;
            solveL3.Text = "Layer 3";
            solveL3.Size = new Size(150, 30);
            solveL3.Click += new EventHandler(Solve3_Clicked);
            solveL3.Location = new Point(320, 280);
            solveL3.Enabled = false;

            this.Controls.Add(rotateFrontFace);
            this.Controls.Add(changeForeFace);
            this.Controls.Add(solve);
            this.Controls.Add(white);
            this.Controls.Add(green);
            this.Controls.Add(red);
            this.Controls.Add(blue);
            this.Controls.Add(yellow);
            this.Controls.Add(orange);
            this.Controls.Add(solveL1);
            this.Controls.Add(solveL2);
            this.Controls.Add(solveL3);
           
            resetButton = new Button();
            resetButton.Text = "Reset Cube!";
            resetButton.Size = new Size(150, 30);

            r1r = new Button();
            r1r.Text = "R1 ->";
            r1r.Size = new Size(50, 23);
            r2r = new Button();
            r2r.Text = "R2 ->";
            r2r.Size = new Size(50, 23);
            r3r = new Button();
            r3r.Text = "R3 ->";
            r3r.Size = new Size(50, 23);
            r1l = new Button();
            r1l.Text = "<- R1";
            r1l.Size = new Size(50, 23);
            r2l = new Button();
            r2l.Text = "<- R2";
            r2l.Size = new Size(50, 23);
            r3l = new Button();
            r3l.Text = "<- R3";
            r3l.Size = new Size(50, 23);
            
            c1d = new Button();
            c1d.Text = "C1 \\/";
            c1d.Size = new Size(50, 23);
            c2d = new Button();
            c2d.Size = new Size(50, 23);
            c2d.Text = "C2 \\/";
            c3d = new Button();
            c3d.Size = new Size(50, 23);
            c3d.Text = "C3 \\/";
            c1u = new Button();
            c1u.Text = "C1 ^";
            c1u.Size = new Size(50, 23);
            c2u = new Button();
            c2u.Text = "C2 ^";
            c2u.Size = new Size(50, 23);
            c3u = new Button();
            c3u.Text = "C3 ^";
            c3u.Size = new Size(50, 23);

            int xPos = 15, yPos = 35;
            int z = 1;
            for (int y = 1; y <= 3; y++)
            {
                if (y == 1)
                {
                    c1u.Click += new EventHandler(C_Clicked);
                    c1u.Location = new Point(xPos + 55, yPos - 28);
                    c2u.Click += new EventHandler(C_Clicked);
                    c2u.Location = new Point(xPos + 55 + 50 + 5, yPos - 28);
                    c3u.Click += new EventHandler(C_Clicked);
                    c3u.Location = new Point(xPos + 55 + 50 + 50 + 5 + 5, yPos - 28);
                    this.Controls.Add(c1u);
                    this.Controls.Add(c2u);
                    this.Controls.Add(c3u);
                }
                if (y == 1)
                {
                    rowButton = r1l;
                }
                else if (y == 2)
                {
                    rowButton = r2l;
                }
                else
                {
                    rowButton = r3l;
                }
                rowButton.Click += new EventHandler(R_Clicked);
                rowButton.Location = new Point(xPos, yPos + 15);
                this.Controls.Add(rowButton);
                xPos += 55;
                for (int x = 1; x <= 3; x++)
                {
                    block[z] = new Label();

                    block[z].UseMnemonic = true;
                    block[z].Text = "";
                    Color theColor = convertColor(cube.getColor(3, x, y));
                    block[z].Location = new Point(xPos, yPos);
                    block[z].BackColor = theColor;
                    block[z].ForeColor = Color.Black;
                    block[z].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    block[z].Size = blockSize;
                    this.Controls.Add(block[z]);

                    xPos += 55;
                    z += 1;
                }
                if (y == 1)
                {
                    rowButton = r1r;
                }
                else if (y == 2)
                {
                    rowButton = r2r;
                }
                else
                {
                    rowButton = r3r;
                }
                rowButton.Click += new EventHandler(R_Clicked);
                rowButton.Location = new Point(xPos, yPos + 15);
                this.Controls.Add(rowButton);
                xPos = 15;
                yPos += 55;
            }
            resetButton.Click += new EventHandler(Reset_Clicked);
            resetButton.Location = new Point(495, 460);
            c1d.Click += new EventHandler(C_Clicked);
            c1d.Location = new Point(xPos + 55, yPos);
            c2d.Click += new EventHandler(C_Clicked);
            c2d.Location = new Point(xPos + 55 + 50 + 5, yPos);
            c3d.Click += new EventHandler(C_Clicked);
            c3d.Location = new Point(xPos + 55 + 50 + 50 + 5 + 5, yPos);
            this.Controls.Add(c1d);
            this.Controls.Add(c2d);
            this.Controls.Add(c3d);
            this.Controls.Add(resetButton);

            actionsTaken.Text = "Actions Taken:\n--------------------\n";
            actionsTaken.Font = new Font("Arial", 9, FontStyle.Regular);
            actionsTaken.Location = new Point(495, 5);
            actionsTaken.BackColor = Color.LightGray;
            actionsTaken.ForeColor = Color.Black;
            actionsTaken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            actionsTaken.Size = new Size(100, 450);
            actionsTaken2.Text = "";
            actionsTaken2.Font = new Font("Arial", 9, FontStyle.Regular);
            actionsTaken2.Location = new Point(595, 5);
            actionsTaken2.BackColor = Color.LightGray;
            actionsTaken2.ForeColor = Color.Black;
            actionsTaken2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            actionsTaken2.Size = new Size(100, 450);
            actionsTaken3.Text = "";
            actionsTaken3.Font = new Font("Arial", 9, FontStyle.Regular);
            actionsTaken3.Location = new Point(695, 5);
            actionsTaken3.BackColor = Color.LightGray;
            actionsTaken3.ForeColor = Color.Black;
            actionsTaken3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            actionsTaken3.Size = new Size(100, 450);
            actionsTaken4.Text = "";
            actionsTaken4.Font = new Font("Arial", 9, FontStyle.Regular);
            actionsTaken4.Location = new Point(795, 5);
            actionsTaken4.BackColor = Color.LightGray;
            actionsTaken4.ForeColor = Color.Black;
            actionsTaken4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            actionsTaken4.Size = new Size(100, 450);
            actionsTaken5.Text = "";
            actionsTaken5.Font = new Font("Arial", 9, FontStyle.Regular);
            actionsTaken5.Location = new Point(895, 5);
            actionsTaken5.BackColor = Color.LightGray;
            actionsTaken5.ForeColor = Color.Black;
            actionsTaken5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            actionsTaken5.Size = new Size(100, 450);
            this.Controls.Add(actionsTaken);
            this.Controls.Add(actionsTaken2);
            this.Controls.Add(actionsTaken3);
            this.Controls.Add(actionsTaken4);
            this.Controls.Add(actionsTaken5);

            movesTaken.Text = "Number of Moves Taken to Solve:";
            movesTaken.Font = new Font("Arial", 11, FontStyle.Bold);
            movesTaken.Location = new Point(200, 420);
            movesTaken.Size = new Size(300, 20);
            this.Controls.Add(movesTaken);

            movesBox.Text = "0";
            movesBox.Font = new Font("Arial", 15, FontStyle.Bold);
            movesBox.Location = new Point(280, 445);
            movesBox.Size = new Size(60, 40);
            movesBox.BackColor = Color.BlanchedAlmond;
            movesBox.ForeColor = Color.Black;
            movesBox.TextAlign = ContentAlignment.MiddleCenter;
            movesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(movesBox);

            int indent = 15;
            int cubeSize = 80;
            int yinit = 240;
            //TOP, 2
            printSmFace(2, 1, indent + cubeSize, yinit);
            //MIDDLE, 1
            printSmFace(1, 10, indent, yinit + cubeSize);
            //MIDDLE, 3
            printSmFace(3, 19, indent + cubeSize, yinit + cubeSize);
            //MIDDLE, 5
            printSmFace(5, 28, indent + cubeSize + cubeSize, yinit + cubeSize);
            //MIDDLE, 6
            printSmFace(6, 37, indent + cubeSize + cubeSize + cubeSize, yinit + cubeSize);
            //BOTTOM, 4
            printSmFace(4, 46, indent + cubeSize, yinit + cubeSize + cubeSize);

            this.Text = "Steph & Mike's Excellent Rubik's Cube Solver";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleBaseSize = new Size(5, 13);
            this.ClientSize = new Size(1010, 500); //Size except the Title Bar-CaptionHeight
            this.MaximizeBox = false;
        }

        /// <summary>
        /// Prints out small representation of a cube face.
        /// </summary>
        /// <param name="face">Face number.</param>
        /// <param name="index">Label array index.</param>
        /// <param name="xPosStart">x coordinate of left corner.</param>
        /// <param name="yPosStart">y coordinate of left corner.</param>
        public void printSmFace(int face, int index, int xPosStart, int yPosStart)
        {
            Size smBlockSize = new Size(20, 20);
            int xPos = xPosStart;
            int yPos = yPosStart;
            for (int y = 1; y <= 3; y++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    smBlock[index] = new Label();

                    smBlock[index].UseMnemonic = true;
                    smBlock[index].Text = "";
                    Color theColor = convertColor(cube.getColor(face, x, y));
                    smBlock[index].Location = new Point(xPos, yPos);
                    smBlock[index].BackColor = theColor;
                    smBlock[index].ForeColor = Color.Black;
                    smBlock[index].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    smBlock[index].Size = smBlockSize;
                    this.Controls.Add(smBlock[index]);

                    xPos += 25;
                    index += 1;
                }
                yPos += 25;
                xPos = xPosStart;
            }
        }


        public void rIsMoving(int r, String direction)
        {
            cube.moveRow(r, direction);
            refreshBoxes("R" + r.ToString(), direction);

            if (direction.Equals("left"))
            {
                this.main.rotateY(3 - r, -1);
            }
            else if (direction.Equals("right"))
            {
                this.main.rotateY(3 - r, 1);
            }
        }

        public void cIsMoving(int c, String direction)
        {
            cube.moveCol(c, direction);
            refreshBoxes("C" + c.ToString(), direction);

            if (direction.Equals("up"))
            {
                this.main.rotateX(c - 1, -1);
            }
            else if (direction.Equals("down"))
            {
                this.main.rotateX(c - 1, 1);
            }
        }

        public void cRotate()
        {
            cube.rotateFace("clockwise");
            refreshBoxes("rotateFace", "clockwise");

            this.main.rotateZ(2, -1);
        }

        public void ccRotate()
        {
            cube.rotateFace("counterclockwise");
            refreshBoxes("rotateFace", "cntrclckwse");

            this.main.rotateZ(2, 1);
        }

        public void changeTheForeFace(String word)
        {
            int face = cube.getFaceNum(word);
            switch (face)
            {
                case 1:
                    this.main.rotateY(0, 1);
                    this.main.rotateY(1, 1);
                    this.main.rotateY(2, 1);
                    break;
                case 2:
                    this.main.rotateX(0, 1);
                    this.main.rotateX(1, 1);
                    this.main.rotateX(2, 1);
                    break;
                case 4:
                    this.main.rotateX(0, -1);
                    this.main.rotateX(1, -1);
                    this.main.rotateX(2, -1);
                    break;
                case 5:
                    this.main.rotateY(0, -1);
                    this.main.rotateY(1, -1);
                    this.main.rotateY(2, -1);
                    break;
                case 6:
                    this.main.rotateY(0, 1);
                    this.main.rotateY(1, 1);
                    this.main.rotateY(2, 1);
                    this.main.rotateY(0, 1);
                    this.main.rotateY(1, 1);
                    this.main.rotateY(2, 1);
                    break;
                default:
                    break;
            }
            cube.changeFace(word);
            refreshBoxes("rotate", "to " + word);
        }

        /// <summary>
        /// Action for moving a row left or right.
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="e"></param>
        public void R_Clicked(object ob, EventArgs e)
        {
            int r;
            if (ob == r1r || ob == r1l)
            {
                r = 1;
            }
            else if (ob == r2r || ob == r2l)
            {
                r = 2;
            }
            else
            {
                r = 3;
            }
            String direction = "left";
            if (ob.ToString().EndsWith(">"))
            {
                direction = "right";
            }
            rIsMoving(r, direction);
        }

        /// <summary>
        /// Action for moving a column up or down.
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="e"></param>
        public void C_Clicked(object ob, EventArgs e)
        {
            int c;
            if (ob == c1u || ob == c1d)
            {
                c = 1;
            }
            else if (ob == c2u || ob == c2d)
            {
                c = 2;
            }
            else
            {
                c = 3;
            }
            String direction = "down";
            if (ob.ToString().EndsWith("^"))
            {
                direction = "up";
            }
            cIsMoving(c, direction);
        }

        /// <summary>
        /// Rotates fore-face clockwise.
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="e"></param>
        public void CRotate_Clicked(object ob, EventArgs e)
        {
            cRotate();
        }

        /// <summary>
        /// Rotates fore-face clockwise.
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="e"></param>
        public void CCRotate_Clicked(object ob, EventArgs e)
        {
            ccRotate();
        }

        /// <summary>
        /// Returns the Rubik's cube to a solved state.
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="e"></param>
        public void Reset_Clicked(object ob, EventArgs e)
        {
            cube = new Orientation();
            refreshBoxes("reset", "reset");
        }

        /// <summary>
        /// Rotates the entire cube to a specified face.
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="e"></param>
        public void FaceChange_Clicked(object ob, EventArgs e)
        {
            String newColor = ob.ToString();
            String word = "";
            for (int x = 0; x <= newColor.Length - 35; x++)
            {
                if ((newColor[34 + x]).ToString().ToLower() != " ")
                {
                    word += (newColor[34 + x]).ToString().ToLower();
                }
            }
            changeTheForeFace(word);
        }

        public void generateSolution()
        {
            Orientation workingCube = this.cube;

            Layer1 l1 = new Layer1(workingCube);
            ArrayList solution1 = l1.fixLayer1();
            workingCube = l1.getCube();

            Layer2 l2 = new Layer2(workingCube);
            ArrayList solution2 = l2.fixLayer2();
            workingCube = l2.getCube();

            Layer3 l3 = new Layer3(workingCube);
            ArrayList solution3 = l3.fixLayer3();

            ArrayList solution = new ArrayList();

            foreach (Moves move in solution1)
            {
                solution.Add(move);
            }
            foreach (Moves move in solution2)
            {
                solution.Add(move);
            }
            foreach (Moves move in solution3)
            {
                solution.Add(move);
            }

            for (int x = 0; x < solution.Count; x++)
            {
                makeMove((Moves) solution[x]);
                updateNumMoves(((Moves) solution[x]).getWeight(), 0);
            }
        }

        public void Solve1_Clicked(object ob, EventArgs e)
        {
            generateSolution();
            return;
            if (moveTemp == 0)
            {
                Layer1 l1 = new Layer1(cube);
                step1 = new ArrayList();
                step1 = l1.fixLayer1();
                updateNumMoves(0, 1);
                solvingNow(true);
            }
            int numMoves = step1.ToArray().Length;
            if ((numMoves != 0) && !(moveTemp >= numMoves))
            {
                //PUT THIS BACK IN when you'd like to solve in one click!!!!!!!!!!!!!!!!!!!!!!!
                //for (int x = 0; x < numMoves; x++)
                //{
                makeMove((Moves)step1[moveTemp]);
                updateNumMoves(((Moves)step1[moveTemp]).getWeight(), 0);
                //TAKE THIS OUT AFTER TESTING.
                moveTemp += 1;
                if (moveTemp == numMoves)
                {
                    solveL1.Enabled = false;
                    solveL2.Enabled = true;
                    solveL2.Focus();
                    moveTemp = 0;
                }
                //}
            }
        }

        public void Solve2_Clicked(object ob, EventArgs e)
        {
            if (moveTemp == 0)
            {
                Layer2 l2 = new Layer2(cube);
                step2 = new ArrayList();
                step2 = l2.fixLayer2();
                updateNumMoves(0, 2);
            }
            int numMoves = step2.ToArray().Length;
            if ((numMoves != 0) && !(moveTemp >= numMoves))
            {
                //PUT THIS BACK IN when you'd like to solve in one click!!!!!!!!!!!!!!!!!!!!!!!
                //for (int x = 0; x < numMoves; x++)
                //{
                makeMove((Moves)step2[moveTemp]);
                updateNumMoves(((Moves)step2[moveTemp]).getWeight(), 0);
                //TAKE THIS OUT AFTER TESTING.
                moveTemp += 1;
                if (moveTemp == numMoves)
                {
                    solveL2.Enabled = false;
                    solveL3.Enabled = true;
                    solveL3.Focus();
                    moveTemp = 0;
                }
                //}
            }
        }

        public void Solve3_Clicked(object ob, EventArgs e)
        {
            if (moveTemp == 0)
            {
                Layer3 l3 = new Layer3(cube);
                step3 = new ArrayList();
                step3 = l3.fixLayer3();
                updateNumMoves(0, 3);
            }
            int numMoves = step3.ToArray().Length;
            if ((numMoves != 0) && !(moveTemp >= numMoves))
            {
                //PUT THIS BACK IN when you'd like to solve in one click!!!!!!!!!!!!!!!!!!!!!!!
                //for (int x = 0; x < numMoves; x++)
                //{
                makeMove((Moves)step3[moveTemp]);
                updateNumMoves(((Moves)step3[moveTemp]).getWeight(), 0);
                //TAKE THIS OUT AFTER TESTING.
                moveTemp += 1;
                if (moveTemp == numMoves)
                {
                    solvingNow(false);
                    moveTemp = 0;
                }
                //}
            }
        }

        public void makeMove(Moves theMove)
        {
            String rowCol = "";
            rowCol = theMove.getRowCol();
            if (rowCol.Equals("R"))
            {
                rIsMoving(theMove.getNum(), theMove.getDirection());
            }
            else if (rowCol.Equals("C"))
            {
                cIsMoving(theMove.getNum(), theMove.getDirection());
            }
            else if (rowCol.Equals("F"))
            {
                if (theMove.getDirection().Equals("clockwise"))
                { cRotate(); }
                else
                { ccRotate(); }
            }
            else
            { changeTheForeFace(theMove.getDirection()); }
        }

        /// <summary>
        /// Updates the number of computer moves made on the screen.
        /// </summary>
        /// <param name="x">Weight of move, 1, or 0 if move is simply entire cube rotation.</param>
        public void updateNumMoves(int x, int layer)
        {
            if (layer != 0)
            {
                numActions += 1;
                String nextLine = "\n";
                if (numActions <= 28)
                {
                    this.actionsTaken.Text += "(Solving L" + layer + ")" + nextLine;
                }
                else if (numActions <= 58)
                {
                    this.actionsTaken2.Text += "(Solving L" + layer + ")" + nextLine;
                }
                else if (numActions <= 88)
                {
                    this.actionsTaken3.Text += "(Solving L" + layer + ")" + nextLine;
                }
                else if (numActions <= 118)
                {
                    this.actionsTaken4.Text += "(Solving L" + layer + ")" + nextLine;
                }
                else
                {
                    this.actionsTaken5.Text += "(Solving L" + layer + ")" + nextLine;
                }
                this.actionsTaken.Refresh();
                this.actionsTaken2.Refresh();
                this.actionsTaken3.Refresh();
                this.actionsTaken4.Refresh();
                this.actionsTaken5.Refresh();
            }
            else
            {
                numMoves += x;
                this.movesBox.Text = numMoves.ToString();
                this.movesBox.Refresh();
            }
        }

        /// <summary>
        /// Refreshes box colors.
        /// </summary>
        public void refreshBoxes(String moved, String dir)
        {
            int z = 1;
            for (int y = 1; y <= 3; y++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    Color theColorRe = convertColor(cube.getColor(3, x, y));
                    block[z].BackColor = theColorRe;
                    z += 1;
                }
            }
            int b = 10;
            int face = 1;
            for (int fa = 1; fa <= 4; fa++)
            {
                for (int y = 1; y <= 3; y++)
                {
                    for (int x = 1; x <= 3; x++)
                    {
                        Color theColorR2 = convertColor(cube.getColor(face, x, y));
                        smBlock[b].BackColor = theColorR2;
                        b += 1;
                    }
                }
                if (face == 5)
                { face = 6; }
                else
                { face += 2; }
            }
            b = 1;
            for (int y = 1; y <= 3; y++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    Color theColorR2 = convertColor(cube.getColor(2, x, y));
                    smBlock[b].BackColor = theColorR2;
                    b += 1;
                }
            }
            b = 54 - 8;
            for (int y = 1; y <= 3; y++)
            {
                for (int x = 1; x <= 3; x++)
                {
                    Color theColorR2 = convertColor(cube.getColor(4, x, y));
                    smBlock[b].BackColor = theColorR2;
                    b += 1;
                }
            }
            for (int zs = 1; zs <= 9; zs++)
            {
                this.block[zs].Refresh();
            }
            for (int bs = 1; bs <= 54; bs++)
            {
                this.smBlock[bs].Refresh();
            }
            if (moved.Equals("rotate"))
            {
                numActions += 1;
                String tab = "   ";
                String nextLine = "\n";
                if (numActions <= 28)
                {
                    this.actionsTaken.Text += "(CF)" + tab + dir + nextLine;
                }
                else if (numActions <= 58)
                {
                    this.actionsTaken2.Text += "(CF)" + tab + dir + nextLine;
                }
                else if (numActions <= 88)
                {
                    this.actionsTaken3.Text += "(CF)" + tab + dir + nextLine;
                }
                else if (numActions <= 118)
                {
                    this.actionsTaken4.Text += "(CF)" + tab + dir + nextLine;
                }
                else
                {
                    this.actionsTaken5.Text += "(CF)" + tab + dir + nextLine;
                }
                this.actionsTaken.Refresh();
                this.actionsTaken2.Refresh();
                this.actionsTaken3.Refresh();
                this.actionsTaken4.Refresh();
                this.actionsTaken5.Refresh();
            }
            else if (moved.Equals("rotateFace"))
            {
                numActions += 1;
                String tab = "   ";
                String nextLine = "\n";
                if (numActions <= 28)
                {
                    this.actionsTaken.Text += "RF" + tab + dir + nextLine;
                }
                else if (numActions <= 58)
                {
                    this.actionsTaken2.Text += "RF" + tab + dir + nextLine;
                }
                else if (numActions <= 88)
                {
                    this.actionsTaken3.Text += "RF" + tab + dir + nextLine;
                }
                else if (numActions <= 118)
                {
                    this.actionsTaken4.Text += "RF" + tab + dir + nextLine;
                }
                else
                {
                    this.actionsTaken5.Text += "RF" + tab + dir + nextLine;
                }
                this.actionsTaken.Refresh();
                this.actionsTaken2.Refresh();
                this.actionsTaken3.Refresh();
                this.actionsTaken4.Refresh();
                this.actionsTaken5.Refresh();
            }
            else if (!moved.Equals("reset"))
            {
                numActions += 1;
                String tab = "   ";
                String nextLine = "\n";
                if (numActions <= 28)
                {
                    this.actionsTaken.Text += moved + tab + dir + nextLine;
                }
                else if (numActions <= 58)
                {
                    this.actionsTaken2.Text += moved + tab + dir + nextLine;
                }
                else if (numActions <= 88)
                {
                    this.actionsTaken3.Text += moved + tab + dir + nextLine;
                }
                else if (numActions <= 118)
                {
                    this.actionsTaken4.Text += moved + tab + dir + nextLine;
                }
                else
                {
                    this.actionsTaken5.Text += moved + tab + dir + nextLine;
                }
                this.actionsTaken.Refresh();
                this.actionsTaken2.Refresh();
                this.actionsTaken3.Refresh();
                this.actionsTaken4.Refresh();
                this.actionsTaken5.Refresh();
            }
            else
            {
                numActions = 0;
                moveTemp = 0;
                numMoves = 0;
                this.actionsTaken.Text = "Actions Taken:\n--------------------\n";
                this.actionsTaken2.Text = "";
                this.actionsTaken3.Text = "";
                this.actionsTaken4.Text = "";
                this.actionsTaken5.Text = "";
                this.movesBox.Text = "0";
                this.actionsTaken.Refresh();
                this.actionsTaken2.Refresh();
                this.actionsTaken3.Refresh();
                this.actionsTaken4.Refresh();
                this.actionsTaken5.Refresh();
                this.movesBox.Refresh();
                solvingNow(false);
            }
        }

        public void solvingNow(bool solving)
        {
            if (solving)
            {
                r1r.Enabled = false;
                r2r.Enabled = false;
                r3r.Enabled = false;
                r1l.Enabled = false;
                r2l.Enabled = false;
                r3l.Enabled = false;
                c1u.Enabled = false;
                c2u.Enabled = false;
                c3u.Enabled = false;
                c1d.Enabled = false;
                c2d.Enabled = false;
                c3d.Enabled = false;
                white.Enabled = false;
                green.Enabled = false;
                red.Enabled = false;
                blue.Enabled = false;
                yellow.Enabled = false;
                orange.Enabled = false;
                clockwise.Enabled = false;
                counterclockwise.Enabled = false;
            }
            else
            {
                r1r.Enabled = true;
                r2r.Enabled = true;
                r3r.Enabled = true;
                r1l.Enabled = true;
                r2l.Enabled = true;
                r3l.Enabled = true;
                c1u.Enabled = true;
                c2u.Enabled = true;
                c3u.Enabled = true;
                c1d.Enabled = true;
                c2d.Enabled = true;
                c3d.Enabled = true;
                white.Enabled = true;
                green.Enabled = true;
                red.Enabled = true;
                blue.Enabled = true;
                yellow.Enabled = true;
                orange.Enabled = true;
                clockwise.Enabled = true;
                counterclockwise.Enabled = true;
                solveL1.Enabled = true;
                solveL2.Enabled = false;
                solveL3.Enabled = false;
            }
        }

        /// <summary>
        /// Method used to debug code, will print to GUI the requested message.
        /// </summary>
        /// <param name="isOn">If on, debug activated.</param>
        /// <param name="message">Requested Debug message.</param>
        public void debug(bool isOn, String message)
        {
            if (isOn)
            {
                numActions += 1;
                String tab = "   ";
                String nextLine = "\n";
                if (numActions <= 28)
                {
                    this.actionsTaken.Text += "!" + tab + message + nextLine;
                }
                else if (numActions <= 58)
                {
                    this.actionsTaken2.Text += "!" + tab + message + nextLine;
                }
                else if (numActions <= 88)
                {
                    this.actionsTaken3.Text += "!" + tab + message + nextLine;
                }
                else if (numActions <= 118)
                {
                    this.actionsTaken4.Text += "!" + tab + message + nextLine;
                }
                else
                {
                    this.actionsTaken5.Text += "!" + tab + message + nextLine;
                }
                this.actionsTaken.Refresh();
                this.actionsTaken2.Refresh();
                this.actionsTaken3.Refresh();
                this.actionsTaken4.Refresh();
                this.actionsTaken5.Refresh();
            }

        }

        /// <summary>
        /// Returns a Color representation of the current string.
        /// </summary>
        /// <param name="col">String color. ("red")</param>
        /// <returns>Color representation of the passed in string.</returns>
        public Color convertColor(String col)
        {
            Color boxColor;
            switch (col)
            {
                case "red":
                    boxColor = Color.Red;
                    break;
                case "green":
                    boxColor = Color.Green;
                    break;
                case "white":
                    boxColor = Color.White;
                    break;
                case "blue":
                    boxColor = Color.Blue;
                    break;
                case "orange":
                    boxColor = Color.Orange;
                    break;
                case "yellow":
                    boxColor = Color.Yellow;
                    break;
                default:
                    boxColor = Color.Gray;
                    break;
            }
            return boxColor;
        }
    }
}