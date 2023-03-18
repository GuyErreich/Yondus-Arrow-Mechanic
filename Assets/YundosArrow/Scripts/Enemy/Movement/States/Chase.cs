using UnityEngine;
using UnityEngine.AI;
using Assets.YundosArrow.Scripts.Enemy.Movement.Decisions;


 namespace Assets.YundosArrow.Scripts.Enemy.Movement.States
 {
     public class Chase : EnemyState {
		private float _timeCounter;
		private NavMeshAgent _agent;

		private void Awake() {
			Transitions.Add(new Transition(this, new ChaseToRoamDecision(), EnemyStates.Roam));
// 			Transitions.Add(new Transition(this, new StartGatlingAttackDecision(), ArrowStates.StartGatlingAttack));

			Stats = GetComponent<EnemyController>().EnemyStats;
			_agent = GetComponent<NavMeshAgent>();
		}

		protected override void Update()
		{
			var hits = Physics.OverlapSphere(transform.position, Stats.FollowStats.ScanRadius, Stats.FollowStats.LayerMask, QueryTriggerInteraction.Collide);
			// foreach (var hit in hits) {
			// 	if (hit.CompareTag("Player"))
			// 	{
			if (hits.Length > 0) 
			{				
				Debug.Log("following player");
				_agent.destination = hits[0].gameObject.transform.position;
				// return;
			}
			// 	}
			// }

			Debug.Log("Chasing player");
		}

		public override void OnStateEnter() {
			_timeCounter = 0;
		}

		public override void OnStateExit() {}
     }
 }