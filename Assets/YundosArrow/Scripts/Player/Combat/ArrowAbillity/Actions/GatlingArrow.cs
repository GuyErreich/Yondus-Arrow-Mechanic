using System.Collections.Generic;
using System.Linq;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
	public partial class Actions : MonoBehaviour
	{
		private static Queue<Transform> _gatlingArrows;
		private static Queue<Transform> _gatlingArrowAnchors;
		public static int GatlingArrowsCount => _gatlingArrows != null ? _gatlingArrows.Count : 0;

		public static void CreateArrows()
		{
			_gatlingArrows = new Queue<Transform>();
			_gatlingArrowAnchors = new Queue<Transform>();
			for (int i = 0; i < ArrowStats.attackStats.gatlingArrow.amount; i++)
			{
				var newArrow = Instantiate(ArrowStats.attackStats.gatlingArrow.arrow);

				var newAnchor = new GameObject($"Gatling Arrow Anchor{i}");
				newAnchor.transform.parent = ArrowStats.attackStats.homingArrow.arrow;
				newAnchor.transform.localPosition = new Vector3(Mathf.Cos(i), Mathf.Sin(i), Mathf.Atan2(Mathf.Cos(i), Mathf.Sin(i)) * 0.5f) * 0.75f;

				_gatlingArrowAnchors.Enqueue(newAnchor.transform);

				newArrow.position = newAnchor.transform.position;

				_gatlingArrows.Enqueue(newArrow);
			}
		}

		private static float _tGatlinRate;
		public static void GatlingAttack()
		{
			if (_gatlingArrows.Count > 0)
			{
				print(_tGatlinRate);
				if (_tGatlinRate >= ArrowStats.attackStats.gatlingArrow.rateOfFire)
				{
					var arrow = _gatlingArrows.Dequeue();
					var arrowAnchor = _gatlingArrowAnchors.Dequeue();
					var destination = arrow.position + (GetHitMarkPoint() - arrow.position).normalized * ArrowStats.attackStats.gatlingArrow.range;
					var duration = ArrowStats.attackStats.gatlingArrow.range / ArrowStats.attackStats.gatlingArrow.speed;
					arrow.DOLookAt(destination, 0.1f)
						.OnComplete(() =>
							arrow.DOMove(destination, duration)
							.SetEase(Ease.Flash)
							.OnComplete(() =>
							{
								if (arrow != null) Destroy(arrow.gameObject);
							}
						)
					);

					_tGatlinRate = 0;
				}

				_tGatlinRate += Time.deltaTime;
			}
		}

		private static void GatlingFollowMainArrow()
		{
			for (int i = 0; i < ArrowStats.attackStats.gatlingArrow.amount; i++)
			{
				var arrow = _gatlingArrows.Dequeue();
				var arrowAnchor = _gatlingArrowAnchors.Dequeue();
				FollowTarget(arrow,  arrowAnchor.position, GetHitMarkPoint(), 0.05f);
				_gatlingArrows.Enqueue(arrow);
				_gatlingArrowAnchors.Enqueue(arrowAnchor);
			}
		}
	}
}
