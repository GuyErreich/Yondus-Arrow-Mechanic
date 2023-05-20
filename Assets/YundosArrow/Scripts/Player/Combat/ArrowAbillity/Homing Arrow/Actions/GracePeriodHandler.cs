using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow
{
	public class MarkReactionGapHandler
	{
		private static float _lastMarkTime;

		public static bool CanMark()
		{
			return Time.unscaledTime - _lastMarkTime >= 0.3f;
		}

		public static void Mark()
		{
			_lastMarkTime = Time.unscaledTime;
		}
	}
}