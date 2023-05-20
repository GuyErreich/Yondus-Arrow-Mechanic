using UnityEngine;
using YundosArrow.Scripts.UI;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Stats
{
	[System.Serializable]
	public class ArrowStats {
		[Header("References")]
		[SerializeField] private CrosshairAnim _crosshairAnim;
		[Space]
		[SerializeField] private IdleStats _idleStats;
		[SerializeField] private AttackStats _attackStats;

		public CrosshairAnim crosshairAnim => _crosshairAnim;
		public IdleStats idleStats => _idleStats;
		public AttackStats attackStats => _attackStats;
	}
}