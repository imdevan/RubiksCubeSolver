using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CsGL.OpenGL;
using CsGL.Pointers;

namespace RubiksCubeSolver
{
    /// <summary>
    /// GLPanel is an instance of the OpenGLControl from the CsGL library. It creates a
    /// windows form element capable of displaying an OpenGL viewport. The OpenGL
    /// representation of the cube is kept here, and all initialization, controls, and
    /// rendering for the viewport are kept here as well.
    /// </summary>
    class GLPanel : OpenGLControl
    {
        public static int size = 3;
        public static int zoom = 20;
        public static float speed = 10.0f;
        public static uint[][] textures = new uint[7][];
        public static float[][] colors = new float[7][];

        public RubiksCube cube;

        // mode 0 normal, mode 1 color only, mode 2 wireframe 
        // (Not used in the demo version for simplicity)
        public uint mode = 0;

        public float cameraX = 0.0f;
        public float cameraY = 0.0f;
        public float cameraZ = 0.0f;

        public int mouseX;
        public int mouseY;
        public bool mouseDown;

        /// <summary>
        /// Create and initialize 
        /// </summary>
        public GLPanel()
            : base()
        {
            this.cube = new RubiksCube(size);
            this.KeyDown += new KeyEventHandler(OurView_OnKeyDown);
        }
        
        /// <summary>
        /// Shift+Q exits
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="kea"></param>
        protected void OurView_OnKeyDown(object Sender, KeyEventArgs kea)
        {
            if (kea.KeyCode == Keys.Q && kea.Modifiers == Keys.Shift)
            {
                Application.Exit();                                                             // Exit if the ESC key is pressed
            }
        }
        
        /// <summary>
        /// The standard glDraw method
        /// </summary>
        public override void glDraw()
        {
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);                        // Clear The Screen And The Depth Buffer    
            this.cube.render();
            Thread.Sleep(20);
        }
        
