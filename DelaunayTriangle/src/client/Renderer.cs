using System;
using System.Collections.Generic;
using System.Drawing;

namespace SimpleX.DelaunayTriangle.Client
{
    using SimpleX.DelaunayTriangle.Engine;

    class Renderer
    {
        private List<Vector2> vertices;
        private List<Triangle2> triangles;

        public void Draw(Graphics g)
        {
            if (triangles != null)
            {
                foreach (var t in triangles)
                {
                    Draw(t, g);
                }
            }

            if (vertices != null)
            {
                foreach (var v in vertices)
                {
                    Draw(v, g);
                }
            }
        }

        public void SetVertices(List<Vector2> vertices)
        {
            this.vertices = vertices;
        }

        public void SetTriangles(List<Triangle2> triangles)
        {
            this.triangles = triangles;
        }

        private void Draw(Triangle2 triangle, Graphics graph)
        {
            var p = new Pen(Color.Black);
            var a = new PointF(triangle.a.x, triangle.a.y);
            var b = new PointF(triangle.b.x, triangle.b.y);
            var c = new PointF(triangle.c.x, triangle.c.y);
            graph.DrawLine(p, a, b);
            graph.DrawLine(p, b, c);
            graph.DrawLine(p, c, a);
        }

        private void Draw(Vector2 vertic, Graphics graph)
        {
            var r = new RectangleF(vertic.x - 2f, vertic.y - 2f, 4, 4);

            var p = new Pen(Color.Red);
            graph.DrawEllipse(p, r);
            var b = new SolidBrush(Color.Red);
            graph.FillEllipse(b, r);
        }
    }
}
