namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions
{
	public class HomingAttackDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return Actions.IsMoving && Actions.IsAttacking;
		}
	}
}
