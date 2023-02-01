using UnityEngine;
using YundosArrow.Scripts.FSM;
using System;
using System.Linq;
using YundosArrow.Scripts.Player.States;

namespace YundosArrow.Scripts.Player
{
    [RequireComponent(typeof(PlayerInputManager))]
    public class YundosPlayerMachine : StateMachine {

        [SerializeField] private PlayerStates InitState;
        [SerializeField] private PlayerStats playerStats;
        
        public State[] States { get; private set; }

        private void Awake() {
            var arraySize = Enum.GetValues(typeof(PlayerStates)).Cast<PlayerStates>().Last() + 1;
            this.States = new State[(int)arraySize];

            this.States[(int)PlayerStates.GroundMovement] = new Movement();
            this.States[(int)PlayerStates.Jumping] = new Jump();
            this.States[(int)PlayerStates.Dash] = new Dash();
            this.States[(int)PlayerStates.DoubleJump] = new DoubleJump();
        }
        
        private void Start() {
            this.SetState(this.States[(int)InitState]);
        }
    }

    public enum PlayerStates {
        GroundMovement = 0,
        Jumping = 1,
        Dash = 2,
        DoubleJump = 3
    }
}