using UnityEngine;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class Mark : ArrowState {

        public Mark(ArrowController playerController) : base(playerController)
        {
			Transitions.Add(new Transition(this, new StartAttackDecision(), ArrowStates.StartAttack));
        }

        public override void Update()
        {
			Actions.Mark();

			Debug.Log("Marking");
        }

        public override void OnStateEnter()
        {
			ArrowStats.CrosshairAnim.Open();
        }

        public override void OnStateExit() {}
    }
}