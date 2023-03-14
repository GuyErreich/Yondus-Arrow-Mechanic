 using UnityEngine;
 using UnityEngine.AI;

 namespace Assets.YundosArrow.Scripts.Enemy.Movement.States
 {
     public class Roam : EnemyState {
		 private float _timeCounter;
		 private Vector3 _position;
		 private NavMeshAgent _agent;

		 public Roam(EnemyController enemyController) : base(enemyController)
         {
// 			Transitions.Add(new Transition(this, new MarkDecision(), ArrowStates.Mark));
// 			Transitions.Add(new Transition(this, new StartGatlingAttackDecision(), ArrowStates.StartGatlingAttack));
			 _timeCounter = 0;
			 _position = enemyController.transform.position;
			 _agent = enemyController.GetComponent<NavMeshAgent>();
 		}

         public override void Update()
         {
			 _timeCounter += Time.deltaTime;

			 if (EnemyStats.Agent.remainingDistance >= 0f)
			 	if (_timeCounter < Random.Range(EnemyStats.RandomMovemebtStats.MinMoveTime, EnemyStats.RandomMovemebtStats.MaxMoveTime))
			 		return;

			 _timeCounter = 0;
//			 EnemyStats.Agent.destination = Actions.RandomMovement(_position, EnemyStats.RandomMovemebtStats.MoveRadius);
			 _agent.destination = Actions.RandomMovement(_position, EnemyStats.RandomMovemebtStats.MoveRadius);
		 }

         public override void OnStateEnter() {}

         public override void OnStateExit() {}
     }
 }