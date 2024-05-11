using UnityEngine;

namespace HazarMath.Utils
{
    public static class FloatMath
    {
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
        
        public static float InverseLerp(float a, float b, float value)
        {
            return (value - a) / (b - a);
        }
        
        public static float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return Lerp(from2, to2, InverseLerp(from1, to1, value));
        }
        
        public static float Normalize(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }
    }
}