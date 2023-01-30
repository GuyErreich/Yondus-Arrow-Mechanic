using UnityEngine;
using YundosArrow.Scripts.Player.Stats;

namespace YundosArrow.Scripts.Player
{
	[System.Serializable]
	public class PlayerStats : ISerializationCallbackReceiver {
		[SerializeField] private MovementStats movementStats;
		[SerializeField] private JumpStats jumpStats;

		#region Serialized Static Variables
		public static MovementStats Movement { get; private set; }
		public static JumpStats Jump { get; private set; }
		#endregion Serialized Static Variables

        public void OnAfterDeserialize()
		{
			Movement = this.movementStats;
			Jump = this.jumpStats;
		}

		public void OnBeforeSerialize()
		{
			return;
		}
	}
}