using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
	public class Move : PlayerState
	{
		private PlayerStates _nextState;

		public Move(YundosPlayerMachine stateMachine, CharacterController characterController) : base(stateMachine) {
			_nextState = PlayerStates.None;
			Actions.CharController = characterController;
		}

		public override void OnUpdate()
		{
			var direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) +
			                (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
			var finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed]
				? PlayerStats.Movement.SprintMultiplier
				: 1f);
			finalSpeed *= PlayerStats.Movement.Speed;
			Actions.Move(direction, finalSpeed);
			Actions.Gravity();
			Actions.Rotate(PlayerStats.Movement.RotationSpeed);

			Debug.Log("Moving");

			Decision();
		}

		public override void OnFixedUpdate() {}

		protected override void Decision()
		{
			if (InputReceiver.Bool[InputReceiverType.JumpPressed] || Actions.IsJumpGracePeriod)
				_nextState = PlayerStates.Jump;

			 if (InputReceiver.Bool[InputReceiverType.RunPressed])
			 	if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DashNumber)
			 		_nextState = PlayerStates.Dash;

			ChangeState(_nextState);
		}
	}
}