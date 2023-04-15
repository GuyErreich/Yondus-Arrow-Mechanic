using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Enemy.Movement
{
	public partial class Actions {
		public static bool IsGrounded(CharacterController characterController) {
			if (Physics.SphereCast(characterController.transform.position + characterController.center,  characterController.radius, -characterController.transform.up, out var hit, characterController.height * 1f, LayerMask.NameToLayer("Enemy")))
			{
				return true;
			}

			return false;
		}

		public static float GetDeltaTime(bool isUnscaled) {
			return isUnscaled ?  Time.unscaledDeltaTime : Time.deltaTime;
		}
	}
}
