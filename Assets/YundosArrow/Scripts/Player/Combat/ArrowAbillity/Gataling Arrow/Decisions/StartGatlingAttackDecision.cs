using Assets.YundosArrow.Scripts.Player.Input;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Decisions
{
	public class StartGatlingAttackDecision : Decision {
		public override bool Decide(GatlingState currentState)
		{
			return InputReceiver.Bool[InputReceiverType.AimPressed] && Actions.GatlingArrowsCount == 0;
		}
	}
}
