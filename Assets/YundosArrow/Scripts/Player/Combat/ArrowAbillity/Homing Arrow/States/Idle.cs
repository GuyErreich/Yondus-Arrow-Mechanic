using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.States
{
    public class Idle : ArrowState {
		public Idle(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.Mark));
		}

        public override void Update()
        {
			Actions.IdleFollow();
			Debug.Log("Idle");
        }

        public override void OnStateEnter() {
            Actions.StopAttack();
            Actions.StopMove();
        }

        public override void OnStateExit() {}
    }
}