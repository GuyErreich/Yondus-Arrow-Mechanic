using UnityEngine;

namespace CaptainClaw.Scripts.Player {
	public class PlayerStats : MonoBehaviour, ISerializationCallbackReceiver {
		#region Serializable Fields
		[Header("Health")]
		[SerializeField] private float health = 100f;

		[Header("Movement")]
		[SerializeField] private float speed = 7f;
		[SerializeField] private float rotationSpeed = 0.2f;
		[SerializeField, Range(1f, 5f)] private float sprintMultiplier = 1f;

		[Header("Jump")]
		[SerializeField] private float jumpForce = 7f;
		[SerializeField, Range(1, 3)] private float fallMultiplier = 1.25f;
		[SerializeField, Range(0f, 1f)] private float jumpGracePeriod = 0.2f;
		[SerializeField] private bool usePhysics = false;

		[Header("Climb Ladder")]
		[SerializeField] private float climbSpeed = 4f;
		// [SerializeField] private float positionCorrectionOffset = 0.03f;
		[SerializeField, Range(0.5f, 10f)] private float climbGracePeriod = 1f;
		#endregion Serializable Fields

		#region Serialized Static Variables
		//Health
		public static float MaxHealth { get; private set; }
		public static float CurrentHealth { get; set; }
		// Movement
		public static float Speed { get; private set; }
		public static float RotationSpeed { get; private set; }
		public static float SprintMultiplier  { get; private set; }

		// Jump
		public static float JumpForce { get; set; }
		public static float JumpGracePeriod  { get; private set; }
		public static float FallMultiplier  { get; private set; }
		public static bool UsePhysics { get; private set; }

		// Climb Ladder
		public static float ClimbSpeed { get; private set; }
		// public static float PositionCorrectionOffset  { get; private set; }
		public static float ClimbGracePeriod { get; private set; }
		#endregion Serialized Static Variables

		public void OnAfterDeserialize()
		{
			
			MaxHealth = this.health;
			CurrentHealth = this.health;
			Speed = this.speed;
			RotationSpeed = this.rotationSpeed;
			SprintMultiplier = this.sprintMultiplier;
			JumpForce = this.jumpForce;
			JumpGracePeriod = this.jumpGracePeriod;
			FallMultiplier = this.fallMultiplier;
			UsePhysics = this.usePhysics;
			ClimbSpeed = this.climbSpeed;
			// PositionCorrectionOffset = this.positionCorrectionOffset;
			ClimbGracePeriod = this.climbGracePeriod;
		}

		public void OnBeforeSerialize()
		{
			return;
		}
	}
}