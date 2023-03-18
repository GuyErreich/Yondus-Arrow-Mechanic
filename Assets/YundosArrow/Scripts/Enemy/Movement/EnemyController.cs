using System;
using Assets.YundosArrow.Scripts.Enemy.Movement.States;
using Assets.YundosArrow.Scripts.Enemy.Movement.Stats;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement
{
		public class EnemyController : MonoBehaviour {
        public EnemyStats EnemyStats;

		private EnemyState _currentState;
		private Dictionary<EnemyStates, EnemyState> _states = new Dictionary<EnemyStates, EnemyState>();
		

		private void Awake() {
			foreach (EnemyStates state in Enum.GetValues(typeof(EnemyStates)))
			{
				AddState(state);
			}
		}

		private void Start()
		{
			_currentState = _states[EnemyStates.Roam];
			_currentState.OnStateEnter();
			_currentState.enabled = true;
		}

		private void Update()
		{
			foreach (Transition transition in _currentState.Transitions)
			{
				if (transition.ShouldTransition())
				{
					SetState(_states[transition.ToState]);
					break;
				}
			}
		}

		private void SetState(EnemyState newState)
		{
			_currentState.OnStateExit();
			_currentState.enabled = false;
			_currentState = newState;
			_currentState.OnStateEnter();
			_currentState.enabled = true;
		}

		private void AddState(EnemyStates state)
		{
			switch (state)
			{
				case EnemyStates.Roam:
					SetComponent<Roam>(state); break;
				case EnemyStates.Chase:
					SetComponent<Chase>(state); break;
				default:
					throw new NotSupportedException($"State: {state}. doesnt exist");
			};
		}

		private void SetComponent<T>(EnemyStates state) where T : EnemyState
		{
			T component = GetComponent<T>();

			if (component == null)
			{
				component = gameObject.AddComponent<T>();
				component.enabled = false;
			}
			
			_states.Add(state, component);
		}

		private void OnDrawGizmos() {
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(Vector3.zero, EnemyStats.FollowStats.ScanRadius);
		}
    }

	public enum EnemyStates {
		Roam,
		Chase
    }
}