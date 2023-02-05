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
		public static void DoMove()
		{
		}

//        public static IEnumerator Move() {
////            var targets = _currentTargets;
//
//			if (_currentTargets == null)
//                throw new NullReferenceException("targets");
//
//			if (_currentTargets.Count == 0)
//                throw new Exception("targets cant be empty.", new IndexOutOfRangeException());
//
//            var cacheParent = ArrowStats.Arrow.parent;
//            var localPos = ArrowStats.Arrow.localPosition;
//            ArrowStats.Arrow.parent = null;
//            ArrowStats.Arrow.position = cacheParent.TransformPoint(localPos);
//            IsMoving = true;
//
//            float t;
//            // var distance = 0f;
//			var path = new ArrowPath(ArrowStats.Arrow.position, _currentTargets[0].position, ArrowStats.Arrow.forward, ArrowStats.AttackStats);
//
//			while (_currentTargets.Count > 0) {
//                t = 0f;
////                var currentPos = ArrowStats.Arrow.position;
//
//				path.ChangeDestination(_currentTargets[0].position, ArrowStats.AttackStats.Movement.Force);
//
//                // distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//
//                while (t <= 1f ) {
//                    ArrowStats.Arrow.DOMove(BezireCurve.CubicPoint(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t), 0f);
//                    ArrowStats.Arrow.forward = BezireCurve.CubicDirection(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//
//                    yield return new WaitForEndOfFrame();
//
//					path.RecalculatePath(_currentTargets[0].position);
//
//                    var velocity = BezireCurve.CubicVelocity(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//                    var distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//                    t += ArrowStats.AttackStats.Movement.Speed * velocity / distance * Time.deltaTime;
//                }
//				_currentTargets.RemoveAt(0);
//            }
//
//            t = 0f;
////            var lastPos = ArrowStats.Arrow.position;
//            path.ChangeDestination(ArrowStats.StartPoint.position, ArrowStats.AttackStats.Movement.Force);
//            // distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//            while (t <= 1f ) {
//                ArrowStats.Arrow.DOMove(BezireCurve.CubicPoint(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t), 0f);
//                ArrowStats.Arrow.forward = BezireCurve.CubicDirection(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//
//                yield return new WaitForEndOfFrame();
//
//                path.RecalculatePath(ArrowStats.StartPoint.position);
//                var point = ArrowStats.StartPoint.position - ArrowStats.StartPoint.forward * (ArrowStats.AttackStats.Movement.ReturnForce);
//                point += ArrowStats.StartPoint.right * (ArrowStats.AttackStats.Movement.ReturnForce);
//                path.MovePoint(path.Points.Length - 2, point);
//
//                var velocity = BezireCurve.CubicVelocity(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//                var distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//                t += ArrowStats.AttackStats.Movement.Speed * velocity / distance * Time.deltaTime;
//            }
//
//            ArrowStats.Arrow.parent = cacheParent;
//            Sequence seq = DOTween.Sequence();
//            seq.Append(ArrowStats.Arrow.DOLocalMove(Vector3.zero, 0.2f));
//            seq.Join(ArrowStats.Arrow.DOLocalRotateQuaternion(Quaternion.identity, 0.2f));
//            seq.Play().OnComplete(() => {
//                _targets.Clear();
//                IsMoving = false;
//            });
//        }

		private static Transform _cacheParent;
		private static Vector3 _localPos;
		private static float _tMove;
		private static ArrowPath _pathMove;

		public static void MoveInit()
		{
			if (_currentTargets == null)
				throw new NullReferenceException("targets");

			if (_currentTargets.Count == 0)
				throw new Exception("targets cant be empty.", new IndexOutOfRangeException());

			_cacheParent = ArrowStats.Arrow.parent;
			_localPos = ArrowStats.Arrow.localPosition;
			ArrowStats.Arrow.parent = null;
			ArrowStats.Arrow.position = _cacheParent.TransformPoint(_localPos);
			_pathMove = new ArrowPath(ArrowStats.Arrow.position, _currentTargets[0].position, ArrowStats.Arrow.forward,
				ArrowStats.AttackStats.Movement.Force);
			_tMove = 0;
			IsMoving = true;
			IsAttacking = true;
		}

		public static void Move()
		{
			if (_currentTargets.Count > 0)
			{

				if (_tMove <= 1f)
				{
					_pathMove.RecalculatePath(_currentTargets[0].position);

					var velocity = BezireCurve.CubicVelocity(_pathMove.Points[0], _pathMove.Points[1], _pathMove.Points[2],
						_pathMove.Points[3], _tMove);
					var distance = BezireCurve.CubicDistance(_pathMove.Points[0], _pathMove.Points[1], _pathMove.Points[2],
						_pathMove.Points[3], _tMove);
					_tMove += ArrowStats.AttackStats.Movement.Speed * velocity / distance * Time.deltaTime;

					ArrowStats.Arrow.position = BezireCurve.CubicPoint(_pathMove.Points[0], _pathMove.Points[1],
						_pathMove.Points[2], _pathMove.Points[3], _tMove);
					ArrowStats.Arrow.forward = BezireCurve.CubicDirection(_pathMove.Points[0], _pathMove.Points[1],
						_pathMove.Points[2], _pathMove.Points[3], _tMove);
				}
				else
				{
					_tMove = 0;
					_currentTargets.RemoveAt(0);
					_pathMove.ChangeDestination(_currentTargets[0].position, ArrowStats.AttackStats.Movement.Force);
				}
			}

			if (_currentTargets.Count == 0)
			{
				IsAttacking = false;
			}
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

				var velocity = BezireCurve.CubicVelocity(_pathMove.Points[0], _pathMove.Points[1], _pathMove.Points[2],
					_pathMove.Points[3], _tMove);
				var distance = BezireCurve.CubicDistance(_pathMove.Points[0], _pathMove.Points[1], _pathMove.Points[2],
					_pathMove.Points[3], _tMove);
				_tMove += ArrowStats.AttackStats.Movement.Speed * velocity / distance * Time.deltaTime;

				ArrowStats.Arrow.position = BezireCurve.CubicPoint(_pathMove.Points[0], _pathMove.Points[1], _pathMove.Points[2],
					_pathMove.Points[3], _tMove);
				ArrowStats.Arrow.forward = BezireCurve.CubicDirection(_pathMove.Points[0], _pathMove.Points[1],
					_pathMove.Points[2], _pathMove.Points[3], _tMove);
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
	}
}
