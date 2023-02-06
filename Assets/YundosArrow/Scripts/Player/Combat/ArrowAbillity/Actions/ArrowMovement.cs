using System;
using System.Collections;
using System.Threading.Tasks;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Utils;
using DG.Tweening;
using UnityEngine;

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

			_pathMove = new ArrowPath(ArrowStats.Arrow.position, _currentTargets[0].position, ArrowStats.Arrow.forward,
				ArrowStats.AttackStats.Movement.Force);

			_cacheParent = ArrowStats.Arrow.parent;
			_localPos = ArrowStats.Arrow.localPosition;
			ArrowStats.Arrow.parent = null;
			ArrowStats.Arrow.position = _cacheParent.TransformPoint(_localPos);
			_tMove = 0;
			IsMoving = true;
			IsAttacking = true;
		}

		public static void MoveToStartingPoint()
		{
			if (_tMove == 0)
				_pathMove.ChangeDestination(ArrowStats.StartPoint.position, ArrowStats.AttackStats.Movement.Force);

			if (_tMove <= 1f)
			{
				_pathMove.RecalculatePath(ArrowStats.StartPoint.position);

				var point = ArrowStats.StartPoint.position -
				            ArrowStats.StartPoint.forward * (ArrowStats.AttackStats.Movement.ReturnForce);
				point += ArrowStats.StartPoint.right * (ArrowStats.AttackStats.Movement.ReturnForce);
				_pathMove.MovePoint(_pathMove.Points.Length - 2, point);

				_tMove += CalculateSpeed(_pathMove, _tMove);
				Move(_pathMove, _tMove);
			}
			else
			{
				ArrowStats.Arrow.parent = _cacheParent;
				ArrowStats.Arrow.localPosition = Vector3.zero;
				ArrowStats.Arrow.localRotation = Quaternion.identity;
				_targets.Clear();
				IsMoving = false;
			}
		}

		public static void Attack()
		{
			if (_currentTargets.Count > 0)
			{
				if (_tMove < 1f)
				{
					_pathMove.RecalculatePath(_currentTargets[0].position);
					_tMove += CalculateSpeed(_pathMove, _tMove);

					Move(_pathMove, _tMove);
				}
				else
				{
					_currentTargets.RemoveAt(0);
					if (_currentTargets.Count > 0)
						_pathMove.ChangeDestination(_currentTargets[0].transform.position, ArrowStats.AttackStats.Movement.Force);
					_tMove = 0;
				}
			}

			if (_currentTargets.Count == 0)
			{
				IsAttacking = false;
			}
		}

		public static void RetargetArrow()
		{
			IsAttacking = true;
		}

		private static void Move(ArrowPath path, float t)
		{
			ArrowStats.Arrow.position = BezireCurve.CubicPoint(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
			ArrowStats.Arrow.forward = BezireCurve.CubicDirection(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
		}

		private static float CalculateSpeed(ArrowPath path, float t)
		{
			var velocity = BezireCurve.CubicVelocity(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
			var distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);

			return ArrowStats.AttackStats.Movement.Speed * velocity / distance * Time.deltaTime;
		}
	}
}
