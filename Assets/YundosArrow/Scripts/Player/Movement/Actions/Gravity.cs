using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public partial class Actions {
		public static void Gravity() {
			Debug.Log("Gravity");
			//TODO: make it global and serializable with a curve
			if (!_charController.isGrounded) {
				if (_verticalSpeed >= 0f)
					_verticalSpeed += Physics.gravity.y * Time.deltaTime;
				else
					_verticalSpeed += Physics.gravity.y * PlayerStats.Jump.FallMultiplier * Time.deltaTime;
			}

			if(_charController.isGrounded) {
				_lastGroundedTime = Time.time;

				if(_verticalSpeed < 0f)
					_verticalSpeed = 0f;
			}
		}
	}
}
