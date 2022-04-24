using System;

namespace SimpleX.DelaunayTriangle.Engine
{
    class Numeric
    {
        public static bool Equal(float a, float b)
        {
            return Math.Abs(a - b) <= float.Epsilon;
        }
    }
}
