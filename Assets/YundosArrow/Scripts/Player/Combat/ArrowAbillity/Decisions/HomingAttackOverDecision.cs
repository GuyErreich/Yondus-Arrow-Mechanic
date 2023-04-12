namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class HomingAttackOverDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return !Actions.IsAttacking;
		}
	}
}
