using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubiksCubeSolver
{
    public partial class rubiksCubeInterfaceForm : Form
    {
        public rubiksCubeInterfaceForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            brushButtonPanel.BackColor = whiteButton.BackColor;
            brush = brushButtonPanel.BackColor;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            brushButtonPanel.BackColor = greenButton.BackColor;
            brush = brushButtonPanel.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brushButtonPanel.BackColor = blueButton.BackColor;
            brush = brushButtonPanel.BackColor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            brushButtonPanel.BackColor = redButton.BackColor;
            brush = brushButtonPanel.BackColor;
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            brushButtonPanel.BackColor = yellowButton.BackColor;
            brush = brushButtonPanel.BackColor;
        }

        private void orangeButton_Click(object sender, EventArgs e)
        {
            brushButtonPanel.BackColor = orangeButton.BackColor;
            brush = brushButtonPanel.BackColor;
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            brushButtonPanel.BackColor = orangeButton.BackColor;
            brush = brushButtonPanel.BackColor;
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void rightArmCallobrationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void ClickHandler(object sender, System.EventArgs e)
        {
            ((Button)sender).BackColor = brush;
        }

    }
}
