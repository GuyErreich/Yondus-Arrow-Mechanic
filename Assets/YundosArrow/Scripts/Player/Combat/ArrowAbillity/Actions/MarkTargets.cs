using System;
using System.Collections.Generic;
using UnityEngine;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions
{
    public static class MarkTargets
    {
        private static LinearArrowPath path;
        private static List<Transform> targets;

        private static RaycastHit _hit;

        public static bool IsMarked { get => targets != null && targets.Count > 0f; }

        public static void Mark() {                
            Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));

            if (Physics.SphereCast(ray, ArrowStats.AttackStats.MarkTargets.Radius, out _hit, ArrowStats.AttackStats.MarkTargets.Range, ArrowStats.AttackStats.MarkTargets.LayerMask)) {
                if (InputReceiver.Bool[InputReceiverType.ShootPressed])
                    if(!GlobalCollections.Targets.Contains(_hit.transform)) {
                        if (!IsMarked) {
                            path = new LinearArrowPath();
                            targets = 
                            path.AddSegment(ArrowStats.StartPoint.position, _hit.point);
                            targets.Add(_hit.transform);
                        }
                        else {
                            GlobalCollections.Targets.Add(_hit.transform);
                            ArrowPathController.AddSegment(_hit.transform);
                        }
                    }
            }

            if (_hit.point == Vector3.zero)
                _hit.point = ray.origin + ray.direction * ArrowStats.AttackStats.MarkTargets.RangeOnNoHit;
        }

        public static void ResetTargets() {
            GlobalCollections.Targets =  new List<Transform>();
        } 

        public static void Draw() {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)).origin,  _hit.point);
            Gizmos.DrawWireSphere(_hit.point, ArrowStats.AttackStats.MarkTargets.Radius);
        }

        // // Update is called once per frame
        // private IEnumerator StartMarking() {
        //     Time.timeScale = slowAmount;
        //     TargetsCollection.Points =  new List<Transform>();
        //     this.lineRenderer.positionCount = 3;
        //     this.sphere.gameObject.SetActive(true);

        //     while (this.currentTime <= this.duration) {
        //         this.Mark();
        //         this.DrawMarkingLine();
        //         yield return new WaitForEndOfFrame();

        //         this.currentTime += Time.unscaledDeltaTime;
        //     }
            
            
        //     this.sphere.gameObject.SetActive(false);
        //     this.lineRenderer.positionCount = 0;
        //     this.currentTime = 0f;
        //     Time.timeScale = 1f;
        //     StartCoroutine((shootScript as ArrowMovement).Move());
        // }

    }
}
