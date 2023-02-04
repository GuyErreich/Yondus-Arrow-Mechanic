using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class DoubleJumpDecision : Decision {
		public override bool Decide(PlayerState currentState)
		{
			if (InputReceiver.Bool[InputReceiverType.JumpPressed])
//				if(Time.time - _lastJumpTime >= PlayerStats.Jump.DoubleJump.ReactionGapTime)
				if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DoubleJumpNumber)
					return true;

			return false;
		}
	}
}
