using System;
using System.Collections.Generic;
using System.Text;
using CsGL.OpenGL;
using CsGL.Pointers;

namespace RubiksCubeSolver
{
    /// <summary>
    /// Represents the OpenGL version of the Rubik's Cube.
    /// </summary>
    class RubiksCube
    {
        public Block[] blocks;
        private int size;

        public hintCircle[] hintCircles = new hintCircle[9];

        public const uint STICKER_ORANGE = 1;
        public const uint STICKER_WHITE = 2;
        public const uint STICKER_RED = 3;
        public const uint STICKER_BLUE = 4;
        public const uint STICKER_GREEN = 5;
        public const uint STICKER_YELLOW = 6;

        private bool scrambling = false;

        /// <summary>
        /// Constructor. Builds the Rubik's cube and initializes the hintCircles.
        /// </summary>
        /// <param name="s">The width/height/depth of the cube</param>
        public RubiksCube(int s)
        {
            this.size = s;
            this.blocks = new Block[(int)Math.Pow(s,3)];

            int count = 0;
            int locationX = 0;
            int locationY = 0;
            int locationZ = 0;
            
            for (float x = -1 * s; x < s; x += 2.0f)
            {
                locationY = 0;
                for (float y = -1 * s; y < s; y += 2.0f)
                {
                    locationZ = 0;
                    for (float z = -1 * s; z < s; z += 2.0f)
                    {
                        blocks[count] = new Block(locationX, locationY, locationZ);
                        if (locationX == 0)
                        {
                            blocks[count].setFaceColor(Block.FACE_LEFT, STICKER_RED);
                        }
                        if (locationX == s - 1)
                        {
                            blocks[count].setFaceColor(Block.FACE_RIGHT, STICKER_ORANGE);
                        }
                        if (locationY == 0)
                        {
                            blocks[count].setFaceColor(Block.FACE_BOTTOM, STICKER_BLUE);
                        }
                        if (locationY == s - 1)
                        {
                            blocks[count].setFaceColor(Block.FACE_TOP, STICKER_GREEN);
                        }
                        if (locationZ == 0)
                        {
                            blocks[count].setFaceColor(Block.FACE_BACK, STICKER_YELLOW);
                        }
                        if (locationZ == s - 1)
                        {
                            blocks[count].setFaceColor(Block.FACE_FRONT, STICKER_WHITE);
                        }
                        count++;
                        locationZ++;
                    }
                    locationY++;
                }
                locationX++;
            }

            this.hintCircles[0] = new hintCircle(new float[] { 0.0f, 0.0f, 1.0f }, -2.0f);
            this.hintCircles[1] = new hintCircle(new float[] { 0.0f, 0.0f, 1.0f }, 0.0f);
            this.hintCircles[2] = new hintCircle(new float[] { 0.0f, 0.0f, 1.0f }, 2.0f);
            this.hintCircles[3] = new hintCircle(new float[] { 0.0f, 1.0f, 0.0f }, -2.0f);
            this.hintCircles[4] = new hintCircle(new float[] { 0.0f, 1.0f, 0.0f }, 0.0f);
            this.hintCircles[5] = new hintCircle(new float[] { 0.0f, 1.0f, 0.0f }, 2.0f);
            this.hintCircles[6] = new hintCircle(new float[] { 1.0f, 0.0f, 0.0f }, -2.0f);
            this.hintCircles[7] = new hintCircle(new float[] { 1.0f, 0.0f, 0.0f }, 0.0f);
            this.hintCircles[8] = new hintCircle(new float[] { 1.0f, 0.0f, 0.0f }, 2.0f);
        }

        /// <summary>
        /// Run the OpenGL code for each block to render the overall cube.
        /// </summary>
        public void render()
        {
            foreach (hintCircle c in this.hintCircles)
            {
                c.draw();
            }

            foreach (Block block in this.blocks)
            {
                GL.glPushMatrix();
                GL.glLoadIdentity();
                block.render();
                GL.glPopMatrix();
            }
        }

        /// <summary>
        /// Tells whether any of the blocks are currently moving. This is used
        /// to determine when the next movement in a solution should be started.
        /// </summary>
        /// <returns></returns>
        public bool isRotating()
        {
            foreach (Block block in this.blocks)
            {
                if (block.rotating) return true;
            }
            return false;
        }

        /// <summary>
        /// Scrambles the OpenGL version of the cube. Not used in the final demo
        /// since all movements must go through the Orientation class. Left here for
        /// completeness.
        /// </summary>
        public void scramble()
        {
            this.scrambling = true;
            for (int i = 0; i < 1000; i++)
            {
                Random rand = new Random();
                for (int j = 0; j < rand.Next(9); j++)
                {
                    this.rotateX(rand.Next(this.size - 1), 1);
                }
                for (int j = 0; j < rand.Next(9); j++)
                {
                    this.rotateY(rand.Next(this.size - 1), 1);
                }
                for (int j = 0; j < rand.Next(9); j++)
                {
                    this.rotateZ(rand.Next(this.size - 1), 1);
                }
            }
            this.scrambling = false;
        }

