using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField, Range(1, 2)] private float force = 1f;

    private ArrowPath path;

    private IEnumerable Shoot() {

        if (this.path == null || path.NumOfSegments == 0) return;

        var positions = new List<Vector3>();

        var segmentIndex = 0;

        while(segmentIndex < this.path.NumOfSegments) {
            var t = 0f;

            while (t <= 1) {
                var segmentPoints = this.path.GetPointsInSegment(segmentIndex);
                positions.Add(BezireCurve.Cubic(segmentPoints[0], segmentPoints[1], segmentPoints[2], segmentPoints[3], t));

                // t += this.precision;
            }

            segmentIndex++;
        }
        
        this.line.positionCount = positions.Count;
        this.line.SetPositions(positions.ToArray());
    }
}
