using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.Decisions;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using Assets.YundosArrow.Scripts.Systems.Managers;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
    public class DoubleJump : PlayerState {
		public DoubleJump(PlayerController playerController, CharacterController characterController) : base(playerController, characterController)
		{
			Transitions.Add(new Transition(this, new FallDecision(), PlayerStates.Fall));
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

			Debug.Log("Double Jumping");
		}

		public override void OnStateEnter()
		{
			_direction = ((Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) +
				(Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y)).normalized;

			ComboManager.Instance.Decrease(ComboManager.Instance.DoubleJumpNumber);

			Actions.Jump(PlayerStats.Jump.JumpForce);
			PlayerStats.Anim.SetTrigger("IsDoubleJump");
		}

		public override void OnStateExit() {}
    }
}