using UnityEngine;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Stats
{
    [System.Serializable]
    public class JumpStats
    {
        [SerializeField] private float _duration;

        public float Duration => _duration;

        public JumpStats()
        {
            _duration = 1.5f;
        }
    }
}