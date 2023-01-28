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

        public static Vector3 CubicPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
            var tSquare = Mathf.Pow(t, 2);
            var tTri = Mathf.Pow(t, 3);

            var P0 = p0 * (1 - (3 * t) + (3 * tSquare) - tTri);
            var P1 = p1 * ((3 * t) - (6 * tSquare) + (3 * tTri));
            var P2 = p2 * ((3 * tSquare) - (3 * tTri));
            var P3 = p3 * tTri;

            return P0 + P1 + P2 + P3;
        }

        public static Vector3 CubicDirection(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
            return CubicDerivative(p0, p1, p2, p3, t).normalized;
        }

        public static float CubicDistance(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
            var numOfSamples = 50;

            var arcLength = 0f;
            var prevSample = CubicPoint(p0, p1, p2, p3, 0);

            for (int i = 1; i <= numOfSamples; i++)
            {
                var nextSample = CubicPoint(p0, p1, p2, p3, (float)i / numOfSamples);
                arcLength += Vector3.Distance(prevSample, nextSample);
                prevSample = nextSample;
            }

            return arcLength;
        }

        public static float CubicVelocity(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
            return CubicDerivative(p0, p1, p2, p3, t).magnitude;
        }

        private static Vector3 CubicDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
            var tSquare = Mathf.Pow(t, 2);
            var tTri = Mathf.Pow(t, 3);

            var P0 =  -3 * p0 * Mathf.Pow((1-t), 2);
            var P1 = 3 * p1 * Mathf.Pow((1-t), 2) - 6 * t * (1-t) * p1;
            var P2 = 6 * t * (1-t) * p2 - 3 * tSquare * p2;
            var P3 =  3 * tSquare * p3;

            return (P0 + P1 + P2 + P3).normalized;
        }
    }
}
