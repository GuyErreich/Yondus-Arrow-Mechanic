using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Utils;
using Assets.YundosArrow.Scripts.Player.Input;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
	public partial class Actions
	{
		/**
        TODO: this what is better -
            to not let the player mark more than once in row(before it is no longer in the list)
            OR
            to limit it to the maximum of time it takes to kill the target so bugs wont happens
        **/
		public static void Mark()
		{
			Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
			var distance = Vector3.Distance(Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f)), Player.transform.position);

			if (Physics.SphereCast(ray, ArrowStats.attackStats.markTargets.radius, out var hit,
				    ArrowStats.attackStats.markTargets.range,
				    ArrowStats.attackStats.markTargets.layerMask))
			{

				if (hit.distance >= distance)
				{
					if (_targets == null || _targets.Count == 0f)
					{
						_targets = new List<Transform> { hit.transform };
						_currentTargets = new List<Transform> { hit.transform };
					}
					else
					{
						if (!_targets.Contains(hit.transform))
						{
							_targets.Add(hit.transform);
							_currentTargets.Add(hit.transform);
						}
					}
				}
			}
		}

		private static Vector3 GetHitMarkPoint()
		{
			Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
			var distance = Vector3.Distance(Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f)), Player.transform.position);

			if (Physics.SphereCast(ray, ArrowStats.attackStats.markTargets.radius, out var hit,
				ArrowStats.attackStats.markTargets.range,
				ArrowStats.attackStats.markTargets.layerMask))
			{
				if (hit.distance >= distance)
					return hit.point;
			}

			return Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)).origin + Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)).direction * ArrowStats.attackStats.markTargets.rangeOnNoHit;
		}
	}
}
