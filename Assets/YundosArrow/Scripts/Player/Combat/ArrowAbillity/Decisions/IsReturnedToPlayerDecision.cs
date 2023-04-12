namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class IsReturnedToPlayerDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return !Actions.IsMoving;
		}
	}
}
