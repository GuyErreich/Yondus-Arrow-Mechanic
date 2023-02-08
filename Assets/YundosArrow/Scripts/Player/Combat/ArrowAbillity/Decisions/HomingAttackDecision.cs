namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class HomingAttackDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return Actions.IsAttacking;
		}
	}
}
