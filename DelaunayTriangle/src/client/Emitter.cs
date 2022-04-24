using System;
using System.Collections.Generic;

namespace SimpleX.DelaunayTriangle.Client
{
    using SimpleX.DelaunayTriangle.Engine;

    class Emitter
    {
        private Random random = new Random();

        public List<Vector2> Emit(int n, int w, int h)
        {
            var L = 50;
            var R = w - 100;
            var B = 50;
            var T = h - 100;

            List<Vector2> vertices = new List<Vector2>();
            for (int i = 0; i < n; i++)
            {
                var x = random.Next(L, R);
                var y = random.Next(B, T);
                vertices.Add(new Vector2(x, y));
                Console.WriteLine($"({x},{y})");
            }

            return vertices;
        }
    }
}
