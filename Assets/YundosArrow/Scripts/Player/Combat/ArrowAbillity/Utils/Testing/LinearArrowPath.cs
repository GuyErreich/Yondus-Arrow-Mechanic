using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils 
{
    public class LinearArrowPath
    {
        private List<Segment> segments;
        public Segment StartSegment { get; set;}
        private bool isClosed { get; set;}
        
        public LinearArrowPath(Segment segment) {
            this.segments = new List<Segment>();
            this.segments.Add(segment);
            this.StartSegment = segment;
        }

        public void Add(Segment segment) {
            this.segments.Add(segment);
        }

        public void RemoveAt(int index) {
            segments.RemoveAt(index);
        }

        private void ToggleClosed() {
            this.isClosed = !this.isClosed;

            if (this.isClosed) {
                var seg = new Segment( segments[segments.Count - 1].end, StartSegment.start);
                this.segments.Add(seg);
            }
            else {
                this.segments.RemoveAt(segments.Count - 1);
            }
        }

        public void ClosePath() {
            if (!this.isClosed)
                this.ToggleClosed();
        }

        public void OpenPath() {
            if (this.isClosed)
                this.ToggleClosed();
        }

        public int Count { get => this.segments.Count; }
        public Segment this[int i] { get => this.segments[i]; }
    }
}