        /// <summary>
        /// Sets the mode to textured, solid, or wireframe
        /// </summary>
        /// <param name="m">0 for normal, 1 for color only, 2 for wireframe</param>
        public void setMode(uint m)
        {
            this.mode = m;
            if (this.mode == 0)
            {
                GL.glPolygonMode(GL.GL_FRONT, GL.GL_FILL);
                GL.glEnable(GL.GL_TEXTURE_2D);
                GL.glLineWidth(1.0f);
            }
            else if (this.mode == 1)
            {
                GL.glPolygonMode(GL.GL_FRONT, GL.GL_FILL);
                GL.glDisable(GL.GL_TEXTURE_2D);
                GL.glLineWidth(1.0f);
                GL.glEnable(GL.GL_LINE_SMOOTH);
            }
            else if (this.mode == 2)
            {
                GL.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);
                GL.glDisable(GL.GL_TEXTURE_2D);
                GL.glLineWidth(2.0f);
            }
            foreach (Block block in this.cube.blocks)
            {
                block.mode = this.mode;
            }
        }
        
        /// <summary>
        /// Initializes the state of the OpenGL viewport
        /// </summary>
        protected override void InitGLContext()
        {
            GL.glShadeModel(GL.GL_SMOOTH);                                                      // Set Smooth Shading                
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);                                            // BackGround Color        
            GL.glClearDepth(1.0f);                                                              // Depth buffer setup            
            GL.glEnable(GL.GL_DEPTH_TEST);                                                      // Enables Depth Testing            
            GL.glDepthFunc(GL.GL_LEQUAL);                                                       // The Type Of Depth Test To Do    
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);                         // Really Nice Perspective Calculations

            float[] global_ambient = { 5.0f, 5.0f, 5.0f, 1.0f };
            GL.glEnable(GL.GL_LIGHTING);
            GL.glLightModelfv(GL.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            this.setMode(0);

            Bitmap[] stickers = new Bitmap[7];
            stickers[0] = new Bitmap("images\\black.bmp");
            stickers[1] = new Bitmap("images\\orange.bmp");
            stickers[2] = new Bitmap("images\\white.bmp");
            stickers[3] = new Bitmap("images\\red.bmp");
            stickers[4] = new Bitmap("images\\blue.bmp");
            stickers[5] = new Bitmap("images\\green.bmp");
            stickers[6] = new Bitmap("images\\yellow.bmp");

            System.Drawing.Imaging.BitmapData bitmapdata;
            Bitmap image;
            Rectangle rect;
            for (uint i = 0; i < stickers.Length; i++)
            {
                image = stickers[i];
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                rect = new Rectangle(0, 0, image.Width, image.Height);
                bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                textures[i] = new uint[2];
                GL.glGenTextures(1, GLPanel.textures[i]);
                GL.glBindTexture(GL.GL_TEXTURE_2D, GLPanel.textures[i][0]);
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB8, image.Width, image.Height,
                    0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_LINEAR);		// Linear Filtering
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_LINEAR);		// Linear Filtering

                image.UnlockBits(bitmapdata);
                image.Dispose();
            }

            colors[0] = new float[3] { 0.0f, 0.0f, 0.0f };
            colors[1] = new float[3] { 1.0f, 0.5f, 0.0f };
            colors[2] = new float[3] { 1.0f, 1.0f, 1.0f };
            colors[3] = new float[3] { 1.0f, 0.0f, 0.0f };
            colors[4] = new float[3] { 0.0f, 0.0f, 1.0f };
            colors[5] = new float[3] { 0.0f, 1.0f, 0.0f };
            colors[6] = new float[3] { 1.0f, 1.0f, 0.0f };

        }
        
        /// <summary>
        /// Resize the window and refresh the cube when the window resizes
        /// </summary>
        /// <param name="e">Resize Event</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.refreshCube();
        }
        
        /// <summary>
        /// Redraw the cube based on the current perspective and window size
        /// </summary>
        public void refreshCube()
        {
            GL.glMatrixMode(GL.GL_PROJECTION);                                                  // Select The Projection Matrix
            GL.glLoadIdentity();                                                                // Reset The Projection Matrix
            GL.gluPerspective(45.0f, (double)this.Size.Width / (double)this.Size.Height, 0.1f, 100.0f);         // Calculate The Aspect Ratio Of The Window
            float x = (float)(Math.Sin(this.cameraX / 180 * Math.PI) * GLPanel.zoom);
            float y = (float)(Math.Sin(this.cameraY / 180 * Math.PI) * GLPanel.zoom);
            float z = (float)(Math.Cos(this.cameraX / 180 * Math.PI) * Math.Cos(this.cameraY / 180 * Math.PI) * GLPanel.zoom);
            GL.gluLookAt(x, y, z, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            GL.glMatrixMode(GL.GL_MODELVIEW);                                                   // Select The Modelview Matrix
            GL.glLoadIdentity();                                                                // Reset The Modelview Matrix
        }

        /// <summary>
        ///  Monitor for mouse clicks
        /// </summary>
        /// <param name="e">Mouse Event</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mouseDown = true;
            
            this.mouseX = e.X;
            this.mouseY = e.Y;
        }
        
        /// <summary>
        /// Monitor for mouse clicks
        /// </summary>
        /// <param name="e">Mouse Event</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.mouseDown = false;
        }
        
        /// <summary>
        /// Monitor for mouse movement to transform the camera perspective
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.mouseDown && e.Button == MouseButtons.Left)
            {
                this.cameraX += this.mouseX - e.X;
                this.cameraY += e.Y - this.mouseY;

                this.refreshCube();

                this.mouseX = e.X;
                this.mouseY = e.Y;
            }
            else if (this.mouseDown && e.Button == MouseButtons.Right)
            {

            }
        }
        
        /// <summary>
        /// Convert a set of Euler angles to a rotation matrix
        /// </summary>
        /// <param name="xAngle">Angle about the X axis by which to rotate</param>
        /// <param name="yAngle">Angle about the Y axis by which to rotate</param>
        /// <param name="zAngle">Angle about the Z axis by which to rotate</param>
        /// <returns></returns>
        public static float[] FromEulerAngles(float xAngle, float yAngle, float zAngle)
        {
            float a = (float)Math.Cos(xAngle);
            float b = (float)Math.Sin(xAngle);
            float c = (float)Math.Cos(yAngle);
            float d = (float)Math.Sin(yAngle);
            float e = (float)Math.Cos(zAngle);
            float f = (float)Math.Sin(zAngle);

            float ad = a * d;
            float bd = b * d;

            float[] matrix = new float[16];

            matrix[0] = c * e;
            matrix[1] = -1.0f * c * f;
            matrix[2] = d;
            matrix[4] = bd * e + a * f;
            matrix[5] = -1.0f * bd * f + a * e;
            matrix[6] = -1.0f * b * c;
            matrix[8] = -1.0f * ad * e + b * f;
            matrix[9] = ad * f + b * e;
            matrix[10] = a * c;
            matrix[3] = matrix[7] = matrix[11] = matrix[12] = matrix[13] = matrix[14] = 0;
            matrix[15] = 1;

            return matrix;
        }

    }
}
