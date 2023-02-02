using UnityEngine;

namespace Assets.YundosArrow.Scripts.FSM
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State _state;
        protected State _prevState;

        protected virtual void Update() 
        {
            _state.OnUpdate();
        }

        protected virtual void FixedUpdate() 
        {
            _state.OnFixedUpdate();
        }
    }
}