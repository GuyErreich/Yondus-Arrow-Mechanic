using YundosArrow.Scripts.FSM;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities
{
    public class ArrowState : State
    {
        protected ArrowAbilityMachine stateMachine;

        private void Start() {
            this.stateMachine = GetComponent<ArrowAbilityMachine>();
        }

        protected void ChangeState(ArrowStates mode) {
            this.stateMachine.SetState(this.stateMachine.States[(int)mode]);
        }
    }
}