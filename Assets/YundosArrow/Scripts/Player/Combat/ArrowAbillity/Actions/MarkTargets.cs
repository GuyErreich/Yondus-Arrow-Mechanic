using UnityEngine;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions
{
    public class MarkTargets
    {
        private static RaycastHit _hit;

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

        public static void Mark() {
            Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            // if (Physics.SphereCast(, this.radius, Camera.main.transform.forward, out _hit, this.range, this.layerMask)) {
            if (Physics.SphereCast(ray, ArrowStats.AttackStats.MarkTargets.Radius, out _hit, ArrowStats.AttackStats.MarkTargets.Range, ArrowStats.AttackStats.MarkTargets.LayerMask)) {
                if (InputReceiver.Bool[InputReceiverType.ShootPressed])
                    if(!TargetsCollection.Points.Contains(_hit.transform))
                        TargetsCollection.Points.Add(_hit.transform);
            }

            if (_hit.point == Vector3.zero)
                _hit.point = ray.origin + ray.direction * ArrowStats.AttackStats.MarkTargets.RangeOnNoHit;
        }

        public static void Draw() {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)).origin,  _hit.point);
            Gizmos.DrawWireSphere(_hit.point, ArrowStats.AttackStats.MarkTargets.Radius);
        }
    }
}
