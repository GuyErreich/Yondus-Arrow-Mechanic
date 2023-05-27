using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions
{
	public class HomingAttackOverDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			return !Actions.IsMarked && Actions.IsMoving && !Actions.IsAttacking;
		}
	}
}
