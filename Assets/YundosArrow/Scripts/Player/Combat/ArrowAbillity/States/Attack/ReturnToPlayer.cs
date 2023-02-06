using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
	public class ReturnToPlayer : ArrowState {

		public ReturnToPlayer(ArrowController playerController) : base(playerController)
        {
			Transitions.Add(new Transition(this, new IsReturnedToPlayerDecision(), ArrowStates.Idle));
//			Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.MarkAgain));
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