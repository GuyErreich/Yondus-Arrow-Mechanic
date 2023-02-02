namespace Assets.YundosArrow.Scripts.FSM
{
    public abstract class State
    {
		protected StateMachine _stateMachine;

		protected State(StateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

        public abstract void OnUpdate();

        public abstract void OnFixedUpdate();

		protected abstract void Decision();
	}
}