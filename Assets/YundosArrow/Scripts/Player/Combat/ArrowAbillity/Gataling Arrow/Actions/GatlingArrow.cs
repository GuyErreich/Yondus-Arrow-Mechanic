using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Stats;
using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow
{
    public partial class Actions : MonoBehaviour
    {
        private static float _tGatlingRate;

        private static Queue<Transform> _gatlingArrows = new Queue<Transform>();
        private static Queue<Transform> _gatlingArrowsCache = new Queue<Transform>();
        private static Queue<Transform> _gatlingArrowAnchors = new Queue<Transform>();
        private static Queue<Transform> _gatlingArrowAnchorsCache = new Queue<Transform>();
        public static int GatlingArrowsCount => _gatlingArrows != null ? _gatlingArrows.Count : 0;

        public static void CreateArrows(Transform arrow, Transform anchor, float zOffset, float distance, int amount, bool isSphere)
        {
            for (int i = 0; i < amount; i++)
            {
                if (_gatlingArrowsCache != null && _gatlingArrowsCache.Count == 0 &&
                    _gatlingArrowAnchorsCache != null && _gatlingArrowAnchorsCache.Count == 0)
                {
                    Vector3 position;
                    float x, y, z, angle;
					
                    float goldenAngle = Mathf.PI * (3f - Mathf.Sqrt(5f)); // Golden angle for evenly spaced points
					float offsetAngle = Mathf.PI / 2f;
					float theta = goldenAngle * i + offsetAngle;
					float phi = Mathf.Acos(1 - 2 * (i / (float)amount));


                    if (isSphere) {
                        x = Mathf.Sin(phi) * Mathf.Cos(theta);
                        y = Mathf.Sin(phi) * Mathf.Sin(theta);
                        z = Mathf.Cos(phi);
                        position = new Vector3(x, y, z * zOffset) * distance;
                    } 
                    else {
                        angle = (360 / amount) * i * Mathf.Deg2Rad;
                        position =  new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), Mathf.Atan2(Mathf.Cos(angle), Mathf.Sin(angle)) * zOffset) * distance;
                    }

                    var newAnchor = new GameObject($"Gatling Arrow Anchor{i}")
                    {
                        transform =
                        {
                            parent = anchor,
                            localPosition = position
                        }
                    };

                    _gatlingArrowAnchorsCache.Enqueue(newAnchor.transform);

					// for (int j = 0; j < 4; j++) 
					// {
						var newArrow = Instantiate(arrow);
						newArrow.gameObject.SetActive(false);

						_gatlingArrowsCache.Enqueue(newArrow);
					// }
                }

                var tempArrow = _gatlingArrowsCache?.Dequeue();
                _gatlingArrows.Enqueue(tempArrow);
                var tempAnchor = _gatlingArrowAnchorsCache?.Dequeue();
                _gatlingArrowAnchors.Enqueue(tempAnchor);

                if (tempAnchor != null && tempArrow != null)
                {
                    tempArrow.position = tempAnchor.position;
                    tempArrow.gameObject.SetActive(true);
                    tempAnchor.gameObject.SetActive(true);
                }
            }
        }

        public static void GatlingAttack(Vector3 hitPoint, float rateOfFire, float range, float speed)
        {
            if (_gatlingArrows.Count > 0)
            {
                if (_tGatlingRate >= rateOfFire)
                {
                    var arrow = _gatlingArrows.Dequeue();
                    var arrowAnchor = _gatlingArrowAnchors.Dequeue();
                                                    
                    var destination = arrow.position + (hitPoint - arrow.position).normalized * range;
                    var duration = range / speed;

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

        public static void GatlingArrowsFollow(Vector3 hitPoint, float duration, int amount)
        {
            for (int i = 0; i <amount; i++)
            {
                if (_gatlingArrows.Count > 0 && _gatlingArrowAnchors.Count > 0)
                {
                    var arrow = _gatlingArrows.Dequeue();
                    var arrowAnchor = _gatlingArrowAnchors.Dequeue();
                    Utils.FollowTarget(arrow, arrowAnchor.position, hitPoint, duration);
                    _gatlingArrows.Enqueue(arrow);
                    _gatlingArrowAnchors.Enqueue(arrowAnchor);
                }
            }
        }
    }
}
