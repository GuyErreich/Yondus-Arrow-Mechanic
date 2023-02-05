using System.Collections.Generic;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public partial class Actions {
		public static bool IsMarked => _targets != null && _targets.Count > 0f;
		public static bool IsMoving { get; private set; }
		public static bool IsAttacking { get; private set; }
		public static List<Transform> CurrentTargets => _currentTargets;
	}
}