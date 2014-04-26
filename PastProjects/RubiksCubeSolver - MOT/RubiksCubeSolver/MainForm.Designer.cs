namespace RubiksCubeSolver
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rotateFaceCW = new System.Windows.Forms.Button();
            this.rotateFaceCC = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.changeFaceLeft = new System.Windows.Forms.Button();
            this.changeFaceDown = new System.Windows.Forms.Button();
            this.changeFaceRight = new System.Windows.Forms.Button();
            this.changeFaceUp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.movesMadeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.movesMadeLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 334);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rotateFaceCW);
            this.groupBox3.Controls.Add(this.rotateFaceCC);
            this.groupBox3.Location = new System.Drawing.Point(4, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 76);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rotate Front Face";
            // 
            // rotateFaceCW
            // 
            this.rotateFaceCW.Image = global::RubiksCubeSolver.Properties.Resources.clockwise;
            this.rotateFaceCW.Location = new System.Drawing.Point(27, 21);
            this.rotateFaceCW.Name = "rotateFaceCW";
            this.rotateFaceCW.Size = new System.Drawing.Size(48, 48);
            this.rotateFaceCW.TabIndex = 38;
            this.rotateFaceCW.UseVisualStyleBackColor = true;
            this.rotateFaceCW.MouseLeave += new System.EventHandler(this.rotateFaceCW_MouseLeave);
            this.rotateFaceCW.Click += new System.EventHandler(this.rotateFaceCW_Click);
            this.rotateFaceCW.MouseEnter += new System.EventHandler(this.rotateFaceCW_MouseEnter);
            // 
            // rotateFaceCC
            // 
            this.rotateFaceCC.Image = global::RubiksCubeSolver.Properties.Resources.counter_clockwise;
            this.rotateFaceCC.Location = new System.Drawing.Point(81, 21);
            this.rotateFaceCC.Name = "rotateFaceCC";
            this.rotateFaceCC.Size = new System.Drawing.Size(48, 48);
            this.rotateFaceCC.TabIndex = 39;
            this.rotateFaceCC.UseVisualStyleBackColor = true;
            this.rotateFaceCC.MouseLeave += new System.EventHandler(this.rotateFaceCC_MouseLeave);
            this.rotateFaceCC.Click += new System.EventHandler(this.rotateFaceCC_Click);
            this.rotateFaceCC.MouseEnter += new System.EventHandler(this.rotateFaceCC_MouseEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.changeFaceLeft);
            this.groupBox2.Controls.Add(this.changeFaceDown);
            this.groupBox2.Controls.Add(this.changeFaceRight);
            this.groupBox2.Controls.Add(this.changeFaceUp);
            this.groupBox2.Location = new System.Drawing.Point(3, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 80);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Switch Face";
            // 
            // changeFaceLeft
            // 
            this.changeFaceLeft.Location = new System.Drawing.Point(36, 19);
            this.changeFaceLeft.Name = "changeFaceLeft";
            this.changeFaceLeft.Size = new System.Drawing.Size(24, 24);
            this.changeFaceLeft.TabIndex = 35;
            this.changeFaceLeft.Text = "<";
            this.changeFaceLeft.UseVisualStyleBackColor = true;
            this.changeFaceLeft.Click += new System.EventHandler(this.changeFaceLeft_Click);
            // 
            // changeFaceDown
            // 
            this.changeFaceDown.Location = new System.Drawing.Point(66, 49);
            this.changeFaceDown.Name = "changeFaceDown";
            this.changeFaceDown.Size = new System.Drawing.Size(24, 24);
            this.changeFaceDown.TabIndex = 37;
            this.changeFaceDown.Text = "v";
            this.changeFaceDown.UseVisualStyleBackColor = true;
            this.changeFaceDown.Click += new System.EventHandler(this.changeFaceDown_Click);
            // 
            // changeFaceRight
            // 
            this.changeFaceRight.Location = new System.Drawing.Point(96, 19);
            this.changeFaceRight.Name = "changeFaceRight";
            this.changeFaceRight.Size = new System.Drawing.Size(24, 24);
            this.changeFaceRight.TabIndex = 36;
            this.changeFaceRight.Text = ">";
            this.changeFaceRight.UseVisualStyleBackColor = true;
            this.changeFaceRight.Click += new System.EventHandler(this.changeFaceRight_Click);
            // 
            // changeFaceUp
            // 
            this.changeFaceUp.Location = new System.Drawing.Point(66, 19);
            this.changeFaceUp.Name = "changeFaceUp";
            this.changeFaceUp.Size = new System.Drawing.Size(24, 24);
            this.changeFaceUp.TabIndex = 34;
            this.changeFaceUp.Text = "^";
            this.changeFaceUp.UseVisualStyleBackColor = true;
            this.changeFaceUp.Click += new System.EventHandler(this.changeFaceUp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button15);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 109);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rotate Row/Col";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(24, 24);
            this.button10.TabIndex = 22;
            this.button10.Text = "<";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.MouseLeave += new System.EventHandler(this.button10_MouseLeave);
            this.button10.Click += new System.EventHandler(this.negRotateY2);
            this.button10.MouseEnter += new System.EventHandler(this.button10_MouseEnter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "^";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.Click += new System.EventHandler(this.negRotateX0);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(66, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "^";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.Click += new System.EventHandler(this.negRotateX1);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 5;
            this.button3.Text = "^";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.button3.Click += new System.EventHandler(this.negRotateX2);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(126, 79);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 24);
            this.button6.TabIndex = 6;
            this.button6.Text = ">";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            this.button6.Click += new System.EventHandler(this.posRotateY0);
            this.button6.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(126, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 24);
            this.button5.TabIndex = 7;
            this.button5.Text = ">";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            this.button5.Click += new System.EventHandler(this.posRotateY1);
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(126, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 24);
            this.button4.TabIndex = 8;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            this.button4.Click += new System.EventHandler(this.posRotateY2);
            this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 79);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(24, 24);
            this.button12.TabIndex = 20;
            this.button12.Text = "<";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.MouseLeave += new System.EventHandler(this.button12_MouseLeave);
            this.button12.Click += new System.EventHandler(this.negRotateY0);
            this.button12.MouseEnter += new System.EventHandler(this.button12_MouseEnter);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 49);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(24, 24);
            this.button11.TabIndex = 21;
            this.button11.Text = "<";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.MouseLeave += new System.EventHandler(this.button11_MouseLeave);
            this.button11.Click += new System.EventHandler(this.negRotateY1);
            this.button11.MouseEnter += new System.EventHandler(this.button11_MouseEnter);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(36, 63);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(24, 24);
            this.button15.TabIndex = 23;
            this.button15.Text = "v";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.MouseLeave += new System.EventHandler(this.button15_MouseLeave);
            this.button15.Click += new System.EventHandler(this.posRotateX0);
            this.button15.MouseEnter += new System.EventHandler(this.button15_MouseEnter);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(66, 63);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(24, 24);
            this.button14.TabIndex = 24;
            this.button14.Text = "v";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.MouseLeave += new System.EventHandler(this.button14_MouseLeave);
            this.button14.Click += new System.EventHandler(this.posRotateX1);
            this.button14.MouseEnter += new System.EventHandler(this.button14_MouseEnter);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(96, 63);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(24, 24);
            this.button13.TabIndex = 25;
            this.button13.Text = "v";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.MouseLeave += new System.EventHandler(this.button13_MouseLeave);
            this.button13.Click += new System.EventHandler(this.posRotateX2);
            this.button13.MouseEnter += new System.EventHandler(this.button13_MouseEnter);
            // 
            // movesMadeLabel
            // 
            this.movesMadeLabel.AutoSize = true;
            this.movesMadeLabel.Location = new System.Drawing.Point(111, 287);
            this.movesMadeLabel.Name = "movesMadeLabel";
            this.movesMadeLabel.Size = new System.Drawing.Size(13, 13);
            this.movesMadeLabel.TabIndex = 44;
            this.movesMadeLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Moves Made:";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(4, 306);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 32;
            this.button7.Text = "Scramble";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.scrambleButtonClick);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(85, 306);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 19;
            this.button9.Text = "Solve";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.solveButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(718, 488);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBox1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(545, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 340F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(170, 482);
            this.tableLayoutPanel2.TabIndex = 40;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 343);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(164, 134);
            this.listBox1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 488);
            this.panel2.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem2});
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.newToolStripMenuItem1.Text = "File";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.resetToolStripMenuItem.Text = "New";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(106, 22);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.newToolStripMenuItem.Text = "New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem.Text = "Reset";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderModeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // renderModeToolStripMenuItem
            // 
            this.renderModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.solidToolStripMenuItem,
            this.wireframeToolStripMenuItem});
            this.renderModeToolStripMenuItem.Name = "renderModeToolStripMenuItem";
            this.renderModeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.renderModeToolStripMenuItem.Text = "Render Mode";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.normalToolStripMenuItem.Text = "Textured";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // solidToolStripMenuItem
            // 
            this.solidToolStripMenuItem.Name = "solidToolStripMenuItem";
            this.solidToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.solidToolStripMenuItem.Text = "Solid";
            this.solidToolStripMenuItem.Click += new System.EventHandler(this.solidToolStripMenuItem_Click);
            // 
            // wireframeToolStripMenuItem
            // 
            this.wireframeToolStripMenuItem.Name = "wireframeToolStripMenuItem";
            this.wireframeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.wireframeToolStripMenuItem.Text = "Wireframe";
            this.wireframeToolStripMenuItem.Click += new System.EventHandler(this.wireframeToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(718, 488);
            this.panel3.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 512);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Rubik\'s Cube Solver";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wireframeToolStripMenuItem;
        private System.Windows.Forms.Button rotateFaceCW;
        private System.Windows.Forms.Button changeFaceDown;
        private System.Windows.Forms.Button changeFaceRight;
        private System.Windows.Forms.Button changeFaceLeft;
        private System.Windows.Forms.Button changeFaceUp;
        private System.Windows.Forms.Button rotateFaceCC;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label movesMadeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

