using System;

namespace SimpleX.DelaunayTriangle.Engine
{
    class Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 v)
            : this(v.x, v.y)
        {
            
        }

        public float magnitude
        {
            get { return (float)Math.Sqrt(magnitude2); }
        }

        public float magnitude2
        {
            get { return x * x + y * y; }
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            return (float)Math.Sqrt(Distance2(a, b));
        }

        public static float Distance2(Vector2 a, Vector2 b)
        {
            var dx = a.x - b.x;
            var dy = a.y - b.y;
            return dx * dx + dy * dy;
        }

        public static bool operator==(Vector2 a, Vector2 b)
        {
            return Numeric.Equal(a.x, b.x) && Numeric.Equal(a.y, b.y);
        }

        public static bool operator !=(Vector2 a, Vector2 b)
        {
            return !Numeric.Equal(a.x, b.x) || !Numeric.Equal(a.y, b.y);
        }
    }
}
