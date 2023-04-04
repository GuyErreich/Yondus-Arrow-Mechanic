using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public partial class Actions {
		public static void Gravity() {
			//TODO: make it global and serializable with a curve
			if (!IsGrounded) {
				if (_verticalSpeed >= 0f)
					_verticalSpeed += Physics.gravity.y * Time.unscaledDeltaTime;
				else
					_verticalSpeed += Physics.gravity.y * PlayerStats.Jump.FallMultiplier * Time.unscaledDeltaTime;
			}

			if(IsGrounded) {
				if(_verticalSpeed < 0f)
					_verticalSpeed = 0f;
			}
		}
	}
}
