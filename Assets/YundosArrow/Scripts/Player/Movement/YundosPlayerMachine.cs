using UnityEngine;
using System;
using Assets.YundosArrow.Scripts.FSM;
using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.States;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	[RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInputManager))]
    public class YundosPlayerMachine : StateMachine {

        [SerializeField] private PlayerStates _initState = PlayerStates.GroundMovement;
        [SerializeField] private PlayerStats _playerStats;

		private CharacterController _characterController;

		private void Awake()
		{
			_characterController = this.GetComponent<CharacterController>();
		}

        private void Start() {
            Transition(_initState);
        }

        public void Transition(PlayerStates state) {
            _prevState = _state;
            _state = state switch
            {
				PlayerStates.GroundMovement => new Move(this, _characterController),
				PlayerStates.Jump => new Jump(this, _characterController),
				PlayerStates.Dash => new Dash(this, _characterController),
				PlayerStates.None => _state,
				_  => throw new ArgumentException(message: "PlayerState", paramName: $"{state}")
            };
        }
    }

    public enum PlayerStates {
        None = 0,
        GroundMovement = 1,
        Jump = 2,
        Dash = 3,
        DoubleJump = 4
    }
}