using Assets.YundosArrow.Scripts.Player.Input;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public partial class Actions {
		public static void Rotate(float rotationTime) {
			if(InputReceiver.Vector2[InputReceiverType.Movement] != Vector2.zero)
			{
				var x = (Camera.main.transform.right.normalized * InputReceiver.Vector2[InputReceiverType.Movement].x);
				var z = (Camera.main.transform.forward.normalized * InputReceiver.Vector2[InputReceiverType.Movement].y);
				var direction = Vector3.Scale(x + z, new Vector3(1,0,1));

				Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

				var angle = Quaternion.Angle(_charController.transform.rotation, toRotation);

				_charController.transform.rotation = Quaternion.RotateTowards(_charController.transform.rotation, toRotation, angle / (rotationTime / Time.deltaTime));
			}
		}
	}
}
