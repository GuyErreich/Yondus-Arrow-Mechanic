using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement;
using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
   public class Jump : PlayerState {
		private PlayerStates _nextState;

       	private Vector3 _direction;
		private float _finalSpeed;
		private float _lastJumpTime;

		public Jump(YundosPlayerMachine stateMachine, CharacterController characterController) : base(stateMachine) {
			Actions.CharController = characterController;
            _nextState = PlayerStates.None;
			_direction = Vector3.zero;
			_finalSpeed = 0f;
			_lastJumpTime = Time.time;

			if (PlayerStats.Jump.UsePhysics) {
				_direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) +
					(Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
				_finalSpeed = InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f;
				_finalSpeed *= PlayerStats.Movement.Speed;
			}
		}

       public override void OnUpdate()
       {
			if (!PlayerStats.Jump.UsePhysics) {
				_direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) +
					(Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
				_finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f);
				_finalSpeed *= PlayerStats.Movement.Speed;
			}
			Actions.Jump(PlayerStats.Jump.JumpForce, PlayerStats.Jump.JumpGracePeriod);
			Actions.Move(_direction, _finalSpeed);
			Actions.Gravity();
			if (!PlayerStats.Jump.UsePhysics)
				Actions.Rotate(PlayerStats.Movement.RotationSpeed);

			Debug.Log("Jumping");

            Decision();
       }

       public override void OnFixedUpdate() {}

       protected override void Decision()
       {
	        if (Actions.IsGrounded)
                _nextState = PlayerStates.GroundMovement;

			if (InputReceiver.Bool[InputReceiverType.RunPressed])
                 if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DashNumber)
                     _nextState = PlayerStates.Dash;

            // if (InputReceiver.Bool[InputReceiverType.JumpPressed])
            //     if(Time.time - _lastJumpTime >= PlayerStats.Jump.DoubleJump.ReactionGapTime)
            //         if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DoubleJumpNumber)
            //             _nextState = PlayerStates.DoubleJump;

            ChangeState(_nextState);
       }
   }
}