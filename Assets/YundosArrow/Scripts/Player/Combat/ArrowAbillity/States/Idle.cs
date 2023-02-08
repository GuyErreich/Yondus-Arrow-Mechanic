using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class Idle : ArrowState {
		public Idle(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.Mark));
			Transitions.Add(new Transition(this, new StartGatlingAttackDecision(), ArrowStates.StartGatlingAttack));
		}

        public override void Update()
        {
			Actions.IdleFollow();
			Debug.Log("Idle");
        }

        public override void OnStateEnter()
        {
			Actions.Mark();
			ArrowStats.crosshairAnim.Close();
        }

        public override void OnStateExit() {}
    }
}