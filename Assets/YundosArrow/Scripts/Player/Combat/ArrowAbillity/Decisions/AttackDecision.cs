namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class AttackDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return Actions.IsAttacking;
		}
	}
}
