using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public partial class Actions {
		public static void Move(Vector3 direction, float speed) {
			_velocity = direction * speed;
			_velocity.y = _verticalSpeed;

			_charController.Move(_velocity * Time.unscaledDeltaTime);
		}
	}
}
