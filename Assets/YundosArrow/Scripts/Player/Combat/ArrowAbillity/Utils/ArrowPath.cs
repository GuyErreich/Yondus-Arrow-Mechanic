using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils 
{
    public class ArrowPath
    {
        private List<Vector3> points;
        private bool isClosed { get; set;}

        public ArrowPath(Vector3 anchor1, Vector3 anchor2, Vector3 direction, float velocity) {
            var control1 = anchor1 + (direction * velocity);

            this.points = new List<Vector3> {
                anchor1,
                control1,
                (control1 + anchor2) * .5f,
                anchor2
            };
        }

        public Vector3 this[int i] {
            get {
                return this.points[i];
            }
        }

        //TODO: remember to remove if not used
        public Vector3[] Points {
            get => this.points.ToArray();
        }

        public void RecalculatePath(Vector3 anchor) {
            this.points[this.points.Count - 2] = (this.points[this.points.Count - 3] + anchor) * .5f;
            this.points[this.points.Count - 1] = anchor;
        }

        public void ChangeDestination(Vector3 anchor, float force) {
            var lastPoint = this.points[this.points.Count - 1];
            var direction = (lastPoint - this.points[this.points.Count - 2]);

            var newPoints = new List<Vector3> {
                lastPoint,
                lastPoint + direction * force,
                (lastPoint + anchor) * .5f,
                anchor
            };

            this.points = newPoints;
        }

        public void MovePoint(int i , Vector3 pos) {
            this.points[i] = pos;
        }
    }
}