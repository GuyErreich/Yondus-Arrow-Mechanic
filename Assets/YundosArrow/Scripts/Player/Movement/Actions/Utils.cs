using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public partial class Actions {
		public static bool IsGrounded {
			get {
				if (Physics.SphereCast(_charController.transform.position + _charController.center,  _charController.radius, -_charController.transform.up, out var hit, _charController.height * 0.5f, LayerMask.NameToLayer("Player")))
				{
					return true;
				}

				return false;
			}
		}
	}
}
