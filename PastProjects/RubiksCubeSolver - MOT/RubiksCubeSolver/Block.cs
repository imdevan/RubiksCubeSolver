using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CsGL.OpenGL;
using CsGL.Pointers;

namespace RubiksCubeSolver
{
    class Block
    {

        public static uint myCircle = 1;

        /*
         * Temporary holder for rotation of a cube. This value is slowly decremented
         * while rendering to animate the movement of the cube.
         */ 
        private float rotateX = 0;
        private float rotateY = 0;
        private float rotateZ = 0;

        /*
         * Location of the block in the larger cube. This is expressed in terms
         * of three integers which count out along the x, y, and z axes starting
         * with 0,0,0 in the back, lower, left-hand corner.
         */
        private int locationX;
        private int locationY;
        private int locationZ;

        /*
         * Some constants to make it easy to refer to the different faces of the
         * individual cube.
         */
        public const uint FACE_TOP = 0;
        public const uint FACE_FRONT = 1;
        public const uint FACE_BOTTOM = 2;
        public const uint FACE_BACK = 3;
        public const uint FACE_LEFT = 4;
        public const uint FACE_RIGHT = 5;

        /*
         * Using our constants above we give each face a color. These will be set
         * by the RubiksCube class when the entire cube is built.
         */
        private uint[] faceColors = new uint[6];

        /*
         * Boolean to indicate whether or not the block is currently rotating.
         */
        public bool rotating = false;

        /*
         * Render mode, 0 = normal, 1 = solid, 2 = wireframe
         */
        public uint mode = 0;

        /*
         * Constructor. Sets the location of the block in the RubiksCube and sets
         * all face colors to zero which corresponds to black.
         */
        public Block(int x, int y, int z)
        {
            this.locationX = x;
            this.locationY = y;
            this.locationZ = z;
            
            this.faceColors[FACE_TOP] = 0;
            this.faceColors[FACE_RIGHT] = 0;
            this.faceColors[FACE_LEFT] = 0;
            this.faceColors[FACE_FRONT] = 0;
            this.faceColors[FACE_BOTTOM] = 0;
            this.faceColors[FACE_BACK] = 0;
        }

