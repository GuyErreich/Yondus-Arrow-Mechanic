using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States
{
    public class StartAttack : ArrowState {

		public StartAttack(ArrowController playerController) : base(playerController)
        {
			Transitions.Add(new Transition(this, new AttackDecision(), ArrowStates.Attack));
        }

        public override void Update()
        {
			Debug.Log("Start attack");
        }

		public override void OnStateEnter()
		{
			Actions.AttackInit();
		}

        public override void OnStateExit() {}
    }
}