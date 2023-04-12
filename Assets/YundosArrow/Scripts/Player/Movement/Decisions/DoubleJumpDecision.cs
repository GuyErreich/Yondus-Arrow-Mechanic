using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.States;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class DoubleJumpDecision : Decision {
		public override bool Decide(PlayerState currentState)
		{
			if (InputReceiver.Bool[InputReceiverType.JumpPressed])
				if(JumpGracePeriodHandler.CanDoubleJump(PlayerStats.Jump.DoubleJump.ReactionGapTime) || currentState is Fall)
					if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DoubleJumpNumber)
						return true;

			return false;
		}
	}
}
