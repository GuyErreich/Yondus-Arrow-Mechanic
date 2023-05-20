using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.States;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow
{
    public class GatlingController : MonoBehaviour
    {
        [SerializeField] private GatlingStats _gatlingStats;

        private GatlingState _currentState;
        private Dictionary<GatlingStates, GatlingState> _states = new Dictionary<GatlingStates, GatlingState>();


        private void Awake()
        {
            foreach (GatlingStates state in Enum.GetValues(typeof(GatlingStates)))
            {
                AddState(state);
            }
        }

        private void Start()
        {
            _currentState = _states[GatlingStates.Idle];
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

        private void SetState(GatlingState newState)
        {
            _currentState.OnStateExit();
            _currentState.enabled = false;
            _currentState = newState;
            _currentState.OnStateEnter();
            _currentState.enabled = true;
        }

        private void AddState(GatlingStates state)
        {
            switch (state)
            {
                case GatlingStates.Idle:
                    SetComponent<Idle>(state); break;
                case GatlingStates.StartAttack:
                    SetComponent<StartAttack>(state); break;
                case GatlingStates.Attack:
                    SetComponent<Attack>(state); break;
                default:
                    throw new NotSupportedException($"State: {state}. doesnt exist");
            };
        }

        private void SetComponent<T>(GatlingStates state) where T : GatlingState
        {
            T component = GetComponent<T>();

            if (component == null)
            {
                component = gameObject.AddComponent<T>();
                component.Stats = _gatlingStats;
                component.enabled = false;
            }

            _states.Add(state, component);
        }
    }

    public enum GatlingStates
    {
        Idle,
        StartAttack,
        Attack
    }
}