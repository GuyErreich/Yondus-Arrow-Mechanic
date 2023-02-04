using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Utils;
using Assets.YundosArrow.Scripts.Player.Input;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
	public partial class Actions
	{
		private static RaycastHit _hit;

		public static bool IsMarked => GlobalCollections.Targets != null && GlobalCollections.Targets.Count > 0f;

		/**
        TODO: this what is better -
            to not let the player mark more than once in row(before it is no longer in the list)
            OR
            to limit it to the maximum of time it takes to kill the target so bugs wont happens
        **/
		public static void Mark()
		{
			Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));

			if (Physics.SphereCast(ray, ArrowStats.AttackStats.MarkTargets.Radius, out _hit,
				    ArrowStats.AttackStats.MarkTargets.Range,
				    ArrowStats.AttackStats.MarkTargets.LayerMask))
			{
				if (InputReceiver.Bool[InputReceiverType.ShootPressed])
				{
					if (!IsMarked)
					{
						GlobalCollections.Targets = new List<Transform> { _hit.transform };
						GlobalCollections.CurrentTargets = new List<Transform> { _hit.transform };
					}
					else
					{
						// if(GlobalCollections.Targets[GlobalCollections.Targets.Count - 1] != _hit.transform) {
						//     GlobalCollections.Targets.Add(_hit.transform);
						// }
						if (!GlobalCollections.Targets.Contains(_hit.transform))
						{
							GlobalCollections.Targets.Add(_hit.transform);
							GlobalCollections.CurrentTargets.Add(_hit.transform);
						}
					}
				}
			}

			if (_hit.point == Vector3.zero)
				_hit.point = ray.origin + ray.direction * ArrowStats.AttackStats.MarkTargets.RangeOnNoHit;
		}
	}
}
