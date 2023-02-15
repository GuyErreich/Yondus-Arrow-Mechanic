using UnityEngine;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class MarkAgain : ArrowState {

		public MarkAgain(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new RetargetDecision(), ArrowStates.StartHomingAttack));
			Transitions.Add(new Transition(this, new HomingAttackDecision(), ArrowStates.HomingAttack));
			Transitions.Add(new Transition(this, new NotMarkedDecision(), ArrowStates.Idle));
		}

        public override void Update()
        {
			Actions.Mark();

//			Debug.Log("Marking again");
        }

        public override void OnStateEnter()
        {
			ArrowStats.crosshairAnim.Open();
        }

		public override void OnStateExit() {}
    }
}