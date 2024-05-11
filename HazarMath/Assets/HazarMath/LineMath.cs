using System;
using System.Collections.Generic;
using UnityEngine;

namespace HazarMath.Utils
{
    public static class LineMath
    {
        public static Vector2 GetPointOnLine(Vector2 p1, Vector2 p2, float t)
        {
            return p1 + (p2 - p1) * t;
        }
        public static Vector2 GetPointOnLineSegment(Vector2 p1, Vector2 p2, float t)
        {
            return p1 + (p2 - p1) * Mathf.Clamp01(t);
        }
        
        public static float GetIntersectionOnLine(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            float x1 = p1.x;
            float y1 = p1.y;
            
            float x2 = p2.x;
            float y2 = p2.y;
            
            float x3 = p3.x;
            float y3 = p3.y;
            
            float x4 = p4.x;
            float y4 = p4.y;
            
            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (Mathf.Abs(den) < Mathf.Epsilon)
            {
                return float.NaN;
            }
            
            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
            return t;
        }
        public static Vector2 GetIntersectionPointOnLine(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            float x1 = p1.x;
            float y1 = p1.y;
            
            float x2 = p2.x;
            float y2 = p2.y;
            
            float x3 = p3.x;
            float y3 = p3.y;
            
            float x4 = p4.x;
            float y4 = p4.y;
            
            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (Mathf.Abs(den) < Mathf.Epsilon)
            {
                return Vector2.zero;
            }
            
            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
            return GetPointOnLine(p1, p2, t);
        }
        public static float GetIntersectionOnLineSegment(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            float x1 = p1.x;
            float y1 = p1.y;
            
            float x2 = p2.x;
            float y2 = p2.y;
            
            float x3 = p3.x;
            float y3 = p3.y;
            
            float x4 = p4.x;
            float y4 = p4.y;
            
            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (Mathf.Abs(den) < Mathf.Epsilon)
            {
                return float.NaN;
            }
            
            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
            if (t < 0 || t > 1)
            {
                return float.NaN;
            }
            return t;
        }
        public static Vector2 GetIntersectionPointOnLineSegment(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            float x1 = p1.x;
            float y1 = p1.y;
            
            float x2 = p2.x;
            float y2 = p2.y;
            
            float x3 = p3.x;
            float y3 = p3.y;
            
            float x4 = p4.x;
            float y4 = p4.y;
            
            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (Mathf.Abs(den) < Mathf.Epsilon)
            {
                return Vector2.zero;
            }
            
            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
            if (t < 0 || t > 1)
            {
                return Vector2.zero;
            }
            return GetPointOnLineSegment(p1, p2, t);
        }
        
        public static Vector2 GetClosestPointOnLine(Vector2 p1, Vector2 p2, Vector2 point)
        {
            Vector2 lineDir = p2 - p1;
            float lineLenght = lineDir.magnitude;
            lineDir /= lineLenght;
            
            float t = Vector2.Dot(point - p1, lineDir);
            return p1 + lineDir * t;
        }
        public static Vector2 GetClosestPointOnLineSegment(Vector2 p1, Vector2 p2, Vector2 point)
        {
            Vector2 lineDir = p2 - p1;
            float lineLenght = lineDir.magnitude;
            lineDir /= lineLenght;
            
            float t = Vector2.Dot(point - p1, lineDir);
            t = Mathf.Clamp(t, 0, lineLenght);
            return p1 + lineDir * t;
        }
        
        public static bool IsPointOnLine(Vector2 p1, Vector2 p2, Vector2 point)
        {
            Vector2 lineVec = p2 - p1;
            Vector2 pointVec = point - p1;
            float determinant = lineVec.x * pointVec.y - lineVec.y * pointVec.x;

            return Mathf.Abs(determinant) < Mathf.Epsilon;
        }
        public static bool IsPointOnLineSegment(Vector2 p1, Vector2 p2, Vector2 point)
        {
            Vector2 lineDir = p2 - p1;
            float lineLenght = lineDir.magnitude;
            lineDir /= lineLenght;
            
            float t = Vector2.Dot(point - p1, lineDir);
            return t >= 0 && t <= lineLenght;
        }
        
        public static bool AreLineSegmentsIntersecting(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            float x1 = p1.x;
            float y1 = p1.y;
            
            float x2 = p2.x;
            float y2 = p2.y;
            
            float x3 = p3.x;
            float y3 = p3.y;
            
            float x4 = p4.x;
            float y4 = p4.y;
            
            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (Mathf.Abs(den) < Mathf.Epsilon)
            {
                return false;
            }
            
            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / den;
            float u = -((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / den;
            return t >= 0 && t <= 1 && u >= 0 && u <= 1;
        }
    }
}