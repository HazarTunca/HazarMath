using System.Collections.Generic;
using UnityEngine;

namespace HazarMath.Utils
{
    public static class ShapeMath
    {
        public static Vector2[] Circle(Vector2 center, float radius, int nPoints = 16)
        {
            Quaternion rot = Quaternion.Euler(0, 0, -360f / nPoints);
            Vector2 rad = Vector2.up * radius;

            Vector2[] points = new Vector2[nPoints];
            for (int i = 0; i < nPoints; i++)
            {
                Vector2 pos = center + rad;
                rad = rot * rad;
                points[i] = pos;
            }

            return points;
        }
        
        public static Vector2[] HalfCircle(Vector2 center, float radius, int nPoints = 16, bool right = true)
        {
            Quaternion rot = Quaternion.Euler(0, 0, (right ? -180f : 180f) / (nPoints - 1));
            Vector2 rad = Vector2.up * radius;

            Vector2[] points = new Vector2[nPoints];
            for (int i = 0; i < nPoints; i++)
            {
                Vector2 pos = center + rad;
                rad = rot * rad;
                points[i] = pos;
            }

            return points;
        }
        
        public static Vector2[] Rectangle(Vector2 center, float width, float height)
        {
            Vector2[] points = new Vector2[4];
            points[0] = center + new Vector2(-width / 2, -height / 2);
            points[1] = center + new Vector2(width / 2, -height / 2);
            points[2] = center + new Vector2(width / 2, height / 2);
            points[3] = center + new Vector2(-width / 2, height / 2);
            return points;
        }
        
        public static Vector2[] Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            return new Vector2[] { p1, p2, p3 };
        }
    }
}