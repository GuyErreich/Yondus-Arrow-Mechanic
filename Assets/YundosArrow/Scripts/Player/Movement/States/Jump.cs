using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.Decisions;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
   public class Jump : PlayerState {
		private float _lastJumpTime;

		public float LastJumpTime { get => _lastJumpTime; }

		public Jump(PlayerController playerController, CharacterController characterController) : base(playerController, characterController)
		{
			Transitions.Add(new Transition(this, new IsGroundedDecision(), PlayerStates.Idle));
			Transitions.Add(new Transition(this, new FallDecision(), PlayerStates.Fall));
			Transitions.Add(new Transition(this, new DoubleJumpDecision(), PlayerStates.DoubleJump));
			Transitions.Add(new Transition(this, new DashDecision(), PlayerStates.Dash));
		}

		public override void Update()
		{
			if (!PlayerStats.Jump.UsePhysics) {
				_direction = ((Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) +
					(Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y)).normalized;
				_speed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f);
				_speed *= PlayerStats.Movement.Speed;
			}

			Actions.Move(_direction, _speed);
			Actions.Gravity();
			Actions.Rotate(_direction, PlayerStats.Movement.RotationSpeed);

			Debug.Log("Jumping");
		}

		public override void OnStateEnter()
		{
			_lastJumpTime = Time.time;
			Actions.Jump(PlayerStats.Jump.JumpForce);
			PlayerStats.Anim.SetTrigger("Jump");
			PlayerStats.Anim.SetBool("IsGrounded", false);
		}

		public override void OnStateExit() {}
   }
}