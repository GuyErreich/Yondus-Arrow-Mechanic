using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils 
{
    public class LinearArrowPath
    {
        private List<Segment> segments;

        public LinearArrowPath() {
            this.segments = new List<Segment>();
        }

        public void AddSegment(Vector3 start, Vector3 end) {
            this.segments.Add(new Segment(start, end));
        }
        public void DeleteSegment(int index) {
            segments.RemoveAt(index);
        }

        // MovePath
        // MovePointInPath
    }
}