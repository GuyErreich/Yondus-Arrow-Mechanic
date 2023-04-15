using UnityEngine;
using UnityEngine.AI;
using Assets.YundosArrow.Scripts.Enemy.Movement.Decisions;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.States
 {
     public class Fall : EnemyState {
		private NavMeshAgent _agent;
		private float _ySpeed;

		private void Awake() {
			Transitions.Add(new Transition(this, new FallToRoamDecision(), EnemyStates.Roam));
			
			Stats = GetComponent<EnemyController>().EnemyStats;
			_agent = GetComponent<NavMeshAgent>();
			Stats.Agent = _agent;
		}

		protected override void Update()
		{
			var deltaTime = Actions.GetDeltaTime(Stats.IsUnsacledTime);
			if(NavMesh.SamplePosition(_agent.transform.position, out var hit, 3f, NavMesh.AllAreas)) 
			{
				Stats.CharacterController.enabled = false;
				_agent.Warp(hit.position);
			}
			else
			{
				// _ySpeed += Stats.FallStats.Speed;
				_ySpeed += 2f;
				Stats.CharacterController.Move(Vector3.down * _ySpeed * deltaTime);
			}

			Debug.Log("Enemy Falling");
		}

		public override void OnStateEnter() 
		{
			_ySpeed = 0;
			Stats.CharacterController.enabled = true;
			Stats.Anim.SetBool("isFalling", true);
		}

		public override void OnStateExit() 
		{
			_ySpeed = 0;
			Stats.CharacterController.enabled = false;
			Stats.Anim.SetBool("isFalling", false);
		}
     }
 }