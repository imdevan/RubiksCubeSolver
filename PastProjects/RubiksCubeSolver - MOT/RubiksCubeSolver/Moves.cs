using System;
using System.Collections.Generic;
using System.Text;

namespace RubiksCubeSolver
{
    public class Moves
    {
        public String rc, dir;
        private int num;
        private int weight;

        public Moves()
        {
            rc = "";
            dir = "";
            num = 0;
            weight = 0;
        }

        /// <summary>
        /// Sets a cube rotation move, with newFaceColor as the new fore-face. Does not
        ///     add to total move count.
        /// </summary>
        /// <param name="newFaceColor">Desired fore-face color.</param>
        public void setMove(String newFaceColor)
        {
            dir = newFaceColor.ToLower();
        }

        /// <summary>
        /// Sets a row, col, or face (clockwise or counter) move.
        /// </summary>
        /// <param name="rowcol"></param>
        /// <param name="number"></param>
        /// <param name="direction"></param>
        public void setMove(String rowcol, int number, String direction)
        {
            rc = rowcol.ToUpper();
            num = number;
            dir = direction.ToLower();
            weight = 1;
        }

        public String getRowCol()
        {
            return rc;
        }

        public int getNum()
        {
            return num;
        }

        public String getDirection()
        {
            return dir;
        }

        public int getWeight()
        {
            return weight;
        }

        public override string ToString()
        {
            string result = "";
            if (this.rc.Equals("R"))
            {
                result += "Row " + this.num;
                result += " " + dir;
            }
            else if (this.rc.Equals("C"))
            {
                result += "Column " + this.num;
                result += " " + dir;
            }
            else if (this.rc.Equals("F"))
            {
                result += "Rotate face " + this.dir;
            }
            else
            {
                result += "Change to " + dir + " face" + rc + " " + num;
            }
            return result;
        }
    }
}
