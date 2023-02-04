using UnityEngine;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using Debug = UnityEngine.Debug;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class Idle : ArrowState {
        public Idle(ArrowController playerController) : base(playerController)
        {
			Transitions.Add(new Transition(this, new AttackDecision(), ArrowStates.Attack));
        }

        public override void Update()
        {
//			Actions.FloatAnimation();
			Actions.Mark();

			Debug.Log("Idle");
        }

        public override void OnStateEnter()
        {
			ArrowStats.CrosshairAnim.Close();
        }

        public override void OnStateExit() {}
    }
}