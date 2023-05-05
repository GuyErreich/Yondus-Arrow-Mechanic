using System;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
	public partial class Actions
	{
		private static Transform _cacheParent;
		private static Vector3 _localPos;
		private static float _tMove;
		private static ArrowPath _pathMove;

		public static void AttackInit()
		{
			if (_currentTargets == null)
				throw new NullReferenceException("targets");

			if (_currentTargets.Count == 0)
				throw new Exception("targets cant be empty.", new IndexOutOfRangeException());

			var sign = Random.Range(0,1) == 0 ? -1 : 1;
			var dir = ArrowStats.attackStats.homingArrow.arrow.forward + (ArrowStats.attackStats.homingArrow.arrow.right * ArrowStats.attackStats.homingArrow.force * sign);
			dir = dir.normalized;
			_pathMove = new ArrowPath(ArrowStats.attackStats.homingArrow.arrow.position, _currentTargets[0].position, dir,
											ArrowStats.attackStats.homingArrow.returnForce);

			_tMove = 0;
			IsMoving = true;
			IsAttacking = true;
		}

		public static void MoveToStartingPoint()
		{
			if (_tMove == 0)
			{
				_targets.Clear();
				_pathMove.ChangeDestination(ArrowStats.attackStats.homingArrow.startPoint.position, ArrowStats.attackStats.homingArrow.force);
			}

			if (_tMove <= 1f)
			{
				_pathMove.RecalculatePath(ArrowStats.attackStats.homingArrow.startPoint.position);
				
				var point = ArrowStats.attackStats.homingArrow.startPoint.position -
					ArrowStats.attackStats.homingArrow.startPoint.forward * (ArrowStats.attackStats.homingArrow.returnForce);
				point += ArrowStats.attackStats.homingArrow.startPoint.right * (ArrowStats.attackStats.homingArrow.returnForce);
				_pathMove.MovePoint(_pathMove.Points.Length - 2, point);

				Move(_pathMove, _tMove);

				_tMove += CalculateSpeed(_pathMove, _tMove);
			}
			else
			{
				IsMoving = false;
			}
		}

		public static void Attack()
		{
			if (_currentTargets.Count <= 0) {
				IsAttacking = false;
				return;
			} 

			var target = _currentTargets[0];

			if (target.GetComponent<Collider>().enabled == false) {
				_currentTargets.RemoveAt(0); 
				return;
			}

			if (_tMove <= 1f)
			{
				_pathMove.RecalculatePath(target.position);
				Move(_pathMove, _tMove);

				_tMove += CalculateSpeed(_pathMove, _tMove);
			}
			else
			{
				_targets.Remove(target);
				_currentTargets.Remove(target);
				if (_currentTargets.Count > 0)
					_pathMove.ChangeDestination(target.transform.position, ArrowStats.attackStats.homingArrow.force);
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
			FollowTarget(ArrowStats.attackStats.homingArrow.arrow, ArrowStats.idleStats.followTarget.target.position, GetHitMarkPoint(), ArrowStats.idleStats.followTarget.duration);
		}

		public static void StopAttack() => IsAttacking = false;
		public static void StopMove() => IsMoving = false;
	}
}
