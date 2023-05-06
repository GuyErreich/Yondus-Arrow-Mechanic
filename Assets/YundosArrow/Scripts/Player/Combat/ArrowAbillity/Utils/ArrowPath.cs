using System;
using System.Collections;
using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Utils
{
    public class ArrowPath
    {
        private List<Vector3> _points;
        private bool IsClosed { get; set;}

        public ArrowPath(Vector3 anchor1, Vector3 anchor2, Vector3 direction, float velocity)
		{
            var control1 = anchor1 + (direction * velocity);

            var newPoints = new List<Vector3> {
                anchor1,
                control1,
                (control1 + anchor2) * 0.5f,
                anchor2
            };

            _points = newPoints;
        }

        public Vector3 this[int i] => _points[i];

        //TODO: remember to remove if not used
        public Vector3[] Points => _points.ToArray();

        public void RecalculatePathDestination(Vector3 anchor)
		{
			_points[_points.Count - 2] = (_points[_points.Count - 3] + anchor) * .5f;
			_points[_points.Count - 1] = anchor;
		}

        public void RecalculatePathOrigin(Vector3 anchor, Vector3 direction, float force)
		{
			_points[0] = anchor;
			_points[1] = anchor + direction * force;
		}

        public void ChangeDestination(Vector3 anchor, float force)
		{
            var lastPoint = _points[_points.Count - 1];
            var direction = (lastPoint - _points[_points.Count - 2]).normalized;
            var control1 = lastPoint + direction * force;

            var newPoints = new List<Vector3> {
                lastPoint,
                control1,
                (control1 + anchor) * .5f,
                anchor
            };

            _points = newPoints;
        }

        public void MovePoint(int i , Vector3 pos)
		{
            _points[i] = pos;
        }
    }
}