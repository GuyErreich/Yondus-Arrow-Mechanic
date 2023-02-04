using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public partial class Actions {
		public static bool IsGrounded {
			get {
				RaycastHit hit;
				if(_charController.isGrounded) {
					return true;
				}
				else if (Physics.SphereCast(_charController.transform.position,  0.2f, -_charController.transform.up, out hit,
							1f, LayerMask.NameToLayer("Player")))
				{
					return true;
				}

				return false;
			}
		}
	}
}
