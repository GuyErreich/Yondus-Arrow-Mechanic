using UnityEngine;

namespace YundosArrow.Scripts.Player.Stats.SubStats
{
	[System.Serializable]
	public class DashStats {
        [SerializeField, Min(0.01f)] private float distance;
        [SerializeField, Range(0f, 3f)] private float duration;
        
        public float Distance { get => this.distance; }
        public float Duration { get => duration; }

        public DashStats()
        {
            this.distance = 10f;
            this.duration = 1.2f;
        }
    }
}