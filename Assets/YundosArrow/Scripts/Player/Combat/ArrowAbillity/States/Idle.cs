using System;
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
			Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.Mark));
        }

        public override void Update()
        {
            Actions.FollowTarget(ArrowStats.StartPoint.position);
			Debug.Log("Idle");
        }

        public override void OnStateEnter()
        {
			ArrowStats.CrosshairAnim.Close();
//			Actions.FloatAnimation();
        }

        public override void OnStateExit() {}
    }
}