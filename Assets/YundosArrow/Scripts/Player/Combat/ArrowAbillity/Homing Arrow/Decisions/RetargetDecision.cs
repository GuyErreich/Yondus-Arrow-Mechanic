using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions
{
	public class RetargetDecision : Decision {
		public override bool Decide(ArrowState currentState)
		{
			Debug.Log($"Retarget: {Actions.IsMarked && Actions.IsMoving && !Actions.IsAttacking}");
			return Actions.IsMarked && Actions.IsMoving && !Actions.IsAttacking;
		}
	}
}
