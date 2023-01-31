using UnityEngine;

namespace YundosArrow.Scripts.FSM
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State state;
        protected State prevState;

        public virtual State PrevState {
            get => this.prevState;
        }
        
        public virtual void SetState(State state) 
        {
            this.prevState = this.state;
            this.state = state;
            StartCoroutine(this.state.On());
        }

    }
}