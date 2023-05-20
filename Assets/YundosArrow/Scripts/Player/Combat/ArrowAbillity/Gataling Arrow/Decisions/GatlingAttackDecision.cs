namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Decisions
{
	public class GatlingAttackDecision : Decision {
		public override bool Decide(GatlingState currentState)
		{
			return Actions.GatlingArrowsCount > 0;
		}
	}
}
