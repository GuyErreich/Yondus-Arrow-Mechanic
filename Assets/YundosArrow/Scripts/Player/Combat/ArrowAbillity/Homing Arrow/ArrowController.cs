using System;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.States;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Stats;
using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Input;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow
{
	[RequireComponent(typeof(PlayerInputManager))]
	public class ArrowController : MonoBehaviour {
        public ArrowStats ArrowStats;

		private ArrowState _currentState;

		private void Start()
		{
			_currentState = GetState(ArrowStates.Idle);
			_currentState.OnStateEnter();
		}

		private void Update()
		{
			_currentState.Update();

			foreach (Transition transition in _currentState.Transitions)
			{
				if (transition.ShouldTransition())
				{
					_currentState.OnStateExit();
					_currentState = GetState(transition.ToState);
					_currentState.OnStateEnter();
					break;
				}
			}
		}

		public void SetState(ArrowState newState)
		{
			_currentState.OnStateExit();
			_currentState = newState;
			_currentState.OnStateEnter();
		}

		private ArrowState GetState(ArrowStates state) => state switch
		{
			ArrowStates.Idle => new Idle(this),
			ArrowStates.Mark => new Mark(this),
			ArrowStates.MarkAgain => new MarkAgain(this),
			ArrowStates.StartHomingAttack => new StartAttack(this),
			ArrowStates.HomingAttack => new Attack(this),
			ArrowStates.ReturnToPlayer => new ReturnToPlayer(this),
			ArrowStates.StopAttack => new StopAttack(this),
			ArrowStates.CurrentState => _currentState,
			_ => throw new NullReferenceException($"State: {state}. doesnt exist")
		};
    }

	public enum ArrowStates {
		CurrentState = 0,
		Idle,
		Mark,
		MarkAgain,
		StartHomingAttack,
		HomingAttack,
		ReturnToPlayer,
		StopAttack
    }
}