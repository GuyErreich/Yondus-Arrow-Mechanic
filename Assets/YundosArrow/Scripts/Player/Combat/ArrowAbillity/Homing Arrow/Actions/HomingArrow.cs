using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Utils;
using AAUtils = Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Utils;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow
{
	public partial class Actions
	{
		private static Transform _cacheParent;
		private static Vector3 _localPos;
		private static float _tMove;
		private static ArrowPath _pathMove;

		// public static float normalizedPathPos { get; private set; }
		public static float normalizedPathPos => _tMove;

		public static void AttackInit()
		{
			if (_currentTargets == null)
				throw new NullReferenceException("targets");

			if (_currentTargets.Count == 0)
				throw new Exception("targets cant be empty.", new IndexOutOfRangeException());

			var sign = Random.Range(0f, 1f) < 0.5f ? -1 : 1;
			var dir = ArrowStats.attackStats.homingArrow.arrow.forward + (ArrowStats.attackStats.homingArrow.arrow.right * ArrowStats.attackStats.homingArrow.force * sign);
			dir = dir.normalized;
			_pathMove = new ArrowPath(ArrowStats.attackStats.homingArrow.arrow.position, _currentTargets[0].position, dir,
											ArrowStats.attackStats.homingArrow.returnForce);

			_tMove = 0;
			StartMove();
			StartAttack();
		}

		public static void MoveToStartingInit()
		{
			_targets.Clear();
			_currentTargets.Clear();

			var returnPoint = ArrowStats.attackStats.homingArrow.startPoint;

			if (_tMove > 0) {
				var sign = Random.Range(0f, 1f) < 0.5f ? -1 : 1;
				var dir = ArrowStats.attackStats.homingArrow.arrow.forward + (ArrowStats.attackStats.homingArrow.arrow.right * ArrowStats.attackStats.homingArrow.force * sign);
				dir = dir.normalized;
				_pathMove = new ArrowPath(ArrowStats.attackStats.homingArrow.arrow.position, returnPoint.position, dir,
												ArrowStats.attackStats.homingArrow.returnForce);
			}
			else {
				_pathMove.ChangeDestination(returnPoint.position, ArrowStats.attackStats.homingArrow.force);
			}

			_tMove = 0;
			StartMove();
			StopAttack();
		}

		public static void MoveToStartingPoint()
		{
			var returnPoint = ArrowStats.attackStats.homingArrow.startPoint;

			if (_tMove <= 1f)
			{
				_pathMove.RecalculatePathDestination(returnPoint.position);
				
				
				var point = returnPoint.position -
					returnPoint.forward * ArrowStats.attackStats.homingArrow.returnForce;
				point += returnPoint.right * ArrowStats.attackStats.homingArrow.returnForce;
				_pathMove.MovePoint(_pathMove.Points.Length - 2, point);

				Move(_pathMove, _tMove);

				_tMove += CalculateSpeed(_pathMove, _tMove);
				// normalizedPathPos += CalculateSpeed(_pathMove, _tMove);
			}
			else
			{
				StopMove();
				_tMove = 0;
			}
		}

		public static void Attack()
		{
			if (_currentTargets.Count <= 0) {
				StopAttack();
				return;
			} 

			var target = _currentTargets[0];

			if (target.GetComponent<Collider>().enabled == false) {
				_currentTargets.RemoveAt(0); 
				return;
			}

			if (_tMove <= 1f)
			{
				_pathMove.RecalculatePathDestination(target.position);
				Move(_pathMove, _tMove);

				_tMove += CalculateSpeed(_pathMove, _tMove);
			}
			else
			{
				_targets.Remove(target);
				_currentTargets.Remove(target);
				// var nextTargets = _currentTargets[0];
				// if (_currentTargets.Count > 0) {
				// 	_pathMove.ChangeDestination(target.transform.position, ArrowStats.attackStats.homingArrow.force);
				// }
				_tMove = 0;
			}
		}

		private static void Move(ArrowPath path, float t)
		{
			ArrowStats.attackStats.homingArrow.arrow.position = BezireCurve.CubicPoint(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
			ArrowStats.attackStats.homingArrow.arrow.forward = BezireCurve.CubicDirection(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
		}

		private static float CalculateSpeed(ArrowPath path, float t)
		{
			var velocity = BezireCurve.CubicVelocity(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t * Time.unscaledDeltaTime);
			var distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t * Time.unscaledDeltaTime);

			return ArrowStats.attackStats.homingArrow.speed * velocity / distance * Time.unscaledDeltaTime;
		}

		public static void IdleFollow()
		{
			var lookAtPoint = AAUtils.GetHitMarkPoint(Player.position, ArrowStats.attackStats.markTargets.range,
													ArrowStats.attackStats.markTargets.rangeOnNoHit,
													ArrowStats.attackStats.markTargets.radius,
													ArrowStats.attackStats.markTargets.layerMask);

			AAUtils.FollowTarget(ArrowStats.attackStats.homingArrow.arrow, ArrowStats.idleStats.followTarget.target.position, 
							lookAtPoint, ArrowStats.idleStats.followTarget.duration);
		}

		public static void StopAttack() => IsAttacking = false;
		public static void StopMove() => IsMoving = false;
		public static void StartAttack() => IsAttacking = true;
		public static void StartMove() => IsMoving = true;
	}
}
