using UnityEngine;
using UnityEngine.AI;
using Assets.YundosArrow.Scripts.Enemy.Movement.Decisions;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.States
 {
     public class Chase : EnemyState {
		private NavMeshAgent _agent;

		private void Awake() {
			Transitions.Add(new Transition(this, new ChaseToRoamDecision(), EnemyStates.Roam));
			// Transitions.Add(new Transition(this, new IsOnOffMeshLinkArea_Jump(), EnemyStates.OffMeshLinkJump));
			Transitions.Add(new Transition(this, new FallDecision(), EnemyStates.Fall));
			
			Stats = GetComponent<EnemyController>().EnemyStats;
			_agent = GetComponent<NavMeshAgent>();
		}

		protected override void Update()
		{
			var hits = Physics.OverlapSphere(transform.position, Stats.FollowStats.ScanRadius, Stats.FollowStats.LayerMask, QueryTriggerInteraction.Collide);
			var path = new NavMeshPath();
			
			if (hits.Length == 0) return;

			var target = hits[0].transform.position;
			_agent.CalculatePath(target, path);
			_agent.SetPath(path);

			_agent.Move(_agent.desiredVelocity * Stats.FollowStats.Speed  * Actions.GetDeltaTime(Stats.IsUnsacledTime));

			Debug.Log("Chasing player");
		}

		private OffMeshLink FindNearestOffMeshLink(Vector3 target) {
            OffMeshLink nearestLink = null;
            float nearestDistance = Mathf.Infinity;

            foreach (OffMeshLink link in FindObjectsOfType<OffMeshLink>()) {
                float distance = Vector3.Distance(link.endTransform.position, target);
                if (distance < nearestDistance) {
                    nearestDistance = distance;
                    nearestLink = link;
                }
            }

            return nearestLink;
        }

		public override void OnStateEnter() 
		{
			_agent.speed = Stats.FollowStats.Speed;
			Stats.Anim.SetBool("isChasing", true);
		}

		public override void OnStateExit() 
		{
			Stats.Anim.SetBool("isChasing", false);
		}

		private void OnDrawGizmos() {
			OffMeshLink nearestLink = FindNearestOffMeshLink(_agent.nextPosition);
			Gizmos.DrawSphere(nearestLink.startTransform.position, 2);
		}
     }
 }