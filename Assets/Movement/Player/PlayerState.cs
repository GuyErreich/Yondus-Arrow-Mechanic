using CaptainClaw.Scripts.FSM;

namespace CaptainClaw.Scripts.Player
{
    public class PlayerState : State
    {
        protected PlayerMachine stateMachine;

        private void Start() {
            this.stateMachine = GetComponent<PlayerMachine>();
        }

        protected void ChangeState(PlayerStates mode) {
            this.stateMachine.SetState(this.stateMachine.States[(int)mode]);
        }
    }
}