using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Enemy.Movement.Stats;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Enemy.Movement
{
    public abstract class EnemyState
    {
//		private EnemyController _arrowController;
		protected EnemyStats EnemyStats;

		public List<Transition> Transitions = new List<Transition>();

		public EnemyState(EnemyController enemyController) {
			EnemyStats = enemyController.EnemyStats;
		}

		public abstract void Update();
		public abstract void OnStateEnter();
		public abstract void OnStateExit();
    }
}