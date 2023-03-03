using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States.HomingArrow
{
    public class Attack : ArrowState {

		public Attack(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new HomingAttackOverDecision(), ArrowStates.ReturnToPlayer));
			Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.MarkAgain));
		}

        public override void Update()
        {
			Actions.Attack();

			Debug.Log("Homing attack");
        }

		public override void OnStateEnter() {}

        public override void OnStateExit() {}
    }
}