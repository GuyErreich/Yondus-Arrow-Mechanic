using Assets.YundosArrow.Scripts.Player.Input;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public partial class Actions {
		public static void Jump(float jumpForce) {
			_verticalSpeed = jumpForce;
		}
	}
}
