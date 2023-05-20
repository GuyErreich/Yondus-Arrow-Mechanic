using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Stats;
using DG.Tweening;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.States
{
    public class Idle : GatlingState {
		private void Awake()
        {
			Transitions.Add(new Transition(this, new StartGatlingAttackDecision(), GatlingStates.StartAttack));
		}

        private void Update()
        {
			Debug.Log("Gatling Idle");
        }

        public override void OnStateEnter() {}

        public override void OnStateExit() {}
    }
}