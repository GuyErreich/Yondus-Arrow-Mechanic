
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Stats
{
	[System.Serializable]
	public class PlayerStats : ISerializationCallbackReceiver {
		[SerializeField] private MovementStats _movementStats;
		[SerializeField] private JumpStats _jumpStats;

		public static MovementStats Movement { get; private set; }
		public static JumpStats Jump { get; private set; }

        public void OnAfterDeserialize()
		{
			Movement = _movementStats;
			Jump = _jumpStats;
		}

		public void OnBeforeSerialize() {}
	}
}