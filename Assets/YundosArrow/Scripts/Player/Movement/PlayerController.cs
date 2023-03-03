using System;
using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.States;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(PlayerInputManager))]
	public class PlayerController : MonoBehaviour {
        [SerializeField] private PlayerStats _playerStats;

		private PlayerState _currentState;
		private CharacterController _characterController;

        private void Awake()
        {
			this.gameObject.AddComponent<TimeScaleController>();
        }

        private void Start()
		{
			_characterController = this.GetComponent<CharacterController>();
			_currentState = GetState(PlayerStates.Idle);
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

		public void SetState(PlayerState newState)
		{
			_currentState.OnStateExit();
			_currentState = newState;
			_currentState.OnStateEnter();
		}

		private PlayerState GetState(PlayerStates state) => state switch
		{
			PlayerStates.Idle => new Idle(this, _characterController),
			PlayerStates.GroundMovement => new Move(this, _characterController),
			PlayerStates.Jump => new Jump(this, _characterController),
			PlayerStates.Fall => new Fall(this, _characterController),
			PlayerStates.Dash => new Dash(this, _characterController),
			PlayerStates.DoubleJump => new DoubleJump(this, _characterController),
			PlayerStates.CurrentState => _currentState,
			_ => throw new NullReferenceException($"State: {state}. doesnt exist")
		};
    }

	public enum PlayerStates {
        CurrentState = 0,
		Idle,
        GroundMovement,
        Jump,
		Fall,
        Dash,
        DoubleJump,
    }
}