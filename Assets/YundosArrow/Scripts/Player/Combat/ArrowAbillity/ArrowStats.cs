using UnityEngine;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities
{
	[System.Serializable]
	public class ArrowStats : ISerializationCallbackReceiver {
		[Header("References")]
		[SerializeField] private Transform arrowTransform;
		[Space]

		[SerializeField] private IdleStats idleStats;
		[SerializeField] private MarkTargetsStats markTargetsStats;

		#region Serialized Static Variables
        public static Transform ArrowTransform { get; private set; }
		public static IdleStats IdleStats { get; private set; }
		public static MarkTargetsStats MarkTargetsStats { get; private set; }
		#endregion Serialized Static Variables


        public void OnAfterDeserialize()
		{
			ArrowTransform =  this.arrowTransform;
			IdleStats =  this.idleStats;
			MarkTargetsStats =  this.markTargetsStats;
		}

		public void OnBeforeSerialize()
		{
			return;
		}
	}
}