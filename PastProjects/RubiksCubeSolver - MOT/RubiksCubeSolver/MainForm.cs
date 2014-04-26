using System;
using System.Collections;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CsGL.OpenGL;
using System.Diagnostics;

namespace RubiksCubeSolver
{
    /// <summary>
    /// The main GUI
    /// </summary>
    public partial class MainForm : Form
    {
        private GLPanel view;
        public Orientation orientation;
        public Orientation holder;

        public static MainForm myForm;
        public static ArrayList solutionList;
        public static int moveNum = 0;
        public static bool solving = false;
        public static bool simulating = false;
        public static bool solved = false;

        public static int movesMade = 0;

        /// <summary>
        /// The main method.
        /// 
        /// Constantly refreshes the OpenGL window and handles execution of the movements
        /// in a solution. Also interprets the moves as they come through and displays them
        /// in the move list.
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            myForm = new MainForm();
            myForm.Show();
            
            while ((myForm.view.Created) && (!myForm.IsDisposed))		// refreshing the window, so it rotates
            {
                if (!myForm.view.cube.isRotating() && solving)
                {
                    if (moveNum < solutionList.Count)
                    {
                        Moves move = (Moves)solutionList[moveNum];
                        Moves lastmove = new Moves();
                        Moves nextmove = new Moves();
                        if (moveNum > 0) lastmove = (Moves)solutionList[moveNum - 1];
                        if (moveNum < solutionList.Count - 1) nextmove = (Moves)solutionList[moveNum + 1];

                        myForm.makeMove(move);
                        if (move.getWeight() == 1)
                        {
                            // Moving twice in the same direction counts as one move
                            if (!move.ToString().Equals(lastmove.ToString()))
                            {
                                movesMade++;
                            }
                        }
                        if (!move.ToString().Equals(lastmove.ToString()))
                        {
                            if (move.ToString().Equals(nextmove.ToString()))
                            {
                                myForm.listBox1.Items.Add(move.ToString() + " x2");
                            }
                            else
                            {
                                myForm.listBox1.Items.Add(move.ToString());
                            }
                        }
                        myForm.movesMadeLabel.Text = movesMade.ToString();
                        moveNum++;
                    }
                    else
                    {
                        stopSolving();
                    }
                }
                
                myForm.view.Refresh();
                Application.DoEvents();
            }
            myForm.Dispose();
        }

        /// <summary>
        /// Constructor. Initializes the form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            
            this.view = new GLPanel();
            this.orientation = new Orientation();

