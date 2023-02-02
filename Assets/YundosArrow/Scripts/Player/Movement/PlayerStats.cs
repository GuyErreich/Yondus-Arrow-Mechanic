using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	[System.Serializable]
	public class PlayerStats : ISerializationCallbackReceiver {
//	public class PlayerStats {

		[SerializeField] private MovementStats _movementStats;
		[SerializeField] private JumpStats _jumpStats;

		public static MovementStats Movement { get; private set; }
		public static JumpStats Jump { get; private set; }

//		public PlayerStats()
//		{
//			_movementStats = new MovementStats();
//			_jumpStats = new JumpStats();
//		}

        public void OnAfterDeserialize()
		{
			Movement = _movementStats;
			Jump = _jumpStats;
		}

		public void OnBeforeSerialize() {}
	}
}