using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States.GatlingArrow
{
    public class Attack : ArrowState {

		public Attack(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new GatlingAttackOverDecision(), ArrowStates.Idle));
		}

        public override void Update()
        {
			Actions.IdleFollow();
			Actions.DryMark();
			Actions.GatlingAttack();

			Debug.Log("Attacking");
        }

		public override void OnStateEnter() {}

        public override void OnStateExit() {}
    }
}