using UnityEngine;

namespace YundosArrow.Scripts.FSM
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State state;

        public virtual void SetState(State state) 
        {
            this.state = state;
            StartCoroutine(this.state.On());
        }
    }
}