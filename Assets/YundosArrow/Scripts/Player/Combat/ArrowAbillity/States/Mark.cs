using UnityEngine;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class Mark : ArrowState {

		public Mark(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new StartHomingAttackDecision(), ArrowStates.StartHomingAttack));
			Transitions.Add(new Transition(this, new NotMarkedDecision(), ArrowStates.Idle));
		}

        public override void Update()
        {
			Actions.Mark();

//			Debug.Log("Marking");
        }

        public override void OnStateEnter()
        {
			ArrowStats.crosshairAnim.Open();
        }

        public override void OnStateExit() {}
    }
}