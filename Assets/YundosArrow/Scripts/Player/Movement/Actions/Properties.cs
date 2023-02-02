using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
    public partial class Actions
    {
		public static CharacterController CharController { set => _charController = value; }
		public static bool UsePhysics { get; private set; }
		public static bool IsGrounded { get => _charController.isGrounded; }
		public static bool IsJumpGracePeriod { get; private set;}
    }
}