        public void render()
        {
            #region Rotate The Cube If Necessary

            /*
             * When a section is rotated, the set of cubes in that section are
             * given some non-zero value for their rotation (multiple of 90 degrees).
             * This method rotates the cube appropriately and slowly decrements
             * the angle to give the appearance of rotation.
             */

            if ((this.getRotateX() == 0) && (this.getRotateY() == 0) && (this.getRotateZ() == 0))
            {
                this.rotating = false;
            }
            else
            {
                this.rotating = true;
            }

            // Rotate X
            if (this.getRotateX() < 0)
            {
                this.setRotateX(this.getRotateX() + GLPanel.speed);
            }
            else if (this.getRotateX() > 0)
            {
                this.setRotateX(this.getRotateX() - GLPanel.speed);
            }
            // Rotate Y
            if (this.getRotateY() < 0)
            {
                this.setRotateY(this.getRotateY() + GLPanel.speed);
            }
            else if (this.getRotateY() > 0)
            {
                this.setRotateY(this.getRotateY() - GLPanel.speed);
            }
            // Rotate Z
            if (this.getRotateZ() < 0)
            {
                this.setRotateZ(this.getRotateZ() + GLPanel.speed);
            }
            else if (this.getRotateZ() > 0)
            {
                this.setRotateZ(this.getRotateZ() - GLPanel.speed);
            }

            float radiansX = (float)(this.getRotateX() / 180 * Math.PI);
            float radiansY = (float)(this.getRotateY() / 180 * Math.PI);
            float radiansZ = (float)(this.getRotateZ() / 180 * Math.PI);

            GL.glMultMatrixf(GLPanel.FromEulerAngles(radiansX, radiansY, radiansZ));

            #endregion

            #region Translate To The Blocks Position

            /*
             * Generate the position of the block in the scene given its location
             * in the RubiksCube.
             */
            float posX = this.getLocationX() * 2 - (GLPanel.size - 1);
            float posY = this.getLocationY() * 2 - (GLPanel.size - 1);
            float posZ = this.getLocationZ() * 2 - (GLPanel.size - 1);

            /*
             * Transform to the location of the block and then render each face.
             * For each face, we load the appropriate texture corresponding to the
             * face color.
             */ 
            GL.glTranslatef(posX, posY, posZ);

            #endregion

            #region Render The Cube Faces
            /*
             * Loads the appropriate texture by referring the array of textures using the
             * blocks face color (which corresponds to the texture image of the sticker
             * of that same color). Once we're done loading the texture we just build each
             * face of the cube.
             */

            float[] color;

            // Front Face
            GL.glBindTexture(GL.GL_TEXTURE_2D, GLPanel.textures[this.getFaceColor(Block.FACE_FRONT)][0]);
            color = GLPanel.colors[this.getFaceColor(Block.FACE_FRONT)];
            GL.glColor3f(color[0], color[1], color[2]);

            if ((color[0] + color[1] + color[2] != 0.0f) || (this.mode == 0))
            {
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(1.0f, 1.0f);			// top right of texture
                GL.glVertex3f(1.0f, 1.0f, 1.0f);		// top right of quad
                GL.glTexCoord2f(0.0f, 1.0f);			// top left of texture
                GL.glVertex3f(-1.0f, 1.0f, 1.0f);		// top left of quad
                GL.glTexCoord2f(0.0f, 0.0f);			// bottom left of texture
                GL.glVertex3f(-1.0f, -1.0f, 1.0f);	    // bottom left of quad
                GL.glTexCoord2f(1.0f, 0.0f);			// bottom right of texture
                GL.glVertex3f(1.0f, -1.0f, 1.0f);		// bottom right of quad
                GL.glEnd();
            }

            // Back Face
            GL.glBindTexture(GL.GL_TEXTURE_2D, GLPanel.textures[this.getFaceColor(Block.FACE_BACK)][0]);
            color = GLPanel.colors[this.getFaceColor(Block.FACE_BACK)];
            GL.glColor3f(color[0], color[1], color[2]);

            if ((color[0] + color[1] + color[2] != 0.0f) || (this.mode == 0))
            {
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(1.0f, 1.0f);			// top right of texture
                GL.glVertex3f(-1.0f, 1.0f, -1.0f);	    // top right of quad
                GL.glTexCoord2f(0.0f, 1.0f);			// top left of texture
                GL.glVertex3f(1.0f, 1.0f, -1.0f);		// top left of quad
                GL.glTexCoord2f(0.0f, 0.0f);			// bottom left of texture
                GL.glVertex3f(1.0f, -1.0f, -1.0f);	    // bottom left of quad
                GL.glTexCoord2f(1.0f, 0.0f);			// bottom right of texture
                GL.glVertex3f(-1.0f, -1.0f, -1.0f);	    // bottom right of quad
                GL.glEnd();
            }
            // Top Face
            GL.glBindTexture(GL.GL_TEXTURE_2D, GLPanel.textures[this.getFaceColor(Block.FACE_TOP)][0]);
            color = GLPanel.colors[this.getFaceColor(Block.FACE_TOP)];
            GL.glColor3f(color[0], color[1], color[2]);

            if ((color[0] + color[1] + color[2] != 0.0f) || (this.mode == 0))
            {
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(1.0f, 1.0f);			// top right of texture
                GL.glVertex3f(1.0f, 1.0f, -1.0f);		// top right of quad
                GL.glTexCoord2f(0.0f, 1.0f);			// top left of texture
                GL.glVertex3f(-1.0f, 1.0f, -1.0f);	    // top left of quad
                GL.glTexCoord2f(0.0f, 0.0f);			// bottom left of texture
                GL.glVertex3f(-1.0f, 1.0f, 1.0f);		// bottom left of quad
                GL.glTexCoord2f(1.0f, 0.0f);			// bottom right of texture
                GL.glVertex3f(1.0f, 1.0f, 1.0f);		// bottom right of quad
                GL.glEnd();
            }

            // Bottom Face
            GL.glBindTexture(GL.GL_TEXTURE_2D, GLPanel.textures[this.getFaceColor(Block.FACE_BOTTOM)][0]);
            color = GLPanel.colors[this.getFaceColor(Block.FACE_BOTTOM)];
            GL.glColor3f(color[0], color[1], color[2]);

            if ((color[0] + color[1] + color[2] != 0.0f) || (this.mode == 0))
            {
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(1.0f, 1.0f);			// top right of texture
                GL.glVertex3f(1.0f, -1.0f, 1.0f);		// top right of quad
                GL.glTexCoord2f(0.0f, 1.0f);			// top left of texture
                GL.glVertex3f(-1.0f, -1.0f, 1.0f);	    // top left of quad
                GL.glTexCoord2f(0.0f, 0.0f);			// bottom left of texture
                GL.glVertex3f(-1.0f, -1.0f, -1.0f);	    // bottom left of quad
                GL.glTexCoord2f(1.0f, 0.0f);			// bottom right of texture
                GL.glVertex3f(1.0f, -1.0f, -1.0f);	    // bottom right of quad
                GL.glEnd();
            }

            // Right Face
            GL.glBindTexture(GL.GL_TEXTURE_2D, GLPanel.textures[this.getFaceColor(Block.FACE_RIGHT)][0]);
            color = GLPanel.colors[this.getFaceColor(Block.FACE_RIGHT)];
            GL.glColor3f(color[0], color[1], color[2]);

            if ((color[0] + color[1] + color[2] != 0.0f) || (this.mode == 0))
            {
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(1.0f, 1.0f);			// top right of texture
                GL.glVertex3f(1.0f, 1.0f, -1.0f);		// top right of quad
                GL.glTexCoord2f(0.0f, 1.0f);			// top left of texture
                GL.glVertex3f(1.0f, 1.0f, 1.0f);		// top left of quad
                GL.glTexCoord2f(0.0f, 0.0f);			// bottom left of texture
                GL.glVertex3f(1.0f, -1.0f, 1.0f);		// bottom left of quad
                GL.glTexCoord2f(1.0f, 0.0f);			// bottom right of texture
                GL.glVertex3f(1.0f, -1.0f, -1.0f);	    // bottom right of quad
                GL.glEnd();
            }

            // Left Face
            GL.glBindTexture(GL.GL_TEXTURE_2D, GLPanel.textures[this.getFaceColor(Block.FACE_LEFT)][0]);
            color = GLPanel.colors[this.getFaceColor(Block.FACE_LEFT)];
            GL.glColor3f(color[0], color[1], color[2]);

            if ((color[0] + color[1] + color[2] != 0.0f) || (this.mode == 0))
            {
                GL.glBegin(GL.GL_QUADS);
                GL.glTexCoord2f(1.0f, 1.0f);			// top right of texture
                GL.glVertex3f(-1.0f, 1.0f, 1.0f);		// top right of quad
                GL.glTexCoord2f(0.0f, 1.0f);			// top left of texture
                GL.glVertex3f(-1.0f, 1.0f, -1.0f);	    // top left of quad
                GL.glTexCoord2f(0.0f, 0.0f);			// bottom left of texture
                GL.glVertex3f(-1.0f, -1.0f, -1.0f);	    // bottom left of quad
                GL.glTexCoord2f(1.0f, 0.0f);			// bottom right of texture
                GL.glVertex3f(-1.0f, -1.0f, 1.0f);	    // bottom right of quad
                GL.glEnd();
            }

            #endregion
        }

