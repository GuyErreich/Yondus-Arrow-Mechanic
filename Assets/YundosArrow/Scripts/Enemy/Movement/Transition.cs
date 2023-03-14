namespace Assets.YundosArrow.Scripts.Enemy.Movement
{
	public class Transition
	{
		public EnemyState FromState;
		private Decision _decision;
		public EnemyStates ToState;


		public Transition(EnemyState fromState, Decision decision, EnemyStates toState)
		{
			FromState = fromState;
			_decision = decision;
			ToState = toState;
		}

		public bool ShouldTransition()
		{
			return _decision.Decide(FromState);
		}
	}
}