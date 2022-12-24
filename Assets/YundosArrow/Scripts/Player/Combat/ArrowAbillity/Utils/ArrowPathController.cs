using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils 
{
    public class ArrowPathController
    {
        public static ArrowPath Path { get; private set; }

        public static void CreatePath(Transform startPoint, Transform endPoint) {
            var direction = startPoint.forward;
            var velocity = (endPoint.position - startPoint.position).magnitude * 0.5f;
            Path = new ArrowPath(startPoint.position, endPoint.position, direction, velocity);
            ClosePath();
        }

        //TODO: update position of targets in the arrow path

        public static void AddSegment(Transform anchor) {
            OpenPath();
            Path.AddSegment(anchor.position, ArrowStats.AttackStats.Movement.Force);
            ClosePath();
        }

        private static void ClosePath() {
            if (!Path.isClosed)
                Path.ToggleClosed(ArrowStats.AttackStats.Movement.Force);
        }

        private static void OpenPath() {
            if (Path.isClosed)
                Path.ToggleClosed(ArrowStats.AttackStats.Movement.Force);
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