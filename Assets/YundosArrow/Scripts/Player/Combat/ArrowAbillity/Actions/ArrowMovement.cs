using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;
using YundosArrow.Scripts.Systems;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions
{
    public class ArrowMovement
    {
        public static bool IsMoving { get; private set; }
        // public static bool IsMoving { get => GlobalCollections.Path != null && GlobalCollections.Path.Count > 0f; }

        public static IEnumerator Move() {
            var targets = GlobalCollections.Targets;

            if (targets == null)
                throw new NullReferenceException("targets");

            if (targets.Count == 0) 
                throw new Exception("targets cant be empty.", new IndexOutOfRangeException());

            var cacheParent = ArrowStats.Arrow.parent;
            var localPos = ArrowStats.Arrow.localPosition;
            ArrowStats.Arrow.parent = null;
            // ArrowStats.Arrow.DOLookAt(targets[0].position, 0.2f);
            ArrowStats.Arrow.position = cacheParent.TransformPoint(localPos);
            IsMoving = true;
            
            var t = 0f;
            var distance = 0f;
            // var forward = Vector3.zero;
            ArrowPath path = null;

            while (targets.Count > 0) {
                t = 0f;
                var currentPos = ArrowStats.Arrow.position;
                distance = Vector3.Distance(currentPos, targets[0].position);
                // forward = ArrowStats.Arrow.forward;
                if (path == null)
                    path = new ArrowPath(ArrowStats.Arrow.position, targets[0].position, ArrowStats.Arrow.forward, ArrowStats.AttackStats.Movement.Force);
                else
                    path.ChangeDestination(targets[0].position, ArrowStats.AttackStats.Movement.Force);
                while (t <= 1f ) {
                    path.RecalculatePath(targets[0].position);
                    // ArrowStats.Arrow.DOLookAt(BezireCurve.Lerp(currentPos, targets[0].position, t), 0.2f);
                    // ArrowStats.Arrow.DOMove(BezireCurve.Lerp(currentPos, targets[0].position, t), 0f);
                    ArrowStats.Arrow.DOMove(BezireCurve.Cubic(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t), 0f);
                    ArrowStats.Arrow.DOLookAt(BezireCurve.Quadratic(path.Points[1], path.Points[2], path.Points[3], t), 0.2f);
                    // ArrowStats.Arrow.DOLookAt(BezireCurve.Quadratic(path.Points[1], path.Points[2], path.Points[3], t), 0.2f);
                    
                    yield return new WaitForEndOfFrame(); 

                    t += (ArrowStats.AttackStats.Movement.Speed / distance)  * Time.deltaTime;              
                    // t += ArrowStats.AttackStats.Movement.Speed * Time.deltaTime;              
                }
                targets.RemoveAt(0);
            }



            t = 0f;
            var lastPos = ArrowStats.Arrow.position;
            distance = Vector3.Distance(lastPos, ArrowStats.StartPoint.position);
            // forward = ArrowStats.Arrow.forward;
            path.ChangeDestination(ArrowStats.StartPoint.position, ArrowStats.AttackStats.Movement.Force);
            while (t <= 1f ) {
                path.RecalculatePath(ArrowStats.StartPoint.position);
                // ArrowStats.Arrow.DOLookAt(BezireCurve.Lerp(lastPos, ArrowStats.StartPoint.position, t), 0.2f);
                // ArrowStats.Arrow.DOMove(BezireCurve.Lerp(lastPos, ArrowStats.StartPoint.position, t), 0f);
                ArrowStats.Arrow.DOMove(BezireCurve.Cubic(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t), 0f);
                ArrowStats.Arrow.DOLookAt(BezireCurve.Quadratic(path.Points[1], path.Points[2], path.Points[3], t), 0.2f);
                yield return new WaitForEndOfFrame();

                t += (ArrowStats.AttackStats.Movement.Speed / distance) * Time.deltaTime;   
                // t += ArrowStats.AttackStats.Movement.Speed * Time.deltaTime;   
            }

            ArrowStats.Arrow.parent = cacheParent;
            ArrowStats.Arrow.DOLocalRotateQuaternion(Quaternion.identity, 0.2f);
            IsMoving = false;
        }

        // public static IEnumerator Move() {
        //     var path = GlobalCollections.Path;

        //     if (path == null)
        //         throw new NullReferenceException("path");

        //     if (path.Count == 0) 
        //         throw new Exception("path cant be empty.", new IndexOutOfRangeException());

        //     var cacheParent = ArrowStats.Arrow.parent;
        //     ArrowStats.Arrow.parent = null;

        //     while (path.Count > 0) {
        //         var t = 0f;
        //         var segment = path[0];
        //         while (t <= 1) {
        //             ArrowStats.Arrow.DOMove(BezireCurve.Lerp(segment.start, segment.end, t), 0f);
                    
        //             yield return new WaitForEndOfFrame();
        //             t += ArrowStats.AttackStats.Movement.Speed * Time.deltaTime;
        //         }
        //         path.RemoveAt(0);
        //         //TODO: try removing the dependence in GlobalCollections.Targets
        //         if (MarkTargets.IsMarked)
        //             GlobalCollections.Targets.RemoveAt(0);
        //     }

        //     ArrowStats.Arrow.parent = cacheParent;
        //     ArrowStats.Arrow.DOLocalRotateQuaternion(Quaternion.identity, 0f);
        // }
    }
}
