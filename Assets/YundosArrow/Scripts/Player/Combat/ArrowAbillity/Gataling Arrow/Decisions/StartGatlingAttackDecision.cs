using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Systems.Managers;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Decisions
{
	public class StartGatlingAttackDecision : Decision {
		public override bool Decide(GatlingState currentState)
		{
			return InputReceiver.Bool[InputReceiverType.AimPressed] && 
					Actions.GatlingArrowsCount == 0 &&
					ComboManager.Instance.CurrentNumber >= ComboManager.Instance.GatlingNumber;
		}
	}
}
