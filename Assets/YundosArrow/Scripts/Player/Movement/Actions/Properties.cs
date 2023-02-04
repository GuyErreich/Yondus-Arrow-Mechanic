using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
    public partial class Actions
    {
		public static CharacterController CharController { set => _charController = value; }
//		public static bool IsGrounded { get => _charController.isGrounded; }
		public static bool CanJump { get; private set;}
		public static float VerticalSpeed { get => _verticalSpeed; }
	}
}
