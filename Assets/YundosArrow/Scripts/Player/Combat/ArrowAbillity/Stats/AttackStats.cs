using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats
{
	[System.Serializable]
	public class AttackStats {
        [SerializeField] private SubStats.Movement _movement;
        [Space]
        [SerializeField] private SubStats.MarkTargets _markTargets;

        public SubStats.Movement Movement => _movement;
        public SubStats.MarkTargets MarkTargets => _markTargets;

        public AttackStats()
        {
            _movement = new SubStats.Movement();
            _markTargets = new SubStats.MarkTargets();
        }
    }
}