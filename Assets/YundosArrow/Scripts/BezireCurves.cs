using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts 
{
    public class BezireCurve : MonoBehaviour
    {
        public static Vector3 Lerp(Vector3 p0, Vector3 p1, float t) {
            return p0 + (p1 - p0) * t;
        }

        public static Vector3 Quadratic(Vector3 p0, Vector3 p1, Vector3 p2, float t) {
            var qPoint0 = Lerp(p0, p1, t); 
            var qPoint1 = Lerp(p1, p2, t); 
            return Lerp(qPoint0, qPoint1, t);
        }

        public static Vector3 Cubic(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
            var qPoint0 = Quadratic(p0, p1, p2, t); 
            var qPoint1 = Quadratic(p1, p2, p3, t); 
            return Lerp(qPoint0, qPoint1, t);
        }
    }
}
