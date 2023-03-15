using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.Decisions;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
	public class Fall : PlayerState
	{

		public Fall(PlayerController playerController, CharacterController characterController) : base(playerController, characterController)
		{
			Transitions.Add(new Transition(this, new IsGroundedDecision(), PlayerStates.GroundMovement));
			Transitions.Add(new Transition(this, new JumpDecision(), PlayerStates.Jump));
			Transitions.Add(new Transition(this, new DashDecision(),  PlayerStates.Dash));
			// Transitions.Add(new Transition(this, new DoubleJumpDecision(), PlayerStates.DoubleJump));
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

			Debug.Log("Falling");
		}

		public override void OnStateEnter() 
		{
			PlayerStats.Anim.SetTrigger("Fall");
		}

		public override void OnStateExit() {}
	}
}