using UnityEngine;
using YundosArrow.Scripts.UI;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats
{
	[System.Serializable]
	public class ArrowStats : ISerializationCallbackReceiver {
		[Header("References")]
		[SerializeField] private CrosshairAnim _crosshairAnim;
		[Space]

		[SerializeField] private Transform _arrow;
		[SerializeField] private Transform _startPoint;
		[Space]

		[SerializeField] private IdleStats _idleStats;
		[SerializeField] private AttackStats _attackStats;

		#region Serialized Static Variables
        public static CrosshairAnim CrosshairAnim { get; private set; }
        public static Transform Arrow { get; private set; }
        public static Transform StartPoint { get; private set; }
		public static IdleStats IdleStats { get; private set; }
		public static AttackStats AttackStats { get; private set; }
		#endregion Serialized Static Variables


        public void OnAfterDeserialize()
		{
			CrosshairAnim = _crosshairAnim;
			Arrow =  _arrow;
			StartPoint =  _startPoint;
			IdleStats =  _idleStats;
			AttackStats =  _attackStats;
		}

		public void OnBeforeSerialize() {}
	}
}