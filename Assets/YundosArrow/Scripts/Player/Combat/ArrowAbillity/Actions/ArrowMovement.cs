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
        //     if (ArrowPathController.Path == null)
        //         throw new NullReferenceException("ArrowPathController.Path");

        //     if (ArrowPathController.Path.NumOfSegments == 0) 
        //         throw new Exception("ArrowPathController.Path cant be empty.", new IndexOutOfRangeException());

            var cacheParent = ArrowStats.Arrow.parent;
            ArrowStats.Arrow.parent = null;

            var path = GlobalCollections.Path;
            while (path.Count > 0) {
                var t = 0f;
                var segment = path[0];
                while (t <= 1) {
                    ArrowStats.Arrow.DOMove(BezireCurve.Lerp(segment.start, segment.end, t), 0f);
                    
                    yield return new WaitForEndOfFrame();
                    t += 0.2f * Time.deltaTime;
                }
                path.RemoveAt(0);
            }

            GlobalCollections.Targets.Clear();

            ArrowStats.Arrow.parent = cacheParent;
            ArrowStats.Arrow.DOLocalRotateQuaternion(Quaternion.identity, 0f);

            // TargetsCollection.Points = null;
            // ArrowPathController.Path = null;
        }
    }
}
