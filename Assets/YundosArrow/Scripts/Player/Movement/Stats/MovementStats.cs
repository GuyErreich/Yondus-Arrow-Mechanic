using Assets.YundosArrow.Scripts.Player.Movement.Stats.SubStats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Stats
{
	[System.Serializable]
	public class MovementStats {
        [SerializeField, Min(0.01f)] private float _speed;
        [SerializeField, Range(0f, 3f)] private float _rotationSpeed;
        [SerializeField, Range(1f, 5f)] private float _sprintMultiplier;
        [SerializeField] private DashStats _dash;

        public float Speed { get => _speed; }
        public float RotationSpeed { get => _rotationSpeed; }
        public float SprintMultiplier { get => _sprintMultiplier; }
        public DashStats Dash { get => _dash; }

        public MovementStats()
        {
            _speed = 10f;
            _rotationSpeed = 1.2f;
            _sprintMultiplier = 1.2f;
            _dash = new DashStats();
        }
    }
}