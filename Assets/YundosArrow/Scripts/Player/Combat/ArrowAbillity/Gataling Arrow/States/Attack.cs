using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.States
{
    public class Attack : GatlingState {

		private void Awake() {
			Transitions.Add(new Transition(this, new GatlingAttackOverDecision(), GatlingStates.Idle));
		}

        private void Update()
        {
            var hitPoint = Utils.GetHitMarkPoint(transform.position, Stats.attackStats.markTargets.range,
													Stats.attackStats.markTargets.rangeOnNoHit,
													Stats.attackStats.markTargets.radius,
													Stats.attackStats.markTargets.layerMask);
			
            Actions.GatlingArrowsFollow(hitPoint, Stats.attackStats.followTarget.duration, Stats.attackStats.amount);
			Actions.GatlingAttack(hitPoint, Stats.attackStats.rateOfFire, Stats.attackStats.range, 
                                    Stats.attackStats.speed);

			Debug.Log("Gatling Attack");
        }

		public override void OnStateEnter() {}

        public override void OnStateExit() {}
    }
}