        /// <summary>
        /// Find and rotate all the appropriate blocks 90 degrees around the X axis
        /// in the appropriate direction.
        /// </summary>
        /// <param name="location">The column to be rotated. (0 - 2 for a 3 sided cube)</param>
        /// <param name="direction">+/- 1, specifies rotation direction</param>
        public void rotateX(int location, int direction)
        {
            foreach (Block block in this.blocks)
            {
                if (block.getLocationX() == location)
                {
                    if (!this.scrambling) block.rotate(direction * 90.0f, 0.0f, 0.0f);
                    if (direction > 0)
                    {
                        int tempY = block.getLocationY();
                        block.setLocationY(this.size - 1 - block.getLocationZ());
                        block.setLocationZ(tempY);
                        uint tempFace = block.getFaceColor(Block.FACE_FRONT);
                        block.setFaceColor(Block.FACE_FRONT, block.getFaceColor(Block.FACE_TOP));
                        block.setFaceColor(Block.FACE_TOP, block.getFaceColor(Block.FACE_BACK));
                        block.setFaceColor(Block.FACE_BACK, block.getFaceColor(Block.FACE_BOTTOM));
                        block.setFaceColor(Block.FACE_BOTTOM, tempFace);
                    }
                    else
                    {
                        int tempZ = block.getLocationZ();
                        block.setLocationZ(this.size - 1 - block.getLocationY());
                        block.setLocationY(tempZ);
                        uint tempFace = block.getFaceColor(Block.FACE_FRONT);
                        block.setFaceColor(Block.FACE_FRONT, block.getFaceColor(Block.FACE_BOTTOM));
                        block.setFaceColor(Block.FACE_BOTTOM, block.getFaceColor(Block.FACE_BACK));
                        block.setFaceColor(Block.FACE_BACK, block.getFaceColor(Block.FACE_TOP));
                        block.setFaceColor(Block.FACE_TOP, tempFace);
                    }
                }
            }
        }

        /// <summary>
        /// Find and rotate all the appropriate blocks 90 degrees around the Y axis
        /// in the appropriate direction.
        /// </summary>
        /// <param name="location">The row to be rotated. (0 - 2 for a 3 sided cube)</param>
        /// <param name="direction">+/- 1, specifies rotation direction</param>
        public void rotateY(int location, int direction)
        {
            foreach (Block block in this.blocks)
            {
                if (block.getLocationY() == location)
                {
                    if (!this.scrambling) block.rotate(0.0f, direction * 90.0f, 0.0f);
                    if (direction > 0)
                    {
                        int tempZ = block.getLocationZ();
                        block.setLocationZ(this.size - 1 - block.getLocationX());
                        block.setLocationX(tempZ);
                        uint tempFace = block.getFaceColor(Block.FACE_FRONT);
                        block.setFaceColor(Block.FACE_FRONT, block.getFaceColor(Block.FACE_LEFT));
                        block.setFaceColor(Block.FACE_LEFT, block.getFaceColor(Block.FACE_BACK));
                        block.setFaceColor(Block.FACE_BACK, block.getFaceColor(Block.FACE_RIGHT));
                        block.setFaceColor(Block.FACE_RIGHT, tempFace);
                    }
                    else
                    {
                        int tempX = block.getLocationX();
                        block.setLocationX(this.size - 1 - block.getLocationZ());
                        block.setLocationZ(tempX);
                        uint tempFace = block.getFaceColor(Block.FACE_FRONT);
                        block.setFaceColor(Block.FACE_FRONT, block.getFaceColor(Block.FACE_RIGHT));
                        block.setFaceColor(Block.FACE_RIGHT, block.getFaceColor(Block.FACE_BACK));
                        block.setFaceColor(Block.FACE_BACK, block.getFaceColor(Block.FACE_LEFT));
                        block.setFaceColor(Block.FACE_LEFT, tempFace);
                    }
                }
            }
        }

        /// <summary>
        /// Find and rotate all the appropriate blocks 90 degrees around the Z axis
        /// in the appropriate direction.
        /// </summary>
        /// <param name="location">The layer to be rotated. (0 - 2 for a 3 sided cube)</param>
        /// <param name="direction">+/- 1, specifies rotation direction</param>
        public void rotateZ(int location, int direction)
        {
            foreach (Block block in this.blocks)
            {
                if (block.getLocationZ() == location)
                {
                    if (!this.scrambling) block.rotate(0.0f, 0.0f, direction * 90.0f);
                    if (direction > 0)
                    {
                        int tempX = block.getLocationX();
                        block.setLocationX(this.size - 1 - block.getLocationY());
                        block.setLocationY(tempX);
                        uint tempFace = block.getFaceColor(Block.FACE_LEFT);
                        block.setFaceColor(Block.FACE_LEFT, block.getFaceColor(Block.FACE_TOP));
                        block.setFaceColor(Block.FACE_TOP, block.getFaceColor(Block.FACE_RIGHT));
                        block.setFaceColor(Block.FACE_RIGHT, block.getFaceColor(Block.FACE_BOTTOM));
                        block.setFaceColor(Block.FACE_BOTTOM, tempFace);
                    }
                    else
                    {
                        int tempY = block.getLocationY();
                        block.setLocationY(this.size - 1 - block.getLocationX());
                        block.setLocationX(tempY);
                        uint tempFace = block.getFaceColor(Block.FACE_LEFT);
                        block.setFaceColor(Block.FACE_LEFT, block.getFaceColor(Block.FACE_BOTTOM));
                        block.setFaceColor(Block.FACE_BOTTOM, block.getFaceColor(Block.FACE_RIGHT));
                        block.setFaceColor(Block.FACE_RIGHT, block.getFaceColor(Block.FACE_TOP));
                        block.setFaceColor(Block.FACE_TOP, tempFace);
                    }
                }
            }
        }
        
        public override String ToString()
        {
            string result = "";
            foreach (Block block in this.blocks)
            {
                result += block.getLocationX() + " " + block.getLocationY() + " " + block.getLocationZ() + ":";
            }
            return result;
        }
    }
}
