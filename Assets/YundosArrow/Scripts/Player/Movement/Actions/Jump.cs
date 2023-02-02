using Assets.YundosArrow.Scripts.Player.Input;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public partial class Actions {
		public static void Jump(float jumpForce, float jumpGracePeriod, bool forceJump = false) {
			if (InputReceiver.Bool[InputReceiverType.JumpPressed])
				_jumpButtonPressedTime = Time.time;

			IsJumpGracePeriod = true;

			// The same as checking ground but gives a little period where it still considers you grounded.
			// this gives the char a better jump interaction because most of the times people don`t press the jump
			// button in the perfect right time to make the char jump again.
			if (Time.time - _jumpButtonPressedTime <= jumpGracePeriod || forceJump) {
				if (Time.time - _lastGroundedTime <= jumpGracePeriod || forceJump)
				{
					_verticalSpeed = jumpForce;

					IsJumpGracePeriod = false;
					_lastGroundedTime = null;
					_jumpButtonPressedTime = null;
				}
			}
		}
	}
}
