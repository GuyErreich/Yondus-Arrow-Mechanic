using System;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Input;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
	[RequireComponent(typeof(PlayerInputManager))]
	public class ArrowController : MonoBehaviour {
        [SerializeField] private ArrowStats _playerStats;

		private ArrowState _currentState;
		private CharacterController _characterController;


		private void Start()
		{
			_characterController = this.GetComponent<CharacterController>();
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
			ArrowStates.StartAttack => new StartAttack(this),
			ArrowStates.Attack => new Attack(this),
			ArrowStates.ReturnToPlayer => new ReturnToPlayer(this),
			//			ArrowStates.ForceAttack => new ForceAttack(this),
			ArrowStates.CurrentState => _currentState,
			_ => throw new NullReferenceException($"State: {state}. doesnt exist")
		};
    }

	public enum ArrowStates {
		CurrentState = 0,
		Idle,
		Mark,
        StartAttack,
		Attack,
		ReturnToPlayer,
        ForceAttack
    }
}