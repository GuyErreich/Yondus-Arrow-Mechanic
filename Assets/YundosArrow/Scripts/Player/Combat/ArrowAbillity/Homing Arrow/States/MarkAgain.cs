using UnityEngine;
using System.Collections;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Decisions;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.States
{
    public class MarkAgain : ArrowState {

		public MarkAgain(ArrowController arrowController) : base(arrowController)
        {
			// Transitions.Add(new Transition(this, new KeepAttackingDecision(), ArrowStates.HomingAttack));
			Transitions.Add(new Transition(this, new RetargetDecision(), ArrowStates.StartHomingAttack));
			Transitions.Add(new Transition(this, new HomingAttackOverDecision(), ArrowStates.ReturnToPlayer));

		}

        public override void Update()
        {
			Actions.Mark();

            // var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // sphere.transform.position = ArrowStats.attackStats.homingArrow.arrow.position;
            // if (Actions.IsAttacking)
            //     Actions.Attack();
            // else if (Actions.IsMoving) 
            //     Actions.MoveToStartingPoint();
			Debug.Log("Marking again");
        }

        public override void OnStateEnter() {}

		public override void OnStateExit() {}
    }
}