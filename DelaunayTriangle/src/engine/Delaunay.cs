using System;
using System.Collections.Generic;

namespace SimpleX.DelaunayTriangle.Engine
{
    class Delaunay
    {
        public List<Triangle2> triangles { get; } = new List<Triangle2>();

        public void Triangulate(List<Vector2> vertices)
        {
            triangles.Clear();

            var minX = vertices[0].x;
            var minY = vertices[0].y;
            var maxX = minX;
            var maxY = minY;

            foreach (var v in vertices)
            {
                minX = Math.Min(minX, v.x);
                minY = Math.Min(minY, v.y);
                maxX = Math.Max(maxX, v.x);
                maxY = Math.Max(maxY, v.y);
            }

            var dx = maxX - minX;
            var dy = maxY - minY;
            var dt = Math.Max(dx, dy);
            var mx = (minX + maxX) * 0.5f;
            var my = (minY + maxY) * 0.5f;

            var p1 = new Vector2(mx - 2 * dt, my - dt);
            var p2 = new Vector2(mx, my + 2 * dt);
            var p3 = new Vector2(mx + 2 * dt, my - dt);

            triangles.Add(new Triangle2(p1, p2, p3));

            foreach (var p in vertices)
            {
                List<Edge2> polygon = new List<Edge2>();

                foreach (var t in triangles)
                {
                    if (t.CircleContains(p))
                    {
                        t.invalid = true;
                        polygon.Add(new Edge2(t.a, t.b));
                        polygon.Add(new Edge2(t.b, t.c));
                        polygon.Add(new Edge2(t.c, t.a));
                    }
                }
                triangles.RemoveAll((t) => { return t.invalid; });

                for (int i=0; i<polygon.Count; i++)
                {
                    var e1 = polygon[i];
                    for (int k=i+1; k<polygon.Count; k++)
                    {
                        var e2 = polygon[k];
                        if (e1 == e2) // 如果两条边重合，则把两条边都删除
                        {
                            e1.invalid = true;
                            e2.invalid = true;
                        }
                    }
                }
                polygon.RemoveAll((e) => { return e.invalid; });

                foreach (var e in polygon)
                {
                    triangles.Add(new Triangle2(e.u, e.w, p));
                }
            }
            triangles.RemoveAll((t) => { return t.Contains(p1) || t.Contains(p2) || t.Contains(p3); });
        }
    }
}
