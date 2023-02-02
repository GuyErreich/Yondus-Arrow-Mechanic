//using UnityEngine;
//using YundosArrow.Scripts.FSM;
//using System;
//using System.Linq;
//using YundosArrow.Scripts.Player.Combat.ArrowAbilities.States;
//
//namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities
//{
//    public class ArrowAbilityMachine : StateMachine {
//
//        [SerializeField] private ArrowStates InitState;
//        [SerializeField] private ArrowStats arrowStats;
//
//        public State[] States { get; private set; }
//
//        private void Awake() {
//            var arraySize = Enum.GetValues(typeof(ArrowStates)).Cast<ArrowStates>().Last() + 1;
//            this.States = new State[(int)arraySize];
//
//            this.States[(int)ArrowStates.Idle] = this.gameObject.AddComponent<Idle>();
//            this.States[(int)ArrowStates.Attack] = this.gameObject.AddComponent<Attack>();
//            this.States[(int)ArrowStates.ForceAttack] = this.gameObject.AddComponent<ForceAttack>();
//        }
//
//        private void Start() {
//            this.SetState(this.States[(int)InitState]);
//        }
//    }
//
//    public enum ArrowStates {
//        Idle = 0,
//        Attack = 1,
//        ForceAttack = 2
//    }
//}