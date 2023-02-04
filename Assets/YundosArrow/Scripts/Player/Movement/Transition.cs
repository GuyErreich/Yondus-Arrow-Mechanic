namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public class Transition
	{
		public PlayerState FromState;
		private Decision _decision;
		public PlayerStates ToState;


		public Transition(PlayerState fromState, Decision decision, PlayerStates toState)
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