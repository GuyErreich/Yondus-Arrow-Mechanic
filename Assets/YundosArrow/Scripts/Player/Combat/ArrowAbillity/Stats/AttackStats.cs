using DG.Tweening;
using UnityEngine;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats.SubStats;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats
{
	[System.Serializable]
	public class AttackStats {
        [SerializeField] private SubStats.Movement movement;
        [Space]
        [SerializeField] private SubStats.MarkTargets markTargets;

        public SubStats.Movement Movement { get => movement; }
        public SubStats.MarkTargets MarkTargets { get => markTargets; }

        public AttackStats()
        {
            this.movement = new SubStats.Movement();
            this.markTargets = new SubStats.MarkTargets();
        }

        public AttackStats(SubStats.Movement movement, MarkTargets markTargets)
        {
            this.movement = movement;
            this.markTargets = markTargets;
        }

    }
}