using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions;
using DG.Tweening;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.States
{
    public class StopAttack : ArrowState {

		public StopAttack(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new StopAttackDecision(), ArrowStates.ReturnToPlayer));
			Transitions.Add(new Transition(this, new HomingAttackOverDecision(), ArrowStates.ReturnToPlayer));
        }

        public override void Update() {
            if (Actions.IsAttacking)
                Actions.Attack();
        }

		public override void OnStateEnter()
		{
            Actions.StopAttack();
			Actions.MoveToStartingInit();
            Actions.StartMove();

			Debug.Log("Stop homing attack");
		}

        public override void OnStateExit() {}
    }
}