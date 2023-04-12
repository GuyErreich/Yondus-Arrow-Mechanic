using Assets.YundosArrow.Scripts.Player.Input;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class IsMovingDecision : Decision {
		public override bool Decide(PlayerState currentState)
		{
			return InputReceiver.Vector2[InputReceiverType.Movement] != Vector2.zero;
		}
	}
}
