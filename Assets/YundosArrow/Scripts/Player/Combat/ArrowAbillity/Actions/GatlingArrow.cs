using System.Collections.Generic;
using System.Linq;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions : MonoBehaviour
    {
        private static Queue<Transform> _gatlingArrows = new Queue<Transform>();
        private static Queue<Transform> _gatlingArrowsCache = new Queue<Transform>();
        private static Queue<Transform> _gatlingArrowAnchors = new Queue<Transform>();
        private static Queue<Transform> _gatlingArrowAnchorsCache = new Queue<Transform>();
        public static int GatlingArrowsCount => _gatlingArrows != null ? _gatlingArrows.Count : 0;

        public static void CreateArrows()
        {
            for (int i = 0; i < ArrowStats.attackStats.gatlingArrow.amount; i++)
            {
                if (_gatlingArrowsCache != null && _gatlingArrowsCache.Count == 0 &&
                    _gatlingArrowAnchorsCache != null && _gatlingArrowAnchorsCache.Count == 0)
                {
					float goldenAngle = Mathf.PI * (3f - Mathf.Sqrt(5f)); // Golden angle for evenly spaced points
					float offsetAngle = Mathf.PI / 2f;
					float theta = goldenAngle * i + offsetAngle;
					float phi = Mathf.Acos(1 - 2 * (i / (float)ArrowStats.attackStats.gatlingArrow.amount));

					float x = Mathf.Sin(phi) * Mathf.Cos(theta);
					float y = Mathf.Sin(phi) * Mathf.Sin(theta);
					float z = Mathf.Cos(phi);
                    // float angle = (360 / ArrowStats.attackStats.gatlingArrow.amount) * i * Mathf.Deg2Rad;

                    var newAnchor = new GameObject($"Gatling Arrow Anchor{i}")
                    {
                        transform =
                        {
                            parent = ArrowStats.attackStats.gatlingArrow.anchor,
                            localPosition = new Vector3(x, y, z * ArrowStats.attackStats.gatlingArrow.offsetZ) * ArrowStats.attackStats.gatlingArrow.distance
                            // localPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), Mathf.Atan2(Mathf.Cos(angle), Mathf.Sin(angle)) * ArrowStats.attackStats.gatlingArrow.offsetZ) * ArrowStats.attackStats.gatlingArrow.distance
                        }
                    };

                    _gatlingArrowAnchorsCache.Enqueue(newAnchor.transform);

					// for (int j = 0; j < 4; j++) 
					// {
						var newArrow = Instantiate(ArrowStats.attackStats.gatlingArrow.arrow);
						// newArrow.position = newAnchor.transform.position;
						newArrow.gameObject.SetActive(false);

						_gatlingArrowsCache.Enqueue(newArrow);
					// }
                }

                var arrow = _gatlingArrowsCache?.Dequeue();
                _gatlingArrows.Enqueue(arrow);
                var anchor = _gatlingArrowAnchorsCache?.Dequeue();
                _gatlingArrowAnchors.Enqueue(anchor);

                if (anchor != null && arrow != null)
                {
                    arrow.position = anchor.position;
                    arrow.gameObject.SetActive(true);
                    anchor.gameObject.SetActive(true);
                }
            }
        }

        private static float _tGatlingRate;
        public static void GatlingAttack()
        {
            if (_gatlingArrows.Count > 0)
            {
                if (_tGatlingRate >= ArrowStats.attackStats.gatlingArrow.rateOfFire)
                {
                    var arrow = _gatlingArrows.Dequeue();
                    var arrowAnchor = _gatlingArrowAnchors.Dequeue();
                    var destination = arrow.position + (GetHitMarkPoint() - arrow.position).normalized * ArrowStats.attackStats.gatlingArrow.range;
                    var duration = ArrowStats.attackStats.gatlingArrow.range / ArrowStats.attackStats.gatlingArrow.speed;

                    arrow.DOLookAt(destination, 0.1f)
                        .SetUpdate(true)
                        .OnComplete(() =>
                            arrow.DOMove(destination, duration)
                            .SetEase(Ease.InFlash)
                            .SetUpdate(true)
                            .OnComplete(() =>
                            {
                                arrow.gameObject.SetActive(false);
                                _gatlingArrowsCache.Enqueue(arrow);
                                arrowAnchor.gameObject.SetActive(false);
                                _gatlingArrowAnchorsCache.Enqueue(arrowAnchor);
                            }
                        )
                    );

                    _tGatlingRate = 0;
                }

                _tGatlingRate += Time.unscaledDeltaTime;
            }
        }

        public static void GatlingArrowsFollow()
        {
            for (int i = 0; i < ArrowStats.attackStats.gatlingArrow.amount; i++)
            {
                if (_gatlingArrows.Count > 0 && _gatlingArrowAnchors.Count > 0)
                {
                    var arrow = _gatlingArrows.Dequeue();
                    var arrowAnchor = _gatlingArrowAnchors.Dequeue();
                    FollowTarget(arrow, arrowAnchor.position, GetHitMarkPoint(), ArrowStats.attackStats.gatlingArrow.duration);
                    _gatlingArrows.Enqueue(arrow);
                    _gatlingArrowAnchors.Enqueue(arrowAnchor);
                }
                //				else
                //				{
                //					var arrow = _gatlingArrowsCache.Dequeue();
                //					var arrowAnchor = _gatlingArrowAnchorsCache.Dequeue();
                //					FollowTarget(arrow,  arrowAnchor.position, GetHitMarkPoint(), 0.05f);
                //					_gatlingArrowsCache.Enqueue(arrow);
                //					_gatlingArrowAnchorsCache.Enqueue(arrowAnchor);
                //				}
            }
        }
    }
}
