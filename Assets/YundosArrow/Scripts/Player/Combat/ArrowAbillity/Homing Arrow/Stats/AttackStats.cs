using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Stats
{
	[System.Serializable]
	public class AttackStats {
		[SerializeField] private SubStats.HomingArrow _homingArrow;
		[Space]
        [SerializeField] private SubStats.MarkTargets _markTargets;

		public SubStats.HomingArrow homingArrow => _homingArrow;
		public SubStats.MarkTargets markTargets => _markTargets;

        public AttackStats()
        {
			_homingArrow = new SubStats.HomingArrow();
			_markTargets = new SubStats.MarkTargets();
        }
    }
}