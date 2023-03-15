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
			return Time.time - _lastGroundTouchTime <= PlayerStats.Jump.GracePeriod && Time.time - _lastJumpTime  <= PlayerStats.Jump.GracePeriod;
		}

		public static bool CanDoubleJump(float gracePeriod)
		{
			return Time.time - _lastGroundTouchTime >= gracePeriod;
		}

		public static void TouchGround()
		{
			_lastGroundTouchTime = Time.time;
		}

		public static void Jump()
		{
			_lastJumpTime = Time.time;
		}
	}

	public class DashRectionGapHandler
	{
		private static float _lastDashTime;

		public static bool CanDash()
		{
			return Time.time - _lastDashTime >= PlayerStats.Movement.Dash.ReactionGapTime;
		}

		public static void Dash()
		{
			_lastDashTime = Time.time;
		}
	}
}