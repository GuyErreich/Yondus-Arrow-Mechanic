using UnityEngine;
using YundosArrow.Scripts.Player.Stats.SubStats;

namespace YundosArrow.Scripts.Player.Stats
{
	[System.Serializable]
	public class MovementStats {
        [SerializeField, Min(0.01f)] private float speed;
        [SerializeField, Range(0f, 3f)] private float rotationSpeed;
        [SerializeField, Range(1f, 5f)] private float sprintMultiplier;
        [SerializeField] private DashStats dash;
        
        public float Speed { get => this.speed; }
        public float RotationSpeed { get => this.rotationSpeed; }
        public float SprintMultiplier { get => this.sprintMultiplier; }
        public DashStats Dash { get => this.dash; }

        public MovementStats()
        {
            this.speed = 10f;
            this.rotationSpeed = 1.2f;
            this.sprintMultiplier = 1.2f;
            this.dash = new DashStats();
        }
    }
}