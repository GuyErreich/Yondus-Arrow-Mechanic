namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow
{
	public class Transition
	{
		public GatlingState FromState;
		private Decision _decision;
		public GatlingStates ToState;

		public Transition(GatlingState fromState, Decision decision, GatlingStates toState)
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