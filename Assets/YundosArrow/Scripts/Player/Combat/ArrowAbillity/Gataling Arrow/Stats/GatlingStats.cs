using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Stats
{
    [System.Serializable]
    public class GatlingStats
    {
        [SerializeField] private AttackStats _attackStats;

		public AttackStats attackStats => _attackStats;
    }
}