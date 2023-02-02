using Assets.YundosArrow.Scripts.FSM;
using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
    public class Dash : PlayerState {
		private PlayerStates _nextState;
		private readonly Vector3 _direction;
		private readonly float _startTime;
		private bool _isDone;

//        public override IEnumerator On() {
//
//            ComboManager.Instance.Decrease(ComboManager.Instance.DashNumber);
//
//            while (Time.time - _startTime < PlayerStats.Movement.Dash.Duration)
//            {
//
//                var speed = PlayerStats.Movement.Dash.Distance / PlayerStats.Movement.Dash.Duration;
//                MovementHandler.Move(_direction, speed);
//                MovementHandler.Gravity();
//
//                Debug.Log("Dashing");
//
//                yield return new WaitForEndOfFrame();
//
//                if (InputReceiver.Bool[InputReceiverType.JumpPressed] && MovementHandler.isGrounded) {
//                    __nextState = PlayerStates.Jumping;
//                    break;
//                } else if (InputReceiver.Bool[InputReceiverType.JumpPressed]) {
//                    if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DoubleJumpNumber) {
//                        __nextState = PlayerStates.DoubleJump;
//                        break;
//                    }
//                }
//            }
//
//            if (MovementHandler.isGrounded)
//                __nextState = PlayerStates.GroundMovement;
//            else
//                __nextState = PlayerStates.Jumping;
//
//            base.ChangeState(__nextState);
//        }

		public Dash(StateMachine stateMachine, CharacterController characterController) : base(stateMachine) {
			Actions.CharController = characterController;
			_nextState = PlayerStates.None;
			_direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) +
				(Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
            _startTime = Time.time;

            ComboManager.Instance.Decrease(ComboManager.Instance.DashNumber);
		}

		public override void OnUpdate()
		{
			if (Time.time - _startTime < PlayerStats.Movement.Dash.Duration)
            {
				_isDone = false;

                var speed = PlayerStats.Movement.Dash.Distance / PlayerStats.Movement.Dash.Duration;
                Actions.Move(_direction, speed);
				Actions.Gravity();

                Debug.Log("Dashing");
            }
			else
			{
				_isDone = true;
			}

			Decision();
		}

		public override void OnFixedUpdate() {}

		protected override void Decision()
		{
			if (InputReceiver.Bool[InputReceiverType.JumpPressed] && Actions.IsGrounded)
				_nextState = PlayerStates.Jump;

//			if (InputReceiver.Bool[InputReceiverType.JumpPressed] && !Actions.IsGrounded)
//				if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DoubleJumpNumber)
//					_nextState = PlayerStates.DoubleJump;

			if (_isDone)
			{
				if (Actions.IsGrounded)
	                _nextState = PlayerStates.GroundMovement;
	            else
	                _nextState = PlayerStates.Jump;

			}

            ChangeState(_nextState);
		}
    }
}