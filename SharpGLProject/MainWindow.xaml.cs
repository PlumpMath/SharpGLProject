using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SharpGLProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float _rQuad = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void OpenGLControl_OpenGLDraw(object sender, OpenGLEventArgs args)
        {
            //  Get the OpenGL instance that's been passed to us.
            OpenGL gl = args.OpenGL;

            //  Clear the color and depth buffers.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Reset the modelview.
            gl.LoadIdentity();

            //  Move into a more central position.
            gl.Translate(0.0f, 0.0f, -10.0f);

            //  Rotate the cube.
            gl.Rotate(_rQuad, 1.0f, 1.0f, 1.0f);

            //  Provide the cube colors and geometry.
            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(3.0f, 1.0f, -1.0f);
            gl.Vertex(-3.0f, 1.0f, -1.0f);
            gl.Vertex(-3.0f, 1.0f, 1.0f);
            gl.Vertex(3.0f, 1.0f, 1.0f);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(3.0f, 1.0f, -1.0f);
            gl.Vertex(-3.0f, 1.0f, -1.0f);
            gl.Vertex(-3.0f, -1.0f, 0.0f);
            gl.Vertex(3.0f, -1.0f, 0.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-3.0f, -1.0f, 0.0f);
            gl.Vertex(3.0f, -1.0f, 0.0f);
            gl.Vertex(-3.0f, 1.0f, 1.0f);
            gl.Vertex(3.0f, 1.0f, 1.0f);

            //gl.BindTexture()

            gl.End();

            //  Flush OpenGL.
            gl.Flush();

            // Rotate the geometry a bit.
            _rQuad -= 3.0f;
        }

        private void OpenGLControl_OpenGLInitialized(object sender, OpenGLEventArgs args)
        {
            //  Enable the OpenGL depth testing functionality.
            args.OpenGL.Enable(OpenGL.GL_DEPTH_TEST);
        }

        private void OpenGLControl_Resized(object sender, OpenGLEventArgs args)
        {
            //  Get the OpenGL instance.
            OpenGL gl = args.OpenGL;

            //  Load and clear the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();

            // Calculate The Aspect Ratio Of The Window
            gl.Perspective(45.0f, (float)gl.RenderContextProvider.Width / (float)gl.RenderContextProvider.Height,
                0.1f, 100.0f);

            //  Load the modelview.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
    }
}
