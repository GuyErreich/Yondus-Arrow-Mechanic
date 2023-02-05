using UnityEngine;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class StartAttack : ArrowState {

		public StartAttack(ArrowController playerController) : base(playerController)
        {
			Transitions.Add(new Transition(this, new AttackDecision(), ArrowStates.Attack));
        }

        public override void Update()
        {
			Debug.Log("Start attack");
        }

		public override void OnStateEnter()
		{
			Actions.MoveInit();
		}

        public override void OnStateExit() {}
    }
}