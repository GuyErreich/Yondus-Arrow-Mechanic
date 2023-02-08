using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States.HomingArrow
{
    public class StartAttack : ArrowState {

		public StartAttack(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new HomingAttackDecision(), ArrowStates.HomingAttack));
        }

        public override void Update()
        {
			Debug.Log("Start homing attack");
        }

		public override void OnStateEnter()
		{
			Actions.AttackInit();
		}

        public override void OnStateExit() {}
    }
}