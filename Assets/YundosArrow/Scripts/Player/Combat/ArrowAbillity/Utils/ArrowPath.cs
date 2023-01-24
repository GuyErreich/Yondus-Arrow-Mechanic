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

        public int NumOfPoints { 
            get {
                return this.points.Count;
            } 
        }

        public int NumOfSegments { 
            get {
                return this.points.Count / 3;
            } 
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

        public void RemoveSegment(int i) {
            this.points.RemoveRange(i, 2);
        }

        public Vector3[] GetPointsInSegment(int i) {
            return new Vector3[] { 
                this.points[LoopIndex(i * 3)],
                this.points[LoopIndex(i * 3 + 1)],
                this.points[LoopIndex(i * 3 + 2)],
                this.points[LoopIndex(i * 3 + 3)] 
            };
        }

        public void MovePoint(int i , Vector3 pos) {
            this.points[i] = pos;
        }

        private void ToggleClosed(float force) {
            this.isClosed = !this.isClosed;

            if (this.isClosed) {
                var direction = (this.points[this.points.Count - 1] - this.points[this.points.Count - 2]);
                this.points.Add(this.points[this.points.Count - 1] + direction * force);

                direction = (this.points[0] - this.points[1]);
                this.points.Add(this.points[0] + direction * force);
            }
            else {
                // this.points.RemoveRange(this.points.Count - 2, 2);
                this.points.RemoveAt(this.points.Count - 1);
            }
        }

        public void ClosePath() {
            if (!this.isClosed)
                this.ToggleClosed(ArrowStats.AttackStats.Movement.Force);
        }

        public void OpenPath() {
            if (this.isClosed)
                this.ToggleClosed(ArrowStats.AttackStats.Movement.Force);
        }

        private int LoopIndex(int i) {
            return (i + this.points.Count) % this.points.Count;
        }
    }
}