using YundosArrow.Scripts.FSM;

namespace YundosArrow.Scripts.Player
{
    public class PlayerState : State
    {
        protected YundosPlayerMachine stateMachine;

        private void Start() {
            this.stateMachine = GetComponent<YundosPlayerMachine>();
        }

        protected void ChangeState(PlayerStates mode) {
            this.stateMachine.SetState(this.stateMachine.States[(int)mode]);
        }
    }
}