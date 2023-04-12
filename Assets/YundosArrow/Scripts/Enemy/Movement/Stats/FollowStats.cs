using UnityEngine;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Stats
{
    [System.Serializable]
    public class FollowStats
    {
        [SerializeField] private float _speed;
        [SerializeField, Min(0)] private float _scanRadius;
        [SerializeField] private LayerMask _layerMask;

        public float Speed => _speed;
        public float ScanRadius => _scanRadius;
        public LayerMask LayerMask => _layerMask;

        public FollowStats()
        {
            _speed = 5f;
            _scanRadius = 10f;
        }
    }
}