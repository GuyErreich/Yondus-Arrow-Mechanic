using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class RetargetAttack : ArrowState {

		public RetargetAttack(ArrowController playerController) : base(playerController)
        {
			Transitions.Add(new Transition(this, new AttackDecision(), ArrowStates.Attack));
        }

        public override void Update()
        {
			Debug.Log("Retarget attack");
        }

		public override void OnStateEnter()
		{
			Actions.RetargetArrow();
		}

        public override void OnStateExit() {}
    }
}