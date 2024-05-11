using System.Collections.Generic;
using UnityEngine;

namespace HazarMath.Utils
{
    public static class VectorMath
    {
        public static Vector2 Rotate2D(Vector2 vector, float angle)
        {
            float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
            float cos = Mathf.Cos(angle * Mathf.Deg2Rad);

            float x = vector.x * cos - vector.y * sin;
            float y = vector.x * sin + vector.y * cos;

            return new Vector2(x, y);
        }
        
        public static Vector2 Rotate90(Vector2 vector)
        {
            return new Vector2(-vector.y, vector.x);
        }
        
        public static float Angle(Vector3 from, Vector3 to)
        {
            return Mathf.Acos(Vector3.Dot(from.normalized, to.normalized)) * Mathf.Rad2Deg;
        }
        
        public static Vector3 Project(Vector3 vector, Vector3 normal)
        {
            float sqrMag = normal.sqrMagnitude;
            if (sqrMag < Mathf.Epsilon) return Vector3.zero;

            return normal * Vector3.Dot(vector, normal) / sqrMag;
        }
        
        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            return vector - 2 * Vector3.Dot(vector, normal) * normal;
        }
        
        public static Vector3 OrthoNormalize(Vector3 normal, Vector3 tangent)
        {
            normal.Normalize();
            tangent -= Vector3.Dot(tangent, normal) * normal;
            tangent.Normalize();
            return tangent;
        }
        
        public static Vector3 GetOrthogonal(Vector3 vector)
        {
            Vector3 result = Vector3.Cross(vector, Vector3.up);
            if (result.sqrMagnitude < Mathf.Epsilon)
            {
                result = Vector3.Cross(vector, Vector3.right);
            }

            return result;
        }
        
        public static Vector3 ClosestPoint(IList<Vector3> points, Vector3 point)
        {
            Vector3 closestPoint = points[0];
            float closestDistance = (point - closestPoint).sqrMagnitude;
            for (int i = 1; i < points.Count; i++)
            {
                float distance = (point - points[i]).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPoint = points[i];
                }
            }

            return closestPoint;
        }
    }
}