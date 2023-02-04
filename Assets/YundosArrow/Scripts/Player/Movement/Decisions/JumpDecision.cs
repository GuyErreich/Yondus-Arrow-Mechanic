using Assets.YundosArrow.Scripts.Player.Input;

namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class JumpDecision : Decision {
		public override bool Decide(PlayerState currentState)
		{
			if (JumpGracePeriodHandler.CanJump())
			{
				return true;
			}

			return false;
		}
	}
}
