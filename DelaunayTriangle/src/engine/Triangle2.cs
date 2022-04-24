using System;
using System.Collections.Generic;

namespace SimpleX.DelaunayTriangle.Engine
{
    class Triangle2
    {
        public Vector2 a;
        public Vector2 b;
        public Vector2 c;
        public bool invalid;

        public Triangle2(Vector2 a, Vector2 b, Vector2 c)
        {
            this.a = new Vector2(a);
            this.b = new Vector2(b);
            this.c = new Vector2(c);
            invalid = false;
        }

        public bool Contains(Vector2 v)
        {
            return a == v || b == v || c == v;
        }

        public bool CircleContains(Vector2 v)
        {
            var am = a.magnitude2;
            var bm = b.magnitude2;
            var cm = c.magnitude2;

            var x = (am * (c.y - b.y) + bm * (a.y - c.y) + cm * (b.y - a.y)) / (a.x * (c.y - b.y) + b.x * (a.y - c.y) + c.x * (b.y - a.y));
            var y = (am * (c.x - b.x) + bm * (a.x - c.x) + cm * (b.x - a.x)) / (a.y * (c.x - b.x) + b.y * (a.x - c.x) + c.y * (b.x - a.x));
            var p = new Vector2(x * 0.5f, y * 0.5f);

            return Vector2.Distance(v, p) <= Vector2.Distance(a, p);
        }
    }
}
