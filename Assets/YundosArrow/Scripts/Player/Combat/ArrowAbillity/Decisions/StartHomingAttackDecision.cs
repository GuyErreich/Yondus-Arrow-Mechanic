namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class StartHomingAttackDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return Actions.IsMarked && !Actions.IsMoving && !Actions.IsAttacking;
			// return Actions.IsMarked;
		}
	}
}
