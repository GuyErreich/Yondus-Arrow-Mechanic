using UnityEngine;
using UnityEngine.AI;
using Assets.YundosArrow.Scripts.Enemy.Movement.Decisions;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.States
 {
     public class OffMeshLinkJump : EnemyState {
		private NavMeshAgent _agent;
		private float _jumpTime;

		private void Awake() {
			Transitions.Add(new Transition(this, new IsOffMeshLinkAreaComplete(), EnemyStates.Chase));
			// Transitions.Add(new Transition(this, new FallDecision(), EnemyStates.Fall));
			
			Stats = GetComponent<EnemyController>().EnemyStats;
			_agent = GetComponent<NavMeshAgent>();
		}

		protected override void Update()
		{
			_jumpTime += Actions.GetDeltaTime(Stats.IsUnsacledTime);
			if (_jumpTime <= Stats.JumpStats.Duration) {
				var offMeshLinkData = _agent.currentOffMeshLinkData;
				_agent.transform.position = Vector3.Slerp(offMeshLinkData.startPos, offMeshLinkData.endPos, _jumpTime / Stats.JumpStats.Duration);
			}
			Debug.Log("Jumping OffMeshLink");
		}

		public override void OnStateEnter() 
		{
			// Stats.Anim.SetBool("isChasing", true);
			_jumpTime = 0;
		}

		public override void OnStateExit() 
		{
			// Stats.Anim.SetBool("isChasing", false);
		}
     }
 }