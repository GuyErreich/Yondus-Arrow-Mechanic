using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
	public class JumpGracePeriodHandler
	{
		private static float _lastGroundTouchTime;
		private static float _lastJumpTime;

		public static bool CanJump()
		{
			return Time.unscaledTime - _lastGroundTouchTime <= PlayerStats.Jump.GracePeriod && Time.unscaledTime - _lastJumpTime  <= PlayerStats.Jump.GracePeriod;
		}

		public static bool CanDoubleJump(float gracePeriod)
		{
			return Time.unscaledTime - _lastGroundTouchTime >= gracePeriod;
		}

		public static void TouchGround()
		{
			_lastGroundTouchTime = Time.unscaledTime;
		}

		public static void Jump()
		{
			_lastJumpTime = Time.unscaledTime;
		}
	}

	public class DashRectionGapHandler
	{
		private static float _lastDashTime;

		public static bool CanDash()
		{
			return Time.unscaledTime - _lastDashTime >= PlayerStats.Movement.Dash.ReactionGapTime;
		}

		public static void Dash()
		{
			_lastDashTime = Time.unscaledTime;
		}
	}
}