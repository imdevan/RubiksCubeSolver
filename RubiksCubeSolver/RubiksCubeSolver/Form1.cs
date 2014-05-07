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
            Solver.Run(rubiksCube);
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void rightArmCallobrationPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void ClickHandler(object sender, System.EventArgs e)
        {
            // Paint the button the same color as the brush.
            ((Button)sender).BackColor = brush;

            // Cast the sender to a button.
            var button = sender as Button;

            // Get the face index.
            var fx = ((TableLayoutPanel)button.Parent.Parent).GetColumn((TableLayoutPanel)button.Parent);
            var fy = ((TableLayoutPanel)button.Parent.Parent).GetRow((TableLayoutPanel)button.Parent);
            int faceIndex = (fx ==1 && fy == 0) ? 1: 
                            (fx ==0 && fy == 1) ? 2: 
                            (fx ==1 && fy == 1) ? 3: 
                            (fx ==2 && fy == 1) ? 4: 
                            (fx ==3 && fy == 1) ? 5: 
                            (fx ==1 && fy == 2) ? 6: 0; 
                            
            // Get the cubie index on face.
            var cubex = ((TableLayoutPanel)button.Parent).GetColumn(button);
            var cubey = ((TableLayoutPanel)button.Parent).GetRow(button);

            // Set the color from the brush.
            Color color = (brush == System.Drawing.Color.Crimson) ? color = Color.RED :
                          (brush == System.Drawing.Color.RoyalBlue) ? color = Color.BLUE :
                          (brush == System.Drawing.Color.WhiteSmoke) ? color = Color.WHITE :
                          (brush == System.Drawing.Color.MediumSeaGreen) ? color = Color.GREEN :
                          (brush == System.Drawing.Color.Gold) ? color = Color.YELLOW :
                          (brush == System.Drawing.Color.DarkOrange) ? color = Color.ORANGE : Color.RED;
                          
            // Set the color of the cube.
            rubiksCube.faces[faceIndex - 1].cubies[cubex, cubey].color = color;

            // Verify
            Console.WriteLine( rubiksCube.faces[faceIndex - 1].cubies[cubex, cubey].ToString());
            Console.WriteLine(faceIndex + " (" + cubex + "," + cubey + ")");
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
                            rubiksCube.faces[fi].cubies[xi, yi].ToString()
                       );
                    }
                }

            }

        }

       
        
        /**********************************************************************************************************************************************
        * Calibration button callbacks.
        * *********************************************************************************************************************************************/

        // Right Arm Close
        private void rightArmCloseConfigPlusClick(object sender, EventArgs e)
        {
            // Right Arm Close Config Input
            byte cValue = Convert.ToByte(label2.Text);

        }
        private void rightArmCloseConfigMinusClick(object sender, EventArgs e)
        {
            // Right Arm Close Config Input
            byte cValue = Convert.ToByte(label2.Text);

        }


        // Right Arm Rotate
        private void rightArmRotateConfigPlusClick(object sender, EventArgs e)
        {
            // Right Arm Rotate Config Input
            byte cValue = Convert.ToByte(label3.Text);

        }
        private void rightArmRotateConfigMinusClick(object sender, EventArgs e)
        {
            // Right Arm Rotate Config Input
            byte cValue = Convert.ToByte(label3.Text);

            
        }


        // Left Arm Close
        private void leftArmCloseConfigPlusClick(object sender, EventArgs e)
        {
            // left Arm Close Config Input
            byte cValue = Convert.ToByte(label4.Text);

        }
        private void leftArmCloseConfigMinusClick(object sender, EventArgs e)
        {
            // left Arm Close Config Input
            byte cValue = Convert.ToByte(label4.Text);

        }


        // Left Arm Rotate
        private void leftArmRotateConfigPlusClick(object sender, EventArgs e)
        {
            // left Arm Rotate Config Input
            byte cValue = Convert.ToByte(label5.Text);

        }
        private void leftArmRotateConfigMinusClick(object sender, EventArgs e)
        {
            // left Arm Rotate Config Input
            byte cValue = Convert.ToByte(label5.Text);

        }


    }
}
