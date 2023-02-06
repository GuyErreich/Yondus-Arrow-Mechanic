using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class Attack : ArrowState {

		public Attack(ArrowController playerController) : base(playerController)
        {
			Transitions.Add(new Transition(this, new IsAttackOverDecision(), ArrowStates.ReturnToPlayer));
			Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.MarkAgain));
		}

        public override void Update()
        {
			Actions.Attack();

			Debug.Log("Attacking");
        }

		public override void OnStateEnter() {}

        public override void OnStateExit() {}
    }
}