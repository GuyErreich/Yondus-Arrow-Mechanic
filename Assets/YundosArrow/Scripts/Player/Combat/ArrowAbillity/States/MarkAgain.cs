using UnityEngine;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class MarkAgain : ArrowState {

		public MarkAgain(ArrowController playerController) : base(playerController)
        {

//			Transitions.Add(new Transition(this, new RetargetDecision(), ArrowStates.RetargetAttack));
			Transitions.Add(new Transition(this, new AttackDecision(), ArrowStates.Attack));
			Transitions.Add(new Transition(this, new NotMarkedDecision(), ArrowStates.Idle));
		}

        public override void Update()
        {
			Actions.Mark();

			Debug.Log("Marking again");
        }

        public override void OnStateEnter()
        {
			ArrowStats.CrosshairAnim.Open();
        }

		public override void OnStateExit() {}
    }
}