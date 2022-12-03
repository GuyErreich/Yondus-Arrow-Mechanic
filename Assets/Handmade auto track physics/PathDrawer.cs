using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathDrawer : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField, Range(1, 64)] private int precision = 4;
    private Path path;
    private LineRenderer line;

    private void Awake()
    {
        this.line = this.GetComponent<LineRenderer>();
        ResetPath();
    }

    private void ResetPath()
    {
        if(points == null || points.Count == 0)
            return;
        
        var direction = this.transform.forward;
        var velocity = (this.points[0].position - this.transform.position).magnitude * 0.5f;
        this.path = new Path(this.transform.position, this.points[0].position, direction, velocity);
        
        for (var i = 1; i < this.points.Count; i++) {
            this.path.AddSegment(this.points[i].position);
        }
    }

    private void LateUpdate() {
        this.ResetPath();

        if (this.path == null || path.NumOfSegments == 0) return;

        var positions = new List<Vector3>();

        var segmentIndex = 0;

        while(segmentIndex < this.path.NumOfSegments) {
            var t = 0f;

            while (t <= 1) {
                var segmentPoints = this.path.GetPointsInSegment(segmentIndex);
                positions.Add(BezireCurve.Cubic(segmentPoints[0], segmentPoints[1], segmentPoints[2], segmentPoints[3], t));

                t += 0.25f;
            }

            segmentIndex++;
        }
        
        this.line.positionCount = positions.Count;
        this.line.SetPositions(positions.ToArray());
    }
}
