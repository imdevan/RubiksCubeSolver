using System;
namespace RubiksCubeSolver
{
    partial class rubiksCubeInterfaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.formWrapper = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rubiksCubeWrapper = new System.Windows.Forms.TableLayoutPanel();
            this.brushButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.blueButton = new System.Windows.Forms.Button();
            this.whiteButton = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.yellowButton = new System.Windows.Forms.Button();
            this.orangeButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.rubiksCubeLog = new System.Windows.Forms.ListBox();
            this.armCallobrationWrapper = new System.Windows.Forms.SplitContainer();
            this.armCallobrationLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rightArmCallobrationPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.TextBox();
            this.leftArmCallobrationPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.leftArmCallobrationLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.formWrapper)).BeginInit();
            this.formWrapper.Panel1.SuspendLayout();
            this.formWrapper.Panel2.SuspendLayout();
            this.formWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.rubiksCubeWrapper.SuspendLayout();
            this.brushButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.armCallobrationWrapper)).BeginInit();
            this.armCallobrationWrapper.Panel1.SuspendLayout();
            this.armCallobrationWrapper.Panel2.SuspendLayout();
            this.armCallobrationWrapper.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.rightArmCallobrationPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.leftArmCallobrationPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // formWrapper
            // 
            this.formWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formWrapper.Location = new System.Drawing.Point(0, 0);
            this.formWrapper.Name = "formWrapper";
            // 
            // formWrapper.Panel1
            // 
            this.formWrapper.Panel1.Controls.Add(this.splitContainer2);
            // 
            // formWrapper.Panel2
            // 
            this.formWrapper.Panel2.AccessibleName = "armCalibrationWrapper";
            this.formWrapper.Panel2.Controls.Add(this.armCallobrationWrapper);
            this.formWrapper.Size = new System.Drawing.Size(774, 529);
            this.formWrapper.SplitterDistance = 580;
            this.formWrapper.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.ForeColor = System.Drawing.Color.CadetBlue;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AccessibleName = "rubicsCubeInterface";
            this.splitContainer2.Panel1.Controls.Add(this.rubiksCubeWrapper);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AccessibleName = "rubiksCubeLogWrapper";
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.splitContainer2.Panel2.Controls.Add(this.rubiksCubeLog);
            this.splitContainer2.Size = new System.Drawing.Size(580, 529);
            this.splitContainer2.SplitterDistance = 396;
            this.splitContainer2.TabIndex = 0;
            // 
            // rubiksCubeWrapper
            // 
            this.rubiksCubeWrapper.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rubiksCubeWrapper.ColumnCount = 4;
            this.rubiksCubeWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.rubiksCubeWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.rubiksCubeWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.rubiksCubeWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.rubiksCubeWrapper.Controls.Add(this.brushButtonPanel, 3, 0);
            this.rubiksCubeWrapper.Controls.Add(this.solveButton, 3, 2);
            this.rubiksCubeWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rubiksCubeWrapper.Location = new System.Drawing.Point(0, 0);
            this.rubiksCubeWrapper.Name = "rubiksCubeWrapper";
            this.rubiksCubeWrapper.RowCount = 3;
            this.rubiksCubeWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rubiksCubeWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rubiksCubeWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rubiksCubeWrapper.Size = new System.Drawing.Size(580, 396);
            this.rubiksCubeWrapper.TabIndex = 0;

            /**********************************************************************************************************************************************
             * Cube Face Definitions
             * 
             * Here we dynamically create and define each cubie and their event handlers
             * 
             * Author:
             * Devan Huapaya
             * *********************************************************************************************************************************************/
            // Counter to keep track of the true cube face
            int trueFace = 0;
            int trueIndex = 0;

            // intiate cube object
            Cube rc = new Cube();
            Face[] faceArray = new Face[6];


            for (int ci = 0; ci < 4; ci++)
            {
                for (int ri = 0; ri < 3; ri++)
                {
                    // do nothing if the table cell is not a cubeface
                    bool notCubeFace = (ri == 0 || ri == 2) && (ci == 0 || ci == 2 || ci == 3);
                    if (notCubeFace)
                        continue;
                        
                    
                    // define each face
                    System.Windows.Forms.TableLayoutPanel tempTableLayout = new System.Windows.Forms.TableLayoutPanel();
                    tempTableLayout.ColumnCount = 3;
                    tempTableLayout.RowCount = 3;
                    for (int i = 0; i < 3; i++)
                        tempTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    for (int i = 0; i < 3; i++)
                        tempTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                    tempTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
                    tempTableLayout.Padding = new System.Windows.Forms.Padding(1);
                    

                    // iterate over each cube face  
                    Cubie[,] cubeArray = new Cubie[3,3];
                    for (int yi = 0; yi < 3; yi++)
                    {
                        for (int xi = 0; xi < 3; xi++)
                        {
                            // create temp button
                            System.Windows.Forms.Button tButton = new System.Windows.Forms.Button();

                            // format button
                            tButton.BackColor = this.cubieColors[ri, ci];
                            tButton.Dock = System.Windows.Forms.DockStyle.Fill;
                            tButton.Size = new System.Drawing.Size(39, 55);
                            tButton.TabIndex = xi + yi;
                            tButton.UseVisualStyleBackColor = false;

                            // Add the button call back
                            tButton.Click += new System.EventHandler(ClickHandler);
                            //tButton.Click += (sender, e) => ClickHandler(sender, e, xi, yi, ri, ci);

                            // middle positions are fixed
                            if (xi == 1 && yi == 1)
                                tButton.Enabled = false;

                            // add cubie to the interface
                            tempTableLayout.Controls.Add(tButton, xi, yi);

                            // add cubie to the rubiks cube object
                            // Cubie(int pindex, Color c, int fi, int xi, int yi)
                            cubeArray[xi, yi] = new Cubie(
                                                    trueIndex, // index
                                                    (Color)(trueFace+1) , // color
                                                    trueFace, // face
                                                    xi, // x
                                                    yi // y
                                                );

                            trueIndex++;
                        }
                    }
                    this.rubiksCubeWrapper.Controls.Add(tempTableLayout, ci, ri);


                    // Add variables to the rubiks cube object
                    faceArray[trueFace] = new Face(trueFace, cubeArray);
                    trueFace++;
                }
            }
            rubiksCube = new Cube(faceArray);


            // 
            // brushButtonPanel
            // 
            this.brushButtonPanel.ColumnCount = 3;
            this.brushButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.brushButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.brushButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.brushButtonPanel.Controls.Add(this.blueButton, 0, 0);
            this.brushButtonPanel.Controls.Add(this.whiteButton, 0, 1);
            this.brushButtonPanel.Controls.Add(this.redButton, 1, 0);
            this.brushButtonPanel.Controls.Add(this.greenButton, 1, 1);
            this.brushButtonPanel.Controls.Add(this.yellowButton, 2, 0);
            this.brushButtonPanel.Controls.Add(this.orangeButton, 2, 1);
            this.brushButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brushButtonPanel.Location = new System.Drawing.Point(438, 3);
            this.brushButtonPanel.Name = "brushButtonPanel";
            this.brushButtonPanel.Padding = new System.Windows.Forms.Padding(5);
            this.brushButtonPanel.RowCount = 2;
            this.brushButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.brushButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.brushButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.brushButtonPanel.Size = new System.Drawing.Size(139, 126);
            this.brushButtonPanel.TabIndex = 0;
            // 
            // blueButton
            // 
            this.blueButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.blueButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueButton.ForeColor = System.Drawing.Color.White;
            this.blueButton.Location = new System.Drawing.Point(5, 5);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(39, 55);
            this.blueButton.TabIndex = 0;
            this.blueButton.Text = "B";
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // whiteButton
            // 
            this.whiteButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.whiteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whiteButton.ForeColor = System.Drawing.Color.Black;
            this.whiteButton.Location = new System.Drawing.Point(5, 66);
            this.whiteButton.Name = "whiteButton";
            this.whiteButton.Size = new System.Drawing.Size(39, 55);
            this.whiteButton.TabIndex = 1;
            this.whiteButton.Text = "W";
            this.whiteButton.UseVisualStyleBackColor = false;
            this.whiteButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // redButton
            // 
            this.redButton.BackColor = System.Drawing.Color.Crimson;
            this.redButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redButton.ForeColor = System.Drawing.Color.White;
            this.redButton.Location = new System.Drawing.Point(50, 5);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(39, 55);
            this.redButton.TabIndex = 2;
            this.redButton.Text = "R";
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.greenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.greenButton.ForeColor = System.Drawing.Color.White;
            this.greenButton.Location = new System.Drawing.Point(50, 66);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(39, 55);
            this.greenButton.TabIndex = 3;
            this.greenButton.Text = "G";
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = System.Drawing.Color.Gold;
            this.yellowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yellowButton.ForeColor = System.Drawing.Color.Black;
            this.yellowButton.Location = new System.Drawing.Point(95, 5);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(39, 55);
            this.yellowButton.TabIndex = 4;
            this.yellowButton.Text = "Y";
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.Click += new System.EventHandler(this.yellowButton_Click);
            // 
            // orangeButton
            // 
            this.orangeButton.BackColor = System.Drawing.Color.DarkOrange;
            this.orangeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orangeButton.ForeColor = System.Drawing.Color.White;
            this.orangeButton.Location = new System.Drawing.Point(95, 66);
            this.orangeButton.Name = "orangeButton";
            this.orangeButton.Size = new System.Drawing.Size(39, 55);
            this.orangeButton.TabIndex = 5;
            this.orangeButton.Text = "O";
            this.orangeButton.UseVisualStyleBackColor = false;
            this.orangeButton.Click += new System.EventHandler(this.orangeButton_Click);
            // 
            // solveButton
            // 
            this.solveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.solveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solveButton.Location = new System.Drawing.Point(445, 314);
            this.solveButton.Margin = new System.Windows.Forms.Padding(10, 50, 10, 50);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(125, 32);
            this.solveButton.TabIndex = 1;
            this.solveButton.Text = "Solve!";
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // rubiksCubeLog
            // 
            this.rubiksCubeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rubiksCubeLog.FormattingEnabled = true;
            this.rubiksCubeLog.ItemHeight = 25;
            this.rubiksCubeLog.Location = new System.Drawing.Point(0, 0);
            this.rubiksCubeLog.Name = "rubiksCubeLog";
            this.rubiksCubeLog.Size = new System.Drawing.Size(580, 129);
            this.rubiksCubeLog.TabIndex = 0;
            // 
            // armCallobrationWrapper
            // 
            this.armCallobrationWrapper.BackColor = System.Drawing.Color.CadetBlue;
            this.armCallobrationWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armCallobrationWrapper.Location = new System.Drawing.Point(0, 0);
            this.armCallobrationWrapper.Name = "armCallobrationWrapper";
            this.armCallobrationWrapper.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // armCallobrationWrapper.Panel1
            // 
            this.armCallobrationWrapper.Panel1.Controls.Add(this.armCallobrationLabel);
            this.armCallobrationWrapper.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // armCallobrationWrapper.Panel2
            // 
            this.armCallobrationWrapper.Panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.armCallobrationWrapper.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.armCallobrationWrapper.Size = new System.Drawing.Size(190, 529);
            this.armCallobrationWrapper.SplitterDistance = 63;
            this.armCallobrationWrapper.TabIndex = 0;
            // 
            // armCallobrationLabel
            // 
            this.armCallobrationLabel.AutoSize = true;
            this.armCallobrationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armCallobrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armCallobrationLabel.Location = new System.Drawing.Point(0, 0);
            this.armCallobrationLabel.Name = "armCallobrationLabel";
            this.armCallobrationLabel.Size = new System.Drawing.Size(192, 29);
            this.armCallobrationLabel.TabIndex = 0;
            this.armCallobrationLabel.Text = "Arm Calibration";
            this.armCallobrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rightArmCallobrationPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.leftArmCallobrationPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rightArmCallobrationPanel
            // 
            this.rightArmCallobrationPanel.ColumnCount = 1;
            this.rightArmCallobrationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightArmCallobrationPanel.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.rightArmCallobrationPanel.Controls.Add(this.label1, 0, 0);
            this.rightArmCallobrationPanel.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.rightArmCallobrationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightArmCallobrationPanel.Location = new System.Drawing.Point(5, 5);
            this.rightArmCallobrationPanel.Name = "rightArmCallobrationPanel";
            this.rightArmCallobrationPanel.Padding = new System.Windows.Forms.Padding(2);
            this.rightArmCallobrationPanel.RowCount = 3;
            this.rightArmCallobrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rightArmCallobrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rightArmCallobrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.rightArmCallobrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightArmCallobrationPanel.Size = new System.Drawing.Size(180, 146);
            this.rightArmCallobrationPanel.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button4, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(5, 99);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(170, 42);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(59, 0);
            this.label3.Name = "rightArmRotateConfigInput";
            this.label3.Size = new System.Drawing.Size(50, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "10";
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "rightArmRotateConfigPlus";
            this.button3.Size = new System.Drawing.Size(50, 36);
            this.button3.TabIndex = 1;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.rightArmRotateConfigPlusClick);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(115, 3);
            this.button4.Name = "rightArmRotateConfigMinus";
            this.button4.Size = new System.Drawing.Size(52, 36);
            this.button4.TabIndex = 2;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.rightArmRotateConfigMinusClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Right Arm Cal.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(5, 52);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(170, 41);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "rightArmCloseConfigPlus";
            this.button1.Size = new System.Drawing.Size(50, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.rightArmCloseConfigPlusClick);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(115, 3);
            this.button2.Name = "rightArmCloseConfigMinus";
            this.button2.Size = new System.Drawing.Size(52, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.rightArmCloseConfigMinusClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(59, 0);
            this.label2.Name = "rightArmCloseConfigInput";
            this.label2.Size = new System.Drawing.Size(50, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "10";
            // 
            // leftArmCallobrationPanel
            // 
            this.leftArmCallobrationPanel.ColumnCount = 1;
            this.leftArmCallobrationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftArmCallobrationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftArmCallobrationPanel.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.leftArmCallobrationPanel.Controls.Add(this.leftArmCallobrationLabel, 0, 0);
            this.leftArmCallobrationPanel.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.leftArmCallobrationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftArmCallobrationPanel.Location = new System.Drawing.Point(5, 157);
            this.leftArmCallobrationPanel.Name = "leftArmCallobrationPanel";
            this.leftArmCallobrationPanel.RowCount = 3;
            this.leftArmCallobrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.leftArmCallobrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.leftArmCallobrationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.leftArmCallobrationPanel.Size = new System.Drawing.Size(180, 146);
            this.leftArmCallobrationPanel.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button8, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 99);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(174, 44);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(61, 0);
            this.label5.Name = "leftArmRotateConfigInput";
            this.label5.Size = new System.Drawing.Size(52, 44);
            this.label5.TabIndex = 5;
            this.label5.Text = "10";
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "leftARmRotateConfigPlus";
            this.button5.Size = new System.Drawing.Size(52, 38);
            this.button5.TabIndex = 2;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.leftArmRotateConfigPlusClick);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(119, 3);
            this.button8.Name = "leftARmRotateConfigMinus";
            this.button8.Size = new System.Drawing.Size(52, 38);
            this.button8.TabIndex = 4;
            this.button8.Text = "-";
            this.button8.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.leftArmRotateConfigPlusClick);
            // 
            // leftArmCallobrationLabel
            // 
            this.leftArmCallobrationLabel.AutoSize = true;
            this.leftArmCallobrationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftArmCallobrationLabel.Location = new System.Drawing.Point(3, 0);
            this.leftArmCallobrationLabel.Name = "leftArmCallobrationLabel";
            this.leftArmCallobrationLabel.Size = new System.Drawing.Size(174, 48);
            this.leftArmCallobrationLabel.TabIndex = 0;
            this.leftArmCallobrationLabel.Text = "Left Arm Cal.";
            this.leftArmCallobrationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button7, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(174, 42);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(61, 0);
            this.label4.Name = "leftArmCloseConfigInput";
            this.label4.Size = new System.Drawing.Size(52, 42);
            this.label4.TabIndex = 4;
            this.label4.Text = "10";
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(3, 3);
            this.button6.Name = "leftArmCloseConfigPlus";
            this.button6.Size = new System.Drawing.Size(52, 36);
            this.button6.TabIndex = 2;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.leftArmCloseConfigPlusClick);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(119, 3);
            this.button7.Name = "leftArmCloseConfigMinus";
            this.button7.Size = new System.Drawing.Size(52, 36);
            this.button7.TabIndex = 3;
            this.button7.Text = "-";
            this.button7.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.leftArmCloseConfigMinusClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Arm Callobration";
            // 
            // rubiksCubeInterfaceForm
            // 
            this.AccessibleName = "form";
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            /**********************************************************************************************************************************************
            * TODO: find good height width for form
            **********************************************************************************************************************************************/
            // this.ClientSize = new System.Drawing.Size(900, 600);
            this.ClientSize = new System.Drawing.Size(1900, 1080);
            this.Controls.Add(this.formWrapper);
            this.Name = "rubiksCubeInterfaceForm";
            this.Text = "Rubik\'s Cube Solver";
            this.formWrapper.Panel1.ResumeLayout(false);
            this.formWrapper.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.formWrapper)).EndInit();
            this.formWrapper.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.rubiksCubeWrapper.ResumeLayout(false);
            this.brushButtonPanel.ResumeLayout(false);
            this.armCallobrationWrapper.Panel1.ResumeLayout(false);
            this.armCallobrationWrapper.Panel1.PerformLayout();
            this.armCallobrationWrapper.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.armCallobrationWrapper)).EndInit();
            this.armCallobrationWrapper.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.rightArmCallobrationPanel.ResumeLayout(false);
            this.rightArmCallobrationPanel.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.leftArmCallobrationPanel.ResumeLayout(false);
            this.leftArmCallobrationPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer formWrapper;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel rubiksCubeWrapper;
        private System.Windows.Forms.SplitContainer armCallobrationWrapper;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox rubiksCubeLog;
        private System.Windows.Forms.Label armCallobrationLabel;
        private System.Windows.Forms.TableLayoutPanel brushButtonPanel;
        private System.Windows.Forms.Button whiteButton;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Button orangeButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel rightArmCallobrationPanel;
        private System.Windows.Forms.TableLayoutPanel leftArmCallobrationPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label leftArmCallobrationLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox label3;
        private System.Windows.Forms.TextBox label2;
        private System.Windows.Forms.TextBox label5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox label4;
        private System.Windows.Forms.Button button7;

        /********************************************
         * Populate Rubiks Cube
        ********************************************/
        private System.Windows.Forms.TableLayoutPanel.ControlCollection[] rSides;
        private System.Drawing.Color[,] cubieColors = { 
                                                        { System.Drawing.Color.RoyalBlue,System.Drawing.Color.Crimson, System.Drawing.Color.RoyalBlue, System.Drawing.Color.RoyalBlue }, 
                                                        { System.Drawing.Color.RoyalBlue, System.Drawing.Color.WhiteSmoke, System.Drawing.Color.MediumSeaGreen, System.Drawing.Color.Gold}, 
                                                        {System.Drawing.Color.RoyalBlue, System.Drawing.Color.DarkOrange, System.Drawing.Color.RoyalBlue, System.Drawing.Color.RoyalBlue } 
                                                      };
        private System.Drawing.Color brush = System.Drawing.Color.Crimson;

        Cube rubiksCube = new Cube();
    }
}