            this.view.Parent = this.panel2;
            this.view.Dock = DockStyle.Fill;
            this.Show();
        }

        /// <summary>
        /// Gives NewCube access to the main GLPanel to setup a new cube. This also
        /// is not in the final demo since the solver can only do 3x3.
        /// </summary>
        public void refreshGLPanel()
        {
            this.view.refreshCube();
        }

        /// <summary>
        /// Runs when solving is complete to restore the state of the GUI and
        /// reset the solver.
        /// </summary>
        public static void stopSolving()
        {
            solving = false;
            solutionList = new ArrayList();
            moveNum = 0;
            myForm.button9.Text = "Solve";
            myForm.button9.Enabled = true;
            myForm.button7.Enabled = true;
            toggleButtons(true);
            solved = false;
        }

        /// <summary>
        /// Enables/Disables the manual controls in the main GUI.
        /// </summary>
        /// <param name="status">True for enabled, False for disabled.</param>
        public static void toggleButtons(bool status)
        {
            myForm.button1.Enabled = status;
            myForm.button2.Enabled = status;
            myForm.button3.Enabled = status;
            myForm.button4.Enabled = status;
            myForm.button5.Enabled = status;
            myForm.button6.Enabled = status;
            myForm.button10.Enabled = status;
            myForm.button11.Enabled = status;
            myForm.button12.Enabled = status;
            myForm.button13.Enabled = status;
            myForm.button14.Enabled = status;
            myForm.button15.Enabled = status;
            myForm.changeFaceDown.Enabled = status;
            myForm.changeFaceLeft.Enabled = status;
            myForm.changeFaceRight.Enabled = status;
            myForm.changeFaceUp.Enabled = status;
            myForm.rotateFaceCC.Enabled = status;
            myForm.rotateFaceCW.Enabled = status;
        }

        /// <summary>
        /// Clears the list of moves in the main GUI
        /// </summary>
        public static void clearMoveList()
        {
            myForm.listBox1.Items.Clear();
            myForm.movesMadeLabel.Text = "0";
            movesMade = 0;
        }

        #region Movers
        public void rotateX(int level, int direction)
        {
            this.view.cube.rotateX(level, direction);
        }
        public void rotateY(int level, int direction)
        {
            this.view.cube.rotateY(level, direction);
        }
        public void rotateZ(int level, int direction)
        {
            this.view.cube.rotateZ(level, direction);
        }
        #endregion

        #region X Rotation Buttons
        private void posRotateX0(object sender, EventArgs e)
        {
            this.orientation.moveCol(1, "down");
            this.view.cube.rotateX(0, 1);
        }
        private void posRotateX1(object sender, EventArgs e)
        {
            this.orientation.moveCol(2, "down");
            this.view.cube.rotateX(1, 1);
        }
        private void posRotateX2(object sender, EventArgs e)
        {
            this.orientation.moveCol(3, "down");
            this.view.cube.rotateX(2, 1);
        }
        private void negRotateX0(object sender, EventArgs e)
        {
            this.orientation.moveCol(1, "up");
            this.view.cube.rotateX(0, -1);
        }
        private void negRotateX1(object sender, EventArgs e)
        {
            this.orientation.moveCol(2, "up");
            this.view.cube.rotateX(1, -1);
        }
        private void negRotateX2(object sender, EventArgs e)
        {
            this.orientation.moveCol(3, "up");
            this.view.cube.rotateX(2, -1);
        }
        #endregion

        #region Y Rotation Buttons
        private void posRotateY0(object sender, EventArgs e)
        {
            this.orientation.moveRow(3, "right");
            this.view.cube.rotateY(0, 1);
        }
        private void posRotateY1(object sender, EventArgs e)
        {
            this.orientation.moveRow(2, "right");
            this.view.cube.rotateY(1, 1);
        }
        private void posRotateY2(object sender, EventArgs e)
        {
            this.orientation.moveRow(1, "right");
            this.view.cube.rotateY(2, 1);
        }
        private void negRotateY0(object sender, EventArgs e)
        {
            this.orientation.moveRow(3, "left");
            this.view.cube.rotateY(0, -1);
        }
        private void negRotateY1(object sender, EventArgs e)
        {
            this.orientation.moveRow(2, "left");
            this.view.cube.rotateY(1, -1);
        }
        private void negRotateY2(object sender, EventArgs e)
        {
            this.orientation.moveRow(1, "left");
            this.view.cube.rotateY(2, -1);
        }
        #endregion

        /// <summary>
        /// Scrambles the cube
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrambleButtonClick(object sender, EventArgs e)
        {
            if (solved)
            {
                this.view.cube = new RubiksCube(GLPanel.size);
                this.orientation = new Orientation();
                solutionList = new ArrayList();
                moveNum = 0;
                solved = false;
            }
            
            myForm.button9.Enabled = false;
            solutionList = new ArrayList();
            clearMoveList();

            Random rand = new Random();
            Moves move = new Moves();
            int count = 20;

            for (int i = 0; i < count; i++)
            {
                int rowcol = rand.Next(2);
                int level = rand.Next(1, 4);
                int direction = rand.Next(2);

                string rc;
                string dir;
                if (rowcol == 0)
                {
                    rc = "r";
                    if (direction == 0)
                    {
                        dir = "left";
                    }
                    else
                    {
                        dir = "right";
                    }
                }
                else
                {
                    rc = "c";
                    if (direction == 0)
                    {
                        dir = "up";
                    }
                    else
                    {
                        dir = "down";
                    }
                }
                move = new Moves();
                move.setMove(rc, level, dir);
                solutionList.Add(move);
            }
            optimizeSolution();
            solving = true;
            toggleButtons(false);
        }

        /// <summary>
        /// Removes unnecessary moves from a solution.
        /// </summary>
        private void optimizeSolution()
        {
            // Optimization, eliminate moves which have no affect by
            // checking the state of the cube after every move and then checking
            // to see if that same state is reached later. If the state does appear
            // later, then all the steps in between can be skipped.

            simulating = true;
            Orientation temp = new Orientation(this.orientation);

            ArrayList orientations = new ArrayList();
            ArrayList optimized = new ArrayList();
            for (int i = 0; i < solutionList.Count; i++)
            {
                makeMove((Moves) solutionList[i]);
                orientations.Add(this.orientation.ToString());
            }
            for (int i = 0; i < orientations.Count; i++)
            {
                int lastIndex = orientations.LastIndexOf(orientations[i]);
                if (lastIndex != i)
                {
                    optimized.Add(solutionList[i]);
                    i = lastIndex;
                }
                else
                    optimized.Add(solutionList[i]);
            }
            solutionList = optimized;

            // Remove any face changes at the end of the solution
            for (int i = optimized.Count - 1; i >= 0; i--)
            {
                if (isFaceChange((Moves)optimized[i]))
                    optimized.RemoveAt(i);
                else
                    break;
            }

            simulating = false;
            this.orientation = new Orientation(temp);
        }

        /// <summary>
        /// Determines if a movement is simple a face change.
        /// </summary>
        /// <param name="m">Movement object</param>
        /// <returns>True/False for whether it's a face change or not.</returns>
        private bool isFaceChange(Moves m)
        {
            if ((!m.rc.Equals("R")) && (!m.rc.Equals("C")) && (!m.rc.Equals("F")))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Generate the solution and flip the switch to start moving the OpenGL cube.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solveButtonClick(object sender, EventArgs e)
        {
            if (solving)
            {
                stopSolving();
            }
            else
            {
                int startTicks = Environment.TickCount;
                clearMoveList();
                myForm.button9.Text = "Stop";
                myForm.button7.Enabled = false;
                ArrayList bestSolution = new ArrayList();

                simulating = true;
                this.holder = new Orientation(this.orientation);

                int fewestMoves = 1000;
                int bestStartFace = 1;

                int[] faces = new int[5] { 1, 2, 4, 5, 6 };
                using (StreamWriter sw = new StreamWriter("testing.txt"))
                {
                    foreach (int i in faces)
                    {
                        sw.WriteLine(i.ToString());
                        this.orientation = new Orientation(this.holder);
                        this.changeTheForeFace(orientation.getFaceColor(i));
                        solutionList = generateSolution();
                        optimizeSolution();
                        simulating = true;
                        if (getMoveCount() < fewestMoves)
                        {
                            bestSolution = solutionList;
                            fewestMoves = getMoveCount();
                            bestStartFace = i;
                        }
                        myForm.listBox1.Items.Add("Face " + i.ToString() + " " + getMoveCount().ToString());
                        int endTicks2 = Environment.TickCount - startTicks;
                        myForm.listBox1.Items.Add("Solution " + i.ToString() + " at " + endTicks2 + " ms");
                    }
                }

                myForm.listBox1.Items.Add("Best Start Face: " + bestStartFace.ToString());
                simulating = false;

                solutionList = bestSolution;
                this.orientation = new Orientation(this.holder);
                this.changeTheForeFace(orientation.getFaceColor(bestStartFace));

                //optimizeSolution();
                solving = true;
                toggleButtons(false);
                int endTicks = Environment.TickCount - startTicks;
                myForm.listBox1.Items.Add("All Solutions in " + endTicks + " ms");
            }
        }

        /// <summary>
        /// Analyze a solution to determine the "optimal" number of moves. i.e. face changes
        /// don't count as moves, and two moves in the same direction on the same row/col is
        /// only one move.
        /// </summary>
        /// <returns></returns>
        public int getMoveCount()
        {
            Moves lastmove = new Moves();
            Moves nextmove = new Moves();
            int movesMade = 0;

            for (int i = 0; i < solutionList.Count; i++)
            {
                Moves move = (Moves)solutionList[i];
                if (i > 0) lastmove = (Moves)solutionList[i - 1];
                if (i < solutionList.Count - 1) nextmove = (Moves)solutionList[i + 1];

                if (move.getWeight() == 1)
                {
                    // Moving twice in the same direction counts as one move
                    if (!move.ToString().Equals(lastmove.ToString()))
                    {
                        movesMade++;
                    }
                }
            }
            return movesMade;
        }

        /// <summary>
        /// Helper method for solveButtonClick()
        /// </summary>
        /// <returns></returns>
        public ArrayList generateSolution()
        {
            solutionList = new ArrayList();
            Orientation workingCube = this.orientation;

            Layer1 l1 = new Layer1(workingCube);
            ArrayList solution1 = l1.fixLayer1();
            workingCube = l1.getCube();

            Layer2 l2 = new Layer2(workingCube);
            ArrayList solution2 = l2.fixLayer2();
            workingCube = l2.getCube();

            Layer3 l3 = new Layer3(workingCube);
            ArrayList solution3 = l3.fixLayer3();

            foreach (Moves move in solution1)
                solutionList.Add(move);
            foreach (Moves move in solution2)
                solutionList.Add(move);
            foreach (Moves move in solution3)
                solutionList.Add(move);

            return solutionList;
        }

        #region File Menu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCube newCube = new NewCube();
            newCube.ShowDialog();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view.cube = new RubiksCube(GLPanel.size);
            this.orientation = new Orientation();
            solutionList = new ArrayList();
            moveNum = 0;
            if (solving) stopSolving();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void newCube(int sides, bool scramble)
        {
            this.view.cube = new RubiksCube(sides);
            this.orientation = new Orientation();
            if (scramble)
                this.view.cube.scramble();
        }

        #endregion

        #region Render Mode Menu
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view.setMode(0);
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view.setMode(1);
        }

        private void wireframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view.setMode(2);
        }
        #endregion

        #region Steph's Code :)

        /// <summary>
        /// Interpret move commands and fire them off to the appropriate method
        /// </summary>
        /// <param name="theMove">Moves object</param>
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
        /// Move a row
        /// </summary>
        /// <param name="r">Row number to move (1-3)</param>
        /// <param name="direction">left, right</param>
        public void rIsMoving(int r, String direction)
        {
            this.orientation.moveRow(r, direction);

            if (direction.Equals("left"))
            {
                if (!simulating) this.rotateY(3 - r, -1);
            }
            else if (direction.Equals("right"))
            {
                if (!simulating) this.rotateY(3 - r, 1);
            }
        }

        /// <summary>
        /// Move a column
        /// </summary>
        /// <param name="c">Column number to move (1-3)</param>
        /// <param name="direction">up, down</param>
        public void cIsMoving(int c, String direction)
        {
            this.orientation.moveCol(c, direction);

            if (direction.Equals("up"))
            {
                if (!simulating) this.rotateX(c - 1, -1);
            }
            else if (direction.Equals("down"))
            {
                if (!simulating) this.rotateX(c - 1, 1);
            }
        }

        /// <summary>
        /// Rotate the current face clockwise
        /// </summary>
        public void cRotate()
        {
            orientation.rotateFace("clockwise");
            if (!simulating) this.rotateZ(2, -1);
        }

        /// <summary>
        /// Rotate the current face counter clockwise
        /// </summary>
        public void ccRotate()
        {
            orientation.rotateFace("counterclockwise");
            if (!simulating) this.rotateZ(2, 1);
        }

        /// <summary>
        /// Change the front face of the cube.
        /// </summary>
        /// <param name="word">red, green, yellow, orange, blue, white</param>
        public void changeTheForeFace(String word)
        {
            if (!simulating)
            {
                int face = orientation.getFaceNum(word);
                switch (face)
                {
                    case 1:
                        this.rotateY(0, 1);
                        this.rotateY(1, 1);
                        this.rotateY(2, 1);
                        break;
                    case 2:
                        this.rotateX(0, 1);
                        this.rotateX(1, 1);
                        this.rotateX(2, 1);
                        break;
                    case 4:
                        this.rotateX(0, -1);
                        this.rotateX(1, -1);
                        this.rotateX(2, -1);
                        break;
                    case 5:
                        this.rotateY(0, -1);
                        this.rotateY(1, -1);
                        this.rotateY(2, -1);
                        break;
                    case 6:
                        this.rotateY(0, 1);
                        this.rotateY(1, 1);
                        this.rotateY(2, 1);
                        this.rotateY(0, 1);
                        this.rotateY(1, 1);
                        this.rotateY(2, 1);
                        break;
                    default:
                        break;
                }
            }
            // Don't move this, it has to be after the switch statement
            this.orientation.changeFace(word);
        }

        #endregion

        #region Change Face Buttons
        private void changeFaceUp_Click(object sender, EventArgs e)
        {
            this.changeTheForeFace(orientation.getFaceColor(2));
        }

        private void changeFaceLeft_Click(object sender, EventArgs e)
        {
            this.changeTheForeFace(orientation.getFaceColor(1));
        }

        private void changeFaceRight_Click(object sender, EventArgs e)
        {
            this.changeTheForeFace(orientation.getFaceColor(5));
        }

        private void changeFaceDown_Click(object sender, EventArgs e)
        {
            this.changeTheForeFace(orientation.getFaceColor(4));
        }

        private void rotateFaceCW_Click(object sender, EventArgs e)
        {
            this.cRotate();
        }

        private void rotateFaceCC_Click(object sender, EventArgs e)
        {
            this.ccRotate();
        }
        #endregion

        #region Hint Circles Mouseovers
        private void clearCircles()
        {
            foreach (hintCircle c in this.view.cube.hintCircles)
            {
                c.status = false;
            }
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[6].status = true;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[7].status = true;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[8].status = true;
        }

        private void button12_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[3].status = true;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[4].status = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[5].status = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[6].status = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[7].status = true;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[8].status = true;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[5].status = true;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button14_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[4].status = true;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[3].status = true;
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void rotateFaceCW_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[2].status = true;
        }

        private void rotateFaceCW_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }

        private void rotateFaceCC_MouseEnter(object sender, EventArgs e)
        {
            this.view.cube.hintCircles[2].status = true;
        }

        private void rotateFaceCC_MouseLeave(object sender, EventArgs e)
        {
            clearCircles();
        }
        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }
    }
}