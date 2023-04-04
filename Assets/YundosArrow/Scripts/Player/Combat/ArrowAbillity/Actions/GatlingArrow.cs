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
					var newAnchor = new GameObject($"Gatling Arrow Anchor{i}")
					{
						transform =
						{
							parent = ArrowStats.attackStats.homingArrow.arrow,
							localPosition = new Vector3(Mathf.Cos(i), Mathf.Sin(i), Mathf.Atan2(Mathf.Cos(i), Mathf.Sin(i)) * 0.5f) * 0.75f
						}
					};

					_gatlingArrowAnchorsCache.Enqueue(newAnchor.transform);

					var newArrow = Instantiate(ArrowStats.attackStats.gatlingArrow.arrow);
					newArrow.position = newAnchor.transform.position;

					_gatlingArrowsCache.Enqueue(newArrow);
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

		private static void GatlingFollowMainArrow()
		{
			for (int i = 0; i < ArrowStats.attackStats.gatlingArrow.amount; i++)
			{
				if (_gatlingArrows.Count > 0 && _gatlingArrowAnchors.Count > 0)
				{
					var arrow = _gatlingArrows.Dequeue();
					var arrowAnchor = _gatlingArrowAnchors.Dequeue();
					FollowTarget(arrow,  arrowAnchor.position, GetHitMarkPoint(), 0.05f);
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
