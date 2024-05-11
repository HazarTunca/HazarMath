using UnityEngine;

namespace HazarMath.Utils
{
    public static class BezierMath
    {
        public static Vector3 GetPointQuadratic(Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            // (1 - t)^2 * p1 + 2 * (1 - t) * t * p2 + t^2 * p3
            t = Mathf.Clamp01(t);
            float oneMinusT = 1f - t;
            return oneMinusT * oneMinusT * p1 + 2f * oneMinusT * t * p2 + t * t * p3;
        }
        
        public static Vector3 GetPointCubic(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float t)
        {
            // (1 - t)^3 * p0 + 3 * (1 - t)^2 * t * p1 + 3 * (1 - t) * t^2 * p2 + t^3 * p3
            t = Mathf.Clamp01(t);
            float oneMinusT = 1f - t;
            return
                oneMinusT * oneMinusT * oneMinusT * p1 +
                3f * oneMinusT * oneMinusT * t * p2 +
                3f * oneMinusT * t * t * p3 +
                t * t * t * p4;
        }
        
        public static float GetLengthQuadratic(Vector3 p1, Vector3 p2, Vector3 p3, int segments)
        {
            float length = 0;
            Vector3 prevPoint = p1;
            for (int i = 1; i <= segments; i++)
            {
                Vector3 point = GetPointQuadratic(p1, p2, p3, i / (float)segments);
                length += Vector3.Distance(prevPoint, point);
                prevPoint = point;
            }

            return length;
        }
        
        public static float GetLengthCubic(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, int segments)
        {
            float length = 0;
            Vector3 prevPoint = p1;
            for (int i = 1; i <= segments; i++)
            {
                Vector3 point = GetPointCubic(p1, p2, p3, p4, i / (float)segments);
                length += Vector3.Distance(prevPoint, point);
                prevPoint = point;
            }

            return length;
        }
        
        public static Vector3 GetClosestPointQuadratic(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 point, int segments)
        {
            Vector3 closestPoint = p1;
            float closestDistance = (point - closestPoint).sqrMagnitude;
            for (int i = 1; i <= segments; i++)
            {
                Vector3 curvePoint = GetPointQuadratic(p1, p2, p3, i / (float)segments);
                float distance = (point - curvePoint).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPoint = curvePoint;
                }
            }

            return closestPoint;
        }
        
        public static Vector3 GetClosestPointCubic(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Vector3 point, int segments)
        {
            Vector3 closestPoint = p1;
            float closestDistance = (point - closestPoint).sqrMagnitude;
            for (int i = 1; i <= segments; i++)
            {
                Vector3 curvePoint = GetPointCubic(p1, p2, p3, p4, i / (float)segments);
                float distance = (point - curvePoint).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPoint = curvePoint;
                }
            }

            return closestPoint;
        }
    }
}