        public void rotate(float x, float y, float z)
        {
            this.rotateX += x;
            this.rotateY += y;
            this.rotateZ += z;
        }

        public void setFaceColor(uint face, uint color)
        {
            this.faceColors[face] = color;
        }

        public uint getFaceColor(uint face)
        {
            return this.faceColors[face];
        }

        public float getRotateX()
        {
            return this.rotateX;
        }
        public void setRotateX(float x)
        {
            this.rotateX = x;
        }

        public float getRotateY()
        {
            return this.rotateY;
        }
        public void setRotateY(float y)
        {
            this.rotateY = y;
        }

        public float getRotateZ()
        {
            return this.rotateZ;
        }
        public void setRotateZ(float z)
        {
            this.rotateZ = z;
        }

        public int getLocationX()
        {
            return this.locationX;
        }
        public void setLocationX(int x)
        {
            this.locationX = x;
        }

        public int getLocationY()
        {
            return this.locationY;
        }
        public void setLocationY(int y)
        {
            this.locationY = y;
        }

        public int getLocationZ()
        {
            return this.locationZ;
        }
        public void setLocationZ(int z)
        {
            this.locationZ = z;
        }

        public override string ToString()
        {
            string blah = "Location- " + this.getLocationX() + " " + this.getLocationY() + " " + this.getLocationZ() + ":";
            blah += "Rotation- " + this.getRotateX() + " " + this.getRotateY() + " " + this.getRotateZ() + ":";
            return blah;
        }

    }
}
