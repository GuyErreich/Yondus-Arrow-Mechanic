using UnityEngine;
using System.Collections;

namespace YundosArrow.Scripts.FSM
{
    public abstract class State
    {
        protected abstract void OnStart();

        public abstract void OnUpdate();

        public abstract void OnFixedUpdate();

        protected abstract void Decision();
    }
}