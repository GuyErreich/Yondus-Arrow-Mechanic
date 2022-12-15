using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player 
{
    [RequireComponent(typeof(MarkTargets))]
    public class PathCreator : MonoBehaviour
    {
        [SerializeField] private bool loop;
        [SerializeField, Range(1, 2)] private float force = 1f;
        [SerializeField, Range(1, 10)] private float loopHole = 1f;

        public static ArrowPath Path { get; private set; }

        // Update is called once per frame
        void Update()
        {                
            if(MarkTargets.Points == null || MarkTargets.Points.Count == 0)
                return;

            var direction = this.transform.forward;
            var velocity = (MarkTargets.Points[0].position - this.transform.position).magnitude * 0.5f;
            Path = new ArrowPath(this.transform.position, MarkTargets.Points[0].position, direction, velocity);

            for (var i = 1; i < MarkTargets.Points.Count; i++) {
                Path.AddSegment(MarkTargets.Points[i].position, this.force);  
            }

            for (var i = 0; i < Path.NumOfSegments; i++) {
                // var segPoints = Path.GetPointsInSegment(Path.NumOfSegments - 1);
                // direction = (segPoints[2] - segPoints[3]).normalized;
                // Path.MovePoint(i * 3 + 2, (segPoints[1] - segPoints[0]) * 0.5f + direction * loopHole);
                // direction = (segPoints[1] - segPoints[0]).normalized;
                // Path.MovePoint(i * 3 + 1, segPoints[1] + direction * loopHole); 
                // if (Random.Range(0, 100) < 50) {
                var segPoints = Path.GetPointsInSegment(i);
                direction = (segPoints[1] - segPoints[0]).normalized;
                Path.MovePoint(i * 3 + 1, (segPoints[2] * 2 - (segPoints[2] - segPoints[3])) * 0.5f + direction * loopHole);
                direction = (segPoints[2] - segPoints[3]).normalized;
                Path.MovePoint(i * 3 + 2, (segPoints[1] * 2 - (segPoints[1]  - segPoints[0])) * 0.5f + direction * loopHole);
                // }
            }
            if (loop && !Path.isClosed)
                Path.ToggleClosed(force);
        }
    }
}