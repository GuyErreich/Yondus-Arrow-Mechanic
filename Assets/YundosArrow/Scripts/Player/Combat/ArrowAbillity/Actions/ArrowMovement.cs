using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions
{
    public class ArrowMovement
    {
        public static IEnumerator Move() {
            if (ArrowPathController.Path == null)
                throw new NullReferenceException("ArrowPathController.Path");

            if (ArrowPathController.Path.NumOfSegments == 0) 
                throw new Exception("ArrowPathController.Path cant be empty.", new IndexOutOfRangeException());

            var cacheParent = ArrowStats.Arrow.parent;
            ArrowStats.Arrow.parent = null;

            var segmentIndex = 0;
            var t = 0f;

            while(segmentIndex < ArrowPathController.Path.NumOfSegments) {
                t = 0f;

                while (t <= 1) {
                    yield return new WaitForEndOfFrame();

                    t += ArrowStats.AttackStats.Movement.Speed * Time.deltaTime;

                    var segmentPoints = ArrowPathController.Path.GetPointsInSegment(segmentIndex);
                    ArrowStats.Arrow.DOMove(BezireCurve.Cubic(segmentPoints[0], segmentPoints[1], segmentPoints[2], segmentPoints[3], t), 0f);
                    ArrowStats.Arrow.DOLookAt(BezireCurve.Quadratic(segmentPoints[1], segmentPoints[2], segmentPoints[3], t), 0.1f);
                }

                segmentIndex++;
            }

            ArrowStats.Arrow.parent = cacheParent;
            ArrowStats.Arrow.DOLocalRotateQuaternion(Quaternion.identity, 0f);

            // TargetsCollection.Points = null;
            // ArrowPathController.Path = null;
        }
    }
}
