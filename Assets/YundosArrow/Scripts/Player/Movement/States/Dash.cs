using Assets.YundosArrow.Scripts.Player.Movement.Decisions;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.States
{
    public class Dash : PlayerState {
		private float _startTime;

		public float StartTime => _startTime;

		public Dash(PlayerController playerController, CharacterController characterController) : base(playerController, characterController)
		{
			Transitions.Add(new Transition(this, new IsDashOverAndGroundedDecision(), PlayerStates.GroundMovement));
			Transitions.Add(new Transition(this, new IsDashOverAndFallingDecision(), PlayerStates.Fall));
		}

		public override void Update()
		{
			var speed = PlayerStats.Movement.Dash.Distance / PlayerStats.Movement.Dash.Duration;

			Actions.Move(_direction, speed);
			Actions.Gravity();

			Debug.Log("Dashing");
		}

		public override void OnStateEnter()
		{
			ComboManager.Instance.Decrease(ComboManager.Instance.DashNumber);
			_startTime = Time.unscaledTime;
			PlayerStats.Movement.Dash.OnStart?.Invoke();
		}

		public override void OnStateExit()
		{
			PlayerStats.Movement.Dash.OnExit?.Invoke();
		}
    }
}