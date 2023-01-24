using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils 
{
    public class ArrowPathController
    {
        public static ArrowPath Path { get; private set; }

        public static void CreatePath(Transform startPoint, Transform endPoint) {
            var direction = startPoint.forward;
            // var velocity = (endPoint.position - startPoint.position).magnitude * 0.5f;
            var velocity = ArrowStats.AttackStats.Movement.Force * 0.5f;
            // Path = new ArrowPath(startPoint.position, endPoint.position, direction, velocity);
            // ClosePath();
        }

        // public static void AddSegment(Transform anchor) {
        //     OpenPath();
        //     Path.AddSegment(anchor.position, ArrowStats.AttackStats.Movement.Force);
        //     ClosePath();
        // }

        public void MoveSegment(int i , Transform point) {
            if (i == 0) {
                var direction = point.forward;
                var velocity = ArrowStats.AttackStats.Movement.Force * 0.5f;

                Path.Points[i * 3] = point.position;
                Path.Points[i * 3 + 1] = point.position + (point.forward * velocity);
                Path.Points[i * 3 + 2] = (Path.Points[i * 3 + 1] + Path.Points[(i + 1) * 3]) * .5f;
            }
            else {
                var direction = (Path.Points[i * 3] - Path.Points[i * 3 - 1]);

                Path.Points[i * 3] = point.position;
                Path.Points[i * 3 + 1] = point.position + direction * ArrowStats.AttackStats.Movement.Force;
                Path.Points[i * 3 + 2] = point.position;
            }
        }

        // void Update()
        // {                
        //     if(TargetsCollection.Points == null || TargetsCollection.Points.Count == 0)
        //         return;

            

        //     for (var i = 1; i < TargetsCollection.Points.Count; i++) {
        //         Path.AddSegment(TargetsCollection.Points[i].position, this.force);  
        //     }

        //     if (loop && !Path.isClosed)
        //         Path.ToggleClosed(force);

        //     for (var i = 0; i < Path.NumOfSegments; i++) {
        //         // var segPoints = Path.GetPointsInSegment(Path.NumOfSegments - 1);
        //         // direction = (segPoints[2] - segPoints[3]).normalized;
        //         // Path.MovePoint(i * 3 + 2, (segPoints[1] - segPoints[0]) * 0.5f + direction * loopHole);
        //         // direction = (segPoints[1] - segPoints[0]).normalized;
        //         // Path.MovePoint(i * 3 + 1, segPoints[1] + direction * loopHole); 
        //         // if (Random.Range(0, 100) < 50) {
        //         var segPoints = Path.GetPointsInSegment(i);
        //         direction = (segPoints[1] - segPoints[0]).normalized;
        //         Path.MovePoint(i * 3 + 1, (segPoints[2] * 2 - (segPoints[2] - segPoints[3])) * 0.5f + direction * loopHole);
        //         direction = (segPoints[2] - segPoints[3]).normalized;
        //         Path.MovePoint(i * 3 + 2, (segPoints[1] * 2 - (segPoints[1]  - segPoints[0])) * 0.5f + direction * loopHole);
        //         // }
        //     }
        // }
    }
}