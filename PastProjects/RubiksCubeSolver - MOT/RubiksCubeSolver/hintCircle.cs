using System;
using System.Collections.Generic;
using System.Text;
using CsGL.OpenGL;
using CsGL.Pointers;

namespace RubiksCubeSolver
{
    /// <summary>
    /// Represents a circle in the OpenGL viewport that shows which section each
    /// button manipulates by enabling a circle when you mouseover a button.
    /// </summary>
    class hintCircle
    {
        public bool status = false;
        float[] rotation = new float[3];
        float location;
        const float DEG2RAD = (float)3.14159 / 180;

        public hintCircle(float[] r, float l)
        {
            this.rotation = r;
            this.location = l;
        }

        public void draw()
        {
            if (this.status)
            {
                GL.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);
                GL.glDisable(GL.GL_TEXTURE_2D);
                GL.glPushMatrix();
                GL.glRotatef(90.0f, this.rotation[0], this.rotation[1], this.rotation[2]);
                GL.glTranslatef(0.0f, 0.0f, this.location);

                GL.glBegin(GL.GL_LINE_LOOP);
                for (int i = 0; i < 360; i++)
                {
                    float degInRad = i * DEG2RAD;
                    GL.glVertex2f((float)Math.Cos(degInRad) * 6, (float)Math.Sin(degInRad) * 6);
                }
                GL.glEnd();

                GL.glPopMatrix();
                GL.glPolygonMode(GL.GL_FRONT, GL.GL_FILL);
                GL.glEnable(GL.GL_TEXTURE_2D);
            }
        }

    }
}
