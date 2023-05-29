using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.States
{
    public class Attack : ArrowState {

		public Attack(ArrowController arrowController) : base(arrowController)
        {
			// Transitions.Add(new Transition(this, new RetargetDecision(), ArrowStates.StartHomingAttack));
			Transitions.Add(new Transition(this, new HomingAttackOverDecision(), ArrowStates.StopAttack));
			Transitions.Add(new Transition(this, new StopAttackDecision(), ArrowStates.StopAttack));
			// Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.MarkAgain));
		}

        public override void Update()
        {
            Actions.Mark();
			Actions.Attack();

			Debug.Log("Homing attack");
        }

		public override void OnStateEnter() {
        }

        public override void OnStateExit() {}
    }
}