using UnityEngine;
using UnityEngine.AI;
using Assets.YundosArrow.Scripts.Enemy.Movement.Decisions;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.States
 {
     public class Roam : EnemyState {
		private float _timeCounter;
		private NavMeshAgent _agent;

		private void Awake() {
			Transitions.Add(new Transition(this, new ChaseDecision(), EnemyStates.Chase));
// 			Transitions.Add(new Transition(this, new StartGatlingAttackDecision(), ArrowStates.StartGatlingAttack));

			Stats = GetComponent<EnemyController>().EnemyStats;
			_agent = GetComponent<NavMeshAgent>();
		}

		protected override void Update()
		{
			_timeCounter += Time.deltaTime;

			if (_agent.remainingDistance >= 0f)
			if (_timeCounter < Random.Range(Stats.RandomMovemebtStats.MinMoveTime, Stats.RandomMovemebtStats.MaxMoveTime))
				return;

			_timeCounter = 0;
			_agent.destination = Actions.RandomMovement(transform.position, Stats.RandomMovemebtStats.MoveRadius);

			Debug.Log("Roaming");
		}

		public override void OnStateEnter() {
			_agent.speed = Stats.FollowStats.Speed;
			_timeCounter = 0;
		}

		public override void OnStateExit() {}
    }
 }