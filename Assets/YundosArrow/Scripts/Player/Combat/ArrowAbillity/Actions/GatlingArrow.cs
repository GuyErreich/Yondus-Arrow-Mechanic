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
		private static Transform[] _gatlingArrowAnchors;
		public static int GatlingArrowsCount => _gatlingArrows != null ? _gatlingArrows.Count : 0;

//		public static void CreateArrows()
//		{
//			_gatlingArrows = new Queue<Transform>();
//			_gatlingArrowAnchors = new Transform[ArrowStats.attackStats.gatlingArrow.amount];
//			for (int i = 0; i < ArrowStats.attackStats.gatlingArrow.amount; i++)
//			{
//				var newArrow = Instantiate(ArrowStats.attackStats.gatlingArrow.arrow);
//				_gatlingArrows.Enqueue(newArrow);
//
//				var newAnchor = new GameObject($"Gatling Arrow Anchor{i}");
//				newAnchor.transform.parent = ArrowStats.attackStats.homingArrow.arrow;
//				newAnchor.transform.localPosition = new Vector3(Mathf.Cos(i), Mathf.Sin(i), Mathf.Atan2(Mathf.Cos(i), Mathf.Sin(i))) * 0.75f;
//				_gatlingArrowAnchors[i] = newAnchor.transform;
//			}
//		}

		public static void CreateArrows()
		{
			_gatlingArrows = new Queue<Transform>();
			_gatlingArrowAnchors = new Transform[ArrowStats.attackStats.gatlingArrow.amount];
			for (int i = 0; i < ArrowStats.attackStats.gatlingArrow.amount; i++)
			{
				var newArrow = Instantiate(ArrowStats.attackStats.gatlingArrow.arrow);
				_gatlingArrows.Enqueue(newArrow);

				var newAnchor = new GameObject($"Gatling Arrow Anchor{i}");
				newAnchor.transform.parent = ArrowStats.attackStats.homingArrow.arrow;
				newAnchor.transform.localPosition = new Vector3(Mathf.Cos(i), Mathf.Sin(i), Mathf.Atan2(Mathf.Cos(i), Mathf.Sin(i))) * 0.75f;
				_gatlingArrowAnchors[i] = newAnchor.transform;
			}
		}

		public static void GatlingAttack()
		{
			var arrow = _gatlingArrows.Peek();
			arrow.DOMove(arrow.position)
		}

		private static void GatlingFollowMainArrow()
		{
			for (int i = 0; i < ArrowStats.attackStats.gatlingArrow.amount; i++)
			{
				var arrow = _gatlingArrows.Dequeue();
				FollowTarget(arrow,  _gatlingArrowAnchors[i].position, GetHitMarkPoint(), 0.05f);
				_gatlingArrows.Enqueue(arrow);
			}
		}
	}
}
