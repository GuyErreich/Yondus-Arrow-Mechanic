using System;
using Assets.YundosArrow.Scripts.Enemy.Movement.States;
using Assets.YundosArrow.Scripts.Enemy.Movement.Stats;
using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Input;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement
{
	[RequireComponent(typeof(PlayerInputManager))]
	public class EnemyController : MonoBehaviour {
        public EnemyStats EnemyStats;

		private EnemyState _currentState;

		private void Start()
		{
			_currentState = GetState(EnemyStates.Roam);
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

		public void SetState(EnemyState newState)
		{
			_currentState.OnStateExit();
			_currentState = newState;
			_currentState.OnStateEnter();
		}

		private EnemyState GetState(EnemyStates state) => state switch
		{
			EnemyStates.Roam => new Roam(this),
			EnemyStates.CurrentState => _currentState,
			_ => throw new NullReferenceException($"State: {state}. doesnt exist")
		};
    }

	public enum EnemyStates {
		CurrentState = 0,
		Roam
    }
}