using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.States
{
    public class StartAttack : GatlingState {

		private void Awake()
        {
			Transitions.Add(new Transition(this, new GatlingAttackDecision(), GatlingStates.Attack));
        }

        private void Update()
        {
			Debug.Log("Start gatling attack");
        }

		public override void OnStateEnter()
		{
			Actions.CreateArrows(Stats.attackStats.arrow, Stats.attackStats.anchor, Stats.attackStats.zOffset,
                                    Stats.attackStats.distance, Stats.attackStats.amount, Stats.attackStats.isSphere);
		}

        public override void OnStateExit() {}
    }
}