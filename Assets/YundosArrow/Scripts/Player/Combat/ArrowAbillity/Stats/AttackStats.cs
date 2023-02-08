using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats
{
	[System.Serializable]
	public class AttackStats {
		[SerializeField] private SubStats.HomingArrow _homingArrow;
		[Space]
		[SerializeField] private SubStats.GatlingArrow _gatlingArrow;
		[Space]
        [SerializeField] private SubStats.MarkTargets _markTargets;

		public SubStats.HomingArrow homingArrow => _homingArrow;
		public SubStats.GatlingArrow gatlingArrow => _gatlingArrow;
		public SubStats.MarkTargets markTargets => _markTargets;

        public AttackStats()
        {
			_homingArrow = new SubStats.HomingArrow();
			_gatlingArrow = new SubStats.GatlingArrow();
			_markTargets = new SubStats.MarkTargets();
        }
    }
}