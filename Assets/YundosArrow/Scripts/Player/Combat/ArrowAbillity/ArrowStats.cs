using UnityEngine;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities
{
	[System.Serializable]
	public class ArrowStats : ISerializationCallbackReceiver {
		[Header("References")]
		[SerializeField] private Transform arrow;
		[SerializeField] private Transform startPoint;
		[Space]

		[SerializeField] private IdleStats idleStats;
		[SerializeField] private AttackStats attackStats;

		#region Serialized Static Variables
        public static Transform Arrow { get; private set; }
        public static Transform StartPoint { get; private set; }
		public static IdleStats IdleStats { get; private set; }
		public static AttackStats AttackStats { get; private set; }
		#endregion Serialized Static Variables


        public void OnAfterDeserialize()
		{
			Arrow =  this.arrow;
			StartPoint =  this.startPoint;
			IdleStats =  this.idleStats;
			AttackStats =  this.attackStats;
		}

		public void OnBeforeSerialize()
		{
			return;
		}
	}
}