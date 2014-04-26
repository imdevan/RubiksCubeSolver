using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RubiksCubeSolver
{
    public partial class NewCube : Form
    {
        public NewCube()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.myForm.newCube((int)this.numericUpDown1.Value,this.checkBox1.Checked);
            GLPanel.size = (int)this.numericUpDown1.Value;
            GLPanel.zoom = GLPanel.size * 4 + 8;
            MainForm.myForm.refreshGLPanel();
            this.Close();
        }
    }
}