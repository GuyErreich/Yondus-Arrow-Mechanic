using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Stats.SubStats
{
	[System.Serializable]
	public class DashStats {
        [SerializeField, Min(0.01f)] private float _distance;
        [SerializeField, Range(0f, 3f)] private float _duration;

        public float Distance { get => _distance; }
        public float Duration { get => _duration; }

        public DashStats()
        {
            _distance = 10f;
            _duration = 0.3f;
        }
    }
}