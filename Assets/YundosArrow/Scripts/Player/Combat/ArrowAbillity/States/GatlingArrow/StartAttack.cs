using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.States.GatlingArrow
{
    public class StartAttack : ArrowState {

		public StartAttack(ArrowController arrowController) : base(arrowController)
        {
			Transitions.Add(new Transition(this, new GatlingAttackDecision(), ArrowStates.GatlingAttack));
        }

        public override void Update()
        {
			Debug.Log("Start gatling attack");
        }

		public override void OnStateEnter()
		{
			Actions.CreateArrows();
		}

        public override void OnStateExit() {}
    }
}