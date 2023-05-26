using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.States
{
	public class ReturnToPlayer : ArrowState {

		public ReturnToPlayer(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new IsReturnedToPlayerDecision(), ArrowStates.Idle));
			Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.MarkAgain));
        }

        public override void Update()
        {
			Actions.MoveToStartingPoint();

			Debug.Log("Returning to player");
        }

		public override void OnStateEnter() {}

		public override void OnStateExit() {}
    }
}