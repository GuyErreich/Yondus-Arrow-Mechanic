namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class NotMarkedDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return !Actions.IsMarked;
		}
	}
}
