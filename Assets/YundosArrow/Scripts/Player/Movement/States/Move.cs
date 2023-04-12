using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.Decisions;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
	public class Move : PlayerState
	{
		public Move(PlayerController playerController, CharacterController characterController) : base(playerController, characterController)
		{
			Transitions.Add(new Transition(this ,new IsIdleDecision(), PlayerStates.Idle));
			Transitions.Add(new Transition(this ,new FallDecision(), PlayerStates.Fall));
			Transitions.Add(new Transition(this, new JumpDecision(), PlayerStates.Jump));
			Transitions.Add(new Transition(this, new DashDecision(),  PlayerStates.Dash));
		}

		public override void Update()
		{
			_direction = ((Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) +
				(Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y)).normalized;
			_speed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f);
			_speed *= PlayerStats.Movement.Speed;
			Actions.Move(_direction, _speed);
			Actions.Gravity();
			Actions.Rotate(PlayerStats.Movement.RotationSpeed);

			JumpGracePeriodHandler.TouchGround();

			Debug.Log("Moving");
		}

		public override void OnStateEnter()
		{
			PlayerStats.Anim.SetBool("IsMoving", true);
			PlayerStats.Anim.SetBool("IsGrounded", true);
		}

		public override void OnStateExit()
		{
			// Stop jump animation
		}
	}
}