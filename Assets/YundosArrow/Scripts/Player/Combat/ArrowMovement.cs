using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.VFX;

namespace YundosArrow.Scripts.Player 
{
    public class ArrowMovement : MonoBehaviour
    {
        [SerializeField] private Transform arrow;
        [SerializeField, Range(1, 4)] private float speed = 1f;

        private Transform parent;

        private IEnumerator Move() {
            var comps = this.GetComponents<LineRenderer>();
            foreach (var comp in comps)
                comp.enabled = false;

            if (PathCreator.Path == null || PathCreator.Path.NumOfSegments == 0) yield return null;

            this.arrow.parent = null;

            var segmentIndex = 0;

            var t = 0f;

            while(segmentIndex < PathCreator.Path.NumOfSegments) {
                // var t = 0f;
                t = 0f;

                while (t <= 1) {
                    yield return new WaitForEndOfFrame();

                    t += speed * Time.deltaTime;

                    var segmentPoints = PathCreator.Path.GetPointsInSegment(segmentIndex);
                    this.arrow.DOMove(BezireCurve.Cubic(segmentPoints[0], segmentPoints[1], segmentPoints[2], segmentPoints[3], t), 0f);
                    this.arrow.DOLookAt(BezireCurve.Quadratic(segmentPoints[1], segmentPoints[2], segmentPoints[3], t), 0.1f);
                }

                segmentIndex++;
            }

            this.arrow.parent = this.transform;

            // this.arrow.DOLocalMove(Vector3.zero, 3f);
            this.arrow.DOLocalRotateQuaternion(Quaternion.identity, 0f);

            foreach (var comp in comps)
                comp.enabled = true;
        }
    }
}
