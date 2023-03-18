using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Enemy.Movement.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Enemy.Movement
{
    public abstract class EnemyState : MonoBehaviour
    {
		// protected EnemyStats EnemyStats;
		
		public EnemyStats Stats;
		public List<Transition> Transitions = new List<Transition>();

		// private void Awake() {
		// 	Stats = GetComponent<EnemyController>().EnemyStats;
		// }

		protected abstract void Update();
		public abstract void OnStateEnter();
		public abstract void OnStateExit();
    }
}