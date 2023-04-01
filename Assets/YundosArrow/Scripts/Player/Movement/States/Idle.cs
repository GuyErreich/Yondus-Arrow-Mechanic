using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.Decisions;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
	public class Idle : PlayerState
	{
		public Idle(PlayerController playerController, CharacterController characterController) : base(playerController, characterController)
		{
			Transitions.Add(new Transition(this ,new IsMovingDecision(), PlayerStates.GroundMovement));
			Transitions.Add(new Transition(this ,new FallDecision(), PlayerStates.Fall));
			Transitions.Add(new Transition(this, new JumpDecision(), PlayerStates.Jump));
			// Transitions.Add(new Transition(this, new DashDecision(),  PlayerStates.Dash));
		}

		public override void Update()
		{
			Actions.Gravity();

			JumpGracePeriodHandler.TouchGround();

			Debug.Log("Idle");
		}

		public override void OnStateEnter()
		{
			_direction = Vector3.zero;
			PlayerStats.Anim.SetBool("IsMoving", false);
			PlayerStats.Anim.SetBool("IsGrounded", true);
		}

		public override void OnStateExit()
		{
			// Stop jump animation
		}
	}
}