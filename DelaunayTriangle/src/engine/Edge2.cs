using System;

namespace SimpleX.DelaunayTriangle.Engine
{
    class Edge2
    {
        public Vector2 u;
        public Vector2 w;
        public bool invalid;

        public Edge2(Vector2 a, Vector2 b)
        {
            u = new Vector2(a);
            w = new Vector2(b);
            invalid = false;
        }

        public static bool operator ==(Edge2 a, Edge2 b)
        {
            return (a.u == b.u && a.w == b.w) || (a.w == b.u && a.u == b.w);
        }

        public static bool operator !=(Edge2 a, Edge2 b)
        {
            return (a.u != b.u || a.w != b.w) && (a.w != b.u && a.u != b.w);
        }
    }
}
