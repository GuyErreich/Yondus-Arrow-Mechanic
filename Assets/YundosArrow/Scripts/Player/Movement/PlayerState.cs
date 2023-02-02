using Assets.YundosArrow.Scripts.FSM;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
    public abstract class PlayerState : State
    {
		protected PlayerState(StateMachine stateMachine) : base(stateMachine) {}

         protected void ChangeState(PlayerStates mode) {
			(_stateMachine as YundosPlayerMachine)?.Transition(mode);
         }
    }
}