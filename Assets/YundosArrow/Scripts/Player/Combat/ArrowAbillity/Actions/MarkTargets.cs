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

			if (Physics.SphereCast(ray, ArrowStats.attackStats.markTargets.radius, out _hitMark,
				    ArrowStats.attackStats.markTargets.range,
				    ArrowStats.attackStats.markTargets.layerMask))
			{

				if (_hitMark.distance >= distance)
				{
					//				if (InputReceiver.Bool[InputReceiverType.ShootPressed])
					//				{
					if (_targets == null || _targets.Count == 0f)
					{
						_targets = new List<Transform> { _hitMark.transform };
						_currentTargets = new List<Transform> { _hitMark.transform };
					}
					else
					{
						// if(_targets[_targets.Count - 1] != _hit.transform) {
						//     _targets.Add(_hit.transform);
						// }
						if (!_targets.Contains(_hitMark.transform))
						{
							_targets.Add(_hitMark.transform);
							_currentTargets.Add(_hitMark.transform);
						}
					}
					//				}
				}
			}
		}

		public static void DryMark()
		{
			Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
			var distance = Vector3.Distance(Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f)), Player.transform.position);

			if (Physics.SphereCast(ray, ArrowStats.attackStats.markTargets.radius, out _hitMark,
				ArrowStats.attackStats.markTargets.range,
				ArrowStats.attackStats.markTargets.layerMask))
			{
				if (_hitMark.distance >= distance)
				{
					_hitMark.point = Vector3.zero;
				}
			}
		}

		private static Vector3 GetHitMarkPoint()
		{
			var markPoint = Vector3.zero;
			if (_hitMark.point == Vector3.zero)
			{
				markPoint = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)).origin + Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)).direction * ArrowStats.attackStats.markTargets.rangeOnNoHit;
			}
			else
			{
				markPoint = _hitMark.point;
			}

			_hitMark.point = Vector3.zero;
			return markPoint;
		}
	}
}
