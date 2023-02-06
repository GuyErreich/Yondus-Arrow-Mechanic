namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class StartAttackDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return Actions.IsMarked && !Actions.IsAttacking;
		}
	}
}
