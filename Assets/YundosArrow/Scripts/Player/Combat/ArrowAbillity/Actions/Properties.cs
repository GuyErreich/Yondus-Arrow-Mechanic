using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions {
		public static ArrowStats ArrowStats { private get; set; }
		public static Transform Player { private get; set; }
		public static bool IsMarked => _currentTargets != null && _currentTargets.Count > 0f;
		public static bool IsMoving { get; private set; }
		public static bool IsAttacking { get; private set; }
		public static List<Transform> CurrentTargets => _currentTargets;
	}
}