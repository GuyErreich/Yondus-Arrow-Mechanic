using UnityEngine;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities
{
	[System.Serializable]
	public class ArrowStats : ISerializationCallbackReceiver {
		#region Serializable Fields
		[Header("References")]
		[SerializeField] private Transform arrowTransform;
		[Space]

		[SerializeField] private IdleStats idleStats;
		#endregion Serialized Static Variables
        public static Transform ArrowTransform { get; private set; }
		public static IdleStats IdleStats { get; private set; }

        public void OnAfterDeserialize()
		{
			ArrowTransform =  this.arrowTransform;
			IdleStats =  this.idleStats;
		}

		public void OnBeforeSerialize()
		{
			return;
		}
	}
}