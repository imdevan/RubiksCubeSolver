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
            ValidateCube();
            SendCubeToSolver();
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

        private void ValidateCube() 
        {
              /**********************************************************************************************************************************************
             * Cube Validation Iterates over user interface cube and checks that each cubie has the correct corresponding sides.
             * *********************************************************************************************************************************************/
            for (int fi = 0; fi < rubiksCube.faces.Length; fi++)
            {
                // iterate over each cube face
                for (int yi = 0; yi < 3; yi++)
                {
                    for (int xi = 0; xi < 3; xi++)
                    {
                        // TODO: check cube here.
                        Console.WriteLine(
                            rubiksCube.faces[fi].cubies[xi,yi].ToString()
                       );
                    }
                }

            }

        }

        private void SendCubeToSolver()
        {
            // TODO:
        }
    }
}
