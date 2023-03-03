using Assets.YundosArrow.Scripts.Player.Input;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class GatlingAttackDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return Actions.GatlingArrowsCount > 0;
		}
	}
}