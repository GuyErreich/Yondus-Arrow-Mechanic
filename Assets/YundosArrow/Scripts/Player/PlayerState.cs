using YundosArrow.Scripts.FSM;

namespace YundosArrow.Scripts.Player
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