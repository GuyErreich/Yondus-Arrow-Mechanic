using Assets.YundosArrow.Scripts.Player.Movement.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
	public class MarkRectionGapHandler
	{
		private static float _lastMarkTime;

		public static bool CanMark()
		{
			return Time.time - _lastMarkTime >= 0.3f;
		}

		public static void Mark()
		{
			_lastMarkTime = Time.time;
		}
	}
}