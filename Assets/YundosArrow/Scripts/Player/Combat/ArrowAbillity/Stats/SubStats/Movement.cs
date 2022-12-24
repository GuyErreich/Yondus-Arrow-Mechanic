using DG.Tweening;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats.SubStats
{
	[System.Serializable]
	public class Movement {
        [SerializeField, Range(1, 4)] private float speed;

        public Movement()
        {
            this.speed = 1f;
        }

        public Movement(float speed)
        {
            this.speed = speed;
        }
    }
}