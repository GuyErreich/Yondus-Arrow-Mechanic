using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils 
{
    [RequireComponent(typeof(LineRenderer))]
    public class PathDrawer : MonoBehaviour
    {
        [SerializeField, Range(0.01f, 1)] private float precision = 0.25f;
        private LineRenderer line;
        private int lineSplits;

        private void Awake()
        {
            this.line = this.GetComponent<LineRenderer>();
        }

        private void LateUpdate() {
            if (ArrowPathController.Path == null || ArrowPathController.Path.NumOfSegments == 0) {
                line.positionCount = 0;
                return;
            }

            var positions = new List<Vector3>();

            var segmentIndex = 0;

            while(segmentIndex < ArrowPathController.Path.NumOfSegments) {
                var t = 0f;

                while (t <= 1) {
                    var segmentPoints = ArrowPathController.Path.GetPointsInSegment(segmentIndex);
                    positions.Add(BezireCurve.Cubic(segmentPoints[0], segmentPoints[1], segmentPoints[2], segmentPoints[3], t));

                    t += this.precision;
                }

                segmentIndex++;
            }
            
            this.line.positionCount = positions.Count;
            this.line.SetPositions(positions.ToArray());
        }
    }
}