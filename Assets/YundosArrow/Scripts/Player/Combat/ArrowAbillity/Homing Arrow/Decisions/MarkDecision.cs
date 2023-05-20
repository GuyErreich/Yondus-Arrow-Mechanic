using Assets.YundosArrow.Scripts.Player.Input;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions
{
	public class MarkDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return InputReceiver.Bool[InputReceiverType.ShootPressed];
		}
	}
}
