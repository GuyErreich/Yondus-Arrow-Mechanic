using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using DG.Tweening;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States.HomingArrow
{
    public class StopAttack : ArrowState {

		public StopAttack(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new StopAttackDecision(), ArrowStates.ReturnToPlayer));
			Transitions.Add(new Transition(this, new HomingAttackOverDecision(), ArrowStates.ReturnToPlayer));
        }

        public override void Update()
        {
			Debug.Log("Stop homing attack");
        }

		public override void OnStateEnter()
		{
			Actions.MoveToStartingInit();
		}

        public override void OnStateExit() {}
    }
}