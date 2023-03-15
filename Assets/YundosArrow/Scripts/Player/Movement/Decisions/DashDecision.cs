using Assets.YundosArrow.Scripts.Player.Input;
using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement.Decisions
{
	public class DashDecision : Decision {
		private float t = 0;
		public override bool Decide(PlayerState currentState)
		{
//			Debug.Log($"Dash pressed: {InputReceiver.Bool[InputReceiverType.RunPressed]}");
//			Debug.Log($"Valid combo: {ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DashNumber}");

			if (InputReceiver.Bool[InputReceiverType.DashPressed])
				if (t > PlayerStats.Movement.Dash.ReactionGapTime)
					if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DashNumber)
					{
	//					Debug.Log($"Do Dash");

						return true;
					}

			t += Time.deltaTime;

			return false;
		}
	}
}
