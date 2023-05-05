using Assets.YundosArrow.Scripts.Player.Input;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions
{
	public class StopAttackDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return !InputReceiver.Bool[InputReceiverType.ShootPressed];
		}
	}
}
