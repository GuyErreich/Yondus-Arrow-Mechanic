namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow
{
	public class Transition
	{
		public ArrowState FromState;
		private Decision _decision;
		public ArrowStates ToState;


		public Transition(ArrowState fromState, Decision decision, ArrowStates toState)
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