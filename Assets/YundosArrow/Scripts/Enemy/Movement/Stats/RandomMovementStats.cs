using UnityEngine;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Stats
{
    [System.Serializable]
    public class RandomMovemebtStats
    {
        [SerializeField] private float _speed;
        [SerializeField, Range(0, 10)] private float _minMoveTime;
        [SerializeField, Range(0, 10)] private float _maxMoveTime;
        [SerializeField] private float _moveRadius;

        public float Speed => _speed;
        public float MinMoveTime => _minMoveTime;
        public float MaxMoveTime => _maxMoveTime;
        public float MoveRadius => _moveRadius;

        public RandomMovemebtStats()
        {
            _speed = 3f;
            _minMoveTime = 2f;
            _maxMoveTime = 2f;
            _moveRadius = 2f;
        }
    }
}