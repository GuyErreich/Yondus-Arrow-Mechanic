using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField, Range(1, 2)] private float force = 1f;
    [SerializeField, Range(1, 4)] private float speed = 1f;

    private ArrowPath path;

    private void Awake() {
        this.ResetPath();
    }

    private void ResetPath()
    {
        if(points == null || points.Count == 0)
            return;
        
        var direction = this.transform.forward;
        var velocity = (this.points[0].position - this.transform.position).magnitude * 0.5f;
        this.path = new ArrowPath(this.transform.position, this.points[0].position, direction, velocity);
        
        for (var i = 1; i < this.points.Count; i++) {
            this.path.AddSegment(this.points[i].position, this.force);
        }
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot() {
        if (this.path == null || path.NumOfSegments == 0) yield return null;

        var segmentIndex = 0;

        while(segmentIndex < this.path.NumOfSegments) {
            var t = 0f;

            while (t <= 1) {
                var segmentPoints = this.path.GetPointsInSegment(segmentIndex);
                this.transform.position = BezireCurve.Cubic(segmentPoints[0], segmentPoints[1], segmentPoints[2], segmentPoints[3], t);

                yield return new WaitForEndOfFrame();

                t += speed * Time.deltaTime;
            }

            segmentIndex++;
        }
    }
}
