using UnityEngine;
using CaptainClaw.Scripts.FSM;
using System;
using System.Linq;

namespace CaptainClaw.Scripts.Player
{
    [RequireComponent(typeof(PlayerInputManager))]
    [RequireComponent(typeof(MovementMode))]
    [RequireComponent(typeof(JumpingMode))]
    // [RequireComponent(typeof(HandleCollision))]
    public class PlayerMachine : StateMachine {

        [SerializeField] private PlayerStates InitState;
        
        public State[] States { get; private set; }

        private void Awake() {
            var arraySize = Enum.GetValues(typeof(PlayerStates)).Cast<PlayerStates>().Last() + 1;
            this.States = new State[(int)arraySize];

            this.States[(int)PlayerStates.GroundMovement] = this.GetComponent<MovementMode>();
            this.States[(int)PlayerStates.Jumping] = this.GetComponent<JumpingMode>();
        }
        
        private void Start() {
            this.SetState(this.States[(int)InitState]);
        }
    }

    public enum PlayerStates {
        GroundMovement = 0,
        Jumping = 1
    }
}