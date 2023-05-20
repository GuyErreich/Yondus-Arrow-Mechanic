namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions
{
	public class IsReturnedToPlayerDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return !Actions.IsMoving;
		}
	}
}
