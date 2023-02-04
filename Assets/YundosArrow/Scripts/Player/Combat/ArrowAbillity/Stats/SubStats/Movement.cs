using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats.SubStats
{
	[System.Serializable]
	public class Movement {
        [SerializeField, Range(0.1f, 50)] private float _speed;
        [SerializeField, Range(1, 10)] private float _force;
        [SerializeField, Range(1, 20)] private float _returnForce;
        [SerializeField, Range(1, 10)] private float _loopHoleForce;

        public float Speed => _speed;
        public float Force => _force;
        public float LoopHoleForce => _loopHoleForce;
        public float ReturnForce => _returnForce;

        public Movement()
        {
            _speed = 1f;
            _force = 1f;
            _returnForce = 5f;
            _loopHoleForce = 1f;
        }
    }
}