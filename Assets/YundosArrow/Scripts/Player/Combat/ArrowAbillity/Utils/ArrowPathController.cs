using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils 
{
    public class ArrowPathController
    {
        [SerializeField] private bool loop;
        [SerializeField] private bool loop;
        [SerializeField, Range(1, 2)] private float force = 1f;
        [SerializeField, Range(1, 10)] private float loopHole = 1f;

        public static ArrowPath Path { get; set; }

        public static void CreatePath() {
            var direction = this.transform.forward;
            var velocity = (TargetsCollection.Points[0].position - this.transform.position).magnitude * 0.5f;
            Path = new ArrowPath(this.transform.position, TargetsCollection.Points[0].position, direction, velocity);
        }

        void Update()
        {                
            if(TargetsCollection.Points == null || TargetsCollection.Points.Count == 0)
                return;

            

            for (var i = 1; i < TargetsCollection.Points.Count; i++) {
                Path.AddSegment(TargetsCollection.Points[i].position, this.force);  
            }

            if (loop && !Path.isClosed)
                Path.ToggleClosed(force);

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
        }
    }
}