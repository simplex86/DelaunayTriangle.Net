using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DelaunayTriangle
{
    using SimpleX.DelaunayTriangle.Client;
    using SimpleX.DelaunayTriangle.Engine;

    public partial class MainForm : Form
    {
        private Delaunay delaunay = new Delaunay();
        private Renderer renderer = new Renderer();
        private Emitter emitter = new Emitter();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Delaunay()
        {
            var verticNum = (int)mVerticNum.Value;

            List<Vector2> vertices = emitter.Emit(verticNum, mPictureBox.Width, mPictureBox.Height);
            delaunay.Triangulate(vertices);

            renderer.SetVertices(vertices);
            renderer.SetTriangles(delaunay.triangles);
        }

        private void OnPictureBoxPaintHandler(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            renderer.Draw(e.Graphics);
        }

        private void OnRefreshClickedHandler(object sender, EventArgs e)
        {
            Delaunay();
            mPictureBox.Refresh();
        }

        private void OnFormShownHandler(object sender, EventArgs e)
        {
            Delaunay();
            mPictureBox.Refresh();
        }
    }
}
