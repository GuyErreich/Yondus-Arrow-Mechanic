namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class IsAttackOverDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return !Actions.IsAttacking;
		}
	}
}
