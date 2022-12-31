using DG.Tweening;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats.SubStats
{
	[System.Serializable]
	public class Movement {
        [SerializeField, Range(0.1f, 50)] private float speed;
        [SerializeField, Range(1, 2)] private float force = 1f;
        [SerializeField, Range(1, 10)] private float loopHoleForce = 1f;
        
        public float Speed { get => speed; }
        public float Force { get => force; }
        public float LoopHoleForce { get => loopHoleForce; }

        public Movement()
        {
            this.speed = 1f;
            this.force = 1f;
            this.loopHoleForce = 1f;
        }

        public Movement(float speed, float force, float loopHoleForce)
        {
            this.speed = speed;
            this.force = force;
            this.loopHoleForce = loopHoleForce;
        }
    }
}