namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class IsGroundedDecision : Decision {
		public override bool Decide(PlayerState currentState)
		{
			if (Actions.IsGrounded)
			{
				return true;
			}

			return false;
		}
	}
}
