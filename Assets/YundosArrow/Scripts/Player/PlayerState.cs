using YundosArrow.Scripts.FSM;

namespace YundosArrow.Scripts.Player
{
    public abstract class PlayerState : State
    {
        // protected YundosPlayerMachine stateMachine;

        // private void Start() {
        //     this.stateMachine = GetComponent<YundosPlayerMachine>();
        // }

        // protected PlayerState PrevState {
        //     get => this.stateMachine.PrevState as PlayerState;
        // } 

        // protected void ChangeState(PlayerStates mode) {
        //     this.stateMachine.SetState(this.stateMachine.States[(int)mode]);
        // }

        // protected void ChangeState(PlayerState state) {
        //     this.stateMachine.SetState(state);
        // }
    }
}