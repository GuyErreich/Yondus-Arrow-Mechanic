using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats.SubStats
{
	[System.Serializable]
	public class FollowTarget {
        [SerializeField, Range(0.01f, 10)] private float _duration;

        public float Duration => _duration;
        public FollowTarget()
        {
            _duration = 0.5f;
        }
    }
}