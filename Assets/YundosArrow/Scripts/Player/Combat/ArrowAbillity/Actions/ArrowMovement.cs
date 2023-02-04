using System;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Utils;
using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions
    {
        public static bool IsMoving { get; private set; }

//        public static IEnumerator Move() {
//            var targets = GlobalCollections.CurrentTargets;
//
//            if (targets == null)
//                throw new NullReferenceException("targets");
//
//            if (targets.Count == 0)
//                throw new Exception("targets cant be empty.", new IndexOutOfRangeException());
//
//            var cacheParent = ArrowStats.Arrow.parent;
//            var localPos = ArrowStats.Arrow.localPosition;
//            ArrowStats.Arrow.parent = null;
//            ArrowStats.Arrow.position = cacheParent.TransformPoint(localPos);
//            IsMoving = true;
//
//            var t = 0f;
//            // var distance = 0f;
//            ArrowPath path = null;
//
//            while (targets.Count > 0) {
//                t = 0f;
//                var currentPos = ArrowStats.Arrow.position;
//
//                if (path == null)
//                    path = new ArrowPath(ArrowStats.Arrow.position, targets[0].position, ArrowStats.Arrow.forward, ArrowStats.AttackStats.Movement.Force);
//                else
//                    path.ChangeDestination(targets[0].position, ArrowStats.AttackStats.Movement.Force);
//
//                // distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//
//                while (t <= 1f ) {
//                    ArrowStats.Arrow.DOMove(BezireCurve.CubicPoint(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t), 0f);
//                    ArrowStats.Arrow.forward = BezireCurve.CubicDirection(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//
//                    yield return new WaitForEndOfFrame();
//
//                    path.RecalculatePath(targets[0].position);
//
//                    var velocity = BezireCurve.CubicVelocity(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//                    var distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
//                    t += ArrowStats.AttackStats.Movement.Speed * velocity / distance * Time.deltaTime;
//                }
//                targets.RemoveAt(0);
//            }
//
//            t = 0f;
//            var lastPos = ArrowStats.Arrow.position;
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
//                GlobalCollections.Targets.Clear();
//                IsMoving = false;
//            });
//        }

		public static void Move() {
			var targets = GlobalCollections.CurrentTargets;

			if (targets == null)
				throw new NullReferenceException("targets");

			if (targets.Count == 0)
				throw new Exception("targets cant be empty.", new IndexOutOfRangeException());

			var cacheParent = ArrowStats.Arrow.parent;
			var localPos = ArrowStats.Arrow.localPosition;
			ArrowStats.Arrow.parent = null;
			ArrowStats.Arrow.position = cacheParent.TransformPoint(localPos);
			IsMoving = true;

			var t = 0f;
			// var distance = 0f;
			ArrowPath path = null;

			while (targets.Count > 0) {
				t = 0f;
				var currentPos = ArrowStats.Arrow.position;

				if (path == null)
					path = new ArrowPath(ArrowStats.Arrow.position, targets[0].position, ArrowStats.Arrow.forward, ArrowStats.AttackStats.Movement.Force);
				else
					path.ChangeDestination(targets[0].position, ArrowStats.AttackStats.Movement.Force);

				// distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);

				while (t <= 1f ) {
					ArrowStats.Arrow.DOMove(BezireCurve.CubicPoint(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t), 0f);
					ArrowStats.Arrow.forward = BezireCurve.CubicDirection(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);

					path.RecalculatePath(targets[0].position);

					var velocity = BezireCurve.CubicVelocity(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
					var distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
					t += ArrowStats.AttackStats.Movement.Speed * velocity / distance * Time.deltaTime;
				}
				targets.RemoveAt(0);
			}

			t = 0f;
			var lastPos = ArrowStats.Arrow.position;
			path.ChangeDestination(ArrowStats.StartPoint.position, ArrowStats.AttackStats.Movement.Force);
			// distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
			while (t <= 1f ) {
				ArrowStats.Arrow.DOMove(BezireCurve.CubicPoint(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t), 0f);
				ArrowStats.Arrow.forward = BezireCurve.CubicDirection(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);

				path.RecalculatePath(ArrowStats.StartPoint.position);
				var point = ArrowStats.StartPoint.position - ArrowStats.StartPoint.forward * (ArrowStats.AttackStats.Movement.ReturnForce);
				point += ArrowStats.StartPoint.right * (ArrowStats.AttackStats.Movement.ReturnForce);
				path.MovePoint(path.Points.Length - 2, point);

				var velocity = BezireCurve.CubicVelocity(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
				var distance = BezireCurve.CubicDistance(path.Points[0], path.Points[1], path.Points[2], path.Points[3], t);
				t += ArrowStats.AttackStats.Movement.Speed * velocity / distance * Time.deltaTime;
			}

			ArrowStats.Arrow.parent = cacheParent;
			Sequence seq = DOTween.Sequence();
			seq.Append(ArrowStats.Arrow.DOLocalMove(Vector3.zero, 0.2f));
			seq.Join(ArrowStats.Arrow.DOLocalRotateQuaternion(Quaternion.identity, 0.2f));
			seq.Play().OnComplete(() => {
				GlobalCollections.Targets.Clear();
				IsMoving = false;
			});
		}
    }
}
