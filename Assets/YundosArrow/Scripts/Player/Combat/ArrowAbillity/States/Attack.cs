using UnityEngine;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class Attack : ArrowState {

        public Attack(ArrowController playerController) : base(playerController)
        {
			Transitions.Add(new Transition(this, new IsAttackOverDecision(), ArrowStates.Idle));
        }

        public override void Update()
        {
			Actions.Mark();
			Actions.Move();

			Debug.Log("Attacking");
        }

        public override void OnStateEnter()
        {
			ArrowStats.CrosshairAnim.Open();
        }

        public override void OnStateExit() {}
    }
}